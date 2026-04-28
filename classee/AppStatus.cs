using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace venolocation.classee
{
    internal class AppStatus
    {

        // Reservations
        public const string ReservationEnAttente = "En attente";
        public const string ReservationConfirmee = "Confirmée";
        public const string ReservationAnnulee = "Annulée";
        public const string ReservationTerminee = "Terminée";

        // Contrats
        public const string ContratEnCours = "En cours";
        public const string ContratTermine = "Terminé";
        public const string ContratAnnule = "Annulé";

        // Voitures
        public const string VoitureDisponible = "Disponible";
        public const string VoitureEnLocation = "En location";
        public const string VoitureMaintenance = "Maintenance";

        // Reparations BIT status
        public const int ReparationMaintenance = 1;
        public const int ReparationTerminee = 0;

        // Textes affichage réparation
        public const string ReparationMaintenanceText = "Maintenance";
        public const string ReparationTermineeText = "Terminée";

        // Roles utilisateurs
        public const string RoleAdmin = "Admin";
        public const string RoleEmploye = "Employé";
        public const string RoleConsultation = "Consultation";
    }
}
