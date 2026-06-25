using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace venolocation.classee
{
    internal class DatabaseTools
    {

     
            private static MySqlConnectionStringBuilder GetBuilder()
            {
                return new MySqlConnectionStringBuilder(DbConfig.GetConnectionString());
            }

        public static void ArchiverContrats(int annee)
        {
            string insertArchive = @"
                    INSERT INTO contrats_archive
                    (
                        contrat_id, client_id, voiture_id, reservation_id,
                        date_contrat, heure_debut, date_retour_prevu, heure_retour_prevu,
                        kilometrage_sortie, kilometrage_retour, prix_jour, prix_heure,
                        avance, total, status, nom_utilisateur, created_at, annee_archive
                    )
                    SELECT
                        contrat_id, client_id, voiture_id, reservation_id,
                        date_contrat, heure_debut, date_retour_prevu, heure_retour_prevu,
                        kilometrage_sortie, kilometrage_retour, prix_jour, prix_heure,
                        avance, total, status, nom_utilisateur, created_at, @annee
                    FROM contrats c
                    WHERE YEAR(c.date_contrat) = @annee
                      AND c.status <> @status_en_cours
                      AND NOT EXISTS (
                          SELECT 1
                          FROM contrats_archive a
                          WHERE a.contrat_id = c.contrat_id
                      );";

            

            string delete = @"
                            DELETE FROM contrats
                            WHERE YEAR(date_contrat) = @annee
                              AND status <> @status_en_cours;";

            ExecuterArchiveContrats(insertArchive, delete, annee);
        }
        private static void ExecuterArchiveContrats(string insertArchive, string delete, int annee)
        {
            using (MySqlConnection cn = Dbexec.GetConnection())
            {
                cn.Open();

                using (MySqlTransaction tr = cn.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand cmdArchive = new MySqlCommand(insertArchive, cn, tr))
                        {
                            cmdArchive.Parameters.AddWithValue("@annee", annee);
                            cmdArchive.Parameters.AddWithValue("@status_en_cours", AppStatus.ContratEnCours);
                            cmdArchive.ExecuteNonQuery();
                        }

                       

                        using (MySqlCommand cmdDelete = new MySqlCommand(delete, cn, tr))
                        {
                            cmdDelete.Parameters.AddWithValue("@annee", annee);
                            cmdDelete.Parameters.AddWithValue("@status_en_cours", AppStatus.ContratEnCours);
                            cmdDelete.ExecuteNonQuery();
                        }

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }
            }
        }

        private static string GetMysqlToolPath(string toolName)
        {
            string[] possiblePaths =
            {
                @"C:\xampp\mysql\bin\" + toolName,
                @"C:\wamp64\bin\mysql\mysql8.0.31\bin\" + toolName,
                @"C:\Program Files\MySQL\MySQL Server 8.0\bin\" + toolName,
                toolName
            };

            foreach (string path in possiblePaths)
            {
                if (File.Exists(path))
                    return path;
            }

            return toolName;
        }

        public static void ArchiverReservations(int annee)
            {
                string insert = @"
                            INSERT INTO reservations_archive
                            (
                                reservation_id, client_id, voiture_id, date_debut, heure_debut,
                                date_fin, heure_fin, prix_total, status, nom_utilisateur,
                                created_at, annee_archive
                            )
                            SELECT
                                reservation_id, client_id, voiture_id, date_debut, heure_debut,
                                date_fin, heure_fin, prix_total, status, nom_utilisateur,
                                created_at, @annee
                            FROM reservations r
                            WHERE YEAR(r.date_debut) = @annee
                              AND NOT EXISTS (
                                  SELECT 1 FROM reservations_archive a
                                  WHERE a.reservation_id = r.reservation_id
                              );";

                string delete = "DELETE FROM reservations WHERE YEAR(date_debut) = @annee;";

                ExecuterArchive(insert, delete, annee);
            }
        //public static void RestaurerTousContratsDepuisOld()
        //{
        //    string insert = @"
        //                INSERT INTO contrats
        //                (
        //                    contrat_id, client_id, voiture_id, reservation_id,
        //                    date_contrat, heure_debut, date_retour_prevu, heure_retour_prevu,
        //                    kilometrage_sortie, kilometrage_retour, prix_jour, prix_heure,
        //                    avance, total, status, nom_utilisateur, created_at
        //                )
        //                SELECT
        //                    o.contrat_id, o.client_id, o.voiture_id, o.reservation_id,
        //                    o.date_contrat, o.heure_debut, o.date_retour_prevu, o.heure_retour_prevu,
        //                    o.kilometrage_sortie, o.kilometrage_retour, o.prix_jour, o.prix_heure,
        //                    o.avance, o.total, o.status, o.nom_utilisateur, o.created_at
        //                FROM old_contrats o
        //                WHERE NOT EXISTS (
        //                    SELECT 1
        //                    FROM contrats c
        //                    WHERE c.contrat_id = o.contrat_id
        //                );";

        //    string deleteOld = @" DELETE FROM old_contrats;";

        //    using (MySqlConnection cn = Dbexec.GetConnection())
        //    {
        //        cn.Open();

        //        using (MySqlTransaction tr = cn.BeginTransaction())
        //        {
        //            try
        //            {
        //                using (MySqlCommand cmdInsert = new MySqlCommand(insert, cn, tr))
        //                {
        //                    cmdInsert.ExecuteNonQuery();
        //                }

        //                using (MySqlCommand cmdDelete = new MySqlCommand(deleteOld, cn, tr))
        //                {
        //                    cmdDelete.ExecuteNonQuery();
        //                }

        //                tr.Commit();
        //            }
        //            catch
        //            {
        //                tr.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}

        public static void ArchiverDepenses(int annee)
            {
                string insert = @"
                            INSERT INTO depenses_archive
                            (
                                depense_id, voiture_id, description, montant, type, date_depense,
                                echeance_id, reparation_id, nom_utilisateur, created_at, annee_archive
                            )
                            SELECT
                                depense_id, voiture_id, description, montant, type, date_depense,
                                echeance_id, reparation_id, nom_utilisateur, created_at, @annee
                            FROM depenses d
                            WHERE YEAR(d.date_depense) = @annee
                              AND NOT EXISTS (
                                  SELECT 1 FROM depenses_archive a
                                  WHERE a.depense_id = d.depense_id
                              );";

                string delete = "DELETE FROM depenses WHERE YEAR(date_depense) = @annee;";

                ExecuterArchive(insert, delete, annee);
            }

            public static void ArchiverRecettes_Type(int annee)
            {
                string insert = @"
                            INSERT INTO recettes_archive
                            (
                                recette_id, contrat_id, montant, type, date_recette,
                                nom_utilisateur, created_at, annee_archive
                            )
                            SELECT
                                recette_id, contrat_id, montant, type, date_recette,
                                nom_utilisateur, created_at, @annee
                            FROM recettes r
                            WHERE YEAR(r.date_recette) = @annee
                              AND NOT EXISTS (
                                  SELECT 1 FROM recettes_archive a
                                  WHERE a.recette_id = r.recette_id
                              );";

                string delete = "DELETE FROM recettes WHERE YEAR(date_recette) = @annee;";

                ExecuterArchive(insert, delete, annee);
            }

            private static void ExecuterArchive(string insertQuery, string deleteQuery, int annee)
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    using (MySqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, cn, tr))
                            {
                            cmdInsert.Parameters.AddWithValue("@annee", annee);
                            //cmdInsert.Parameters.AddWithValue("@status_en_cours", AppStatus.ContratEnCours);
                            cmdInsert.ExecuteNonQuery();
                            }

                            using (MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, cn, tr))
                            {
                            cmdDelete.Parameters.AddWithValue("@annee", annee);
                            //cmdDelete.Parameters.AddWithValue("@status_en_cours", AppStatus.ContratEnCours);
                            cmdDelete.ExecuteNonQuery();
                            }

                            tr.Commit();
                        }
                        catch
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }
            }

            public static void ViderTableAvecReset(string tableName)
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    using (MySqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            using (MySqlCommand cmdDelete = new MySqlCommand("DELETE FROM `" + tableName + "`;", cn, tr))
                            {
                                cmdDelete.ExecuteNonQuery();
                            }

                            using (MySqlCommand cmdReset = new MySqlCommand("ALTER TABLE `" + tableName + "` AUTO_INCREMENT = 1;", cn, tr))
                            {
                                cmdReset.ExecuteNonQuery();
                            }

                            tr.Commit();
                        }
                        catch
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }
            }

            public static void ViderLogs()
            {
                Dbexec.ExecuteQuery("DELETE FROM logs;");
                LogHelper.AddLog("Vidage complet des logs.", Session.Username);
            }

            public static string CopierLogsTxt(string dossier)
            {
                DataTable dt = Dbexec.GetData(@"
                        SELECT 
                            id,
                            utilisateur,
                            message,
                            DATE_FORMAT(date, '%d/%m/%Y %H:%i:%s') AS date_log
                        FROM logs
                        ORDER BY id ASC;");

                string file = Path.Combine(dossier, "logs_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt");

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ID | UTILISATEUR | MESSAGE | DATE");
                sb.AppendLine("-----------------------------------------------");

                foreach (DataRow row in dt.Rows)
                {
                    sb.AppendLine(
                        row["id"] + " | " +
                        row["utilisateur"] + " | " +
                        row["message"] + " | " +
                        row["date_log"]
                    );
                }

                File.WriteAllText(file, sb.ToString(), Encoding.UTF8);
                return file;
            }

        public static string CopierErreurTxt(string dossier)
        {
            DataTable dt = Dbexec.GetData(@"
                        SELECT 
                            id,
                            message,
                            utilisateur,
                            form_name,
                            action_name,
                            DATE_FORMAT(created_at, '%d/%m/%Y %H:%i:%s') AS date_erreur
                        FROM erreur
                        ORDER BY id ASC;");

            string file = Path.Combine(dossier, "Erreur_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID |             MESSAGE         | UTILISATEUR | Forme name |  Action namee | DATE");
            sb.AppendLine("-----------------------------------------------");

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine(
                    row["id"] + " | " +
                    row["message"] + " | " +
                    row["utilisateur"] + " | " +
                    row["action_name"] + " | " +
                    row["date_erreur"]
                );
            }

            File.WriteAllText(file, sb.ToString(), Encoding.UTF8);
            return file;
        }

        public static string BackupDatabase(string dossier)
        {
            MySqlConnectionStringBuilder b = GetBuilder();

            string file = Path.Combine(
                dossier,
                "backup_db_location_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql"
            );

            string mysqldumpPath = GetMysqlToolPath("mysqldump.exe");

            string args =
                "--host=" + b.Server +
                " --user=" + b.UserID +
                " --password=" + b.Password +
                " --databases " + b.Database +
                " --routines --events --triggers " +
                " --result-file=\"" + file + "\"";

            RunProcess(mysqldumpPath, args);

            return file;
        }

        public static void ImportDatabase(string sqlFile)
        {
            MySqlConnectionStringBuilder b = GetBuilder();

            string mysqlPath = GetMysqlToolPath("mysql.exe");

            string command =
                "\"" + mysqlPath + "\"" +
                " --host=" + b.Server +
                " --user=" + b.UserID +
                " --password=" + b.Password +
                " " + b.Database +
                " < \"" + sqlFile + "\"";

            RunProcessWithCmd(command);
        }
        private static void RunProcess(string exe, string args)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = exe;
            psi.Arguments = args;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;

            using (Process p = Process.Start(psi))
            {
                p.WaitForExit();

                string error = p.StandardError.ReadToEnd();

                if (p.ExitCode != 0)
                    throw new Exception(error);
            }
        }

        private static void RunProcessWithCmd(string command)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                psi.Arguments = "/C " + command;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardError = true;
                psi.RedirectStandardOutput = true;

                using (Process p = Process.Start(psi))
                {
                    p.WaitForExit();

                    if (p.ExitCode != 0)
                        throw new Exception(p.StandardError.ReadToEnd());
                }
         }

        private static void ExecuterRestaurationArchive(string insert, string deleteArchive, int annee)
        {
            using (MySqlConnection cn = Dbexec.GetConnection())
            {
                cn.Open();

                using (MySqlTransaction tr = cn.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand cmdInsert = new MySqlCommand(insert, cn, tr))
                        {
                            cmdInsert.Parameters.AddWithValue("@annee", annee);
                            cmdInsert.ExecuteNonQuery();
                        }

                        using (MySqlCommand cmdDelete = new MySqlCommand(deleteArchive, cn, tr))
                        {
                            cmdDelete.Parameters.AddWithValue("@annee", annee);
                            cmdDelete.ExecuteNonQuery();
                        }

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }
            }
        }


        public static void RestaurerReservationsDepuisArchive(int annee)
        {
            string insert = @"
                INSERT INTO reservations
                (
                    reservation_id, client_id, voiture_id,
                    date_debut, heure_debut, date_fin, heure_fin,
                    prix_total, status, nom_utilisateur, created_at
                )
                SELECT
                    a.reservation_id, a.client_id, a.voiture_id,
                    a.date_debut, a.heure_debut, a.date_fin, a.heure_fin,
                    a.prix_total, a.status, a.nom_utilisateur, a.created_at
                FROM reservations_archive a
                WHERE a.annee_archive = @annee
                  AND NOT EXISTS (
                      SELECT 1
                      FROM reservations r
                      WHERE r.reservation_id = a.reservation_id
                  );";

            string deleteArchive = @"
                DELETE a
                FROM reservations_archive a
                INNER JOIN reservations r ON r.reservation_id = a.reservation_id
                WHERE a.annee_archive = @annee;";

            ExecuterRestaurationArchive(insert, deleteArchive, annee);
        }


        public static void RestaurerContratsDepuisArchive(int annee)
        {
            string insert = @"
        INSERT INTO contrats
        (
            contrat_id, client_id, voiture_id, reservation_id,
            date_contrat, heure_debut, date_retour_prevu, heure_retour_prevu,
            kilometrage_sortie, kilometrage_retour, prix_jour, prix_heure,
            avance, total, status, nom_utilisateur, created_at
        )
        SELECT
            a.contrat_id, a.client_id, a.voiture_id, a.reservation_id,
            a.date_contrat, a.heure_debut, a.date_retour_prevu, a.heure_retour_prevu,
            a.kilometrage_sortie, a.kilometrage_retour, a.prix_jour, a.prix_heure,
            a.avance, a.total, a.status, a.nom_utilisateur, a.created_at
        FROM contrats_archive a
        WHERE a.annee_archive = @annee
          AND NOT EXISTS (
              SELECT 1
              FROM contrats c
              WHERE c.contrat_id = a.contrat_id
          );";

            string deleteArchive = @"
        DELETE a
        FROM contrats_archive a
        INNER JOIN contrats c ON c.contrat_id = a.contrat_id
        WHERE a.annee_archive = @annee;";

            ExecuterRestaurationArchive(insert, deleteArchive, annee);
        }

        public static void RestaurerDepensesDepuisArchive(int annee)
        {
            string insert = @"
        INSERT INTO depenses
        (
            depense_id, voiture_id, description, montant, type,
            date_depense, echeance_id, reparation_id,
            nom_utilisateur, created_at
        )
        SELECT
            a.depense_id, a.voiture_id, a.description, a.montant, a.type,
            a.date_depense, a.echeance_id, a.reparation_id,
            a.nom_utilisateur, a.created_at
        FROM depenses_archive a
        WHERE a.annee_archive = @annee
          AND NOT EXISTS (
              SELECT 1
              FROM depenses d
              WHERE d.depense_id = a.depense_id
          );";

            string deleteArchive = @"
        DELETE a
        FROM depenses_archive a
        INNER JOIN depenses d ON d.depense_id = a.depense_id
        WHERE a.annee_archive = @annee;";

            ExecuterRestaurationArchive(insert, deleteArchive, annee);
        }


        public static void RestaurerRecettesDepuisArchive(int annee)
        {
            string insert = @"
                INSERT INTO recettes
                (
                    recette_id, contrat_id, montant, type,
                    date_recette, nom_utilisateur, created_at
                )
                SELECT
                    a.recette_id, a.contrat_id, a.montant, a.type,
                    a.date_recette, a.nom_utilisateur, a.created_at
                FROM recettes_archive a
                WHERE a.annee_archive = @annee
                  AND NOT EXISTS (
                      SELECT 1
                      FROM recettes r
                      WHERE r.recette_id = a.recette_id
                  );";

                    string deleteArchive = @"
                DELETE a
                FROM recettes_archive a
                INNER JOIN recettes r ON r.recette_id = a.recette_id
                WHERE a.annee_archive = @annee;";

            ExecuterRestaurationArchive(insert, deleteArchive, annee);
        }

        public static void ResetDatabaseAndCreateAdmin()
        {
            string connectionString = Dbexec.GetConnection().ConnectionString;

            string file;
            
           // MessageBox.Show("Sauvegarde de la base de données créée ", "Sauvegarde créée", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string[] tables =
            {
                "accidents",
                "alerte",
                "clients",
                "client_comptes",
                "contrats",
                "contrats_archive",
                "depenses",
                "depenses_archive",
                "entretiens",
                "erreur",
                "logs",
                "recettes",
                "recettes_archive",
                "reparations",
                "reservations",
                "reservations_archive",
                "utilisateurs",
                "voitures",
                "voiture_echeances"
            };

            try
            {
                // Backuop de la base avant de tout supprimer
                using (FolderBrowserDialog f = new FolderBrowserDialog())
                {


                    f.Description = "Choisissez le dossier de sauvegarde";

                    if (f.ShowDialog() != DialogResult.OK)
                        return;

                    file = DatabaseTools.BackupDatabase(f.SelectedPath);

                    LogHelper.AddLog("Backup base de données : " + file, Session.Username);

                }


                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    using (MySqlCommand cmd = cn.CreateCommand())
                    {
                        try
                        {
                            cmd.CommandText = "SET FOREIGN_KEY_CHECKS = 0;";
                            cmd.ExecuteNonQuery();

                            foreach (string table in tables)
                            {
                                cmd.CommandText = $"TRUNCATE TABLE `{table}`;";
                                cmd.ExecuteNonQuery();
                            }
                        }
                        finally
                        {
                            cmd.CommandText = "SET FOREIGN_KEY_CHECKS = 1;";
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = @"
                                INSERT INTO utilisateurs 
                                (nom, login, mot_de_passe, role, created_at)
                                VALUES 
                                (@nom, @login, @mot_de_passe, @role, NOW());";

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@nom", "admin");
                        cmd.Parameters.AddWithValue("@login", "admin");
                        cmd.Parameters.AddWithValue("@mot_de_passe", "admin");
                        cmd.Parameters.AddWithValue("@role", "Admin");

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Database reset avec succès. Utilisateur admin/admin créé.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur reset database: " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );


                dbErreur.AddLog(
                    "Erreur reset database: " + ex.Message,
                    Session.Username,
                    "DatabaseTools",
                    "ResetDatabaseAndCreateAdmin"
                );
            }
        }

    }
}
