namespace Manifest
{
    using System;

    class PersonType : IComparable<PersonType>
    {
        private string manifestNumber;
        private string firstName;
        private string lastName;
        private double paid;

        public PersonType(string manNum, string fname, string lname, double p)
        {
            if (string.IsNullOrWhiteSpace(manNum))
            {
                throw new Exception("Person manifest number cannot be empty.");
            }

            if (p < 0)
            {
                throw new Exception("Person paid amount cannot be less than 0.");
            }

            this.manifestNumber = manNum;
            if (!string.IsNullOrWhiteSpace(fname))
            {
                this.firstName = fname;
            }

            if (!string.IsNullOrWhiteSpace(lname))
            {
                this.lastName = lname;
            }

            this.paid = p;
        }

        public int CompareTo(PersonType otherPerson)
        {
            int result = this.manifestNumber.CompareTo(otherPerson.GetManifestNumber());
            return result;
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        public string GetManifestNumber()
        {
            return this.manifestNumber;
        }
    }
}
