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
        public DateTime startTIme_inOriginal { get; set; }
        public DateTime endTIme_inOriginal { get; set; }
        public string endTime { get; set; }
        public int empID { get; set; }
        
        public double hoursWorked
        {
            get
            {
                var st = DateTime.ParseExact(startTime, "HH:mm:ss", CultureInfo.InvariantCulture);
                var et = DateTime.ParseExact(endTime, "H:mm", null, System.Globalization.DateTimeStyles.None);
                //var st = dat.Parse(startTime);
                //var et = TimeSpan.Parse(endTime);

                TimeSpan dif = st - et;

                string gg = dif.ToString();
                TimeSpan duration = DateTime.ParseExact(endTime, "HH:mm:ss tt", CultureInfo.CurrentCulture).Subtract(DateTime.ParseExact(startTime, "HH:mm:ss tt", CultureInfo.CurrentCulture));



             //   double dif = (et - st).TotalHours;
                double x = dif.TotalHours;
                _hoursWorked = duration.TotalHours;

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
