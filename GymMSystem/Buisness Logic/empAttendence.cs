using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
    

namespace GymMSystem.Buisness_Logic
{
    class empAttendence
    {
       
        private double _hoursWorked;
        private double _extraHours;

            
        public string  theDay { get; set; }

        public Boolean _attendenceStatus{ get; set; }

        public string startTime { get; set; }

        public string endTime { get; set; }
        public int empID { get; set; }
        
        public double  hoursWorked
        {
            get
            {
                DateTime st = DateTime.ParseExact(" " + startTime, " h:mm tt", CultureInfo.InvariantCulture);
                DateTime et = DateTime.ParseExact(" " + endTime, " h:mm tt", CultureInfo.InvariantCulture);
                TimeSpan dif = et - st;
                // string y = dif.ToString(@"hh\:mm");
                _hoursWorked = Math.Round(dif.TotalHours, 2);

                return _hoursWorked;

                     
            }

            set
            {
                _hoursWorked = value;
            }
        }

        public double extraHours
        {
            get
            {
                if (_hoursWorked > 10)
                {
                    _extraHours = _hoursWorked - 10;
                   
                }
                else
                {
                    _extraHours = 0;
                }

                return _extraHours;
            }

            set
            {
                _extraHours = value;

            }
        }


       

       



    }
}
