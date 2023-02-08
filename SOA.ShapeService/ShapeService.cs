using SOA.ShapeService.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//https://learn.microsoft.com/en-us/dotnet/framework/wcf/feature-details/data-contract-known-types
namespace SOA.ShapeService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ShapeService" à la fois dans le code et le fichier de configuration.
    public class ShapeService : IShapeService
    {
        public void CalculerPerimetre(Forme forme)
        {
            if(forme is Cercle)
            {
                Cercle cercle = forme as Cercle;
                Debug.WriteLine(cercle.Perimetre);
            }
            else if(forme is Rectangle)
            {
                Rectangle rectangle = forme as Rectangle;
                Debug.WriteLine(rectangle.Perimetre);
            }
        }

        public void CalculerSurface(Forme forme)
        {
            if (forme is Cercle)
            {
                Cercle cercle = forme as Cercle;
                Debug.WriteLine(cercle.Surface);
            }
            else if (forme is Rectangle)
            {
                Rectangle rectangle = forme as Rectangle;
                Debug.WriteLine(rectangle.Surface);
            }
        }
    }
}
