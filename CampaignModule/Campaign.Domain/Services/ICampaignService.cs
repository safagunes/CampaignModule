using Campaign.Domain.Dtos.Campaign;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Services
{
    public interface ICampaignService
    {
        void CampaignCreate(CampaignCreateDto model);
        CampaingInfoDto GetCampaingInfo(string code);
    }
}
