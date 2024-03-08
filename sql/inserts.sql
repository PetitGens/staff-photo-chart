INSERT INTO fonctions (id, intitule) VALUES ('1', 'Enseignant titulaire');

INSERT INTO services (id, intitule) VALUES ('1', 'Module ergonomie');

INSERT INTO `personnels` (`id`, `prenom`, `nom`, `idService`, `idFonction`, `telephone`, `photo`) 
VALUES ('1', 'Philippe', 'Brutus', '1', '1', NULL, NULL);