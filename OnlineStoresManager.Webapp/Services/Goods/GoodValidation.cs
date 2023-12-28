using FluentValidation;
using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;
using OnlineStoresManager.WebApp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Services.Goods
{
    public class GoodValidation : GoodValidation<BasicGood> { }
    public class GoodValidation<TGood> : AbstractValidator<TGood>, IMudValidation
        where TGood : BasicGood
    {
        public GoodValidation()
        {
            RuleFor(g => g.Name)
                .NotEmpty()
                .WithMessage(Resource.MustBeFilled);

            RuleFor(g => g.Price)
                .NotNull()
                .WithMessage(Resource.MustBeFilled);

            RuleFor(g => g.ImageUrls)
                .NotEmpty()
                .WithMessage(Resource.MustBeFilled);
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<TGood>.CreateWithOptions((TGood)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
