using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manifest
{
    class AircraftType
    {
        private string name;
        private int capacity;

        public AircraftType(string n, int c)
        {
            if (string.IsNullOrWhiteSpace(n))
                throw new Exception("Aircraft name cannot be blank or null.");
            if (c < 1)
                throw new Exception("Aircraft capacity cannot be less than 1.");
            this.name = n;
            this.capacity = c;
        }

        public string getName()
        {
            return name;
        }

        public int getCapacity()
        {
            return capacity;
        }
    }
}
