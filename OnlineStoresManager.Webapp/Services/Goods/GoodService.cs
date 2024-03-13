using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Services.Goods
{
    public class GoodService : ServiceClient
    {
        public GoodService(HttpClient client, JsonSerializerOptions jsonOptions) : base(client, jsonOptions)
        {
        }

        public async Task<BasicGood?> Create(BasicGood good)
        {
            HttpResponseMessage response = await PostAsJsonAsync("", good);
            BasicGood? created = await ReadFromJsonAsync<BasicGood?>(response);

            return created;
        }

        public async Task<TGood?> Create<TGood>(TGood good)
            where TGood : BasicGood
        {
            HttpResponseMessage response = await PostAsJsonAsync("", good);
            TGood? created = await ReadFromJsonAsync<TGood?>(response);

            return created;
        }

        public async Task<BasicGood?> Delete(Guid id)
        {
            HttpResponseMessage response = await DeleteAsync($"{id}");
            BasicGood? good = await ReadFromJsonAsync<BasicGood?>(response);

            return good;
        }

        //public async Task<FileBytes?> Export(FileExportRequest<BasicGood, BasicGoodFilter> request)
        //{
        //    HttpResponseMessage response = await PostAsJsonAsync("export", request);
        //    FileBytes? file = await ReadFromJsonAsync<FileBytes>(response);

        //    return file;
        //}

        public async Task<IPage<BasicGood>?> Find(BasicGoodFilter filter)
        {
            HttpResponseMessage response = await PostAsJsonAsync("find", filter);
            PagedList<BasicGood>? goods = await ReadFromJsonAsync<PagedList<BasicGood>>(response);

            return goods;
        }

        public async Task<BasicGood?> Get(Guid id)
        {
            HttpResponseMessage response = await GetAsync($"{id}");
            BasicGood? goods = await ReadFromJsonAsync<BasicGood?>(response);

            return goods;
        }

        public async Task<TGood?> Get<TGood>(Guid id)
            where TGood : BasicGood
        {
            HttpResponseMessage response = await GetAsync($"{id}");
            TGood? good = await ReadFromJsonAsync<TGood?>(response);

            return good;
        }

        public async Task<BasicGood?> Update(BasicGood good)
        {
            HttpResponseMessage response = await PutAsJsonAsync($"{good.Id}", good);
            BasicGood? updated = await ReadFromJsonAsync<BasicGood?>(response);

            return updated;
        }

        public async Task<TBasicGood?> Update<TBasicGood>(TBasicGood good)
            where TBasicGood : BasicGood
        {
            HttpResponseMessage response = await PutAsJsonAsync($"{good.Id}", good);
            TBasicGood? updated = await ReadFromJsonAsync<TBasicGood?>(response);

            return updated;
        }
    }
}
