using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    public class BO_Utilisateur
    {
        public int IdUtilisateur { get; set; }

        public string NomUtilisateur { get; set; }

        public string Courriel { get; set; }
    }
}