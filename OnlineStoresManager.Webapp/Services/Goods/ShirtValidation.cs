using FluentValidation;
using OnlineStoresManager.Goods;

namespace OnlineStoresManager.WebApp.Services.Goods
{
    public class ShirtValidation : GoodValidation<Shirt>
    {
        public ShirtValidation()
        {
            RuleFor(s => s.ShirtType)
                .NotNull();
            //.WithMessage(Resource...)

            RuleFor(s => s.Color)
                .NotEmpty();
                //.WithMessage(Resource.MustBeFilled)
        }
    }
}
