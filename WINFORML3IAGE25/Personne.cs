using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WINFORML3IAGE25
{
    internal class Personne
    {
        public string prenom { get; set; }
        public string nom { get; set; }
        public string tel { get; set; }
        public string sexe { get; set; }
        public string competences { get; set; }
        public string classe { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public Personne()
        {
        }
    }
}
