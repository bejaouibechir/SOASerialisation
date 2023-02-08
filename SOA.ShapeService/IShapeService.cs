using SOA.ShapeService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOA.ShapeService
{
     
    [ServiceContract]
    public interface IShapeService
    {
        [OperationContract]
        void CalculerPerimetre(Forme forme);
        
        [OperationContract]
        void CalculerSurface(Forme forme);

    }
}
