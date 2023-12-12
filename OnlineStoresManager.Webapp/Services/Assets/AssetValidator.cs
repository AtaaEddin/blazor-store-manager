using FluentValidation;

using HyOPT.Assets;
using HyOPT.Web.App.Localization;

namespace HyOPT.Web.App
{
    public class AssetValidator : AssetValidator<Asset> { }

    public class AssetValidator<TAsset> : AbstractValidator<TAsset>
        where TAsset : Asset
    {
        public AssetValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage(Resource.MustBeFilled)
                .MaximumLength(Asset.NameMaxLength)
                .WithMessage(Resource.MaxLengthExceeded);

            RuleFor(a => a.MeteringPoint)
                .NotEmpty()
                .WithMessage(Resource.MustBeFilled)
                .MaximumLength(Asset.MeteringPointMaxLength)
                .WithMessage(Resource.MaxLengthExceeded);

            RuleFor(a => a.MastrNr)
                .MaximumLength(Asset.MastrNrMaxLength)
                .WithMessage(Resource.MaxLengthExceeded);

            RuleFor(a => a.ShortName)
                .MaximumLength(Asset.ShortNameMaxLength)
                .WithMessage(Resource.MaxLengthExceeded);

            RuleFor(a => a.Description)
                .MaximumLength(Asset.DescriptionMaxLength)
                .WithMessage(Resource.MaxLengthExceeded);

            RuleFor(a => a.OEM)
                .MaximumLength(Asset.OEMMaxLength)
                .WithMessage(Resource.MaxLengthExceeded);
        }
    }
}
