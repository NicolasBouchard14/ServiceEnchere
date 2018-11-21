using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Objects
{
    [System.Xml.Serialization.XmlType(Namespace = "http://BiztalkEnchereSchemas.DemandeCreationEnchere")]
    [System.Xml.Serialization.XmlRoot("DemandeCreationEnchere", IsNullable = false)]
    public class DemandeCreationEnchere
    {
        [System.Xml.Serialization.XmlElement()]
        public int IdUtilisateur_Vendeur { get; set; }

        [System.Xml.Serialization.XmlElement()]
        public string NomEnchere { get; set; }

        [System.Xml.Serialization.XmlElement()]
        public decimal PrixMinimum { get; set; }

        [System.Xml.Serialization.XmlElement()]
        public string OptionTransport { get; set; }

        [System.Xml.Serialization.XmlElement()]
        public int Duree { get; set; }

        [System.Xml.Serialization.XmlElement()]
        public string TypeEnchere { get; set; }

        [System.Xml.Serialization.XmlElement()]
        public string Categorie { get; set; }

        [System.Xml.Serialization.XmlElement()]
        public string MotsCles { get; set; }

        [System.Xml.Serialization.XmlElement()]
        public string AutresInformations { get; set; }
    }
}