#define soaporbinary

using System;

namespace SOA.Serialisation
{
#if soaporbinary
    [Serializable]
#endif
    public  class Personne
    {
        public Personne() /*Pour éviter l'erreur de sérialisation XML
                           * il faut ajouter se constructeur sans paramètres*/
        {

        }
        
        public Personne(int id, string nom, int age) /*
                                                      * Cette classe ne peut pas être serialisée en XML 
                                                        si vous définisser uniquement des constrcuteurs 
                                                        avec paramètres
                                                      */
                                                        
        {
            Id = id;
            Nom = nom;
            Age = age;
        }

        public int Id { get; set; } = 1;
        public string Nom { get; set; } = "Bechir Bejaoui";
        public int Age { get; set; } = 44;
    }
}
