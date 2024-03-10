INSERT INTO fonctions (id, intitule) VALUES ('1', 'Enseignant titulaire');
INSERT INTO fonctions (intitule) VALUES ('Enseignant contractuel');
INSERT INTO fonctions (intitule) VALUES ('Enseignant chercheur');
INSERT INTO fonctions (intitule) VALUES ('Secrétaire');
INSERT INTO fonctions (intitule) VALUES ('Chef de département');
INSERT INTO fonctions (intitule) VALUES ('Étudiant');
INSERT INTO fonctions (intitule) VALUES ('Étudiant délégué');

INSERT INTO services (id, intitule) VALUES ('1', 'Module ergonomie');
INSERT INTO services (intitule) VALUES ('Module Algo / Prog');
INSERT INTO services (intitule) VALUES ('Module Systèmes et réseaux');
INSERT INTO services (intitule) VALUES ('Module Bases de données');
INSERT INTO services (intitule) VALUES ('Département Informatique');
INSERT INTO services (intitule) VALUES ('BUT INFO 2A');


INSERT INTO `personnels` (`id`, `prenom`, `nom`, `idService`, `idFonction`, `telephone`, `photo`) 
VALUES ('1', 'Philippe', 'Brutus', '1', '1', NULL, NULL);
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Nouzha', 'Tber', '3', '2');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Laurent', 'Jeanpierre', '2', '3');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Clément', 'Catel', '2', '2');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Eric', 'Porcq', '4', '1');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Pierrick', 'Meignen', '4', '1');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Gwendoline', 'Lugnier', '5', '4');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Fabienne', 'Jort', '5', '5');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Julien', 'Ait Azzouzene', '6', '6');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Guillaume', 'Bergerot', '6', '6');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Julien', 'Sailly', '6', '7');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Clément', 'Baratin', '6', '7');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Guilhem', 'Saint-Gaudin', '6', '7');
INSERT INTO personnels (prenom, nom, idService, idFonction) VALUES ('Victor', 'Friboulet', '6', '7');
