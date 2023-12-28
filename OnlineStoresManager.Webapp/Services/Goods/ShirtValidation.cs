using FluentValidation;
using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods.Clothes;
using OnlineStoresManager.WebApp.Localization;

namespace OnlineStoresManager.WebApp.Services.Goods
{
    public class ShirtValidation : GoodValidation<Shirt>
    {
        public ShirtValidation()
        {
            RuleFor(s => s.Color)
                .NotEmpty()
                .WithMessage(Resource.MustBeFilled);

            RuleFor(s => s.ShirtType)
                .NotNull()
                .WithMessage(Resource.MustBeFilled);
        }
    }
}
