using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://BiztalkEnchereSchemas.DemandeCreationEnchere")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://EAI.DemandeCreationEnchere", IsNullable = false)]
    public class DemandeCreationEnchere
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NomEnchere { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal PrixMinimum { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OptionTransport { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Duree { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TypeEnchere { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Categorie { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MotsCles { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AutresInformations { get; set; }
    }
}