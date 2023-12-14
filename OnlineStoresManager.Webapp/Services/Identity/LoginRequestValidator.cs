﻿using FluentValidation;
using OnlineStoresManager.Identity;

namespace OnlineStoresManager.Web.App
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
