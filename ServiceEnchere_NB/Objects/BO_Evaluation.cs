using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    public class BO_Evaluation
    {
        public int IdEnchere { get; set; }

        public int IdUtilisateur { get; set; }

        public bool EvaluationGlobale { get; set; }

        public string Message { get; set; }

        public string FonctionnementProduit { get; set; }
    }
}