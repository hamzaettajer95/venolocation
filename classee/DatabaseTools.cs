using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MySql.Data.MySqlClient;

namespace venolocation.classee
{
    internal class DatabaseTools
    {

     
            private static MySqlConnectionStringBuilder GetBuilder()
            {
                return new MySqlConnectionStringBuilder(Properties.Settings.Default.conx);
            }

            public static void ArchiverContrats(int annee)
            {
                string insert = @"
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
                              AND NOT EXISTS (
                                  SELECT 1 FROM contrats_archive a
                                  WHERE a.contrat_id = c.contrat_id
                              );";

                string delete = "DELETE FROM contrats WHERE YEAR(date_contrat) = @annee;";

                ExecuterArchive(insert, delete, annee);
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
                                cmdInsert.ExecuteNonQuery();
                            }

                            using (MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, cn, tr))
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
    }
}
