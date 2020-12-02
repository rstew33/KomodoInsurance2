using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceRepository
{
    public class Developer //POCO
    {
        public string DevName { get; set; }
        public int DevID { get; set; }
        public bool PluralSight { get; set; }

        public Developer() { }
        public Developer(string devName, int devID, bool pluralSight)
        {
            DevName = devName;
            DevID = devID;
            PluralSight = pluralSight;

        }
    }
}
