using System;
using System.IO;
using System.Text.Json;

namespace SOA.Serialisation
{
    public class JsonSerialisation
    {
        public void Serialize(Personne p, string path)
        {
          string content = JsonSerializer.Serialize(p);
          File.WriteAllText(path, content);
          Console.WriteLine("L'objet personne est persistée");
        }

        public Personne Deserialize(string path)
        {
            Personne personne;
            string content = File.ReadAllText("C:\\temp\\moi.json");
            personne = JsonSerializer.Deserialize<Personne>(content);     
                Console.WriteLine("L'objet personne est recuprérée");  
            return personne;
        }

    }
}
