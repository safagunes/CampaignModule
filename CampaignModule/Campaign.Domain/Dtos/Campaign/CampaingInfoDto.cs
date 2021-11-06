using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Dtos.Campaign
{
    public class CampaingInfoDto
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public int TargetSalesCount { get; set; }
        public int TotalSalesCount { get; set; }
        public int Turnover { get; set; }
        public decimal AvarageItemPrice { get; set; }
    }
}
