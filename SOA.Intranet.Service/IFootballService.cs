using System.ServiceModel;

namespace SOA.Intranet.Service
{

    [ServiceContract]
    public interface IFootballService
    {
        [OperationContract]
        void VoirMatchEnDirect();

    }
}
