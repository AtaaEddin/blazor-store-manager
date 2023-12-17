using FluentValidation;
using OnlineStoresManager.Goods;
using OnlineStoresManager.WebApp.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

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

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<TGood>.CreateWithOptions((TGood)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
