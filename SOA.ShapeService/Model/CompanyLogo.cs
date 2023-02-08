using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SOA.ShapeService.Model
{
    [DataContract]
    [KnownType(typeof(Cercle))]
    [KnownType(typeof(Rectangle))]
    public class CompanyLogo
    {
        [DataMember]
        public Forme FormeLogo;  
    }
}
