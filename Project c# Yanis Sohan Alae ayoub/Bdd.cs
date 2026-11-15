using MySql.Data.MySqlClient;

namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de parler avec la base de données
    /// toutes les requêtes sql sont ici
    /// </summary>
    public static class Bdd
    {
        /// <summary>
        /// ce code permet de savoir où est la base de données
        /// </summary>
        public static string ChaineConnexion = "server=localhost;port=3306;database=gsb_incidents;uid=root;pwd=;";

        /// <summary>
        /// ce code permet de récupérer toutes les personnes qui ont ce rôle
        /// </summary>
        /// <param name="role">utilisateur ou technicien ou responsable</param>
        /// <returns>la liste des personnes</returns>
        public static List<Personnel> GetPersonnels(string role)
        {
            List<Personnel> liste = new List<Personnel>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "SELECT idPersonnel, matricule, nom, prenom, adresse, dateEmbauche, login, role "
                    + "FROM PERSONNEL WHERE role = @role ORDER BY nom, prenom";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@role", role);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(LirePersonnel(reader));
                    }
                }
            }

            return liste;
        }

        /// <summary>
        /// ce code permet de récupérer tous les techniciens
        /// </summary>
        /// <returns>la liste des techniciens</returns>
        public static List<Technicien> GetTechniciens()
        {
            List<Technicien> liste = new List<Technicien>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "SELECT p.idPersonnel, p.matricule, p.nom, p.prenom, p.adresse, p.dateEmbauche, p.login, p.role, "
                    + "t.niveauIntervention, t.formation, t.competences "
                    + "FROM PERSONNEL p JOIN TECHNICIEN t ON t.idPersonnel = p.idPersonnel "
                    + "ORDER BY p.nom, p.prenom";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(LireTechnicien(reader));
                    }
                }
            }

            return liste;
        }

        /// <summary>
        /// ce code permet de rajouter une personne dans la base
        /// le matricule est créé tout seul après
        /// </summary>
        /// <param name="p">la personne à rajouter</param>
        /// <param name="motDePasse">le mot de passe qui sera mis en sha2</param>
        public static void AjouterPersonnel(Personnel p, string motDePasse)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "INSERT INTO PERSONNEL (nom, prenom, adresse, dateEmbauche, login, motDePasse, role) "
                    + "VALUES (@nom, @prenom, @adresse, @dateEmbauche, @login, SHA2(@motDePasse, 256), @role)";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@nom", p.Nom);
                cmd.Parameters.AddWithValue("@prenom", p.Prenom);
                cmd.Parameters.AddWithValue("@adresse", p.Adresse);
                cmd.Parameters.AddWithValue("@dateEmbauche", p.DateEmbauche);
                cmd.Parameters.AddWithValue("@login", p.Login);
                cmd.Parameters.AddWithValue("@motDePasse", motDePasse);
                cmd.Parameters.AddWithValue("@role", p.Role);
                cmd.ExecuteNonQuery();

                p.IdPersonnel = (int)cmd.LastInsertedId;
                p.Matricule = p.GenererMatricule();

                MySqlCommand cmdMatricule = new MySqlCommand("UPDATE PERSONNEL SET matricule = @matricule WHERE idPersonnel = @id", cnx);
                cmdMatricule.Parameters.AddWithValue("@matricule", p.Matricule);
                cmdMatricule.Parameters.AddWithValue("@id", p.IdPersonnel);
                cmdMatricule.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de rajouter un technicien dans la base
        /// </summary>
        /// <param name="t">le technicien à rajouter</param>
        /// <param name="motDePasse">le mot de passe du technicien</param>
        public static void AjouterTechnicien(Technicien t, string motDePasse)
        {
            AjouterPersonnel(t, motDePasse);

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "INSERT INTO TECHNICIEN (idPersonnel, niveauIntervention, formation, competences) "
                    + "VALUES (@id, @niveau, @formation, @competences)";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@id", t.IdPersonnel);
                cmd.Parameters.AddWithValue("@niveau", t.NiveauIntervention);
                cmd.Parameters.AddWithValue("@formation", t.Formation);
                cmd.Parameters.AddWithValue("@competences", t.Competences);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de modifier une personne
        /// </summary>
        /// <param name="p">la personne avec les nouvelles infos</param>
        public static void ModifierPersonnel(Personnel p)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "UPDATE PERSONNEL SET nom = @nom, prenom = @prenom, adresse = @adresse, "
                    + "dateEmbauche = @dateEmbauche, login = @login WHERE idPersonnel = @id";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@nom", p.Nom);
                cmd.Parameters.AddWithValue("@prenom", p.Prenom);
                cmd.Parameters.AddWithValue("@adresse", p.Adresse);
                cmd.Parameters.AddWithValue("@dateEmbauche", p.DateEmbauche);
                cmd.Parameters.AddWithValue("@login", p.Login);
                cmd.Parameters.AddWithValue("@id", p.IdPersonnel);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de modifier un technicien
        /// </summary>
        /// <param name="t">le technicien avec les nouvelles infos</param>
        public static void ModifierTechnicien(Technicien t)
        {
            ModifierPersonnel(t);

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "UPDATE TECHNICIEN SET niveauIntervention = @niveau, formation = @formation, "
                    + "competences = @competences WHERE idPersonnel = @id";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@niveau", t.NiveauIntervention);
                cmd.Parameters.AddWithValue("@formation", t.Formation);
                cmd.Parameters.AddWithValue("@competences", t.Competences);
                cmd.Parameters.AddWithValue("@id", t.IdPersonnel);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de changer le mot de passe
        /// </summary>
        /// <param name="p">la personne</param>
        /// <param name="nouveauMotDePasse">le nouveau mot de passe qui sera mis en sha2</param>
        public static void ModifierMotDePasse(Personnel p, string nouveauMotDePasse)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE PERSONNEL SET motDePasse = SHA2(@motDePasse, 256) WHERE idPersonnel = @id", cnx);
                cmd.Parameters.AddWithValue("@motDePasse", nouveauMotDePasse);
                cmd.Parameters.AddWithValue("@id", p.IdPersonnel);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de supprimer une personne
        /// </summary>
        /// <param name="p">la personne à supprimer</param>
        public static void SupprimerPersonnel(Personnel p)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM PERSONNEL WHERE idPersonnel = @id", cnx);
                cmd.Parameters.AddWithValue("@id", p.IdPersonnel);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de récupérer toutes les régions
        /// </summary>
        /// <returns>la liste des régions</returns>
        public static List<Region> GetRegions()
        {
            List<Region> liste = new List<Region>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT idRegion, libelleRegion FROM REGION ORDER BY idRegion", cnx);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Region r = new Region(Convert.ToInt32(reader["idRegion"]), reader["libelleRegion"].ToString());
                        liste.Add(r);
                    }
                }
            }

            return liste;
        }

        /// <summary>
        /// ce code permet de trouver la région où la personne travaille en ce moment
        /// on prend la région avec la date la plus récente
        /// </summary>
        /// <param name="p">la personne</param>
        /// <returns>la région ou null si elle a aucune région</returns>
        public static Region GetRegionActuelle(Personnel p)
        {
            Region region = null;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "SELECT r.idRegion, r.libelleRegion FROM AFFECTER a "
                    + "JOIN REGION r ON r.idRegion = a.idRegion "
                    + "WHERE a.idPersonnel = @id ORDER BY a.dateAffectation DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@id", p.IdPersonnel);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        region = new Region(Convert.ToInt32(reader["idRegion"]), reader["libelleRegion"].ToString());
                    }
                }
            }

            return region;
        }

        /// <summary>
        /// ce code permet de mettre une personne dans une nouvelle région avec la date du jour
        /// </summary>
        /// <param name="p">la personne</param>
        /// <param name="r">la nouvelle région</param>
        public static void AffecterRegion(Personnel p, Region r)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmdSupprimer = new MySqlCommand("DELETE FROM AFFECTER WHERE idPersonnel = @idPersonnel AND dateAffectation = CURDATE()", cnx);
                cmdSupprimer.Parameters.AddWithValue("@idPersonnel", p.IdPersonnel);
                cmdSupprimer.ExecuteNonQuery();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO AFFECTER (idPersonnel, idRegion, dateAffectation) VALUES (@idPersonnel, @idRegion, CURDATE())", cnx);
                cmd.Parameters.AddWithValue("@idPersonnel", p.IdPersonnel);
                cmd.Parameters.AddWithValue("@idRegion", r.IdRegion);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de récupérer tous les fournisseurs
        /// </summary>
        /// <returns>la liste des fournisseurs</returns>
        public static List<Fournisseur> GetFournisseurs()
        {
            List<Fournisseur> liste = new List<Fournisseur>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM FOURNISSEUR ORDER BY nomFournisseur", cnx);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(LireFournisseur(reader));
                    }
                }
            }

            return liste;
        }

        /// <summary>
        /// ce code permet de récupérer tout le matériel
        /// </summary>
        /// <returns>la liste du matériel</returns>
        public static List<Materiel> GetMateriels()
        {
            List<Materiel> liste = new List<Materiel>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM MATERIEL ORDER BY idMateriel", cnx);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(LireMateriel(reader));
                    }
                }
            }

            return liste;
        }

        /// <summary>
        /// ce code permet de récupérer le matériel de la personne et le matériel commun
        /// </summary>
        /// <param name="p">la personne</param>
        /// <returns>la liste du matériel</returns>
        public static List<Materiel> GetMaterielsDuPersonnel(Personnel p)
        {
            List<Materiel> liste = new List<Materiel>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM MATERIEL WHERE idPersonnel = @id OR idPersonnel IS NULL ORDER BY idMateriel", cnx);
                cmd.Parameters.AddWithValue("@id", p.IdPersonnel);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(LireMateriel(reader));
                    }
                }
            }

            return liste;
        }

        /// <summary>
        /// ce code permet de rajouter un matériel dans la base
        /// </summary>
        /// <param name="m">le matériel à rajouter</param>
        public static void AjouterMateriel(Materiel m)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "INSERT INTO MATERIEL (typeMateriel, composants, logicielsInstalles, dateAcquisition, garantie, modeAcquisition, idPersonnel, idFournisseur) "
                    + "VALUES (@type, @composants, @logiciels, @dateAcquisition, @garantie, @mode, @idPersonnel, @idFournisseur)";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@type", m.TypeMateriel);
                cmd.Parameters.AddWithValue("@composants", m.Composants);
                cmd.Parameters.AddWithValue("@logiciels", m.LogicielsInstalles);
                cmd.Parameters.AddWithValue("@dateAcquisition", m.DateAcquisition);
                cmd.Parameters.AddWithValue("@garantie", m.Garantie);
                cmd.Parameters.AddWithValue("@mode", m.ModeAcquisition);

                if (m.Personnel != null)
                {
                    cmd.Parameters.AddWithValue("@idPersonnel", m.Personnel.IdPersonnel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idPersonnel", null);
                }

                if (m.Fournisseur != null)
                {
                    cmd.Parameters.AddWithValue("@idFournisseur", m.Fournisseur.IdFournisseur);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idFournisseur", null);
                }

                cmd.ExecuteNonQuery();
                m.IdMateriel = (int)cmd.LastInsertedId;
            }
        }

        /// <summary>
        /// ce code permet de supprimer un matériel
        /// </summary>
        /// <param name="m">le matériel à supprimer</param>
        public static void SupprimerMateriel(Materiel m)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM MATERIEL WHERE idMateriel = @id", cnx);
                cmd.Parameters.AddWithValue("@id", m.IdMateriel);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de déclarer un nouvel incident
        /// </summary>
        /// <param name="i">le nouvel incident</param>
        public static void DeclarerIncident(Incident i)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "INSERT INTO INCIDENT (objet, description, niveauUrgence, niveauDemande, idDeclarant, idMateriel) "
                    + "VALUES (@objet, @description, @urgence, @niveau, @idDeclarant, @idMateriel)";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@objet", i.Objet);
                cmd.Parameters.AddWithValue("@description", i.Description);
                cmd.Parameters.AddWithValue("@urgence", i.NiveauUrgence);
                cmd.Parameters.AddWithValue("@niveau", i.NiveauDemande);
                cmd.Parameters.AddWithValue("@idDeclarant", i.Declarant.IdPersonnel);
                cmd.Parameters.AddWithValue("@idMateriel", i.Materiel.IdMateriel);
                cmd.ExecuteNonQuery();
                i.IdIncident = (int)cmd.LastInsertedId;
            }
        }

        /// <summary>
        /// ce code permet de récupérer les incidents déclarés par une personne
        /// </summary>
        /// <param name="p">la personne</param>
        /// <returns>la liste de ses incidents</returns>
        public static List<Incident> GetIncidentsDuDeclarant(Personnel p)
        {
            List<Incident> liste = new List<Incident>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM INCIDENT WHERE idDeclarant = @id ORDER BY dateDeclaration DESC", cnx);
                cmd.Parameters.AddWithValue("@id", p.IdPersonnel);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(LireIncident(reader));
                    }
                }
            }

            return liste;
        }

        /// <summary>
        /// ce code permet de récupérer les incidents que le technicien peut voir
        /// le niveau 1 voit que les incidents de niveau 1 de sa région
        /// le niveau 2 voit tout
        /// </summary>
        /// <param name="t">le technicien</param>
        /// <returns>la liste des incidents</returns>
        public static List<Incident> GetIncidentsPourTechnicien(Technicien t)
        {
            List<Incident> liste = new List<Incident>();
            Region regionTechnicien = GetRegionActuelle(t);

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM INCIDENT ORDER BY dateDeclaration DESC", cnx);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Incident i = LireIncident(reader);

                        if (t.NiveauIntervention == 1)
                        {
                            Region regionDeclarant = GetRegionActuelle(i.Declarant);
                            if (i.NiveauDemande == 1 && regionTechnicien != null && regionDeclarant != null && regionDeclarant.IdRegion == regionTechnicien.IdRegion)
                            {
                                liste.Add(i);
                            }
                        }
                        else
                        {
                            liste.Add(i);
                        }
                    }
                }
            }

            return liste;
        }

        /// <summary>
        /// ce code permet de mettre un technicien sur un incident
        /// ensuite le trigger le passe en cours de traitement
        /// </summary>
        /// <param name="i">un incident pas encore pris</param>
        /// <param name="t">le technicien qui le prend</param>
        /// <param name="typePriseEnCharge">téléphone ou télémaintenance ou déplacement sur site</param>
        public static void PrendreEnCharge(Incident i, Technicien t, string typePriseEnCharge)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE INCIDENT SET idTechnicien = @idTechnicien, typePriseEnCharge = @type WHERE idIncident = @id", cnx);
                cmd.Parameters.AddWithValue("@idTechnicien", t.IdPersonnel);
                cmd.Parameters.AddWithValue("@type", typePriseEnCharge);
                cmd.Parameters.AddWithValue("@id", i.IdIncident);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de passer un incident en résolue
        /// </summary>
        /// <param name="i">un incident en cours</param>
        public static void ResoudreIncident(Incident i)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE INCIDENT SET etat = 'Résolue' WHERE idIncident = @id", cnx);
                cmd.Parameters.AddWithValue("@id", i.IdIncident);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de passer un incident en clôturée
        /// </summary>
        /// <param name="i">un incident résolu</param>
        public static void CloturerIncident(Incident i)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE INCIDENT SET etat = 'Clôturée' WHERE idIncident = @id", cnx);
                cmd.Parameters.AddWithValue("@id", i.IdIncident);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de rajouter une intervention sur un incident
        /// </summary>
        /// <param name="v">la nouvelle intervention</param>
        public static void AjouterIntervention(Intervention v)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "INSERT INTO INTERVENTION (dateIntervention, heureDebut, heureFin, travailRealise, idIncident, idTechnicien) "
                    + "VALUES (@date, @debut, @fin, @travail, @idIncident, @idTechnicien)";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@date", v.DateIntervention.Date);
                cmd.Parameters.AddWithValue("@debut", v.HeureDebut);
                cmd.Parameters.AddWithValue("@fin", v.HeureFin);
                cmd.Parameters.AddWithValue("@travail", v.TravailRealise);
                cmd.Parameters.AddWithValue("@idIncident", v.Incident.IdIncident);
                cmd.Parameters.AddWithValue("@idTechnicien", v.Technicien.IdPersonnel);
                cmd.ExecuteNonQuery();
                v.IdIntervention = (int)cmd.LastInsertedId;
            }
        }

        /// <summary>
        /// ce code permet de récupérer les interventions faites sur un incident
        /// </summary>
        /// <param name="i">un incident de la liste</param>
        /// <returns>la liste des interventions</returns>
        public static List<Intervention> GetInterventions(Incident i)
        {
            List<Intervention> liste = new List<Intervention>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM INTERVENTION WHERE idIncident = @id ORDER BY dateIntervention, heureDebut", cnx);
                cmd.Parameters.AddWithValue("@id", i.IdIncident);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Technicien t = GetTechnicien(Convert.ToInt32(reader["idTechnicien"]));

                        Intervention v = new Intervention(Convert.ToInt32(reader["idIntervention"]), Convert.ToDateTime(reader["dateIntervention"]),
                            (TimeSpan)reader["heureDebut"], (TimeSpan)reader["heureFin"], reader["travailRealise"].ToString(), i, t);
                        liste.Add(v);
                    }
                }
            }

            return liste;
        }

        /// <summary>
        /// ce code permet de calculer les stats de tous les incidents
        /// </summary>
        /// <returns>les stats</returns>
        public static Statistiques GetStatistiques()
        {
            int nbDeclares = CompterIncidents("Enregistrée");
            int nbEnCharge = CompterIncidents("En cours de traitement");
            int nbResolus = CompterIncidents("Résolue") + CompterIncidents("Clôturée");
            double delaiMoyenJours = 0;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT AVG(DATEDIFF(dateResolution, dateDeclaration)) FROM INCIDENT WHERE dateResolution IS NOT NULL", cnx);
                object resultat = cmd.ExecuteScalar();
                if (resultat.ToString() != "")
                {
                    delaiMoyenJours = Convert.ToDouble(resultat);
                }
            }

            return new Statistiques(nbDeclares, nbEnCharge, nbResolus, delaiMoyenJours);
        }

        /// <summary>
        /// ce code permet de calculer les stats de chaque technicien
        /// </summary>
        /// <returns>la liste des stats</returns>
        public static List<StatTechnicien> GetStatsTechniciens()
        {
            List<StatTechnicien> liste = new List<StatTechnicien>();

            List<Technicien> techniciens = GetTechniciens();
            foreach (Technicien t in techniciens)
            {
                int nbEnCharge = CompterIncidentsDuTechnicien(t, "En cours de traitement");
                int nbResolus = CompterIncidentsDuTechnicien(t, "Résolue") + CompterIncidentsDuTechnicien(t, "Clôturée");
                double nbHeures = GetNbHeures(t);
                liste.Add(new StatTechnicien(t, nbEnCharge, nbResolus, nbHeures));
            }

            return liste;
        }

        /// <summary>
        /// ce code permet de compter les incidents déclarés par une personne
        /// </summary>
        /// <param name="p">la personne</param>
        /// <returns>le nombre de ses incidents</returns>
        public static int GetNbIncidents(Personnel p)
        {
            int nb = 0;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM INCIDENT WHERE idDeclarant = @id", cnx);
                cmd.Parameters.AddWithValue("@id", p.IdPersonnel);
                nb = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return nb;
        }

        /// <summary>
        /// ce code permet de copier toutes les tables dans la base gsb_sauvegarde
        /// </summary>
        public static void SauvegarderBase()
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "DROP DATABASE IF EXISTS gsb_sauvegarde; "
                    + "CREATE DATABASE gsb_sauvegarde; "
                    + "CREATE TABLE gsb_sauvegarde.REGION AS SELECT * FROM REGION; "
                    + "CREATE TABLE gsb_sauvegarde.FOURNISSEUR AS SELECT * FROM FOURNISSEUR; "
                    + "CREATE TABLE gsb_sauvegarde.PERSONNEL AS SELECT * FROM PERSONNEL; "
                    + "CREATE TABLE gsb_sauvegarde.TECHNICIEN AS SELECT * FROM TECHNICIEN; "
                    + "CREATE TABLE gsb_sauvegarde.AFFECTER AS SELECT * FROM AFFECTER; "
                    + "CREATE TABLE gsb_sauvegarde.MATERIEL AS SELECT * FROM MATERIEL; "
                    + "CREATE TABLE gsb_sauvegarde.INCIDENT AS SELECT * FROM INCIDENT; "
                    + "CREATE TABLE gsb_sauvegarde.INTERVENTION AS SELECT * FROM INTERVENTION;";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ce code permet de compter les incidents qui ont cet état
        /// </summary>
        /// <param name="etat">enregistrée ou en cours de traitement ou résolue ou clôturée</param>
        /// <returns>le nombre trouvé</returns>
        private static int CompterIncidents(string etat)
        {
            int nb = 0;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM INCIDENT WHERE etat = @etat", cnx);
                cmd.Parameters.AddWithValue("@etat", etat);
                nb = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return nb;
        }

        /// <summary>
        /// ce code permet de compter les incidents du technicien qui ont cet état
        /// </summary>
        /// <param name="t">le technicien</param>
        /// <param name="etat">en cours de traitement ou résolue ou clôturée</param>
        /// <returns>le nombre trouvé</returns>
        private static int CompterIncidentsDuTechnicien(Technicien t, string etat)
        {
            int nb = 0;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM INCIDENT WHERE idTechnicien = @id AND etat = @etat", cnx);
                cmd.Parameters.AddWithValue("@id", t.IdPersonnel);
                cmd.Parameters.AddWithValue("@etat", etat);
                nb = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return nb;
        }

        /// <summary>
        /// ce code permet de calculer le total des heures passées par le technicien
        /// on additionne la durée de chaque intervention
        /// </summary>
        /// <param name="t">le technicien</param>
        /// <returns>le total des heures</returns>
        private static double GetNbHeures(Technicien t)
        {
            double nbHeures = 0;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT heureDebut, heureFin FROM INTERVENTION WHERE idTechnicien = @id", cnx);
                cmd.Parameters.AddWithValue("@id", t.IdPersonnel);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Intervention v = new Intervention();
                        v.HeureDebut = (TimeSpan)reader["heureDebut"];
                        v.HeureFin = (TimeSpan)reader["heureFin"];
                        nbHeures = nbHeures + v.DureeEnHeures();
                    }
                }
            }

            return nbHeures;
        }

        /// <summary>
        /// ce code permet de récupérer une personne avec son numéro
        /// </summary>
        /// <param name="idPersonnel">le numéro de la personne</param>
        /// <returns>la personne trouvée</returns>
        private static Personnel GetPersonnel(int idPersonnel)
        {
            Personnel p = null;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM PERSONNEL WHERE idPersonnel = @id", cnx);
                cmd.Parameters.AddWithValue("@id", idPersonnel);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = LirePersonnel(reader);
                    }
                }
            }

            return p;
        }

        /// <summary>
        /// ce code permet de récupérer un technicien avec son numéro
        /// </summary>
        /// <param name="idPersonnel">le numéro du technicien</param>
        /// <returns>le technicien trouvé</returns>
        private static Technicien GetTechnicien(int idPersonnel)
        {
            Technicien t = null;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "SELECT p.idPersonnel, p.matricule, p.nom, p.prenom, p.adresse, p.dateEmbauche, p.login, p.role, "
                    + "t.niveauIntervention, t.formation, t.competences "
                    + "FROM PERSONNEL p JOIN TECHNICIEN t ON t.idPersonnel = p.idPersonnel "
                    + "WHERE p.idPersonnel = @id";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@id", idPersonnel);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        t = LireTechnicien(reader);
                    }
                }
            }

            return t;
        }

        /// <summary>
        /// ce code permet de récupérer un matériel avec son numéro
        /// </summary>
        /// <param name="idMateriel">le numéro du matériel</param>
        /// <returns>le matériel trouvé</returns>
        private static Materiel GetMateriel(int idMateriel)
        {
            Materiel m = null;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM MATERIEL WHERE idMateriel = @id", cnx);
                cmd.Parameters.AddWithValue("@id", idMateriel);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        m = LireMateriel(reader);
                    }
                }
            }

            return m;
        }

        /// <summary>
        /// ce code permet de récupérer un fournisseur avec son numéro
        /// </summary>
        /// <param name="idFournisseur">le numéro du fournisseur</param>
        /// <returns>le fournisseur trouvé</returns>
        private static Fournisseur GetFournisseur(int idFournisseur)
        {
            Fournisseur f = null;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM FOURNISSEUR WHERE idFournisseur = @id", cnx);
                cmd.Parameters.AddWithValue("@id", idFournisseur);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        f = LireFournisseur(reader);
                    }
                }
            }

            return f;
        }

        /// <summary>
        /// ce code permet de remplir une personne avec la ligne lue dans la base
        /// </summary>
        /// <param name="p">la personne à remplir</param>
        /// <param name="reader">la ligne lue dans la base</param>
        private static void RemplirPersonnel(Personnel p, MySqlDataReader reader)
        {
            p.IdPersonnel = Convert.ToInt32(reader["idPersonnel"]);
            p.Matricule = reader["matricule"].ToString();
            p.Nom = reader["nom"].ToString();
            p.Prenom = reader["prenom"].ToString();
            p.Adresse = reader["adresse"].ToString();
            p.DateEmbauche = LireDate(reader, "dateEmbauche");
            p.Login = reader["login"].ToString();
            p.Role = reader["role"].ToString();
        }

        /// <summary>
        /// ce code permet de créer une personne avec la ligne lue dans la base
        /// </summary>
        /// <param name="reader">la ligne lue dans la base</param>
        /// <returns>la personne</returns>
        private static Personnel LirePersonnel(MySqlDataReader reader)
        {
            Personnel p = new Personnel();
            RemplirPersonnel(p, reader);
            return p;
        }

        /// <summary>
        /// ce code permet de créer un technicien avec la ligne lue dans la base
        /// </summary>
        /// <param name="reader">la ligne lue dans la base</param>
        /// <returns>le technicien</returns>
        private static Technicien LireTechnicien(MySqlDataReader reader)
        {
            Technicien t = new Technicien();
            RemplirPersonnel(t, reader);
            t.NiveauIntervention = Convert.ToInt32(reader["niveauIntervention"]);
            t.Formation = reader["formation"].ToString();
            t.Competences = reader["competences"].ToString();
            return t;
        }

        /// <summary>
        /// ce code permet de créer un fournisseur avec la ligne lue dans la base
        /// </summary>
        /// <param name="reader">la ligne lue dans la base</param>
        /// <returns>le fournisseur</returns>
        private static Fournisseur LireFournisseur(MySqlDataReader reader)
        {
            Fournisseur f = new Fournisseur(Convert.ToInt32(reader["idFournisseur"]), reader["nomFournisseur"].ToString(),
                reader["adresse"].ToString(), reader["telephone"].ToString(), reader["typeFournisseur"].ToString());
            return f;
        }

        /// <summary>
        /// ce code permet de créer un matériel avec la ligne lue dans la base
        /// on va chercher aussi la personne et le fournisseur
        /// </summary>
        /// <param name="reader">la ligne lue dans la base</param>
        /// <returns>le matériel</returns>
        private static Materiel LireMateriel(MySqlDataReader reader)
        {
            Materiel m = new Materiel();
            m.IdMateriel = Convert.ToInt32(reader["idMateriel"]);
            m.TypeMateriel = reader["typeMateriel"].ToString();
            m.Composants = reader["composants"].ToString();
            m.LogicielsInstalles = reader["logicielsInstalles"].ToString();
            m.DateAcquisition = LireDate(reader, "dateAcquisition");
            m.Garantie = reader["garantie"].ToString();
            m.ModeAcquisition = reader["modeAcquisition"].ToString();

            if (reader["idPersonnel"].ToString() != "")
            {
                m.Personnel = GetPersonnel(Convert.ToInt32(reader["idPersonnel"]));
            }

            if (reader["idFournisseur"].ToString() != "")
            {
                m.Fournisseur = GetFournisseur(Convert.ToInt32(reader["idFournisseur"]));
            }

            return m;
        }

        /// <summary>
        /// ce code permet de créer un incident avec la ligne lue dans la base
        /// on va chercher aussi le déclarant le technicien et le matériel
        /// </summary>
        /// <param name="reader">la ligne lue dans la base</param>
        /// <returns>un incident tout rempli</returns>
        private static Incident LireIncident(MySqlDataReader reader)
        {
            Incident i = new Incident();
            i.IdIncident = Convert.ToInt32(reader["idIncident"]);
            i.Objet = reader["objet"].ToString();
            i.Description = reader["description"].ToString();
            i.NiveauUrgence = Convert.ToInt32(reader["niveauUrgence"]);
            i.NiveauDemande = Convert.ToInt32(reader["niveauDemande"]);
            i.DateDeclaration = Convert.ToDateTime(reader["dateDeclaration"]);
            i.DatePriseEnCharge = LireDate(reader, "datePriseEnCharge");
            i.DateResolution = LireDate(reader, "dateResolution");
            i.Etat = reader["etat"].ToString();
            i.TypePriseEnCharge = reader["typePriseEnCharge"].ToString();

            i.Declarant = GetPersonnel(Convert.ToInt32(reader["idDeclarant"]));
            i.Materiel = GetMateriel(Convert.ToInt32(reader["idMateriel"]));

            if (reader["idTechnicien"].ToString() != "")
            {
                i.Technicien = GetTechnicien(Convert.ToInt32(reader["idTechnicien"]));
            }

            return i;
        }

        /// <summary>
        /// ce code permet de lire une date qui peut être vide
        /// </summary>
        /// <param name="reader">la ligne lue dans la base</param>
        /// <param name="colonne">le nom de la colonne</param>
        /// <returns>la date ou null si elle est vide</returns>
        private static DateTime? LireDate(MySqlDataReader reader, string colonne)
        {
            if (reader[colonne].ToString() == "")
            {
                return null;
            }
            return Convert.ToDateTime(reader[colonne]);
        }
    }
}
