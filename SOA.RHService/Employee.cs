using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace SOA.RHService
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public DateTime  DateRecrutement { get; set; }
        [DataMember]
        public decimal Salaire { get; set; }

        public override string ToString()
        {
            string content = $"Id: {Id}Nom: {Nom} Date Recrutement: {DateRecrutement} Salaire:{Salaire}";
            Debug.WriteLine(content);
            return content; 
        }

    }
}