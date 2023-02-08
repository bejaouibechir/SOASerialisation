using System.Diagnostics;
using System.ServiceModel;

namespace SOA.Intranet.Service
{
    [ServiceContract]
    public class FootballService //: IFootballSpecialService
    {

        [OperationContract]
        #region client abonnement basique
        public void VoirMatchEnDirect()
        {
            Debug.WriteLine("Voir les matchs en direct");
        }

        #endregion

        
        #region client abonnement vip
        [OperationContract(Name ="Planing")]
        public void ConsulterdPlaningDesMatchs()
        {
            Debug.WriteLine("Consulter le planing des matchs");
        }
        [OperationContract]
        public void VoirRedifusion()
        {
            Debug.WriteLine("Voir les redifusions");
        }
        #endregion
    }
}
