using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMSystem.Buisness_Logic
{
    class member
    {
  
        private string Name;
        public int MemberID { get; set; }
        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public string dob { get; set; }

        public string  gender { get; set; }
        public string nic { get; set; }
        public string  addresss { get; set; }
      
        public string  phone { get; set; }
       

    }
}
