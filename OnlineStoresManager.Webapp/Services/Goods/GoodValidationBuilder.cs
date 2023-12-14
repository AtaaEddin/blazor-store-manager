using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
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

        public IValidator Create(BasicGood basicGood)
        {
            switch(basicGood.Discriminator)
            {
                case GoodDiscriminator.Shirt:
                    return _serviceProvider.GetRequiredService<ShirtValidation>();

                case GoodDiscriminator.Books:
                    return _serviceProvider.GetRequiredService<BookValidation>();

                default:
                    throw new ArgumentException($"Not supported asset type '{basicGood.Discriminator}'");
            }
        }
    }
}
