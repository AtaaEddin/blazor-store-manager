﻿using FluentValidation;

using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Assets;
using OnlineStoresManager.EnergyParks;
using OnlineStoresManager.Meterings;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Telerik.Blazor.Components;

namespace OnlineStoresManager.WebApp.Pages.Assets
{
    public partial class AssetDialog : OSMAwaitableComponent
    {
        [Parameter]
        public AssetDiscriminator? Discriminator { get; set; }

        [Parameter]
        public Guid? Id { get; set; }

        [Parameter]
        public EventCallback<Asset> OnSaved { get; set; }

        [Inject]
        public AssetService AssetService { get; set; } = null!;

        [Inject]
        public AssetValidatorBuilder AssetValidatorBuilder { get; set; } = null!;

        [Inject]
        public EnergyParkService EnergyParkService { get; set; } = null!;

        [Inject]
        public MeteringService MeteringService { get; set; } = null!;

        protected TelerikDialog? DialogRef { get; set; }
        protected bool IsNew => Id == null || Id == Guid.Empty;
        protected Asset? Asset { get; set; }
        protected EditContext? AssetContext { get; set; }
        protected IValidator? AssetValidator { get; set; }
        protected IReadOnlyCollection<EnergyPark>? EnergyParks { get; set; }
        protected IReadOnlyCollection<MeteringPoint>? MeteringPoints { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            await Load();
        }

        protected Task Close()
        {
            return OSMDialogService.Close();
        }

        private Task Load()
        {
            return Await(async () =>
            {
                EnergyParks = await EnergyParkService.Find(new EnergyParkFilter { PageSize = int.MaxValue });
                MeteringPoints = await MeteringService.Find(new MeteringPointFilter { PageSize = int.MaxValue });

                if (!IsNew)
                {
                    Asset = await AssetService.Get(Id!.Value);
                }

                Asset ??= AssetBuilder.Create(Discriminator ?? AssetDiscriminator.Consumption);
                Asset.Geo ??= new Coordinates();

                AssetContext = new EditContext(Asset!);
                AssetValidator = AssetValidatorBuilder.Create(Asset);
            }).ContinueWith(_ => DialogRef?.Refresh());
        }

        protected Task Save()
        {
            return Await(async () =>
            {
                bool isValid = AssetContext!.Validate();
                if (isValid)
                {
                    Asset? saved = IsNew
                        ? await AssetService.Create(Asset!)
                        : await AssetService.Update(Asset!);

                    await OnSaved.InvokeAsync(saved);
                    await OSMDialogService.Close();
                }
            });
        }
    }
}
