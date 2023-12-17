using FluentValidation;
using OnlineStoresManager.Identity;
using OnlineStoresManager.WebApp.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace OnlineStoresManager.WebApp
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

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<LoginRequest>.CreateWithOptions((LoginRequest)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
