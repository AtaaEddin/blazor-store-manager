using FluentValidation;

using OnlineStoresManager.Assets;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace OnlineStoresManager.Web.App
{
    public class AssetValidatorBuilder
    {
        private readonly IServiceProvider _services;

        public AssetValidatorBuilder(IServiceProvider services)
        {
            _services = services;
        }

        public IValidator Create(Asset asset)
        {
            switch (asset.Discriminator)
            {
                case AssetDiscriminator.BatteryStorage:
                    return _services.GetRequiredService<BatteryStorageAssetValidator>();

                case AssetDiscriminator.ChargePoint:
                    return _services.GetRequiredService<ChargePointAssetValidator>();

                case AssetDiscriminator.Consumption:
                    return _services.GetRequiredService<ConsumptionAssetValidator>();

                case AssetDiscriminator.ElektrolysisPlant:
                    return _services.GetRequiredService<ElektrolysisPlantAssetValidator>();

                case AssetDiscriminator.HydrogenStorage:
                    return _services.GetRequiredService<HydrogenStorageAssetValidator>();

                case AssetDiscriminator.Windturbine:
                    return _services.GetRequiredService<WindturbineAssetValidator>();

                default:
                    throw new ArgumentException($"Not supported asset type '{asset.Discriminator}'");
            }
        }
    }
}
