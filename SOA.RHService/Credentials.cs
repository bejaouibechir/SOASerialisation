using System.Runtime.Serialization;

namespace SOA.RHService
{

    [DataContract]
    public struct Credentials
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}