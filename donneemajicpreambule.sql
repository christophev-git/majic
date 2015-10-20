
 CREATE TABLE IF NOT EXISTS majic2011.commune
  (idcommune serial,insee varchar(3),nom varchar(255),departement varchar(2));
  
  WITH c as (SELECT insee,departement FROM majic2011.tempparcelle GROUP BY departement,insee)
  INSERT INTO majic2011.commune (insee,departement) SELECT * FROM c;
   CREATE TABLE IF NOT EXISTS majic2011.section
   (idsection SERIAL,nom VARCHAR(2),ptrcommune INTEGER);
 
 WITH sec as (SELECT insee,departement,replace(section,' ','0') as nomsec FROM majic2011.tempparcelle GROUP BY departement,insee,section ORDER BY insee,section),
 sec1 as (SELECT nomsec,idcommune FROM majic2011.commune,sec WHERE sec.departement=commune.departement AND sec.insee=commune.insee)
 INSERT INTO majic2011.section (nom,ptrcommune) SELECT * FROM sec1;

 
 CREATE TABLE majic2011.subsection
 (
   idsubsection serial,
   nom character varying(10),
   ptrsection integer
 );
WITH sec as (SELECT insee,departement,prefsec,replace(section,' ','0') as nomsec FROM majic2011.tempparcelle GROUP BY departement,insee,prefsec,section ORDER BY insee,section),
sub as (SELECT commune.insee|| case WHEN trim(prefsec)='' THEN '000' ELSE prefsec END || nomsec || '01' as nomsub,idsection
FROM majic2011.commune,majic2011.section,sec WHERE idcommune=ptrcommune AND sec.departement=commune.departement AND sec.insee=commune.insee AND nomsec=section.nom)

 INSERT INTO majic2011.subsection (nom,ptrsection) select * from sub;

CREATE TABLE majic2011.parcelle
(
  idparcelle serial NOT NULL,
  ptrsubsection integer,
  numero character varying(255),
  contenance integer,
  dateacte character varying(8),
  primitive character varying(4),
  arpente boolean,
  nfp boolean,
  anomalie integer,
  ptrparcasspdl integer,
  pdltype character varying(3),
  numvoie character varying(4),
  voiemajic character varying(5),
  rivoli character varying(5),
  inseemere character varying(3),
  prefsecmere character varying(3),
  sectionmere character varying(2),
  numplanmere character varying(4),
  typefiliation character varying(1));

--UPDATE majic2011.tempparcelle SET prefsec='000' WHERE trim(prefsec)='';

 WITH sub as (SELECT departement,insee,section.nom as nomsec,idsubsection,subsection.nom as nomsub 
 FROM majic2011.commune INNER JOIN majic2011.section ON idcommune=ptrcommune INNER JOIN majic2011.subsection ON ptrsection=idsection),
 parc as (select idsubsection,plan from sub,majic2011.tempparcelle 
 WHERE  sub.departement=tempparcelle.departement AND sub.insee=tempparcelle.insee AND nomsec=replace(section,' ','0') AND  tempparcelle.prefsec = substring(nomsub,4,3) )
 INSERT INTO majic2011.parcelle (ptrsubsection,numero) SELECT * FROM parc;