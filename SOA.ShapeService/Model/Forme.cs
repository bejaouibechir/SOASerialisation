using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SOA.ShapeService.Model
{
    [DataContract]
    abstract public class Forme
    {
        [DataMember]
        public abstract double Perimetre { get; set; }

        [DataMember]
        public abstract double Surface { get; set; }
    }
}
