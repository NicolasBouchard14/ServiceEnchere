using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    public class DemandeCreationEnchere
    {
        public string NomEnchere { get; set; }

        public decimal PrixMinimum { get; set; }

        public string OptionTransport { get; set; }

        public int Duree { get; set; }

        public string TypeEnchere { get; set; }

        public string Categorie { get; set; }

        public string MotsCles { get; set; }

        public string AutresInformations { get; set; }
    }
}