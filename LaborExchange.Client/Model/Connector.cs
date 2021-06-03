using System;
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

        /// <summary>
        ///
        /// </summary>
        public static Connector Instance => _instance ??= new Connector();

        /// <summary>
        ///
        /// </summary>
        private ILaborExchangeHub _client;

        /// <summary>
        ///
        /// </summary>
        public ILaborExchangeHub Client => _client;

        public JobOffer[] Offers { get; set; }

        public Connector()
        {
            Connect();
        }

        /// <summary>
        ///
        /// </summary>
        public async Task Connect()
        {
            try
            {
                _client = await StreamingHubClient.ConnectAsync<ILaborExchangeHub, ILaborExchangeHubReciever>(
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
                _client = await StreamingHubClient.ConnectAsync<ILaborExchangeHub, ILaborExchangeHubReciever>(
                   channel,this);
            }

        }

        public void PushOffers(JobOffer[] offers)
        {
            Offers = offers;
        }
    }
}
