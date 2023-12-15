﻿using FluentValidation;
using OnlineStoresManager.Goods;
using OnlineStoresManager.WebApp.Localization;

namespace OnlineStoresManager.WebApp.Services.Goods
{
    public class GoodValidation : GoodValidation<BasicGood> { }
    public class GoodValidation<TGood> : AbstractValidator<TGood> 
        where TGood : BasicGood 
    {
        public GoodValidation() 
        {
            RuleFor(g => g.Name)
                .NotEmpty()
                .WithMessage(Resource.MustBeFilled);

            RuleFor(g => g.ImageUrls)
                .NotEmpty()
                .WithMessage(Resource.MustBeFilled);

            RuleFor(g => g.Description)
                .MaximumLength(100)
                .WithMessage(Resource.MaxLengthExceeded);
        }
    }
}
