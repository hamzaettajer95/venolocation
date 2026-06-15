using System;

namespace venolocation.classee
{
    internal class FactureEtatVehiculeData
    {
        // =========================
        // SOCIETE
        // =========================
        public string NomSociete { get; set; }
        public string AdresseSociete { get; set; }
        public string TelephoneSociete { get; set; }
        public string EmailSociete { get; set; }

        // =========================
        // CONTRAT
        // =========================
        public string NumeroContrat { get; set; }
        public string NumeroFacture { get; set; }
        public string DateFacture { get; set; }
        public string Reference { get; set; }

        // =========================
        // CLIENT PRINCIPAL
        // =========================
        public string ClientNom { get; set; }
        public string ClientPrenom { get; set; }
        public string ClientTelephone { get; set; }
        public string ClientCin { get; set; }
        public string ClientAdresse { get; set; }
        public string ClientPermis { get; set; }
        public string ClientPermisDate { get; set; }
        public string ClientPassport { get; set; }
        public string ClientPassportDate { get; set; }

        // =========================
        // 2EME CONDUCTEUR
        // =========================
        public string Conducteur2Nom { get; set; }
        public string Conducteur2Prenom { get; set; }
        public string Conducteur2Telephone { get; set; }
        public string Conducteur2Cin { get; set; }
        public string Conducteur2Adresse { get; set; }
        public string Conducteur2Permis { get; set; }
        public string Conducteur2PermisDate { get; set; }
        public string Conducteur2Passport { get; set; }
        public string Conducteur2PassportDate { get; set; }

        // =========================
        // VOITURE
        // =========================
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string TypeVoiture { get; set; }
        public string Immatriculation { get; set; }
        public string Carburant { get; set; }
        public string KmDepart { get; set; }
        public string KmRetour { get; set; }

        // =========================
        // LOCATION
        // =========================
        public string DateDepart { get; set; }
        public string HeureDepart { get; set; }
        public string LieuDepart { get; set; }

        public string DateRetour { get; set; }
        public string HeureRetour { get; set; }
        public string LieuRetour { get; set; }

        public string NombreJours { get; set; }
        public string PrixJour { get; set; }

        // =========================
        // PAIEMENT
        // =========================
        public string Total { get; set; }
        public string Avance { get; set; }
        public string Reste { get; set; }
        public string ModePaiement { get; set; }

        // =========================
        // PROLONGATION
        // =========================
        public string ProlongationDu { get; set; }
        public string ProlongationAu { get; set; }
        public string ProlongationLieuDepart { get; set; }
        public string ProlongationLieuRetour { get; set; }
        public string ProlongationFrais { get; set; }

        // =========================
        // CHANGEMENT VEHICULE
        // =========================
        public string ChangementMarque { get; set; }
        public string ChangementMatricule { get; set; }
        public string ChangementDate { get; set; }
        public string ChangementHeure { get; set; }
        public string ChangementLieu { get; set; }
        public string ChangementKm { get; set; }

        // =========================
        // ETAT
        // =========================
        public string NiveauCarburant { get; set; }
        public string Observations { get; set; }

       
    }
}