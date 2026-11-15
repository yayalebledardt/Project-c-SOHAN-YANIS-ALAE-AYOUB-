-- comptes de test, mot de passe pour tous : azerty

DROP DATABASE IF EXISTS gsb_incidents;
CREATE DATABASE gsb_incidents CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE gsb_incidents;


-- 1. Création des tables

-- role : 'utilisateur', 'technicien' ou 'responsable'
-- motDePasse : mot de passe crypté avec SHA2 (64 caractères)
CREATE TABLE PERSONNEL(
   idPersonnel INT AUTO_INCREMENT,
   matricule VARCHAR(10),
   nom VARCHAR(50) NOT NULL,
   prenom VARCHAR(50) NOT NULL,
   adresse VARCHAR(150),
   dateEmbauche DATE,
   login VARCHAR(50) NOT NULL UNIQUE,
   motDePasse VARCHAR(64) NOT NULL,
   role VARCHAR(20) NOT NULL,
   PRIMARY KEY(idPersonnel),
   CHECK (role IN ('utilisateur', 'technicien', 'responsable'))
);

-- niveauIntervention : 1 = premier niveau, 2 = niveau supérieur
CREATE TABLE TECHNICIEN(
   idPersonnel INT,
   niveauIntervention INT NOT NULL DEFAULT 1,
   formation VARCHAR(100),
   competences VARCHAR(255),
   PRIMARY KEY(idPersonnel),
   FOREIGN KEY(idPersonnel) REFERENCES PERSONNEL(idPersonnel) ON DELETE CASCADE,
   CHECK (niveauIntervention IN (1, 2))
);

-- typeFournisseur : 'vendeur' (matériel acheté) ou 'loueur' (société de location)
CREATE TABLE FOURNISSEUR(
   idFournisseur INT AUTO_INCREMENT,
   nomFournisseur VARCHAR(50) NOT NULL,
   adresse VARCHAR(150),
   telephone VARCHAR(20),
   typeFournisseur VARCHAR(20) NOT NULL,
   PRIMARY KEY(idFournisseur),
   CHECK (typeFournisseur IN ('vendeur', 'loueur'))
);

CREATE TABLE REGION(
   idRegion INT AUTO_INCREMENT,
   libelleRegion VARCHAR(50) NOT NULL,
   PRIMARY KEY(idRegion)
);

-- modeAcquisition : 'achat' (maintenu en interne) ou 'location' (maintenu par le loueur)
-- idPersonnel : la personne à qui le matériel est affecté (peut être vide)
CREATE TABLE MATERIEL(
   idMateriel INT AUTO_INCREMENT,
   typeMateriel VARCHAR(50) NOT NULL,
   composants VARCHAR(255),
   logicielsInstalles VARCHAR(255),
   dateAcquisition DATE,
   garantie VARCHAR(50),
   modeAcquisition VARCHAR(20) NOT NULL,
   idPersonnel INT NULL,
   idFournisseur INT NULL,
   PRIMARY KEY(idMateriel),
   FOREIGN KEY(idPersonnel) REFERENCES PERSONNEL(idPersonnel) ON DELETE SET NULL,
   FOREIGN KEY(idFournisseur) REFERENCES FOURNISSEUR(idFournisseur),
   CHECK (modeAcquisition IN ('achat', 'location'))
);

-- niveauUrgence : 1 = faible, 2 = moyenne, 3 = urgente
-- niveauDemande : 1 = premier niveau, 2 = niveau supérieur
-- idDeclarant : la personne qui a déclaré l'incident
-- idTechnicien : le technicien qui le prend en charge (vide au début)
CREATE TABLE INCIDENT(
   idIncident INT AUTO_INCREMENT,
   objet VARCHAR(100) NOT NULL,
   description TEXT,
   niveauUrgence INT NOT NULL DEFAULT 1,
   niveauDemande INT NOT NULL DEFAULT 1,
   dateDeclaration DATETIME DEFAULT CURRENT_TIMESTAMP,
   datePriseEnCharge DATETIME NULL,
   dateResolution DATETIME NULL,
   etat VARCHAR(30) NOT NULL DEFAULT 'Enregistrée',
   typePriseEnCharge VARCHAR(30) NULL,
   idTechnicien INT NULL,
   idDeclarant INT NOT NULL,
   idMateriel INT NOT NULL,
   PRIMARY KEY(idIncident),
   FOREIGN KEY(idTechnicien) REFERENCES TECHNICIEN(idPersonnel) ON DELETE SET NULL,
   FOREIGN KEY(idDeclarant) REFERENCES PERSONNEL(idPersonnel),
   FOREIGN KEY(idMateriel) REFERENCES MATERIEL(idMateriel) ON DELETE CASCADE,
   CHECK (niveauUrgence IN (1, 2, 3)),
   CHECK (niveauDemande IN (1, 2)),
   CHECK (etat IN ('Enregistrée', 'En cours de traitement', 'Résolue', 'Clôturée')),
   CHECK (typePriseEnCharge IN ('Téléphone', 'Télémaintenance', 'Déplacement sur site'))
);

-- une intervention = une phase de travail du technicien sur un incident
CREATE TABLE INTERVENTION(
   idIntervention INT AUTO_INCREMENT,
   dateIntervention DATE NOT NULL,
   heureDebut TIME NOT NULL,
   heureFin TIME NOT NULL,
   travailRealise TEXT NOT NULL,
   idIncident INT NOT NULL,
   idTechnicien INT NOT NULL,
   PRIMARY KEY(idIntervention),
   FOREIGN KEY(idIncident) REFERENCES INCIDENT(idIncident) ON DELETE CASCADE,
   FOREIGN KEY(idTechnicien) REFERENCES TECHNICIEN(idPersonnel)
);

-- les régions par lesquelles une personne est passée
-- (la région actuelle = celle avec la date la plus récente)
CREATE TABLE AFFECTER(
   idPersonnel INT,
   idRegion INT,
   dateAffectation DATE NOT NULL,
   PRIMARY KEY(idPersonnel, idRegion, dateAffectation),
   FOREIGN KEY(idPersonnel) REFERENCES PERSONNEL(idPersonnel) ON DELETE CASCADE,
   FOREIGN KEY(idRegion) REFERENCES REGION(idRegion)
);


-- 2. Données de test

INSERT INTO REGION (libelleRegion) VALUES
('Paris-Centre'),
('Sud'),
('Nord'),
('Ouest'),
('Est'),
('DTOM Caraïbes-Amériques'),
('DTOM Asie-Afrique');

-- matricule = 2 lettres du nom + 2 lettres du prénom + id sur 3 chiffres
INSERT INTO PERSONNEL (matricule, nom, prenom, adresse, dateEmbauche, login, motDePasse, role) VALUES
('MASO001', 'Martin', 'Sophie', '12 rue de Rivoli, 75001 Paris', '2012-09-01', 'smartin', SHA2('azerty', 256), 'responsable'),
('DUPA002', 'Durand', 'Paul', '8 avenue Foch, 75016 Paris', '2018-03-15', 'pdurand', SHA2('azerty', 256), 'technicien'),
('BELU003', 'Bernard', 'Lucie', '25 rue Alsace-Lorraine, 31000 Toulouse', '2020-06-01', 'lbernard', SHA2('azerty', 256), 'technicien'),
('PEKA004', 'Petit', 'Karim', '3 place Bellecour, 69002 Lyon', '2015-01-10', 'kpetit', SHA2('azerty', 256), 'technicien'),
('DUJE005', 'Dupont', 'Jean', '14 rue de la Paix, 75002 Paris', '2019-11-04', 'jdupont', SHA2('azerty', 256), 'utilisateur'),
('ROCL006', 'Robert', 'Claire', '5 allée Jean Jaurès, 31000 Toulouse', '2021-02-01', 'crobert', SHA2('azerty', 256), 'utilisateur'),
('MOTH007', 'Moreau', 'Thomas', '40 rue Nationale, 59000 Lille', '2017-05-22', 'tmoreau', SHA2('azerty', 256), 'utilisateur'),
('LAEM008', 'Laurent', 'Emma', '9 rue du Port, 97200 Fort-de-France', '2022-09-12', 'elaurent', SHA2('azerty', 256), 'utilisateur');

INSERT INTO TECHNICIEN (idPersonnel, niveauIntervention, formation, competences) VALUES
(2, 1, 'BTS SIO SISR', 'Postes Windows, imprimantes, messagerie'),
(3, 1, 'BTS SIO SISR', 'Postes Windows, téléphonie, tablettes'),
(4, 2, 'Licence pro ASUR', 'Réseau, serveurs, sécurité, virtualisation');

-- Jean Dupont est passé par le Nord avant d'arriver à Paris
INSERT INTO AFFECTER (idPersonnel, idRegion, dateAffectation) VALUES
(1, 1, '2012-09-01'),
(2, 1, '2018-03-15'),
(3, 2, '2020-06-01'),
(4, 5, '2015-01-10'),
(4, 1, '2019-09-01'),
(5, 3, '2019-11-04'),
(5, 1, '2023-01-02'),
(6, 2, '2021-02-01'),
(7, 3, '2017-05-22'),
(8, 6, '2022-09-12');

INSERT INTO FOURNISSEUR (nomFournisseur, adresse, telephone, typeFournisseur) VALUES
('InfoDistrib', '18 rue des Entrepreneurs, 69007 Lyon', '04 72 00 00 01', 'vendeur'),
('PC Pro Direct', '7 boulevard Haussmann, 75009 Paris', '01 45 00 00 02', 'vendeur'),
('LocaMat Services', '22 avenue de la Gare, 31500 Toulouse', '05 61 00 00 03', 'loueur');

INSERT INTO MATERIEL (typeMateriel, composants, logicielsInstalles, dateAcquisition, garantie, modeAcquisition, idPersonnel, idFournisseur) VALUES
('PC fixe', 'Intel i5, 16 Go RAM, SSD 512 Go', 'Windows 11, Office 2021', '2023-01-02', '3 ans', 'achat', 5, 2),
('PC portable', 'Intel i7, 16 Go RAM, SSD 1 To', 'Windows 11, Office 2021, VPN', '2021-02-01', '3 ans', 'achat', 6, 1),
('PC portable', 'Intel i5, 8 Go RAM, SSD 256 Go', 'Windows 10, Office 2019', '2017-05-22', '2 ans', 'achat', 7, 1),
('Tablette', 'Samsung Galaxy Tab 2 10.1, 16 Go', 'Android, application GSB', '2022-09-12', '1 an', 'achat', 8, 1),
('Imprimante', 'HP LaserJet, réseau', NULL, '2020-04-10', '2 ans', 'location', NULL, 3),
('PC fixe', 'Intel i5, 8 Go RAM, SSD 512 Go', 'Windows 11, Office 2021', '2018-03-15', '3 ans', 'achat', 2, 2),
('PC portable', 'Intel i7, 32 Go RAM, SSD 1 To', 'Windows 11, outils réseau', '2019-09-01', '3 ans', 'achat', 4, 1),
('Tablette', 'Samsung Galaxy Tab 2 10.1, 16 Go', 'Android, application GSB', '2022-09-12', '1 an', 'achat', 5, 1);

-- des incidents dans tous les états pour tester l'appli et les statistiques
INSERT INTO INCIDENT (objet, description, niveauUrgence, niveauDemande, dateDeclaration, datePriseEnCharge, dateResolution, etat, typePriseEnCharge, idTechnicien, idDeclarant, idMateriel) VALUES
('Écran noir au démarrage', 'Le PC démarre mais l''écran reste noir.', 3, 1, '2026-09-08 09:12:00', '2026-09-08 10:00:00', '2026-09-09 16:30:00', 'Clôturée', 'Déplacement sur site', 2, 5, 1),
('Outlook ne se lance plus', 'Message d''erreur au lancement d''Outlook.', 2, 1, '2026-09-22 14:05:00', '2026-09-22 14:30:00', '2026-09-22 15:10:00', 'Résolue', 'Télémaintenance', 3, 6, 2),
('PC très lent', 'Le PC met plus de 5 minutes à démarrer.', 1, 1, '2026-10-05 08:40:00', '2026-10-06 09:00:00', '2026-10-08 11:00:00', 'Résolue', 'Déplacement sur site', 2, 5, 1),
('Pas de connexion VPN', 'Impossible de se connecter au VPN depuis la maison.', 3, 2, '2026-10-20 18:02:00', '2026-10-21 08:30:00', NULL, 'En cours de traitement', 'Téléphone', 4, 7, 3),
('Tablette ne charge plus', 'La tablette ne charge plus avec son câble.', 2, 1, '2026-11-02 10:15:00', NULL, NULL, 'Enregistrée', NULL, NULL, 8, 4),
('Bourrage papier', 'L''imprimante du 2e étage bloque à chaque impression.', 1, 1, '2026-11-03 11:20:00', NULL, NULL, 'Enregistrée', NULL, NULL, 5, 5);

INSERT INTO INTERVENTION (dateIntervention, heureDebut, heureFin, travailRealise, idIncident, idTechnicien) VALUES
('2026-09-08', '10:00:00', '11:30:00', 'Diagnostic : câble écran défectueux, commande d''un câble neuf.', 1, 2),
('2026-09-09', '16:00:00', '16:30:00', 'Remplacement du câble, écran fonctionnel.', 1, 2),
('2026-09-22', '14:30:00', '15:10:00', 'Réparation d''Office à distance, profil Outlook recréé.', 2, 3),
('2026-10-06', '09:00:00', '10:30:00', 'Désactivation des programmes au démarrage.', 3, 2),
('2026-10-08', '10:00:00', '11:00:00', 'Nettoyage du disque et mises à jour Windows.', 3, 2),
('2026-10-21', '08:30:00', '09:15:00', 'Vérification du compte VPN, problème de certificat.', 4, 4);


-- 3. Triggers

DELIMITER //

-- Trigger 1 : quand on modifie un incident
-- si on lui affecte un technicien, on enregistre la date de prise en charge
-- et l'incident passe "En cours de traitement"
-- s'il passe "Résolue", on enregistre la date de résolution
CREATE TRIGGER trg_incident_maj
BEFORE UPDATE ON INCIDENT
FOR EACH ROW
BEGIN
   IF NEW.idTechnicien IS NOT NULL AND OLD.idTechnicien IS NULL THEN
      SET NEW.datePriseEnCharge = NOW();
      IF NEW.etat = 'Enregistrée' THEN
         SET NEW.etat = 'En cours de traitement';
      END IF;
   END IF;

   IF NEW.etat = 'Résolue' AND OLD.etat <> 'Résolue' THEN
      SET NEW.dateResolution = NOW();
   END IF;
END //

-- Trigger 2 : on ne peut pas enregistrer une intervention
-- si l'heure de fin est avant l'heure de début
-- ou si l'incident est déjà clôturé
CREATE TRIGGER trg_intervention_ajout
BEFORE INSERT ON INTERVENTION
FOR EACH ROW
BEGIN
   DECLARE etatIncident VARCHAR(30);

   IF NEW.heureFin <= NEW.heureDebut THEN
      SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L''heure de fin doit être après l''heure de début.';
   END IF;

   SELECT etat INTO etatIncident FROM INCIDENT WHERE idIncident = NEW.idIncident;
   IF etatIncident = 'Clôturée' THEN
      SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible : cet incident est déjà clôturé.';
   END IF;
END //

-- Trigger 3 : on ne peut pas supprimer un matériel
-- qui a encore un incident pas résolu
CREATE TRIGGER trg_materiel_suppression
BEFORE DELETE ON MATERIEL
FOR EACH ROW
BEGIN
   DECLARE nbIncidents INT;

   SELECT COUNT(*) INTO nbIncidents FROM INCIDENT
   WHERE idMateriel = OLD.idMateriel
   AND etat IN ('Enregistrée', 'En cours de traitement');

   IF nbIncidents > 0 THEN
      SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible : ce matériel a encore des incidents en cours.';
   END IF;
END //

DELIMITER ;
