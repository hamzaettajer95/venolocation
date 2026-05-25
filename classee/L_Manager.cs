using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace venolocation.classee
{
    public static class L_Manager
    {

        static string path =
         Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
         "sys.dat");

        public static void Save(data data)
        {
            string json = JsonSerializer.Serialize(data);
            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            File.WriteAllText(path, encoded);
        }

        public static data Load()
        {
            if (!File.Exists(path))
                return null;

            string encoded = File.ReadAllText(path);
            string json = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));

            return JsonSerializer.Deserialize<data>(json);
        }
    }
}
