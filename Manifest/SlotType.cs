using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manifest
{
    class SlotType
    {
        private String load;
        private String manifestNumber;
        private String jumpType;
        private double jumpPrice;
        private String instructor1;
        private String instuctor2OrVideo;
        private String tandemName;

        public SlotType(String l, String m, String jt, double jp, String i1, String i2, String t)
        {
            if (string.IsNullOrWhiteSpace(l))
                throw new Exception("Error - load cannot be blank.");
            if (string.IsNullOrWhiteSpace(m))
                throw new Exception("Manifest number cannot be blank.");
            if (string.IsNullOrWhiteSpace(jt))
                throw new Exception("Jump type cannot be blank.");

        }
    }
}
