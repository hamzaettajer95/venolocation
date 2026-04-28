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

namespace venolocation.settin
{
    public partial class utilisateur : Form
    {
        public utilisateur()
        {
            InitializeComponent();
        }
        public utilisateur(int userId, string nom, string loginUser, string motDePasse, string role)
        {
            InitializeComponent();

            modeModification = true;
            userIdSelectionne = userId;

            txtNomUser.Text = nom;
            txtLoginUser.Text = loginUser;
            txtPasswordUser.Text = motDePasse;
            cbRoleUser.Text = role;
        }
        private bool modeModification = false;
        private int userIdSelectionne = -1;


        private bool ChampsValides()
        {
            if (string.IsNullOrWhiteSpace(txtNomUser.Text))
            {
                MessageService.Warning("Saisissez le nom.");
                txtNomUser.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLoginUser.Text))
            {
                MessageService.Warning("Saisissez le login.");
                txtLoginUser.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPasswordUser.Text))
            {
                MessageService.Warning("Saisissez le mot de passe.");
                txtPasswordUser.Focus();
                return false;
            }

            if (cbRoleUser.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cbRoleUser.Text))
            {
                MessageService.Warning("Sélectionnez le rôle.");
                cbRoleUser.Focus();
                return false;
            }

            return true;
        }
        private void utilisateur_Load(object sender, EventArgs e)
        {
            try
            {
                cbRoleUser.Items.Clear();
                cbRoleUser.Items.Add("Admin");
                cbRoleUser.Items.Add("Employé");

                if (modeModification)
                {
                    this.Text = "Modifier Utilisateur";
                    btnEnregistrerUser.Text = "Modifier";

                    txtNomUser.ReadOnly = true;
                    txtNomUser.FillColor = Color.FromArgb(245, 247, 250);
                }
                else
                {
                    this.Text = "Ajouter Utilisateur";
                    btnEnregistrerUser.Text = "Enregistrer";

                    txtNomUser.ReadOnly = false;
                    txtNomUser.FillColor = Color.White;
                    cbRoleUser.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "ajouter_utilisateur", "ajouter_utilisateur_Load");
                MessageService.Error("Erreur chargement formulaire utilisateur.");
            }
        }

        private void btnEnregistrerUser_Click(object sender, EventArgs e)
        {
            if (!ChampsValides())
                return;

            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    if (modeModification)
                    {
                        string queryCheck = @"
                                        SELECT COUNT(*) 
                                        FROM utilisateurs 
                                        WHERE login = @login AND user_id <> @user_id";

                        using (MySqlCommand cmdCheck = new MySqlCommand(queryCheck, cn))
                        {
                            cmdCheck.Parameters.AddWithValue("@login", txtLoginUser.Text.Trim());
                            cmdCheck.Parameters.AddWithValue("@user_id", userIdSelectionne);

                            int nb = Convert.ToInt32(cmdCheck.ExecuteScalar());

                            if (nb > 0)
                            {
                                MessageService.Warning("Ce login existe déjà.");
                                return;
                            }
                        }

                                    string queryUpdate = @"
                                    UPDATE utilisateurs
                                    SET login = @login,
                                        mot_de_passe = @mot_de_passe,
                                        role = @role
                                    WHERE user_id = @user_id";

                        using (MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, cn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@login", txtLoginUser.Text.Trim());
                            cmdUpdate.Parameters.AddWithValue("@mot_de_passe", txtPasswordUser.Text.Trim());
                            cmdUpdate.Parameters.AddWithValue("@role", cbRoleUser.Text);
                            cmdUpdate.Parameters.AddWithValue("@user_id", userIdSelectionne);

                            cmdUpdate.ExecuteNonQuery();
                        }

                        LogHelper.AddLog("Modification utilisateur : " + txtLoginUser.Text.Trim(), Session.Username);
                        MessageService.Success("Utilisateur modifié avec succès.");
                    }
                    else
                    {
                        string queryCheck = "SELECT COUNT(*) FROM utilisateurs WHERE login = @login";

                        using (MySqlCommand cmdCheck = new MySqlCommand(queryCheck, cn))
                        {
                            cmdCheck.Parameters.AddWithValue("@login", txtLoginUser.Text.Trim());

                            int nb = Convert.ToInt32(cmdCheck.ExecuteScalar());

                            if (nb > 0)
                            {
                                MessageService.Warning("Ce login existe déjà.");
                                return;
                            }
                        }

                                    string queryInsert = @"
                            INSERT INTO utilisateurs (nom, login, mot_de_passe, role, created_at)
                            VALUES (@nom, @login, @mot_de_passe, @role, NOW())";

                        using (MySqlCommand cmdInsert = new MySqlCommand(queryInsert, cn))
                        {
                            cmdInsert.Parameters.AddWithValue("@nom", txtNomUser.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@login", txtLoginUser.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@mot_de_passe", txtPasswordUser.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@role", cbRoleUser.Text);

                            cmdInsert.ExecuteNonQuery();
                        }

                        LogHelper.AddLog("Ajout utilisateur : " + txtLoginUser.Text.Trim(), Session.Username);
                        MessageService.Success("Utilisateur ajouté avec succès.");
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "ajouter_utilisateur", "btnEnregistrerUser_Click");
                MessageService.Error("Erreur lors de l'enregistrement de l'utilisateur.");
            }
        }
    }
}
