using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    public class Encherissement
    {
        public int IdUtilisateur { get; set; }

        public int IdEnchere { get; set; }

        public decimal OffreMaximale { get; set; }
    }
}