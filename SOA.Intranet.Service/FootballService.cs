using System.Diagnostics;

namespace SOA.Intranet.Service
{
    public class FootballService : IFootballSpecialService
    {

        #region client abonnement basique
        public void VoirMatchEnDirect()
        {
            Debug.WriteLine("Voir les matchs en direct");
        }

        #endregion

        #region client abonnement vip

        public void ConsulterdPlaningDesMatchs()
        {
            Debug.WriteLine("Consulter le planing des matchs");
        }

        public void VoirRedifusion()
        {
            Debug.WriteLine("Voir les redifusions");
        }
        #endregion
    }
}
