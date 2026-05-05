using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace venolocation.classee
{
    public class UpdateInfo
    {
        public string CurrentVersion { get; set; }
        public string LatestVersion { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool Obligatoire { get; set; }
        public bool IsNewVersion { get; set; }
    }
}
