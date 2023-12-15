using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Assets;
using OnlineStoresManager.Identity;
using OnlineStoresManager.Mastr.Assets;

using OnlineStoresManager.WebApp.Pages.Mastr;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Telerik.Blazor.Components;

namespace OnlineStoresManager.WebApp.Pages.Assets
{
    public partial class AssetList : OSMAwaitableComponent
    {
        [Parameter]
        public int? PageSize { get; set; }

        [Parameter]
        public Guid? ParkId { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        [Inject]
        public AssetService AssetService { get; set; } = null!;

        [Inject]
        public MastrService MastrService { get; set; } = null!;

        protected AssetFilter Filter { get; set; } = new AssetFilter();
        protected TelerikGrid<Asset>? GridRef { get; set; }
        protected bool IsAdministrator { get; set; }
        protected IPage<MastrAsset>? MastrAssets { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            AuthenticationState state = await AuthenticationStateTask;
            IsAdministrator = state?.User?.IsInRole(Roles.Administrator) == true;

            Filter.PageSize = PageSize ?? Filter.PageSize;
            Filter.ParkId = ParkId;
        }

        protected Task Export(FileType fileType)
        {
            return Await(async () =>
            {
                FileExportRequest<Asset, AssetFilter> request = new FileExportRequest<Asset, AssetFilter>(
                    configuration: new FileExportConfiguration<Asset>(
                        fileType,
                        new List<FileExportProperty<Asset>>
                        {
                            new FileExportProperty<Asset>(
                                selector: a => a.Name,
                                template: a => a.Name,
                                title: Localizer["AssetName"]),
                            new FileExportProperty<Asset>(
                                selector: a => a.ShortName,
                                template: a => a.ShortName ?? string.Empty,
                                title: Localizer["AssetShortName"]),
                            new FileExportProperty<Asset>(
                                selector: a => a.MeteringPoint,
                                template: a => a.MeteringPoint,
                                title: Localizer["MeteringPoint"]),
                            new FileExportProperty<Asset>(
                                selector: a => a.Regulation,
                                template: a => a.Regulation != null ? ( a.Regulation == true ? Localizer["YesMastrIdRegistered"].ToString() :  Localizer["NoMastrIdRegistered"].ToString()) : string.Empty,
                                title: Localizer["AssetRegulation"]),
                            new FileExportProperty<Asset>(
                                selector: a => a.Type,
                                template: a => a.Type != null ? a.Type.ToString() : string.Empty,
                                title: Localizer["AssetType"]),
                            new FileExportProperty<Asset>(
                                selector: a => a.MastrNr,
                                template: a => a.MastrNr ?? string.Empty,
                                title: Localizer["MastrNr"])
                        }),
                    filter: (AssetFilter)Filter.Clone());
                request.Filter.PageIndex = 0;
                request.Filter.PageSize = int.MaxValue;

                FileBytes? file = await AssetService.Export(request);
                if (file != null)
                {
                    await Download(file);
                }
            });
        }

        protected Task ReadAssets(GridReadEventArgs args)
        {
            return Await(async () =>
            {
                Filter.PageIndex = args.Request.Page - 1;
                Filter.SortBy = (int?)args.Request.GetSortBy<AssetFieldIdentifier>() ?? AssetFilter.DefaultSortBy;
                Filter.SortOrder = args.Request.GetSortOrder() ?? AssetFilter.DefaultSortOrder;

                IPage<Asset>? assets = await AssetService.Find(Filter);
                string[] mastrAssetIds = assets?.Select(a => a.MastrNr ?? string.Empty).Distinct().ToArray() ?? Array.Empty<string>();
                MastrAssets = await MastrService.Find(new MastrAssetFilter { Ids = mastrAssetIds, PageSize = mastrAssetIds.Length });

                args.Data = assets;
                args.Total = assets!.TotalCount;
            });
        }

        protected void RefreshGrid()
        {
            GridRef?.Rebind();
        }

        protected Task ShowCreateDialog()
        {
            return OSMDialogService.Show<AssetDialog>(
                new Dictionary<string, object>
                {
                    [nameof(AssetDialog.Id)] = Guid.Empty,
                    [nameof(AssetDialog.OnSaved)] = EventCallback.Factory.Create<Asset>(this, RefreshGrid)
                });
        }

        protected async Task ShowDeleteDialog(GridCommandEventArgs args)
        {
            bool isConfirmed = await DialogFactory.ConfirmAsync(Localizer["DeleteConfirmation"]);
            if (isConfirmed)
            {
                await Await(async () =>
                {
                    Asset asset = (Asset)args.Item;
                    await AssetService.Delete(asset.Id);
                    RefreshGrid();
                });
            }
        }

        protected Task ShowEditDialog(Asset asset)
        {
            return OSMDialogService.Show<AssetDialog>(
                new Dictionary<string, object>
                {
                    [nameof(AssetDialog.Id)] = asset.Id,
                    [nameof(AssetDialog.OnSaved)] = EventCallback.Factory.Create<Asset>(this, RefreshGrid)
                });
        }

        protected Task ShowEditMastrAssetDialog(string id)
        {
            return OSMDialogService.Show<MastrAssetDialog>(
                new Dictionary<string, object>
                {
                    [nameof(MastrAssetDialog.Id)] = id,
                    [nameof(MastrAssetDialog.OnSaved)] = EventCallback.Factory.Create<MastrAsset>(this, RefreshGrid)
                });
        }

        protected Task Update(GridCommandEventArgs args)
        {
            return Await(async () =>
            {
                Asset asset = (Asset)args.Item;
                await AssetService.Update(asset);
                RefreshGrid();
            });
        }
    }
}
