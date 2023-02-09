using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace SOA.ConsoleHost
{
    /*Implémenter IExtensibleDataObject lorsque vous constatez qu'il y a un changement fréquent
       de versions de DataContract en ajoutant des propriété supplementaires ce qui rend certains
       ancients clients incompatibles avec les nouvelles versions de contrats de données
     */

    [DataContract]
    public class Employee :IExtensibleDataObject
    {
        [DataMember(Name ="Identifier", IsRequired =true,Order =1)]
        public int Id { get; set; }

        [DataMember(Name = "Name", IsRequired = true, Order = 2)]
        public string Nom { get; set; }

        [DataMember(Name = "HireDate", IsRequired = true, Order = 3)]
        public DateTime  DateRecrutement { get; set; }
        [DataMember(Name = "Salary", IsRequired = true, Order = 4)]
        public decimal Salaire { get; set; }

        [DataMember(Name="SeakDays",IsRequired =false, Order = 5)]
        public int SeakDaysNumber { get; set; }
        public ExtensionDataObject ExtensionData { get ; set ; }

        public override string ToString()
        {
            string content = $"Id: {Id}Nom: {Nom} Date Recrutement: {DateRecrutement} Salaire:{Salaire}";
            Debug.WriteLine(content);
            return content; 
        }

    }
}