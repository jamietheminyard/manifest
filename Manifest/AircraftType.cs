namespace Manifest
{
    using System;

    class AircraftType
    {
        private string name;
        private int capacity;

        public AircraftType(string n, int c)
        {
            if (string.IsNullOrWhiteSpace(n))
            {
                throw new Exception("Aircraft name cannot be blank or null.");
            }

            if (c < 1)
            {
                throw new Exception("Aircraft capacity cannot be less than 1.");
            }

            this.name = n;
            this.capacity = c;
        }

        public string GetName()
        {
            return name;
        }

        public int GetCapacity()
        {
            return capacity;
        }
    }
}
