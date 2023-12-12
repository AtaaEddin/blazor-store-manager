using HyOPT.Abstractions;
using HyOPT.Assets;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HyOPT.Web.App
{
    public class AssetService : ServiceClient
    {
        public AssetService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
            : base(httpClient, jsonOptions) { }

        public async Task<Asset?> Create(Asset asset)
        {
            HttpResponseMessage response = await PostAsJsonAsync("", asset);
            Asset? created = await ReadFromJsonAsync<Asset?>(response);

            return created;
        }

        public async Task<TAsset?> Create<TAsset>(TAsset asset)
            where TAsset : Asset
        {
            HttpResponseMessage response = await PostAsJsonAsync("", asset);
            TAsset? created = await ReadFromJsonAsync<TAsset?>(response);

            return created;
        }

        public async Task<ChargePoint?> Create(ChargePoint point)
        {
            HttpResponseMessage response = await PostAsJsonAsync("charge-points", point);
            ChargePoint? created = await ReadFromJsonAsync<ChargePoint?>(response);

            return created;
        }

        public async Task<Asset?> Delete(Guid id)
        {
            HttpResponseMessage response = await DeleteAsync($"{id}");
            Asset? asset = await ReadFromJsonAsync<Asset?>(response);

            return asset;
        }

        public async Task<ChargePoint?> DeleteChargePoint(string id)
        {
            HttpResponseMessage response = await DeleteAsync($"charge-points/{id}");
            ChargePoint? point = await ReadFromJsonAsync<ChargePoint?>(response);

            return point;
        }

        public async Task<FileBytes?> Export(FileExportRequest<Asset, AssetFilter> request)
        {
            HttpResponseMessage response = await PostAsJsonAsync("export", request);
            FileBytes? file = await ReadFromJsonAsync<FileBytes>(response);

            return file;
        }

        public async Task<FileBytes?> Export(FileExportRequest<ChargePoint, ChargePointFilter> request)
        {
            HttpResponseMessage response = await PostAsJsonAsync("charge-points/export", request);
            FileBytes? file = await ReadFromJsonAsync<FileBytes>(response);

            return file;
        }

        public async Task<IPage<Asset>?> Find(AssetFilter filter)
        {
            HttpResponseMessage response = await PostAsJsonAsync("find", filter);
            PagedList<Asset>? assets = await ReadFromJsonAsync<PagedList<Asset>>(response);

            return assets;
        }

        public async Task<IPage<TAsset>?> Find<TAsset>(AssetFilter filter)
            where TAsset : Asset
        {
            HttpResponseMessage response = await PostAsJsonAsync("find", filter);
            PagedList<TAsset>? assets = await ReadFromJsonAsync<PagedList<TAsset>>(response);

            return assets;
        }

        public async Task<IPage<ChargePoint>?> Find(ChargePointFilter filter)
        {
            HttpResponseMessage response = await PostAsJsonAsync("charge-points/find", filter);
            PagedList<ChargePoint>? points = await ReadFromJsonAsync<PagedList<ChargePoint>>(response);

            return points;
        }

        public async Task<Asset?> Get(Guid id)
        {
            HttpResponseMessage response = await GetAsync($"{id}");
            Asset? asset = await ReadFromJsonAsync<Asset?>(response);

            return asset;
        }

        public async Task<TAsset?> Get<TAsset>(Guid id)
            where TAsset : Asset
        {
            HttpResponseMessage response = await GetAsync($"{id}");
            TAsset? asset = await ReadFromJsonAsync<TAsset?>(response);

            return asset;
        }

        public async Task<ChargePoint?> GetChargePoint(string id)
        {
            HttpResponseMessage response = await GetAsync($"charge-points/{id}");
            ChargePoint? point = await ReadFromJsonAsync<ChargePoint?>(response);

            return point;
        }

        public async Task<Asset?> Update(Asset asset)
        {
            HttpResponseMessage response = await PutAsJsonAsync($"{asset.Id}", asset);
            Asset? updated = await ReadFromJsonAsync<Asset?>(response);

            return updated;
        }

        public async Task<TAsset?> Update<TAsset>(TAsset asset)
            where TAsset : Asset
        {
            HttpResponseMessage response = await PutAsJsonAsync($"{asset.Id}", asset);
            TAsset? updated = await ReadFromJsonAsync<TAsset?>(response);

            return updated;
        }

        public async Task<ChargePoint?> Update(ChargePoint point)
        {
            HttpResponseMessage response = await PutAsJsonAsync($"charge-points/{point.Id}", point);
            ChargePoint? updated = await ReadFromJsonAsync<ChargePoint?>(response);

            return updated;
        }
    }
}
