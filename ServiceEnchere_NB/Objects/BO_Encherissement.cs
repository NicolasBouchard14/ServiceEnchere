using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    public class BO_Encherissement
    {
        public BO_Encherissement()
        {
            IdEnchere = 0;
        }

        public int IdUtilisateur_Encherisseur { get; set; }

        public int IdEnchere { get; set; }

        public decimal OffreMaximale { get; set; }
    }
}