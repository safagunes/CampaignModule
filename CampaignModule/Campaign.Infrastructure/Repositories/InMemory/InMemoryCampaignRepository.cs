using Campaign.Domain.Exceptions;
using Campaign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Infrastructure.Repositories.InMemory
{
    public class InMemoryCampaignRepository : ICampaignRepository
    {

        private static Dictionary<string, Domain.Models.Campaign> _campaigns = new Dictionary<string, Domain.Models.Campaign>();
        public void Create(Domain.Models.Campaign model)
        {
            if (_campaigns.TryGetValue(model.ProductCode, out Domain.Models.Campaign campaign))
            {
                throw new DatabaseException("Campaign already exist");
            }
            _campaigns.Add(model.ProductCode, model);
        }

        public Domain.Models.Campaign Get(string code)
        {
            if (!_campaigns.TryGetValue(code, out Domain.Models.Campaign campaign))
            {
                throw new DatabaseException("Campaign not found");
            }
            return campaign;
        }
    }
}
