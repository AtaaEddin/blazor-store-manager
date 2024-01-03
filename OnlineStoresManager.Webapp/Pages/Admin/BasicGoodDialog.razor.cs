using Microsoft.AspNetCore.Components;

using MudBlazor;

using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;
using OnlineStoresManager.WebApp.Components.Dialog;
using OnlineStoresManager.WebApp.Services.Goods;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Pages.Admin
{
    public partial class BasicGoodDialog : OSMAwaitableComponent
    {
        [CascadingParameter]
        MudDialogInstance? MudDialog { get; set; }

        [Parameter]
        public GoodType? Type { get; set; }

        [Parameter]
        public BasicGood? BasicGood { get; set; }

        [Parameter]
        public EventCallback<BasicGood> OnSaved { get; set; }

        [Inject]
        public GoodValidationBuilder GoodValidationBuilder { get; set; } = null!;

        [Inject]
        public GoodService GoodService { get; set; } = null!;

        protected IMudValidation? GoodValidation { get; set; }
        protected DialogOptions? DialogOptions { get; set; }
        protected bool IsNew => BasicGood?.Id == null || BasicGood?.Id == Guid.Empty;
        protected MudForm? MudFormRef { get; set; }
        protected MudSelect<string>? ShirtTypeSelectRef { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Load();
        }

        protected void Close()
        {
            OSMDialogService.Close();
            MudDialog?.Cancel();
        }

        private void Load()
        {
            BasicGood ??= GoodBuilder.Create(Type ?? GoodType.Shirt);
            GoodValidation = GoodValidationBuilder.Create(BasicGood);
        }

        protected async Task Save()
        {
            await MudFormRef!.Validate();

            if (MudFormRef.IsValid)
            {
                BasicGood? saved = IsNew
                    ? await GoodService.Create(BasicGood!)
                    : await GoodService.Update(BasicGood!);

                await OnSaved.InvokeAsync(saved);
                MudDialog!.Close();
            }
        }

        protected void TypeChanged(string goodTypeStr)
        {
            BasicGood.Type = Enum.Parse<GoodType>(goodTypeStr);
            OSMDialogService.Close();
            MudDialog!.Close();
            OSMDialogService.Show<BasicGoodDialog>(
                new Dictionary<string, object>
                {
                    [nameof(Goods.BasicGood.Type)] = BasicGood.Type,
                    [nameof(BasicGoodDialog.OnSaved)] = EventCallback.Factory.Create<BasicGood>(this, OnSaved)
                });
        }

    }
}
