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

        protected Task RefreshGrid() => Await(async () =>  await MudDataGrid!.ReloadServerData());
        
    }
}
