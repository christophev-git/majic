ALTER TABLE majic2015.commune
  ADD PRIMARY KEY (idcommune);

ALTER TABLE majic2015.section
  ADD PRIMARY KEY (idsection);

ALTER TABLE majic2015.section
  ADD CONSTRAINT fkey_section_commune FOREIGN KEY (ptrcommune) REFERENCES majic2015.commune(idcommune)
   ON UPDATE NO ACTION ON DELETE NO ACTION;
CREATE INDEX fki_fkey_section_commune
  ON majic2015.section(ptrcommune);

ALTER TABLE majic2015.subsection
  ADD PRIMARY KEY (idsubsection);

ALTER TABLE majic2015.subsection
  ADD CONSTRAINT fkey_subsection_section FOREIGN KEY (ptrsection) REFERENCES majic2015.section (idsection)
   ON UPDATE NO ACTION ON DELETE NO ACTION;
CREATE INDEX fki_fkey_subsection_idsection
  ON majic2015.subsection(ptrsection);

ALTER TABLE majic2015.parcelle
  ADD PRIMARY KEY (idparcelle);

ALTER TABLE majic2015.parcelle
  ADD CONSTRAINT fkey_parcelle_subsection FOREIGN KEY (ptrsubsection) REFERENCES majic2015.subsection (idsubsection)
   ON UPDATE NO ACTION ON DELETE NO ACTION;
CREATE INDEX fki_fkey_parcelle_subsection
  ON majic2015.parcelle(ptrsubsection);

ALTER TABLE majic2015.proprietaire
  ADD PRIMARY KEY (idproprietaire);

ALTER TABLE majic2015.comptecommunal
  ADD PRIMARY KEY (idcomptecommunal);

ALTER TABLE majic2015.comptecommunal
  ADD CONSTRAINT fkey_comptecommunal_commune FOREIGN KEY (ptrcommune) REFERENCES majic2015.commune (idcommune)
   ON UPDATE NO ACTION ON DELETE NO ACTION;
CREATE INDEX fki_fkey_comptecommunal_commune
  ON majic2015.comptecommunal(ptrcommune);

ALTER TABLE majic2015.surface
  ADD PRIMARY KEY (idsurface);

ALTER TABLE majic2015.surface
  ADD CONSTRAINT fkey_surface_parcele FOREIGN KEY (ptrparcelle) REFERENCES majic2015.parcelle (idparcelle)
   ON UPDATE NO ACTION ON DELETE NO ACTION;
CREATE INDEX fki_key_surface_parcelle
  ON majic2015.surface(ptrparcelle);  

ALTER TABLE majic2015.lot
  ADD PRIMARY KEY (idlot);


CREATE INDEX index_lot_parcelle
  ON majic2015.lot(ptrparcelle);

ALTER TABLE majic2015.surface
  ADD CONSTRAINT fkey_surface_lot FOREIGN KEY (ptrlot) REFERENCES majic2015.lot (idlot)
   ON UPDATE NO ACTION ON DELETE NO ACTION;
CREATE INDEX fki_key_surface_lot
  ON majic2015.surface(ptrlot);  

ALTER TABLE majic2015.locaux
  ADD PRIMARY KEY (idlocal);

CREATE INDEX fki_fkey_locaux_parcelle
  ON majic2015.locaux(ptrparcelle);

ALTER TABLE majic2015.pev
  ADD PRIMARY KEY(idpev);
ALTER TABLE majic2015.pev
  ADD CONSTRAINT fkey_pev_locaux FOREIGN KEY (ptrlocal) REFERENCES majic2015.locaux (idlocal)
   ON UPDATE NO ACTION ON DELETE NO ACTION;
CREATE INDEX fki_fkey_pev_locaux
  ON majic2015.pev(ptrlocal);

ALTER TABLE majic2015.art40
  ADD PRIMARY KEY (idart40);

ALTER TABLE majic2015.art40
  ADD CONSTRAINT fkey_art40_pev FOREIGN KEY (ptrpev) REFERENCES majic2015.pev (idpev)
   ON UPDATE NO ACTION ON DELETE NO ACTION;
CREATE INDEX fki_fkey_art40_pev
  ON majic2015.art40(ptrpev);

ALTER TABLE majic2015.art50
  ADD PRIMARY KEY (idart50);

ALTER TABLE majic2015.art50
  ADD CONSTRAINT fkey_art50_pev FOREIGN KEY (ptrpev) REFERENCES majic2015.pev (idpev)
   ON UPDATE NO ACTION ON DELETE NO ACTION;
CREATE INDEX fki_fkey_art50_pev
  ON majic2015.art50(ptrpev);

ALTER TABLE majic2015.art60
  ADD PRIMARY KEY (idart60);

ALTER TABLE majic2015.art60
  ADD CONSTRAINT fkey_art60_pev FOREIGN KEY (ptrpev) REFERENCES majic2015.pev (idpev)
   ON UPDATE NO ACTION ON DELETE NO ACTION;
CREATE INDEX fki_fkey_art60_pev
  ON majic2015.art60(ptrpev);
  
CREATE INDEX index_jointcomptecommunalproprietaire_ptrcomptecommunal
  ON majic2015.jointcomptecommunalproprietaire(ptrcomptecommunal);

CREATE INDEX index_jointcomptecommunalproprietaire_ptrproprietaire
  ON majic2015.jointcomptecommunalproprietaire(ptrproprietaire);

CREATE INDEX index_jointlotlocal_ptrlocal
  ON majic2015.jointlotlocal(ptrlocal);

CREATE INDEX index_jointlotlocal_ptrlot
  ON majic2015.jointlotlocal(ptrlot);

CREATE INDEX index_jointlotproprietaire_ptrproprietaire
 on majic2015.jointlotproprietaire (ptrproprietaire);

CREATE INDEX index_jointlotproprietaire_ptrlot
  on majic2015.jointlotproprietaire (ptrlot);

CREATE INDEX index_jointproplocal_ptrlocal
 ON majic2015.jointproplocal(ptrlocal);

CREATE INDEX index_jointproplocal_ptrproprietaire
 ON majic2015.jointproplocal(ptrproprietaire);