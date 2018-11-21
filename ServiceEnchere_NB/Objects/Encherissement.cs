using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    [System.Xml.Serialization.XmlType(Namespace = "http://BiztalkEnchereSchemas.Encherissement")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://BiztalkEnchere.Encherissement", IsNullable = false)]
    public class Encherissement
    {
        [System.Xml.Serialization.XmlElement()]
        public int IdUtilisateur_Encherisseur { get; set; }

        [System.Xml.Serialization.XmlElement()]
        public int IdEnchere { get; set; }

        [System.Xml.Serialization.XmlElement()]
        public decimal OffreMaximale { get; set; }
    }
}