using Campaign.ConsoleApp.Commands;
using Campaign.Domain.Services;
using System;

namespace Campaign.ConsoleApp
{
    public class CommandFactory
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ICampaignService _campaignService;
        private readonly ITimeService _timeService;

        public CommandFactory(IProductService productService, IOrderService orderService, ICampaignService campaignService, ITimeService timeService)
        {
            _productService = productService;
            _orderService = orderService;
            _campaignService = campaignService;
            _timeService = timeService;
        }
        public Commands.ICommand CreateCommand(string commandName)
        {
            Commands.ICommand command = commandName switch
            {
                "create_product" => new ProductCreateCommand(_productService),
                "get_product_info" => new ProductInfoCommand(_productService),
                "create_order" => new OrderCreateCommand(_orderService),
                "create_campaign" => new CampaignCreateCommand(_campaignService),
                "get_campaign_info" => new CampaignInfoCommand(_campaignService),
                "increase_time" => new IncreaseTimeCommand(_timeService),
                _ => throw new ApplicationException($"{commandName} command not found"),
            };
            return command;
        }
    }
}
