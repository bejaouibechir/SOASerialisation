using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SOA.Serialisation
{
    public class BinarySerialisation
    {
        BinaryFormatter _formatter;
        FileStream _fstream;

        public BinarySerialisation()
        {
            _formatter = new BinaryFormatter();
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
