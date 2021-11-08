using System.Collections.Generic;

namespace Campaign.Domain.Repositories
{
    public interface ICampaignRepository
    {
        void Create(Models.Campaign model);
        Models.Campaign Get(string name);
        List<Models.Campaign> GetByProductCode(string productCode);
    }
}
