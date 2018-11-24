using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    public class BO_EncherissementGagnant
    {
        public BO_Encherissement Encherissement { get; set; }

        public BO_Utilisateur Utilisateur_Vendeur { get; set; }

        public BO_Utilisateur Utilisateur_EncherisseurGagnant { get; set; }
    }
}