using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace venolocation.classee
{
    public static class L_Service
    {
        public static int DemoLimit = 10;

        public static data Init()
        {
            var data = L_Manager.Load();

            if (data == null)
            {
                data = new data
                {
                   
                    FirstRun = DateTime.Now,
                    Counter = 0
                };

                L_Manager.Save(data);
            }

            return data;
        }

        public static bool IsValid()
        {
            var data = L_Manager.Load();
            if (data == null) return false;

         

            // demo limit
            //MessageBox.Show(data.Counter.ToString());
            if (data.Counter >= DemoLimit)
                return false;

            return true;
        }

        public static void Use()
        {
            var data = L_Manager.Load();
            if (data == null) return;

            data.Counter++;
            L_Manager.Save(data);
        }

    }
}
