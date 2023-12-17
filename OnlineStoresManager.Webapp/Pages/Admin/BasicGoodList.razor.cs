using Microsoft.AspNetCore.Components;
using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;
using OnlineStoresManager.WebApp.Services.Goods;
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
        protected IPage<BasicGood>? BasicGoods { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await ReadBasicGoods();
        }

        protected async Task ReadBasicGoods()
        {
            _basicGoodFilter.PageSize = PageSize ?? _basicGoodFilter.PageSize;
            BasicGoods = await GoodService.Find(_basicGoodFilter);
        }
    }
}
