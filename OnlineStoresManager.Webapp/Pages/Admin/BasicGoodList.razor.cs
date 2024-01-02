using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using OnlineStoresManager.Goods;
using OnlineStoresManager.Goods.Books;
using OnlineStoresManager.WebApp.Components.SimpleDialog;
using OnlineStoresManager.WebApp.Localization;
using OnlineStoresManager.WebApp.Services.Goods;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Pages.Admin
{
    public partial class BasicGoodList : OSMAwaitableComponent
    {
        [Parameter]
        public int? PageSize { get; set; }

        [Inject]
        public GoodService GoodService { get; set; } = null!;

        private BasicGoodFilter _basicGoodFilter = new BasicGoodFilter();
        protected MudDataGrid<BasicGood>? MudDataGrid { get; set; }

        protected string? SearchString { get; set; }
        private HashSet<BasicGood> SelectedGoods { get; set; } = new HashSet<BasicGood>();
 
        protected Task ShowBasicGoodDialog(Guid? basicGoodId = null, GoodType? goodType = null)
        {
            return Await(async () =>
            {
                BasicGood? good = null;
                if (basicGoodId != null)
                {
                    good = await GoodService.Get(basicGoodId!.Value);

                }
                await OSMDialogService.Show<BasicGoodDialog>(
                    new Dictionary<string, object>
                    {
                        [nameof(BasicGood)] = good,
                        [nameof(BasicGood.Type)] = goodType ?? GoodType.Shirt,
                        [nameof(BasicGoodDialog.OnSaved)] = EventCallback.Factory.Create<BasicGood>(this, RefreshGrid)
                    });
            });
        }

        protected async Task<GridData<BasicGood>> LoadGridData(GridState<BasicGood> state)
        {
            _basicGoodFilter.PageIndex = state.Page;
            _basicGoodFilter.PageSize = state.PageSize;
            _basicGoodFilter.SearchText = SearchString ?? string.Empty;

            var BasicGoods = await GoodService.Find(_basicGoodFilter);
            if (BasicGoods == null)
            {
                return new();
            }

            GridData<BasicGood> data = new()
            {
                Items = BasicGoods,
                TotalItems = BasicGoods!.TotalCount
            };

            return data;
        }

        protected Task RefreshGrid() => Await(async () => await MudDataGrid!.ReloadServerData());

        protected Task OnSearchTextBoxKeyPress(KeyboardEventArgs args)
        {
            return Await(async () =>
            {
                if (args.Key == KeyboardKeys.Enter)
                {
                    await MudDataGrid!.ReloadServerData();
                }
            });
        }

        protected Task DeleteGood(BasicGood basicGood)
        {
            return Await(async () =>
            {
                var deleteConfirmed = await ShowDeleteConfimationDialog(Localizer["DeleteGood"]);
                if (deleteConfirmed)
                {
                    await GoodService.Delete(basicGood.Id);
                }
            }).ContinueWith(async _ => await MudDataGrid!.ReloadServerData());
        }

        protected Task DeleteSelectedGoods()
        {
            return Await(async () =>
            {
                var deleteConfirmed = await ShowDeleteConfimationDialog(Localizer["DeleteSelectedGood"]);
                if (deleteConfirmed)
                {
                    foreach (var good in SelectedGoods)
                    {
                        await GoodService.Delete(good.Id);
                    }
                    SelectedGoods = new HashSet<BasicGood>();
                }
            }).ContinueWith(async _ => await MudDataGrid!.ReloadServerData());
        }

        protected void SelectedItemsChanged(HashSet<BasicGood> items)
        {
            SelectedGoods = items;
        }
    }
}
