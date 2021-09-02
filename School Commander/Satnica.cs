using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Commander
{
    class Satnica
    {
        public int ID_satnice { get; set; }

        public int ID_uposlenika { get; set; }

        public DateTime datumRada { get; set; }

        public string nacinRada { get; set; }

        public double radiOd { get; set; }

        public double radiDo { get; set; }

        public double ukupnoRadnoVrijeme { get; set; }

        public double nocniRad { get; set; }

        public double prekovremenoVrijeme { get; set; }

        public double radNedjeljom { get; set; }

        public double radZaPraznike { get; set; }

        public double godisnjiOdmor { get; set; }

        public double bolovanje { get; set; }

        public double dopustPN { get; set; }

        public double napomena { get; set; }

        public string posebnaNapomena { get; set; }

        public double UkupnoSati { get; set; }
    }
}
