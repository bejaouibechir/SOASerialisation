using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SOA.ShapeService.Model
{
    [DataContract]
    public class Rectangle :Forme
    {
        private double _perimetre;
        private double _surface;

        public double Longeur { get; set; }
        public double Largeur { get; set; }
        public override double Perimetre { get => _perimetre; set => _perimetre = (Longeur + Largeur) * 2; }

        public override double Surface { get => _surface; set => _surface = Longeur *Largeur; }


    }
}
