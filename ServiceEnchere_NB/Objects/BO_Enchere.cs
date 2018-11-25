using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    public class BO_Enchere
    {
        public BO_Enchere()
        {
            IdEnchere = 0;
        }

        public int IdEnchere { get; set; }

        public BO_DemandeCreationEnchere DemandeCreationEnchere { get; set; }
    }
}