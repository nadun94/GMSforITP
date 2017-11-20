using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMSystem.Buisness_Logic
{
    class workout
    {

        public int  id { get; set; }
        public string workout_name { get; set; }
        public string  type { get; set; }
        public double BMI_rate { get; set; }
        public double fat_level { get; set; }

        public int repeats { get; set; }
        public string interval_days { get; set; }
        public string exName { get; set; }

       public List <exercise> _exercise_w { get; set; }

    }
}
