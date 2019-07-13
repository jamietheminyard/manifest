using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manifest
{
    class PersonType : IComparable<PersonType>
    {
        private string manifestNumber;
        private string firstName;
        private string lastName;
        private double paid;

        public PersonType(string manNum, string fname, string lname, double p)
        {
            if (string.IsNullOrWhiteSpace(manNum))
                throw new Exception("Person manifest number cannot be empty.");
            if (p < 0)
                throw new Exception("Person paid amount cannot be less than 0.");
            this.manifestNumber = manNum;
            if (!string.IsNullOrWhiteSpace(fname))
                this.firstName = fname;
            if (!string.IsNullOrWhiteSpace(lname))
                this.lastName = lname;
            this.paid = p;
        }

        public int CompareTo(PersonType otherPerson)
        {
            int result = this.manifestNumber.CompareTo(otherPerson.getManifestNumber());
            return result;
        }

        public string getFirstName()
        {
            return this.firstName;
        }

        public string getLastName()
        {
            return this.lastName;
        }

        public string getManifestNumber()
        {
            return this.manifestNumber;
        }
    }
}
