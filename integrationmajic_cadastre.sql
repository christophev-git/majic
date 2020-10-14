-- ajoute une colonne etat à tempparcelle
-- ajoute une colonne codei code integration à parcelle

	ALTER TABLE cadastre.tempparcelle
 	   ADD COLUMN etat integer NOT NULL DEFAULT 0;
 	ALTER TABLE cadastre.parcelle 
 		ADD COLUMN codei integer NOT NULL DEFAULT 0;
	ALTER TABLE cadastre.lot
		ADD COLUMN pdltype varchar(3);
	ALTER TABLE cadastre.commune
		ADD COLUMN departement varchar(2);
BEGIN;
-- Remplacer section majic " A" par section majic2015 "0A"

update cadastre.tempparcelle set
section= replace(section,' ','0');

update cadastre.tempparcelle set
section2= replace(section2,' ','0');

update cadastre.tempparcelle set
sectionmere= replace(sectionmere,' ','0');

-- Remplacer prefsection par 000 si null------------------------------------------------

UPDATE cadastre.tempparcelle SET
prefsec='000' WHERE trim(prefsec)='';

UPDATE cadastre.tempparcelle SET
pref2='000' WHERE trim(pref2)='';

UPDATE cadastre.tempparcelle SET
prefsecmere='000' WHERE trim(prefsecmere)='';



-- Ajouter un index sur idtempparcelle (primarykey)

-- verifie l'existence graphique de la commune
-- commune existe pas etat = 0
-- état = 1 commune existe
-- execution environ 8 mm 40 sur 2A+2B

with res as (SELECT idtempparcelle from cadastre.tempparcelle WHERE tempparcelle.insee in (select insee from cadastre.commune))

UPDATE cadastre.tempparcelle SET
etat=1
FROM res WHERE res.idtempparcelle = tempparcelle.idtempparcelle;

-- Verifie existence de section pour commune existantes
-- Etat = 1 section n'existe pas
-- Etat = 2 section existe
-- execution 2 mm 39

WITH res as (select insee, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where  ptrcommune = idcommune and ptrsection = idsection GROUP BY insee,section.nom ORDER BY insee),
temp as (SELECT idtempparcelle FROM res, cadastre.tempparcelle WHERE etat=1 and tempparcelle.insee=res.insee AND tempparcelle.section=res.nom ORDER BY idtempparcelle)

UPDATE cadastre.tempparcelle SET
etat=2
FROM temp
WHERE tempparcelle.idtempparcelle=temp.idtempparcelle;

-- Verifie l'existence des parcelles
-- ATTENTION si parcelle NFP la parcelle est existante cf etape suivante ********************************************************
-- Etat = 2  parcelle n'existe pas (commune et section existe) au plan OU EST NFP OU EXISTE AU PLAN ET PAS DANS majic
-- Etat = 5 la parcelle existe DANS majic ET AU PLAN
-- Execution = 3 mm 11

with sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where ptrcommune = idcommune and ptrsection = idsection ),

parc as (select * from cadastre.parcelle,sec where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection )
and ptrsubsection = idsubsection),

res as (SELECT idtempparcelle FROM parc,cadastre.tempparcelle WHERE etat=2 AND parc.insee=tempparcelle.insee AND parc.nom=tempparcelle.section AND substring(nomsub,4,3)=prefsec AND parc.numero=tempparcelle.plan)

UPDATE cadastre.tempparcelle SET
etat=5
FROM res
WHERE res.idtempparcelle=tempparcelle.idtempparcelle;


-- Si NFP pas pris en compte !!!!!


--************************************************************** Ajout des parcelles NFP de code 2 ************************************************************
-- Elles seront ajoutées à la fin du traitement de tempparcelle
-- !!!! Prendre en compte la première subsection de la section pour pointeur ptrsubsection

--*************************************************************************************************************************************************************

-- UPDATE de la table parcelle avec tempparcelle =5 présente au plan dans MAJIC et non nfp
-- execution 2 mm

with sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where  ptrcommune = idcommune and ptrsection = idsection ),
res as (select parcelle.idparcelle,tempparcelle.* from cadastre.parcelle,sec,cadastre.tempparcelle 
where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where  ptrcommune=idcommune and ptrsection = idsection )
and etat=5 AND ptrsubsection = idsubsection AND sec.insee=tempparcelle.insee AND sec.nom=tempparcelle.section AND substring(nomsub,4,3)=prefsec AND numero=plan)

UPDATE cadastre.parcelle SET 
contenance =res.contenance::integer,
dateacte=res.dateacte,
primitive=res.primitive,
arpente=(res.arpente='A'),
nfp=(res.nfp='0'),
numvoie=res.numvoie,
voiemajic=res.voiemajic,
rivoli=res.rivoli,
inseemere=res.inseemere,
prefsecmere=res.prefsecmere,
sectionmere=res.sectionmere,
numplanmere=res.numplanmere,
typefiliation=res.typefiliation,
codei=res.etat
FROM res WHERE parcelle.idparcelle=res.idparcelle
;


--***********************************************************************************
--************************************************************** Ajout des parcelles NFP  ************************************************************

-- !!!! Prendre en compte la première subsection de la section pour pointeur ptrsubsection
-- !! conversion de type integer et boolean
-- Parcelle nfp codei=4
-- Execution 5 s
--*************************************************************************************************************************************************************



WITH subsec as (SELECT insee,section.nom, first_value(idsubsection) OVER (PARTITION BY insee,section.nom ORDER BY idsubsection ASC ) 
FROM cadastre.commune,cadastre.section,cadastre.subsection WHERE ptrcommune = idcommune and ptrsection = idsection ORDER BY insee,section.nom),
agg as (SELECT * FROM subsec GROUP BY insee,nom,first_value ORDER BY insee,nom),
temp as (SELECT * FROM cadastre.tempparcelle WHERE etat=2 AND nfp='1' ORDER BY insee),
res as (SELECT first_value ,plan,contenance::integer,dateacte,primitive,not length(trim(arpente)) = 0,
nfp::boolean,numvoie,voiemajic,rivoli,inseemere,prefsecmere,sectionmere,numplanmere,typefiliation,4  
FROM agg,temp WHERE temp.insee=agg.insee AND temp.section=agg.nom)

INSERT INTO cadastre.parcelle (ptrsubsection,numero,contenance,dateacte,primitive,arpente,nfp,numvoie,voiemajic,rivoli,inseemere,prefsecmere,sectionmere,numplanmere,typefiliation,codei) 
SELECT * FROM res;

--*********************************************************************************************
--************************************* Ajout parcelle etat 2 non nfp --- codei=2 present dans majic pas au plan et non nfp-----------------------------
--*****************************

WITH subsec as (SELECT insee,section.nom, first_value(idsubsection) OVER (PARTITION BY insee,section.nom ORDER BY idsubsection ASC ) 
FROM cadastre.commune,cadastre.section,cadastre.subsection WHERE ptrcommune = idcommune and ptrsection = idsection ORDER BY insee,section.nom),
agg as (SELECT * FROM subsec GROUP BY insee,nom,first_value ORDER BY insee,nom),
temp as (SELECT * FROM cadastre.tempparcelle WHERE etat=2 AND nfp='0' ORDER BY insee),
res as (SELECT first_value ,plan,contenance::integer,dateacte,primitive,not length(trim(arpente)) = 0,
nfp::boolean,numvoie,voiemajic,rivoli,inseemere,prefsecmere,sectionmere,numplanmere,typefiliation,2  
FROM agg,temp WHERE temp.insee=agg.insee AND temp.section=agg.nom)

INSERT INTO cadastre.parcelle (ptrsubsection,numero,contenance,dateacte,primitive,arpente,nfp,numvoie,voiemajic,rivoli,inseemere,prefsecmere,sectionmere,numplanmere,typefiliation,codei) 
SELECT * FROM res;

--**************************************************************************************************
--*************************** AJOUT des parcelles au plan et pas dans MAJIC codei=3**************************

with res AS (SELECT idparcelle FROM cadastre.parcelle WHERE codei=0)
UPDATE cadastre.parcelle SET codei=3 FROM res WHERE res.idparcelle=parcelle.idparcelle;


-- Création table surface -------------
CREATE TABLE IF NOT EXISTS cadastre.surface
(
  idsurface serial,
  ptrparcelle integer,
  ptrlot integer,
  contenance integer,
  groupe character varying(2),
  sousgroupe character varying(2),
  groupeclasse character varying(2),
  culture character varying(5),
  numpdl character varying(3),
  numlot character varying(7),
  lettre character varying(2)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cadastre.surface
  OWNER TO postgres;
--****************************************

--***********************************************************************************

-- Insertion des surfaces liées aux parcelles
-- Execution : 1 mm 17

--***********************************************************************************

with sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where ptrcommune = idcommune and ptrsection = idsection ),
parc as (select * from cadastre.parcelle,sec where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection)
and ptrsubsection = idsubsection),
tsurf as (SELECT  idparcelle,tempsurface.contenance::integer,groupe,sousgroupe,groupeclasse,culturespeciale,numpdl,numlot,lettre FROM cadastre.tempparcelle, cadastre.tempsurface,parc WHERE ptrtempparcelle=idtempparcelle AND etat>1 
AND tempparcelle.insee=parc.insee AND  tempparcelle.section=parc.nom AND substring(nomsub,4,3)=prefsec AND tempparcelle.plan=numero)

INSERT INTO cadastre.surface (ptrparcelle,contenance,groupe,sousgroupe,groupeclasse,culture,numpdl,numlot,lettre)
SELECT * FROM tsurf;

--*******************************************Analyse discordances tempparcelle temppdl **************************
SELECT prefsec,insee,replace(section,' ','0') as section,plan FROM cadastre.temppdl
EXCEPT 	
SELECT prefsec,insee,section,plan FROM cadastre.tempparcelle WHERE  GPDL='1';
--****************************************** 2 occurences en 2013*************************************************

-- une parcelle peut contenir plusieurs pdl de différents types modification du modèle****************************
-- bascule de pdltype au niveau lot

-- ajouter colonne pdltype varchar(3)

-- un lot fictif par pdl

--****************************************************************************************************************
-- cretaion table lot

CREATE TABLE IF NOT EXISTS cadastre.lot
(
  idlot serial,
  ptrparcelle integer,
  comptecom character varying(6),
  numlot character varying(7),
  naturelot integer,
  surfacelot integer,
  numerateur character varying(9),
  denominateur character varying(9),
  dateactelot character varying(8),
  numpdl character varying(3),
  pdltype character varying(3)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cadastre.lot
  OWNER TO postgres;


-- Integration des lots fictifs pour GPDL=0 et gpdl=2
-- Execution: 54 s

with sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where ptrcommune = idcommune and ptrsection = idsection ),
parc as (select insee,nom,numero,idsubsection,nomsub,idparcelle,contenance from cadastre.parcelle,sec 
where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection)
and ptrsubsection = idsubsection),
res as (SELECT parc.idparcelle,parc.contenance, comptecom FROM parc,cadastre.tempparcelle WHERE (gpdl='0' or gpdl='2') AND etat>1 AND parc.insee=tempparcelle.insee AND parc.nom=tempparcelle.section AND substring(parc.nomsub,4,3)=prefsec  AND parc.numero=tempparcelle.plan)

INSERT INTO cadastre.lot (ptrparcelle,comptecom,surfacelot,numlot,numerateur,denominateur,numpdl) SELECT idparcelle,comptecom,contenance,'0000000','*','*','000' FROM res;

--****************************************************************************************************************

-- !!!!!!!!!!!!!!!! remplacer section ' A' par '0A' dans temppdl -------------- et prefsec null=000

UPDATE cadastre.temppdl SET section = replace(section,' ','0');

UPDATE cadastre.temppdl SET prefsec='000' WHERE trim(prefsec)='';
--****************************************************************************************************************

-- Intégration lot fictifs pour GPDL = 1
-- Execution 27 s

with sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where ptrcommune = idcommune and ptrsection = idsection ),
parc as (select insee,nom,numero,idsubsection,nomsub,idparcelle,contenance from cadastre.parcelle,sec 
where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection)
and ptrsubsection = idsubsection),
res as (SELECT parc.idparcelle, temppdl.comptecom,contenance,'0000000','*','*',temppdl.numpdl,pdltype FROM parc,cadastre.temppdl 
WHERE  parc.insee=temppdl.insee AND parc.nom=temppdl.section AND substring(nomsub,4,3)=prefsec AND parc.numero=temppdl.plan)

INSERT INTO cadastre.lot (ptrparcelle,comptecom,surfacelot,numlot,numerateur,denominateur,numpdl,pdltype) SELECT * FROM res;


-- Intégration des lots existants
-- Execution 32 s

with sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where ptrcommune = idcommune and ptrsection = idsection ),
parc as (select insee,nom,numero,idsubsection,nomsub,idparcelle,contenance from cadastre.parcelle,sec 
where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection)
and ptrsubsection = idsubsection),
res1 as (SELECT parc.idparcelle, idtemppdl,pdltype,numpdl FROM parc,cadastre.temppdl WHERE  parc.insee=temppdl.insee AND parc.nom=temppdl.section AND substring(nomsub,4,3)=prefsec AND parc.numero=temppdl.plan),
res2 as (SELECT idparcelle,comptecomlot,numlot,naturelot::integer,surfacelot::integer,numerateur,denominateur,dateactelot,numpdl,pdltype FROM res1,cadastre.templot WHERE ptrtemppdl=res1.idtemppdl)

INSERT INTO cadastre.lot (ptrparcelle,comptecom,numlot,naturelot,surfacelot,numerateur,denominateur,dateactelot,numpdl,pdltype) SELECT * FROM res2;

--**** Gestion GPDL = 2 mise à jour pointeur parcelle******
with sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where ptrcommune = idcommune and ptrsection = idsection ),
parc as (select insee,nom,numero,idsubsection,nomsub,idparcelle,contenance from cadastre.parcelle,sec 
where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection)
and ptrsubsection = idsubsection),
res1 as (SELECT parc.idparcelle as idparcelle,idtempparcelle as idt1 FROM parc,cadastre.tempparcelle WHERE  gpdl='2' AND etat>1 AND parc.insee=tempparcelle.insee AND parc.nom=tempparcelle.section 
        AND substring(parc.nomsub,4,3)=prefsec  AND parc.numero=tempparcelle.plan),
        
res2 as (SELECT parc.idparcelle as idparcelleassise,idtempparcelle as idt2 FROM parc,cadastre.tempparcelle WHERE  gpdl='2' 
         AND etat>1 AND parc.insee=tempparcelle.insee AND parc.nom=tempparcelle.section2 
        AND substring(parc.nomsub,4,3)=pref2  AND parc.numero=tempparcelle.numplan2),
                
res as (SELECT idparcelle,idparcelleassise FROM res1,res2 WHERE idt1=idt2 )

UPDATE cadastre.parcelle SET ptrparcasspdl=idparcelleassise FROM res WHERE parcelle.idparcelle=res.idparcelle;




--**** Gestion liaison lot surface ************
with sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where ptrcommune = idcommune and ptrsection = idsection ),
parc as (select * from cadastre.parcelle,sec where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection)
and ptrsubsection = idsubsection),
tsurf as (SELECT  idparcelle,tempsurface.contenance::integer,surfacelot,lettre,lot.numpdl as nump,tempsurface.numpdl,lot.numlot as numl,tempsurface.numlot,idlot FROM cadastre.tempparcelle, cadastre.tempsurface,parc,cadastre.lot 
WHERE ptrtempparcelle=idtempparcelle AND etat>1
AND tempparcelle.insee=parc.insee AND replace(tempparcelle.section,' ','0')=parc.nom AND substring(nomsub,4,3)=prefsec AND tempparcelle.plan=numero AND ptrparcelle=idparcelle AND lot.numpdl=tempsurface.numpdl AND lot.numlot=tempsurface.numlot ),

s as (SELECT idlot,idsurface FROM tsurf,cadastre.surface WHERE idparcelle=ptrparcelle AND surface.numlot=numl AND surface.numpdl=nump)

UPDATE cadastre.surface SET
ptrlot=s.idlot
FROM s WHERE surface.idsurface=s.idsurface;

--**** creation table comptecommunal *********************************************************************

CREATE TABLE cadastre.comptecommunal
(
  idcomptecommunal serial,
  valeur character varying(6),
  ptrcommune integer)
  
WITH (
  OIDS=FALSE
);
ALTER TABLE cadastre.comptecommunal
  OWNER TO postgres;

-- insertion compte communaux ********************************

 WITH compte as (
 SELECT departement, insee,comptecom FROM cadastre.tempproprio GROUP BY departement,insee,comptecom ORDER BY departement,insee),
 res as (
 SELECT compte.*,idcommune ,commune.insee FROM compte,cadastre.commune WHERE compte.insee=commune.insee)
 
INSERT INTO cadastre.comptecommunal (valeur,ptrcommune) SELECT comptecom,idcommune FROM res;



--****       Detection anomalie etat civil propriétaires *************************************************

 WITH res as (SELECT departement,numper,physique,codephysique,codenaturephy,codegroupemoral,siglemoral,siglemajic,denomination,
  type3,type4,type5 ,  type6 ,  adr3 , adr4,adr5,adr6,codepays,depadr,adrinsee,codemajicadr, rivoliadr ,numvoie,repnumvoie, qualite,nom,prenom,datenaissance,
  lieuxnaissance,complement,nomcomplement,prenomcomplement FROM cadastre.tempproprio GROUP BY
  departement,numper,physique,codephysique,codenaturephy,codegroupemoral,siglemoral,siglemajic,denomination,
  type3,type4,type5 ,  type6 ,  adr3 , adr4,adr5,adr6,codepays,depadr,adrinsee,codemajicadr, rivoliadr ,numvoie,repnumvoie, qualite,nom,prenom,datenaissance,
  lieuxnaissance,complement,nomcomplement,prenomcomplement),

  compte as (SELECT departement,numper FROM res GROUP BY departement, numper HAVING count(*) >1)

  SELECT tempproprio.* FROM cadastre.tempproprio, compte WHERE tempproprio.departement=compte.departement AND tempproprio.numper=compte.numper;


-- Ajout d'une colonne departement dans commune et dans propriétaire ---------------------------

  --ALTER TABLE cadastre.commune
   --ADD COLUMN departement character varying(2);

--update commune**********************

WITH l as (SELECT departement,insee FROM cadastre.tempparcelle GROUP BY departement,insee ORDER by insee)
UPDATE cadastre.commune SET
departement = l.departement
FROM l
WHERE commune.insee=l.insee;
-- *******************création table propriétaire *********************************************************
CREATE TABLE cadastre.proprietaire
(
  idproprietaire serial,
  dnumper character varying(6),
  destavis boolean,
  physique boolean,
  codephysique integer,
  nature character varying(3),
  groupe character varying(2),
  sigle character varying(10),
  siglemajic character varying(7),
  denomination character varying(60),
  type3 integer,
  type4 integer,
  type5 integer,
  type6 integer,
  adr3 character varying(30),
  adr4 character varying(36),
  adr5 character varying(30),
  adr6 character varying(32),
  codepays character varying(3),
  depadr character varying(2),
  inseeadr character varying(3),
  qualite character varying(3),
  nom character varying(30),
  prenom character varying(15),
  datenaissance character varying(10),
  lieunaissance character varying(58),
  complement character varying(3),
  nomcomplement character varying(30),
  prenomcomplement character varying(15),
  departement character varying(2)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cadastre.proprietaire
  OWNER TO postgres;
--******************************** insertion propriétaires ************************************************
-- Etape 1
--Execution 1 mm 4

 WITH res as (SELECT numper,
  CASE WHEN physique='1' THEN true ELSE FALSE END,
  CASE WHEN length(trim(codephysique))=0 THEN 0 ELSE codephysique::integer END,
  codenaturephy,siglemoral,siglemajic,denomination,
  CASE WHEN length(trim(type3))=0 THEN 0 ELSE type3::integer END,
  CASE WHEN length(trim(type4))=0 THEN 0 ELSE type4::integer END,
  CASE WHEN length(trim(type5))=0 THEN 0 ELSE type5::integer END,
  CASE WHEN length(trim(type6))=0 THEN 0 ELSE type6::integer END,
  adr3 , adr4,adr5,adr6,codepays,depadr,adrinsee, qualite,nom,prenom,datenaissance,
  lieuxnaissance,complement,nomcomplement,prenomcomplement,departement FROM cadastre.tempproprio GROUP BY
  departement,numper,physique,codephysique,codenaturephy,codegroupemoral,siglemoral,siglemajic,denomination,
  type3,type4,type5 ,  type6 ,  adr3 , adr4,adr5,adr6,codepays,depadr,adrinsee,codemajicadr, rivoliadr ,numvoie,repnumvoie, qualite,nom,prenom,datenaissance,
  lieuxnaissance,complement,nomcomplement,prenomcomplement)

  INSERT INTO cadastre.proprietaire (dnumper,physique,codephysique,nature,sigle,siglemajic,denomination,
  type3,type4,type5 ,  type6 ,  adr3 , adr4,adr5,adr6,codepays,depadr,inseeadr, qualite,nom,prenom,datenaissance,
  lieunaissance,complement,nomcomplement,prenomcomplement,departement)
  SELECT * FROM res;
  -- création index propriétaire
  CREATE INDEX id_numper
  ON cadastre.proprietaire
  USING btree
  (dnumper COLLATE pg_catalog."default");
  
--création table jointure

CREATE TABLE IF NOT EXISTS cadastre.jointcomptecommunalproprietaire (ptrcomptecommunal integer, ptrproprietaire integer,naturedroit varchar(2) ,destavis boolean);

-- Etape 2
-- Création lien 
-- execution 15 s 6

WITH prop as (SELECT idcommune,idproprietaire,comptecom,codedroit,codedem,tempproprio.destavis FROM cadastre.proprietaire,cadastre.tempproprio,cadastre.commune WHERE proprietaire.departement=tempproprio.departement
 AND proprietaire.dnumper=tempproprio.numper AND tempproprio.insee=commune.insee),
res as (SELECT idcomptecommunal,idproprietaire,codedroit||codedem as droit,destavis::boolean FROM prop,cadastre.comptecommunal WHERE prop.idcommune=ptrcommune AND comptecom=valeur)
INSERT INTO cadastre.jointcomptecommunalproprietaire (ptrcomptecommunal,ptrproprietaire,naturedroit,destavis) SELECT * FROM res;


-- Création table jointure propriétaire lot
--***************************************** nota on peut fondre les deux tables de jointure (comptecomproprio et lotproprio en une seule à étudier)**************************

CREATE TABLE IF NOT EXISTS cadastre.jointlotproprietaire (ptrlot integer, ptrproprietaire integer,naturedroit varchar(2),destavis boolean);

-- Intégration jointure lot-propriétaire
-- execution 1 mm 3

WITH prop as (SELECT idproprietaire,naturedroit,jointcomptecommunalproprietaire.destavis,valeur,insee,idcommune 
FROM cadastre.commune,cadastre.comptecommunal,cadastre.proprietaire,cadastre.jointcomptecommunalproprietaire 
WHERE idcommune=ptrcommune AND idcomptecommunal=ptrcomptecommunal AND idproprietaire=ptrproprietaire),
sec as (select distinct insee, idsubsection, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where  ptrcommune = idcommune and ptrsection = idsection ),
parc as (select sec.*,numero,idparcelle from cadastre.parcelle,sec where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection )
AND ptrsubsection = idsubsection ),
lot as (SELECT idlot,lot.comptecom,parc.* FROM parc,cadastre.lot WHERE idparcelle=ptrparcelle),
res as (SELECT idlot,idproprietaire,naturedroit,prop.destavis FROM prop,lot WHERE prop.insee=lot.insee AND prop.valeur=lot.comptecom)

INSERT INTO cadastre.jointlotproprietaire (ptrlot,ptrproprietaire,naturedroit,destavis) SELECT * FROM res;

-- un peu de repos
------------------------------------------------- templocaux subsection à 000 si null-----------------------------------------------

-- MAJ prefsubsection pour templocaux
UPDATE cadastre.templocaux SET 
prefsection='000' WHERE trim(prefsection)='';

------------------------------------------------Creation table locaux---------------------------------------------------------------
CREATE TABLE IF NOT EXISTS cadastre.locaux
( idlocal serial,
  ptrparcelle integer,
  invariant character varying(10),
  lettre character varying(2),
  entree character varying(2),
  niveau character varying(2),
  coderivoli character varying(4),
  codemajic character varying(5),
  numvoie character varying(4),
  indrep character varying(1),
  libelle character varying(30),
  clefalpha character varying(1),
  gpdl character varying(1),
  serierole character varying(1),
  comptecom character varying(6),
  datemutation character varying(8),
  codeeval character varying(1),
  typelocal character varying(1),
  codeconstructionp character varying(1),
  codenature character varying(2),
  vl character varying(9),
  occupation character varying(1),
  topmutation character varying(1),
  anneeconstruction character varying(4),
  nbniveau character varying(2),
  idtemplocal integer
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cadastre.locaux
  OWNER TO postgres;
---------------------------------------------------Insertion locaux avec liaison parcelle ------------------------------------------------
with sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where ptrcommune = idcommune and ptrsection = idsection ),
parc as (select * from cadastre.parcelle,sec where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection)
and ptrsubsection = idsubsection),
tloc as (SELECT  idparcelle,invariant,lettre,entree,niveau,  coderivoli,  codemajic,  templocaux.numvoie,  indrep,  libelle,  clefalpha,
  gpdl,  serierole,  comptecom,  datemutation,  codeeval,  typelocal,  codeconstructionp,  codenature,vl,  occupation,  topmutation,
  anneeconstruction,  nbniveau,  idtemplocal 
  FROM cadastre.templocaux,parc WHERE  
 templocaux.insee=parc.insee AND replace(templocaux.section,' ','0')=parc.nom AND substring(nomsub,4,3)=prefsection AND
   templocaux.plan=parc.numero)

   INSERT INTO cadastre.locaux (
  ptrparcelle, 
  invariant,
  lettre,
  entree,
  niveau,
  coderivoli,
  codemajic,
  numvoie,
  indrep,
  libelle,
  clefalpha,
  gpdl,
  serierole,
  comptecom,
  datemutation,
  codeeval,
  typelocal,
  codeconstructionp,
  codenature,
  vl,
  occupation,
  topmutation,
  anneeconstruction,
  nbniveau,
  idtemplocal)
SELECT * FROM tloc;

-----------------------------------------------------Insertion locaux sans parcelle d'assise ---------------------------------------------------
with sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where ptrcommune = idcommune and ptrsection = idsection ),
parc as (select * from cadastre.parcelle,sec where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection)
and ptrsubsection = idsubsection),
tloc as (SELECT  idparcelle,parc.insee,nom,parc.numero,templocaux.* FROM cadastre.templocaux,parc WHERE  
 templocaux.insee=parc.insee AND replace(templocaux.section,' ','0')=parc.nom AND substring(nomsub,4,3)=prefsection AND
   templocaux.plan=parc.numero),
tlocabs as (SELECT   0,invariant,lettre,entree,niveau,  coderivoli,  codemajic,  templocaux.numvoie,  indrep,  libelle,  clefalpha,
  gpdl,  serierole,  comptecom,  datemutation,  codeeval,  typelocal,  codeconstructionp,  codenature,vl,  occupation,  topmutation,
  anneeconstruction,  nbniveau,  idtemplocal  FROM cadastre.templocaux WHERE idtemplocal NOT in (SELECT idtemplocal FROM tloc ))

INSERT INTO cadastre.locaux (
  ptrparcelle, 
  invariant,
  lettre,
  entree,
  niveau,
  coderivoli,
  codemajic,
  numvoie,
  indrep,
  libelle,
  clefalpha,
  gpdl,
  serierole,
  comptecom,
  datemutation,
  codeeval,
  typelocal,
  codeconstructionp,
  codenature,
  vl,
  occupation,
  topmutation,
  anneeconstruction,
  nbniveau,
  idtemplocal)
SELECT * FROM tlocabs;
-------------------------------------------------Création PEV------------------------------------------------------
CREATE TABLE cadastre.pev
(  idpev serial,
  ptrlocal integer,
  numpev character varying(3),
  affectation character varying(1),
  categorie character varying(2),
  vl70 integer,
  vlactu integer,
  exop character varying(2),
  idtemppev integer
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cadastre.pev
  OWNER TO postgres;


----------------------------------------------- Insertion PEV-------------------------------------------------------
with res as (SELECT idlocal,numpev,affectation,categorie,vl70,vlactu,exop,idtemppev FROM cadastre.locaux,cadastre.temppev WHERE idtemplocal=ptrlocal)

INSERT INTO cadastre.pev 
(ptrlocal,numpev,affectation,categorie,vl70,vlactu,exop,idtemppev)
SELECT * FROM res;

--------------------------------------------- Creation joint proplocal----------------------------------------------
CREATE TABLE IF NOT EXISTS cadastre.jointproplocal
(ptrproprietaire integer,
ptrlocal integer,
naturedroit varchar(2));

--------------------------------------------- Insertion jointure prop local-----------------------------------------
WITH ins as (SELECT idlocal,insee,section,prefsection,numero,locaux.comptecom FROM cadastre.templocaux,cadastre.locaux WHERE templocaux.idtemplocal=locaux.idtemplocal),
 prop as (SELECT idcommune,commune.insee as see,idproprietaire,comptecom,codedroit,codedem,tempproprio.destavis FROM cadastre.proprietaire,cadastre.tempproprio,cadastre.commune WHERE proprietaire.departement=tempproprio.departement
 AND proprietaire.dnumper=tempproprio.numper AND tempproprio.insee=commune.insee),
res as (SELECT idlocal,idproprietaire,codedroit||codedem as droit FROM ins,prop WHERE prop.see=ins.insee AND prop.comptecom=ins.comptecom )
INSERT INTO cadastre.jointproplocal (ptrlocal,ptrproprietaire,naturedroit)
SELECT * FROM res;

--------------------------------------------- Création table jointure lot local---------------------------------------------
CREATE TABLE IF NOT EXISTS cadastre.jointlotlocal
(ptrlot  integer,
ptrlocal  integer);

----------------------------------------------- update prefsection pour templotlocal-----------------------------------------
UPDATE cadastre.templotlocal SET
prefsection='000' WHERE trim(prefsection)='';
--------------------------------------------- intégration lot local pour gpdl 1----------------------------------------------
WITH sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where  ptrcommune = idcommune and ptrsection = idsection ),
parc as (select sec.*,numero,idparcelle from cadastre.parcelle,sec where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection )
AND ptrsubsection = idsubsection ),
lota as (SELECT idlot,lot.numlot,parc.* FROM parc,cadastre.lot WHERE idparcelle=ptrparcelle),
lotloc as (SELECT idlot,idlocal FROM cadastre.templotlocal,lota,cadastre.locaux WHERE lota.insee=templotlocal.insee AND replace(templotlocal.section,' ','0')=lota.nom 
--AND substring(nomsub,4,3)=prefsection 
AND plan=numero AND templotlocal.numlot=lota.numlot
AND locaux.ptrparcelle=idparcelle 
AND locaux.invariant=templotlocal.invariant)

INSERT INTO cadastre.jointlotlocal (ptrlot,ptrlocal)
SELECT * FROM lotloc;
---------------------------------------------- intégration lot local pour lot fictif
WITH sec as (select distinct insee, idsubsection,subsection.nom as nomsub, section.nom from cadastre.section,cadastre.commune,cadastre.subsection where  ptrcommune = idcommune and ptrsection = idsection ),
parc as (select sec.*,numero,idparcelle from cadastre.parcelle,sec where ptrsubsection in (select idsubsection from cadastre.commune,cadastre.section,cadastre.subsection where ptrcommune=idcommune and ptrsection = idsection )
AND ptrsubsection = idsubsection ),
lota as (SELECT idlot,lot.numlot,parc.* FROM parc,cadastre.lot WHERE idparcelle=ptrparcelle AND numerateur='*' AND denominateur='*'),
lotloc as (SELECT idlot,idlocal FROM lota,cadastre.locaux WHERE 
locaux.ptrparcelle=idparcelle) 

INSERT INTO cadastre.jointlotlocal (ptrlot,ptrlocal)
SELECT * FROM lotloc; 


-- creation article bati pev
CREATE TABLE IF NOT EXISTS cadastre.art40(
idart40 serial,
ptrpev integer,
eau boolean,
electricite boolean,
escalier boolean,
gaz boolean,
ascenceur boolean,
chauffagecentral boolean,
videordure boolean,
egout boolean,
baignoire integer,
douche integer,
lavabo integer,
wc integer,
pieceprincipale integer,
salleamanger integer,
chambre integer,
cuisineinf9 integer,
cuisinesup9 integer,
salledebain integer,
annexe integer,
piece integer,
superficie real);

CREATE TABLE IF NOT EXISTS cadastre.art50(
idart50 serial,
ptrpev integer,
surface real);

CREATE TABLE IF NOT EXISTS cadastre.art60(
idart60 serial,
ptrpev integer,
nature varchar(2),
surface real);
--**************************************************
-- integration art40
WITH res as (SELECT idpev,eau,electricite,escalier,gaz,ascenceur,chauffagecentral,videordure,egout,baignoire,douche,lavabo,wc,
pieceprincipale,salleamanger,chambre,cuisineinf9,cuisinesup9,salledebain,annexe,piece,superficie
FROM cadastre.pev,cadastre.tempart40
WHERE idtemppev=ptrtemppev)

INSERT INTO cadastre.art40
(ptrpev,eau,electricite,escalier,gaz,ascenceur,chauffagecentral,videordure,egout,baignoire,douche,lavabo,wc,
pieceprincipale,salleamanger,chambre,cuisineinf9,cuisinesup9,salledebain,annexe,piece,superficie)
SELECT * FROM res;
--**************************************************
--integration art50
WITH res as (SELECT idpev,surface
FROM cadastre.pev,cadastre.tempart50
WHERE idtemppev=ptrtemppev)

INSERT INTO cadastre.art50
(ptrpev,surface)
SELECT * FROM res;
--integration art60
--**************************************************
WITH res as (SELECT idpev,nature,surface
FROM cadastre.pev,cadastre.tempart60
WHERE idtemppev=ptrtemppev)

INSERT INTO cadastre.art60
(ptrpev,nature,surface)
SELECT * FROM res


COMMIT;