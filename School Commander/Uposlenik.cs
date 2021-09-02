using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Commander
{
    public class Uposlenik
    {
        public int ID_uposlenika { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string radnoMjesto { get; set; }
        public string GetFullName()
        {
            return $"{this.ime} {this.prezime}";
        }
    }
}
