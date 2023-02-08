using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SOA.ShapeService.Model
{
    [DataContract]
    public class Cercle :Forme
    {
        private double _perimetre;
        private double _surface;

        public readonly double PI;

        public Cercle()
        {
            PI = 3.14;
        }

        [DataMember]
        public double Rayon { get; set; }

        [DataMember]
        public override double Perimetre 
        
        { get => _perimetre; set => _perimetre = Rayon*PI*2; }

        public override double Surface { get => _surface; set => _surface = Rayon * PI * Rayon; }
    }
}
