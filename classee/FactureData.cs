using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace venolocation.classee
{
    internal class FactureData
    {


        public string NumeroFacture { get; set; }
        public string DateFacture { get; set; }
        public string Reference { get; set; }

        public string NomSociete { get; set; }
        public string AdresseSociete { get; set; }
        public string TelephoneSociete { get; set; }
        public string EmailSociete { get; set; }

        public string LogoPath { get; set; }
        public string EtatVoitureImagePath { get; set; }

        public string ClientNom { get; set; }
        public string ClientTelephone { get; set; }
        public string ClientCin { get; set; }
        public string ClientAdresse { get; set; }
        public string ClientPermis { get; set; }

        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Immatriculation { get; set; }
        public string Carburant { get; set; }
        public string Couleur { get; set; }
        public string KilometrageDepart { get; set; }
        public string KilometrageRetour { get; set; }

        public string DateDepart { get; set; }
        public string HeureDepart { get; set; }
        public string DateRetour { get; set; }
        public string HeureRetour { get; set; }
        public string NombreJours { get; set; }
        public string PrixJour { get; set; }

        public string Total { get; set; }
        public string Avance { get; set; }
        public string Reste { get; set; }
        public string ModePaiement { get; set; }

        // خليه مثلا: "E", "1/4", "1/2", "3/4", "F"
        public string NiveauCarburant { get; set; }

        public string Observations { get; set; }
    }
    }


