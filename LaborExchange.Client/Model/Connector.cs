using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using LaborExchange.Commons;
using MagicOnion.Client;

namespace LaborExchange.Client
{
    public class Connector : ILaborExchangeHubReciever
    {
        private static Connector _instance;

        /// <summary>
        ///
        /// </summary>
        public static Connector Instance => _instance ??= new Connector();

        /// <summary>
        ///
        /// </summary>
        public ILaborExchangeHub Client { get; private set; }

        public async Task<ILaborExchangeHub> GetClient()
        {
            return Client ?? await Connect();
        }

        public JobOffer[] Offers { get; set; }

        public Connector()
        {
            Connect();
        }

        /// <summary>
        ///
        /// </summary>
        public async Task<ILaborExchangeHub> Connect()
        {
            try
            {
               return Client = await StreamingHubClient.ConnectAsync<ILaborExchangeHub, ILaborExchangeHubReciever>(
                    GrpcChannel.ForAddress("http://localhost:5000", new GrpcChannelOptions()
                    {
                        Credentials = ChannelCredentials.Insecure,
                        MaxReceiveMessageSize = 1024 *1024 *64,
                        MaxSendMessageSize = 1024 *1024 *64
                    }) ,this);
            }
            catch (Exception e)
            {
                var channel = GrpcChannel.ForAddress("https://localhost:5000");
                return Client = await StreamingHubClient.ConnectAsync<ILaborExchangeHub, ILaborExchangeHubReciever>(
                   channel,this);
            }

        }

        public void PushOffers(JobOffer[] offers)
        {
            Offers = offers;
        }
    }
}
