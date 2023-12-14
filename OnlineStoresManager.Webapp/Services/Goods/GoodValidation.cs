using FluentValidation;
using OnlineStoresManager.Goods;

namespace OnlineStoresManager.WebApp.Services.Goods
{
    public class GoodValidation<TGood> : AbstractValidator<TGood> 
        where TGood : BasicGood 
    {
        public GoodValidation() 
        {
            RuleFor(g => g.Name)
                .NotEmpty();
                //.WithMessage(Resource.MustBeFilled)

            RuleFor(g => g.ImageUrls)
                .NotEmpty();
            //.WithMessage(Resource.MustBeFilled)

            RuleFor(g => g.Description)
                .MaximumLength(100);
                //.WithMessage(Resource.MaxLengthExceeded);
        }
    }
}
