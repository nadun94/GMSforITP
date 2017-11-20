using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMSystem.Buisness_Logic
{
   public  static class global
    {
        static Buisness_Logic.login slog;
        public  static Buisness_Logic.login sglobal
        {
            get
            {
                return slog;
            }
            set
            {
                slog = value;
            }
        }

        
            
        
    }
}
