using Campaign.Domain.Exceptions;
using Campaign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campaign.Infrastructure.Repositories.InMemory
{
    public class InMemoryCampaignRepository : ICampaignRepository
    {

        private List<Domain.Models.Campaign> _campaigns = new List<Domain.Models.Campaign>();
        public void Create(Domain.Models.Campaign model)
        {
            if (_campaigns.Any(a => a.Name == model.Name))
            {
                throw new DatabaseException("Campaign already exist.");
            }
            _campaigns.Add(model);
        }

        public Domain.Models.Campaign Get(string name)
        {
            return _campaigns.SingleOrDefault(a => a.Name == name);
        }

        public List<Domain.Models.Campaign> GetByProductCode(string productCode)
        {
            return _campaigns.Where(a => a.ProductCode == productCode).ToList();
        }
    }
}
