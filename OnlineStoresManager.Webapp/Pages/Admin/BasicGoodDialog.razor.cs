using Microsoft.AspNetCore.Components;

using MudBlazor;

using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;
using OnlineStoresManager.Goods.Clothes;
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
        public Guid? Id { get; set; }

        [Parameter]
        public EventCallback<BasicGood> OnSaved { get; set; }

        [Inject]
        public GoodValidationBuilder GoodValidationBuilder { get; set; } = null!;

        [Inject]
        public GoodService GoodService { get; set; } = null!;

        protected BasicGood? Good { get; set; }
        protected IMudValidation? GoodValidation { get; set; }
        protected DialogOptions? DialogOptions { get; set; }
        protected bool IsNew => Id == null || Id == Guid.Empty;
        protected MudForm? MudFormRef { get; set; }
        protected MudSelect<string>? ShirtTypeSelectRef { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await Load();
        }

        protected void Close()
        {
            OSMDialogService.Close();
            MudDialog?.Cancel();
        }

        private async Task Load()
        {
            if(!IsNew)
            {
                Good = await GoodService.Get(Id!.Value);
            }

            Good ??= GoodBuilder.Create(Type ?? GoodType.Shirt);
            GoodValidation = GoodValidationBuilder.Create(Good);
        }

        protected async Task Save()
        {
            await MudFormRef!.Validate();

            if(MudFormRef.IsValid)
            {
                BasicGood? saved = IsNew
                    ? await GoodService.Create(Good!)
                    : await GoodService.Update(Good!);

                await OnSaved.InvokeAsync(saved);
                MudDialog!.Close();
            }
        }
        protected Func<object, string, Task<IEnumerable<string>>> FormValidator
        { get => GoodValidation!.ValidateValue; }

        protected void TypeChanged(string goodTypeStr)
        {
            Good.Type = Enum.Parse<GoodType>(goodTypeStr);
            OSMDialogService.Close();
            MudDialog!.Close();
            OSMDialogService.Show<BasicGoodDialog>(
                new Dictionary<string, object>
                {
                    [nameof(BasicGood.Type)] = Good.Type,
                    [nameof(BasicGoodDialog.OnSaved)] = EventCallback.Factory.Create<BasicGood>(this, OnSaved)
                });
        }

    }
}
