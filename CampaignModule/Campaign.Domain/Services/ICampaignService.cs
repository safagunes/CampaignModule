using Campaign.Domain.Dtos.Campaign;

namespace Campaign.Domain.Services
{
    public interface ICampaignService
    {
        void CampaignCreate(CampaignCreateDto model);
        CampaingInfoDto GetCampaingInfo(string code);
    }
}
