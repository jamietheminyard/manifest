namespace Manifest
{
    using System;

    internal class AircraftType
    {
        private string name;
        private int capacity;

        public AircraftType(string n, int c)
        {
            if (string.IsNullOrWhiteSpace(n))
            {
                throw new ArgumentException("Aircraft name cannot be blank or null.");
            }

            if (c < 1)
            {
                throw new ArgumentException("Aircraft capacity cannot be less than 1.");
            }

            this.name = n;
            this.capacity = c;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetCapacity()
        {
            return this.capacity;
        }
    }
}
