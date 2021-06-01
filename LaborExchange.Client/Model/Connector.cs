using Grpc.Core;
using Grpc.Net.Client;
using LaborExchange.Commons;
using MagicOnion.Client;

namespace LaborExchange.Client.Model
{
    public class Client : ILaborExchangeHubReciever
    {
        private static Client _instance;
        public static Client Instance => _instance ??= new Client();

        private ILaborExchangeHub _client;
        public Client()
        {

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
    }
}