using Microsoft.AspNetCore.Components;
using MudBlazor;
using OnlineStoresManager.Goods;
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

        protected Task ShowCreateDialog()
        {
            return OSMDialogService.Show<BasicGoodDialog>(
                new Dictionary<string, object>
                {
                    [nameof(BasicGood.Id)] = Guid.Empty,
                    [nameof(BasicGoodDialog.OnSaved)] = EventCallback.Factory.Create<BasicGood>(this, RefreshGrid)
                });
        }

        private async Task<GridData<BasicGood>> LoadGridData(GridState<BasicGood> state)
        {
            _basicGoodFilter.PageIndex = state.Page;
            _basicGoodFilter.PageSize = state.PageSize;

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

        protected async Task RefreshGrid()
        {
            await MudDataGrid!.ReloadServerData();
        }
    }
}
