using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using LaborExchange.Commons;
using MagicOnion.Client;

namespace LaborExchange.Client.Model
{
    public class Connector : ILaborExchangeHubReciever
    {
        private static Connector _instance;
        public static Connector Instance => _instance ??= new Connector();

        private ILaborExchangeHub _client;

        public ILaborExchangeHub Client => _client;

        public JobOffer[] Offers { get; set; }

        public Connector()
        {
            Connect();
        }

        public void Connect()
        {
            _client = StreamingHubClient.Connect<ILaborExchangeHub, ILaborExchangeHubReciever>(
                GrpcChannel.ForAddress("0.0.0.0:5000", new GrpcChannelOptions()
                {
                    Credentials = ChannelCredentials.Insecure,
                    MaxReceiveMessageSize = 1024 *1024 *64,
                    MaxSendMessageSize = 1024 *1024 *64
                }) ,this);
        }

        public void PushOffers(JobOffer[] offers)
        {
            Offers = offers;
        }
    }
}