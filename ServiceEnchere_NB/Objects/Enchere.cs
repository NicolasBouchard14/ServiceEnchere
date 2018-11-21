using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    [System.Xml.Serialization.XmlType(Namespace = "http://BiztalkEnchereSchemas.Enchere")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://BiztalkEnchere.Enchere", IsNullable = false)]
    public class Enchere : DemandeCreationEnchere
    {
        [System.Xml.Serialization.XmlElement()]
        public int IdEnchere { get; set; }
    }
}