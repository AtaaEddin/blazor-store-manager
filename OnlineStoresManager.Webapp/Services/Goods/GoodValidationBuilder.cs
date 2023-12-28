using Microsoft.Extensions.DependencyInjection;

using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;
using System;

namespace OnlineStoresManager.WebApp.Services.Goods
{
    public class GoodValidationBuilder
    {
        private readonly IServiceProvider _serviceProvider;

        public GoodValidationBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMudValidation Create(BasicGood basicGood)
        {
            switch(basicGood.Type)
            {
                case GoodType.Shirt:
                    return _serviceProvider.GetRequiredService<ShirtValidation>();

                case GoodType.ShortStory:
                    return _serviceProvider.GetRequiredService<ShortStoryValidation>();

                default:
                    throw new ArgumentException($"Not supported asset type '{basicGood.Gategory}'");
            }
        }
    }
}
