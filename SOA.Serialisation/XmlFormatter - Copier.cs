using System;
using System.IO;
using System.Xml.Serialization;

namespace SOA.Serialisation
{
    public class XmlSerialisation
    {
        XmlSerializer _formatter;
        FileStream _fstream;

        public XmlSerialisation()
        {
            _formatter= new XmlSerializer(typeof(Personne));
        }

        public void Serialize(Personne p, string path)
        {
            using (_fstream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                _formatter.Serialize(_fstream, p);
                Console.WriteLine("L'objet personne est persisté");
            }
        }

        public Personne Deserialize(string path)
        {
            Personne personne;
            using (_fstream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
               personne = (Personne)_formatter.Deserialize(_fstream);
                Console.WriteLine("L'objet personne est recuprérée");
            }

            return personne;
        }

    }
}
