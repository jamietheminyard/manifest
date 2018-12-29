using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manifest
{
    class LoadType
    {
        private String dateAndLoad;
        private String aircraft;
        private int capacity;
        public LoadType(String ac, int cap, int l)
        {
            if (string.IsNullOrWhiteSpace(ac))
                throw new Exception("Load aircraft name cannot be empty.");
            if (cap < 1)
                throw new Exception("Load aircraft capacity cannot be less than 1.");
            if (l < 1)
                throw new Exception("Load number cannot be less than 1");
            String day = DateTime.Now.Day.ToString();
            String month = DateTime.Now.Month.ToString();
            String year = DateTime.Now.Year.ToString();
            this.dateAndLoad = day + month + year + "LOAD" + l.ToString();
            this.aircraft = ac;
            this.capacity = cap;
        }

        public String getDateAndLoad()
        {
            return this.dateAndLoad;
        }

        public String getAircraft()
        {
            return this.aircraft;
        }

        public int getCapacity()
        {
            return this.capacity;
        }
    }
}
