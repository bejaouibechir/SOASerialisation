//#define soap
//#define restxml
//#define serializesoap
//#define deserializesoap
//#define serializexml
//#define deserializexml
#define restjson
//#define serializejson
#define deserializejson

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;


namespace SOA.Serialisation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Game de service asmx,WCF utilisent echangent les données exclusivement avec SOAP
            //WCF utilisent echangent les données principalement avec SOAP
#if soap
#if serialize
          Personne moi = new Personne();
          SoapSerailisation soapSerailisation = new SoapSerailisation();
          soapSerailisation.Serialize(moi, "C:\\temp\\moi.soap");
#endif
#if deserialize
            SoapSerailisation soapSerailisation = new SoapSerailisation();
            Personne moi = soapSerailisation.Deserialize("C:\\temp\\moi.soap");
#endif
#endif

#if restxml
#if serializexml
          Personne moi = new Personne();
            XmlSerialisation xmlSerailisation = new XmlSerialisation();
            xmlSerailisation.Serialize(moi, "C:\\temp\\moi.xml");
#endif
#if deserializexml
            XmlSerialisation soapSerailisation = new XmlSerialisation();
            Personne moi = soapSerailisation.Deserialize("C:\\temp\\moi.xml");
#endif
#endif

#if restjson
#if serializejson
          Personne moi = new Personne();
            JsonSerialisation jsonSerailisation = new JsonSerialisation();
            jsonSerailisation.Serialize(moi, "C:\\temp\\moi.json");
#endif
#if deserializejson
            JsonSerialisation jsonSerailisation = new JsonSerialisation();
            Personne moi = jsonSerailisation.Deserialize("C:\\temp\\moi.json");
#endif
#endif

        }
    }
}

