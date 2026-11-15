using MySql.Data.MySqlClient;

namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    public static class Bdd
    {
        public static string ChaineConnexion = "server=localhost;port=3306;database=gsb_incidents;uid=root;pwd=;";

        private const string SelectIncidents =
            "SELECT i.idIncident, i.objet, i.description, i.niveauUrgence, i.niveauDemande, i.dateDeclaration, "
            + "i.datePriseEnCharge, i.dateResolution, i.etat, i.typePriseEnCharge, "
            + "d.idPersonnel AS idDeclarant, d.matricule AS matriculeDeclarant, d.nom AS nomDeclarant, d.prenom AS prenomDeclarant, "
            + "t.idPersonnel AS idTechnicien, t.nom AS nomTechnicien, t.prenom AS prenomTechnicien, tt.niveauIntervention, "
            + "m.idMateriel, m.typeMateriel, m.composants, m.modeAcquisition, "
            + "f.idFournisseur, f.nomFournisseur, f.telephone "
            + "FROM INCIDENT i "
            + "JOIN PERSONNEL d ON d.idPersonnel = i.idDeclarant "
            + "LEFT JOIN PERSONNEL t ON t.idPersonnel = i.idTechnicien "
            + "LEFT JOIN TECHNICIEN tt ON tt.idPersonnel = i.idTechnicien "
            + "JOIN MATERIEL m ON m.idMateriel = i.idMateriel "
            + "LEFT JOIN FOURNISSEUR f ON f.idFournisseur = m.idFournisseur ";

        private const string SelectMateriels =
            "SELECT m.idMateriel, m.typeMateriel, m.composants, m.logicielsInstalles, m.dateAcquisition, m.garantie, m.modeAcquisition, "
            + "p.idPersonnel, p.matricule, p.nom, p.prenom, "
            + "f.idFournisseur, f.nomFournisseur, f.adresse, f.telephone, f.typeFournisseur "
            + "FROM MATERIEL m "
            + "LEFT JOIN PERSONNEL p ON p.idPersonnel = m.idPersonnel "
            + "LEFT JOIN FOURNISSEUR f ON f.idFournisseur = m.idFournisseur ";

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
                cmd.Parameters.AddWithValue("@adresse", ValeurOuNull(p.Adresse));
                cmd.Parameters.AddWithValue("@dateEmbauche", ValeurOuNull(p.DateEmbauche));
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
                cmd.Parameters.AddWithValue("@formation", ValeurOuNull(t.Formation));
                cmd.Parameters.AddWithValue("@competences", ValeurOuNull(t.Competences));
                cmd.ExecuteNonQuery();
            }
        }

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
                cmd.Parameters.AddWithValue("@adresse", ValeurOuNull(p.Adresse));
                cmd.Parameters.AddWithValue("@dateEmbauche", ValeurOuNull(p.DateEmbauche));
                cmd.Parameters.AddWithValue("@login", p.Login);
                cmd.Parameters.AddWithValue("@id", p.IdPersonnel);
                cmd.ExecuteNonQuery();
            }
        }

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
                cmd.Parameters.AddWithValue("@formation", ValeurOuNull(t.Formation));
                cmd.Parameters.AddWithValue("@competences", ValeurOuNull(t.Competences));
                cmd.Parameters.AddWithValue("@id", t.IdPersonnel);
                cmd.ExecuteNonQuery();
            }
        }

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

        public static List<Fournisseur> GetFournisseurs()
        {
            List<Fournisseur> liste = new List<Fournisseur>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT idFournisseur, nomFournisseur, adresse, telephone, typeFournisseur FROM FOURNISSEUR ORDER BY nomFournisseur", cnx);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Fournisseur f = new Fournisseur(Convert.ToInt32(reader["idFournisseur"]), reader["nomFournisseur"].ToString(),
                            reader["adresse"].ToString(), reader["telephone"].ToString(), reader["typeFournisseur"].ToString());
                        liste.Add(f);
                    }
                }
            }

            return liste;
        }

        public static List<Materiel> GetMateriels()
        {
            List<Materiel> liste = new List<Materiel>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(SelectMateriels + "ORDER BY m.idMateriel", cnx);

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

        public static List<Materiel> GetMaterielsDuPersonnel(Personnel p)
        {
            List<Materiel> liste = new List<Materiel>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(SelectMateriels + "WHERE m.idPersonnel = @id OR m.idPersonnel IS NULL ORDER BY m.idMateriel", cnx);
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

        public static void AjouterMateriel(Materiel m)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "INSERT INTO MATERIEL (typeMateriel, composants, logicielsInstalles, dateAcquisition, garantie, modeAcquisition, idPersonnel, idFournisseur) "
                    + "VALUES (@type, @composants, @logiciels, @dateAcquisition, @garantie, @mode, @idPersonnel, @idFournisseur)";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@type", m.TypeMateriel);
                cmd.Parameters.AddWithValue("@composants", ValeurOuNull(m.Composants));
                cmd.Parameters.AddWithValue("@logiciels", ValeurOuNull(m.LogicielsInstalles));
                cmd.Parameters.AddWithValue("@dateAcquisition", ValeurOuNull(m.DateAcquisition));
                cmd.Parameters.AddWithValue("@garantie", ValeurOuNull(m.Garantie));
                cmd.Parameters.AddWithValue("@mode", m.ModeAcquisition);

                if (m.Personnel != null)
                {
                    cmd.Parameters.AddWithValue("@idPersonnel", m.Personnel.IdPersonnel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idPersonnel", DBNull.Value);
                }

                if (m.Fournisseur != null)
                {
                    cmd.Parameters.AddWithValue("@idFournisseur", m.Fournisseur.IdFournisseur);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idFournisseur", DBNull.Value);
                }

                cmd.ExecuteNonQuery();
                m.IdMateriel = (int)cmd.LastInsertedId;
            }
        }

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

        public static void DeclarerIncident(Incident i)
        {
            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "INSERT INTO INCIDENT (objet, description, niveauUrgence, niveauDemande, idDeclarant, idMateriel) "
                    + "VALUES (@objet, @description, @urgence, @niveau, @idDeclarant, @idMateriel)";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@objet", i.Objet);
                cmd.Parameters.AddWithValue("@description", ValeurOuNull(i.Description));
                cmd.Parameters.AddWithValue("@urgence", i.NiveauUrgence);
                cmd.Parameters.AddWithValue("@niveau", i.NiveauDemande);
                cmd.Parameters.AddWithValue("@idDeclarant", i.Declarant.IdPersonnel);
                cmd.Parameters.AddWithValue("@idMateriel", i.Materiel.IdMateriel);
                cmd.ExecuteNonQuery();
                i.IdIncident = (int)cmd.LastInsertedId;
            }
        }

        public static List<Incident> GetIncidentsDuDeclarant(Personnel p)
        {
            List<Incident> liste = new List<Incident>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(SelectIncidents + "WHERE i.idDeclarant = @id ORDER BY i.dateDeclaration DESC", cnx);
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

        public static List<Incident> GetIncidentsPourTechnicien(Technicien t)
        {
            List<Incident> liste = new List<Incident>();

            string requete = SelectIncidents;
            if (t.NiveauIntervention == 1)
            {
                requete = requete + "WHERE i.niveauDemande = 1 AND "
                    + "(SELECT a.idRegion FROM AFFECTER a WHERE a.idPersonnel = i.idDeclarant ORDER BY a.dateAffectation DESC LIMIT 1) = "
                    + "(SELECT a.idRegion FROM AFFECTER a WHERE a.idPersonnel = @idTechnicien ORDER BY a.dateAffectation DESC LIMIT 1) ";
            }
            requete = requete + "ORDER BY i.dateDeclaration DESC";

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@idTechnicien", t.IdPersonnel);

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

        public static List<Intervention> GetInterventions(Incident i)
        {
            List<Intervention> liste = new List<Intervention>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "SELECT v.idIntervention, v.dateIntervention, v.heureDebut, v.heureFin, v.travailRealise, "
                    + "p.idPersonnel, p.nom, p.prenom "
                    + "FROM INTERVENTION v JOIN PERSONNEL p ON p.idPersonnel = v.idTechnicien "
                    + "WHERE v.idIncident = @id ORDER BY v.dateIntervention, v.heureDebut";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@id", i.IdIncident);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Technicien t = new Technicien();
                        t.IdPersonnel = Convert.ToInt32(reader["idPersonnel"]);
                        t.Nom = reader["nom"].ToString();
                        t.Prenom = reader["prenom"].ToString();

                        Intervention v = new Intervention(Convert.ToInt32(reader["idIntervention"]), Convert.ToDateTime(reader["dateIntervention"]),
                            (TimeSpan)reader["heureDebut"], (TimeSpan)reader["heureFin"], reader["travailRealise"].ToString(), i, t);
                        liste.Add(v);
                    }
                }
            }

            return liste;
        }

        public static Statistiques GetStatistiques()
        {
            int nbDeclares = 0;
            int nbEnCharge = 0;
            int nbResolus = 0;
            double delaiMoyenJours = 0;

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT etat, COUNT(*) AS nb FROM INCIDENT GROUP BY etat", cnx);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string etat = reader["etat"].ToString();
                        int nb = Convert.ToInt32(reader["nb"]);

                        if (etat == "Enregistrée")
                        {
                            nbDeclares = nb;
                        }
                        else if (etat == "En cours de traitement")
                        {
                            nbEnCharge = nb;
                        }
                        else
                        {
                            nbResolus = nbResolus + nb;
                        }
                    }
                }

                MySqlCommand cmdDelai = new MySqlCommand("SELECT AVG(DATEDIFF(dateResolution, dateDeclaration)) FROM INCIDENT WHERE dateResolution IS NOT NULL", cnx);
                object resultat = cmdDelai.ExecuteScalar();
                if (resultat != DBNull.Value)
                {
                    delaiMoyenJours = Convert.ToDouble(resultat);
                }
            }

            return new Statistiques(nbDeclares, nbEnCharge, nbResolus, delaiMoyenJours);
        }

        public static List<StatTechnicien> GetStatsTechniciens()
        {
            List<StatTechnicien> liste = new List<StatTechnicien>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "SELECT p.idPersonnel, p.matricule, p.nom, p.prenom, p.adresse, p.dateEmbauche, p.login, p.role, "
                    + "t.niveauIntervention, t.formation, t.competences, "
                    + "(SELECT COUNT(*) FROM INCIDENT i WHERE i.idTechnicien = p.idPersonnel AND i.etat = 'En cours de traitement') AS nbEnCharge, "
                    + "(SELECT COUNT(*) FROM INCIDENT i WHERE i.idTechnicien = p.idPersonnel AND i.etat IN ('Résolue', 'Clôturée')) AS nbResolus, "
                    + "(SELECT IFNULL(SUM(TIME_TO_SEC(TIMEDIFF(v.heureFin, v.heureDebut))), 0) / 3600 FROM INTERVENTION v WHERE v.idTechnicien = p.idPersonnel) AS nbHeures "
                    + "FROM PERSONNEL p JOIN TECHNICIEN t ON t.idPersonnel = p.idPersonnel "
                    + "ORDER BY p.nom, p.prenom";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Technicien t = LireTechnicien(reader);
                        StatTechnicien stat = new StatTechnicien(t, Convert.ToInt32(reader["nbEnCharge"]),
                            Convert.ToInt32(reader["nbResolus"]), Convert.ToDouble(reader["nbHeures"]));
                        liste.Add(stat);
                    }
                }
            }

            return liste;
        }

        public static Dictionary<string, int> GetNbIncidentsParUtilisateur()
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();

            using (MySqlConnection cnx = new MySqlConnection(ChaineConnexion))
            {
                cnx.Open();
                string requete = "SELECT p.matricule, p.nom, p.prenom, COUNT(i.idIncident) AS nb "
                    + "FROM PERSONNEL p LEFT JOIN INCIDENT i ON i.idDeclarant = p.idPersonnel "
                    + "WHERE p.role = 'utilisateur' "
                    + "GROUP BY p.idPersonnel, p.matricule, p.nom, p.prenom "
                    + "ORDER BY nb DESC, p.nom";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nom = reader["nom"].ToString() + " " + reader["prenom"].ToString() + " (" + reader["matricule"].ToString() + ")";
                        stats.Add(nom, Convert.ToInt32(reader["nb"]));
                    }
                }
            }

            return stats;
        }

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

        private static Personnel LirePersonnel(MySqlDataReader reader)
        {
            Personnel p = new Personnel();
            RemplirPersonnel(p, reader);
            return p;
        }

        private static Technicien LireTechnicien(MySqlDataReader reader)
        {
            Technicien t = new Technicien();
            RemplirPersonnel(t, reader);
            if (reader["niveauIntervention"] != DBNull.Value)
            {
                t.NiveauIntervention = Convert.ToInt32(reader["niveauIntervention"]);
            }
            t.Formation = reader["formation"].ToString();
            t.Competences = reader["competences"].ToString();
            return t;
        }

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

            if (reader["idPersonnel"] != DBNull.Value)
            {
                Personnel p = new Personnel();
                p.IdPersonnel = Convert.ToInt32(reader["idPersonnel"]);
                p.Matricule = reader["matricule"].ToString();
                p.Nom = reader["nom"].ToString();
                p.Prenom = reader["prenom"].ToString();
                m.Personnel = p;
            }

            if (reader["idFournisseur"] != DBNull.Value)
            {
                m.Fournisseur = new Fournisseur(Convert.ToInt32(reader["idFournisseur"]), reader["nomFournisseur"].ToString(),
                    reader["adresse"].ToString(), reader["telephone"].ToString(), reader["typeFournisseur"].ToString());
            }

            return m;
        }

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

            Personnel declarant = new Personnel();
            declarant.IdPersonnel = Convert.ToInt32(reader["idDeclarant"]);
            declarant.Matricule = reader["matriculeDeclarant"].ToString();
            declarant.Nom = reader["nomDeclarant"].ToString();
            declarant.Prenom = reader["prenomDeclarant"].ToString();
            i.Declarant = declarant;

            if (reader["idTechnicien"] != DBNull.Value)
            {
                Technicien t = new Technicien();
                t.IdPersonnel = Convert.ToInt32(reader["idTechnicien"]);
                t.Nom = reader["nomTechnicien"].ToString();
                t.Prenom = reader["prenomTechnicien"].ToString();
                t.NiveauIntervention = Convert.ToInt32(reader["niveauIntervention"]);
                i.Technicien = t;
            }

            Materiel m = new Materiel();
            m.IdMateriel = Convert.ToInt32(reader["idMateriel"]);
            m.TypeMateriel = reader["typeMateriel"].ToString();
            m.Composants = reader["composants"].ToString();
            m.ModeAcquisition = reader["modeAcquisition"].ToString();
            if (reader["idFournisseur"] != DBNull.Value)
            {
                Fournisseur f = new Fournisseur();
                f.IdFournisseur = Convert.ToInt32(reader["idFournisseur"]);
                f.NomFournisseur = reader["nomFournisseur"].ToString();
                f.Telephone = reader["telephone"].ToString();
                m.Fournisseur = f;
            }
            i.Materiel = m;

            return i;
        }

        private static DateTime? LireDate(MySqlDataReader reader, string colonne)
        {
            if (reader[colonne] == DBNull.Value)
            {
                return null;
            }
            return Convert.ToDateTime(reader[colonne]);
        }

        private static object ValeurOuNull(object valeur)
        {
            if (valeur == null)
            {
                return DBNull.Value;
            }
            return valeur;
        }
    }
}
