using System.ServiceModel;

namespace SOA.Intranet.Service
{

    [ServiceContract]
    public interface IFootballSpecialService :IFootballService
    {
        [OperationContract]
        void VoirRedifusion();

        [OperationContract]
        void ConsulterdPlaningDesMatchs();

    }
}
