using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

using venolocation.classee;

namespace venolocation.formee
{
    public partial class retour : Form
    {
        public retour()
        {
            InitializeComponent();
        }
        string connectionString = dashboard.connection_string;
        private int contratId = -1;
        private int voitureId = -1;
        private int kilometrageSortie = 0;
        private void retour_Load(object sender, EventArgs e)
        {
            ChargerVoituresEnLocation();

            txtInfoContrat.ReadOnly = true;
            txtInfoContrat.Clear();

            txtDescriptionAccident.Clear();
            txtMontantReparation.Clear();
            txtKilometrageRetour.Clear();

            btnRetourSimple.Enabled = false;
            btnAccident.Enabled = false;
        }
        private void ChargerVoituresEnLocation()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    string query = @"
                        SELECT DISTINCT v.voiture_id,
                               CONCAT(v.matricule, ' - ', v.marque, ' ', v.modele) AS voiture
                        FROM contrats c
                        INNER JOIN voitures v ON v.voiture_id = c.voiture_id
                        WHERE c.status <> 'Terminé'
                        ORDER BY v.matricule;";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cbVoiture.DataSource = dt;
                        cbVoiture.DisplayMember = "voiture";
                        cbVoiture.ValueMember = "voiture_id";
                        cbVoiture.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement voitures : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cbVoiture.SelectedIndex == -1)
            {
                MessageBox.Show("Sélectionnez une voiture.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            voitureId = Convert.ToInt32(cbVoiture.SelectedValue);
            ChargerContratEnCours(voitureId);
        }

        private void btnRetourSimple_Click(object sender, EventArgs e)
        {
            if (!ValiderKilometrage(out int kmRetour))
                return;

            DialogResult rep = MessageBox.Show(
                "Confirmer le retour simple de cette voiture ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rep != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    using (MySqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            string updateContrat = @"
                                UPDATE contrats
                                SET kilometrage_retour = @kilometrage_retour
                                WHERE contrat_id = @contrat_id;";

                            using (MySqlCommand cmd = new MySqlCommand(updateContrat, cn, tr))
                            {
                                cmd.Parameters.AddWithValue("@kilometrage_retour", kmRetour);
                                cmd.Parameters.AddWithValue("@contrat_id", contratId);
                                cmd.ExecuteNonQuery();
                            }

                            tr.Commit();
                            LogHelper.AddLog("Retour voiture: " + cbVoiture.Text, login.nom);
                            MessageBox.Show("Retour simple enregistré avec succès.",
                                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ReinitialiserForm();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            MessageBox.Show("Erreur enregistrement retour : " + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur connexion : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReinitialiserForm()
        {
            contratId = -1;
            voitureId = -1;
            kilometrageSortie = 0;

            txtInfoContrat.Clear();
            txtKilometrageRetour.Clear();
            txtDescriptionAccident.Clear();
            txtMontantReparation.Clear();

            btnRetourSimple.Enabled = false;
            btnAccident.Enabled = false;

            ChargerVoituresEnLocation();
            cbVoiture.SelectedIndex = -1;
        }

        private void btnAccident_Click(object sender, EventArgs e)
        {
            if (!ValiderKilometrage(out int kmRetour))
                return;

            string descriptionAccident = txtDescriptionAccident.Text.Trim();

            if (string.IsNullOrWhiteSpace(descriptionAccident))
            {
                MessageBox.Show("Saisissez la description de l'accident.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescriptionAccident.Focus();
                return;
            }

            decimal montantReparation = 0;

            if (!string.IsNullOrWhiteSpace(txtMontantReparation.Text))
            {
                if (!decimal.TryParse(txtMontantReparation.Text.Trim(), out montantReparation) || montantReparation < 0)
                {
                    MessageBox.Show("Montant réparation invalide.",
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMontantReparation.Focus();
                    return;
                }
            }

            DialogResult rep = MessageBox.Show(
                "Confirmer le retour avec accident ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rep != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    using (MySqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            string updateContrat = @"
                                UPDATE contrats
                                SET kilometrage_retour = @kilometrage_retour
                                WHERE contrat_id = @contrat_id;";

                            using (MySqlCommand cmd1 = new MySqlCommand(updateContrat, cn, tr))
                            {
                                cmd1.Parameters.AddWithValue("@kilometrage_retour", kmRetour);
                                cmd1.Parameters.AddWithValue("@contrat_id", contratId);
                                cmd1.ExecuteNonQuery();
                            }

                            string insertAccident = @"
                                INSERT INTO accidents
                                (contrat_id, date_accident, description, montant_reparation, nom_utilisateur)
                                VALUES
                                (@contrat_id, @date_accident, @description, @montant_reparation, @nom_utilisateur);";

                            using (MySqlCommand cmd2 = new MySqlCommand(insertAccident, cn, tr))
                            {
                                cmd2.Parameters.AddWithValue("@contrat_id", contratId);
                                cmd2.Parameters.AddWithValue("@date_accident", DateTime.Now.Date);
                                cmd2.Parameters.AddWithValue("@description", descriptionAccident);
                                cmd2.Parameters.AddWithValue("@montant_reparation", montantReparation);
                                cmd2.Parameters.AddWithValue("@nom_utilisateur", login.nom);
                                cmd2.ExecuteNonQuery();
                            }

                            tr.Commit();
                            LogHelper.AddLog("Retour avec accident voiture: " + cbVoiture.Text, login.nom);
                            MessageBox.Show("Retour avec accident enregistré avec succès.",
                                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ReinitialiserForm();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            MessageBox.Show("Erreur retour avec accident : " + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch { }
            
        }

        private void ChargerContratEnCours(int selectedVoitureId)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    string query = @"
                        SELECT 
                            c.contrat_id,
                            c.voiture_id,
                            c.client_id,
                            c.date_contrat,
                            c.heure_debut,
                            c.date_retour_prevu,
                            c.heure_retour_prevu,
                            c.kilometrage_sortie,
                            c.kilometrage_retour,
                            c.prix_jour,
                            c.prix_heure,
                            c.avance,
                            c.total,
                            c.status,
                            cl.nom,
                            cl.prenom,
                            v.matricule,
                            v.marque,
                            v.modele
                        FROM contrats c
                        INNER JOIN clients cl ON cl.client_id = c.client_id
                        INNER JOIN voitures v ON v.voiture_id = c.voiture_id
                        WHERE c.voiture_id = @voiture_id
                          AND c.status <> 'Terminé'
                        ORDER BY c.contrat_id DESC
                        LIMIT 1;";

                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@voiture_id", selectedVoitureId);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                contratId = Convert.ToInt32(dr["contrat_id"]);
                                voitureId = Convert.ToInt32(dr["voiture_id"]);
                                kilometrageSortie = dr["kilometrage_sortie"] == DBNull.Value
                                    ? 0
                                    : Convert.ToInt32(dr["kilometrage_sortie"]);

                                StringBuilder sb = new StringBuilder();
                                sb.AppendLine("N° Contrat : " + dr["contrat_id"].ToString());
                                sb.AppendLine("Client : " + dr["nom"].ToString() + " " + dr["prenom"].ToString());
                                sb.AppendLine("Voiture : " + dr["matricule"].ToString() + " - " + dr["marque"].ToString() + " " + dr["modele"].ToString());
                                sb.AppendLine("Date contrat : " + Convert.ToDateTime(dr["date_contrat"]).ToString("dd/MM/yyyy"));
                                sb.AppendLine("Heure début : " + dr["heure_debut"].ToString());
                                sb.AppendLine("Date retour prévu : " + Convert.ToDateTime(dr["date_retour_prevu"]).ToString("dd/MM/yyyy"));
                                sb.AppendLine("Heure retour prévu : " + dr["heure_retour_prevu"].ToString());
                                sb.AppendLine("Kilométrage sortie : " + kilometrageSortie);
                                sb.AppendLine("Prix/Jour : " + dr["prix_jour"].ToString() + " DH");
                                sb.AppendLine("Prix/Heure : " + dr["prix_heure"].ToString() + " DH");
                                sb.AppendLine("Avance : " + dr["avance"].ToString() + " DH");
                                sb.AppendLine("Total : " + dr["total"].ToString() + " DH");
                                sb.AppendLine("Status : " + dr["status"].ToString());

                                txtInfoContrat.Text = sb.ToString();

                                btnRetourSimple.Enabled = true;
                                btnAccident.Enabled = true;
                            }
                            else
                            {
                                contratId = -1;
                                kilometrageSortie = 0;
                                txtInfoContrat.Clear();
                                btnRetourSimple.Enabled = false;
                                btnAccident.Enabled = false;

                                MessageBox.Show("Aucun contrat en cours pour cette voiture.",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement contrat : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValiderKilometrage(out int kmRetour)
        {
            kmRetour = 0;

            if (contratId <= 0)
            {
                MessageBox.Show("Chargez d'abord le contrat de la voiture.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtKilometrageRetour.Text.Trim(), out kmRetour))
            {
                MessageBox.Show("Kilométrage retourné invalide.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKilometrageRetour.Focus();
                return false;
            }

            if (kmRetour < kilometrageSortie)
            {
                MessageBox.Show("Le kilométrage retourné ne peut pas être inférieur au kilométrage de sortie.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKilometrageRetour.Focus();
                return false;
            }

            return true;
        }

        private void txtKilometrageRetour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtMontantReparation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
               !char.IsDigit(e.KeyChar) &&
               e.KeyChar != ',' &&
               e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (txtMontantReparation.Text.Contains(",") || txtMontantReparation.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }
    }
}
