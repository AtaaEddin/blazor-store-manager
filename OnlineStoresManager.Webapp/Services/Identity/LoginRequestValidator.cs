using FluentValidation;

using HyOPT.Identity;
using HyOPT.Web.App.Localization;
using mudblazor.Identity;

namespace HyOPT.Web.App
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(r => r.UserName)
                .NotEmpty()
                .WithMessage(Resource.MustBeFilled);

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage(Resource.MustBeFilled);
        }
    }
}
