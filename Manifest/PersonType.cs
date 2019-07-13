using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manifest
{
    class PersonType : IComparable<PersonType>
    {
        private String manifestNumber;
        private String firstName;
        private String lastName;
        private double paid;

        public PersonType(String manNum, String fname, String lname, double p)
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

        public String getFirstName()
        {
            return this.firstName;
        }

        public String getLastName()
        {
            return this.lastName;
        }

        public String getManifestNumber()
        {
            return this.manifestNumber;
        }
    }
}
