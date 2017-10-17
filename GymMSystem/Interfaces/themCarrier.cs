using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace GymMSystem.Interfaces
{
    class themCarrier
    {
       public void theme()
        {
            Interfaces.Settings set = new Settings();
            Interfaces.Finance fin = new Finance();

            fin.metroStyleManager_fin.Theme = MetroFramework.MetroThemeStyle.Dark;
                //metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
        }
    }
}
