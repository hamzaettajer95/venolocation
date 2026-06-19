//using MySql.Data.MySqlClient;
using MySqlConnector;
using System;

namespace venolocation.classee
{
    internal static class PaymentService
    {
        public static void AjouterPaiementContrat(
            MySqlConnection cn,
            MySqlTransaction tr,
            int contratId,
            decimal montant,
            string typePaiement,
            string modePaiement,
            string reference,
            string nomUtilisateur)
        {
            if (montant <= 0)
                return;

            string insertPayment = @"
                INSERT INTO payment_history
                (contrat_id, montant, mode_paiement, type_paiement, reference, created_at)
                VALUES
                (@contrat_id, @montant, @mode_paiement, @type_paiement, @reference, NOW());";

            using (MySqlCommand cmd = new MySqlCommand(insertPayment, cn, tr))
            {
                cmd.Parameters.AddWithValue("@contrat_id", contratId);
                cmd.Parameters.AddWithValue("@montant", montant);
                cmd.Parameters.AddWithValue("@mode_paiement", modePaiement);
                cmd.Parameters.AddWithValue("@type_paiement", typePaiement);
                cmd.Parameters.AddWithValue("@reference", string.IsNullOrWhiteSpace(reference) ? DBNull.Value : (object)reference);
                cmd.ExecuteNonQuery();
            }

            string insertRecette = @"
                INSERT INTO recettes
                (contrat_id, montant, type, date_recette, nom_utilisateur)
                VALUES
                (@contrat_id, @montant, @type, NOW(), @nom_utilisateur);";

            using (MySqlCommand cmd = new MySqlCommand(insertRecette, cn, tr))
            {
                cmd.Parameters.AddWithValue("@contrat_id", contratId);
                cmd.Parameters.AddWithValue("@montant", montant);
                cmd.Parameters.AddWithValue("@type", typePaiement);
                cmd.Parameters.AddWithValue("@nom_utilisateur", nomUtilisateur);
                cmd.ExecuteNonQuery();
            }
        }
    }
}