using System.Threading.Tasks;

namespace LaborExchange.Commons
{
    public interface ILaborExchangeHubReciever
    {
        void PushOffers(JobOffer[] offers);
    }
}