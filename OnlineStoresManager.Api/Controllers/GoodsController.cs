using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnlineStoresManager.Abstractions;
using OnlineStoresManager.API.Goods;
using OnlineStoresManager.Goods;

namespace OnlineStoresManager.API.Controllers
{
    [ApiController]
    [Authorize]
    public class GoodsController : ControllerBase
    {
        //private readonly FileExporter _fileExporter;
        private readonly IGoodManager _manager;
        public GoodsController(IGoodManager goodsManager)
        {
            _manager = goodsManager;
        }

        [HttpPost("api/goods")]
        public async Task<IActionResult> Create([FromBody] BasicGood good)
        {
            BasicGood created = await _manager.Create(good);

            return Ok(created);
        }

        [HttpDelete("api/goods/{id:guid}")]
        public async Task<IActionResult> Deletegood([FromRoute] Guid id)
        {
            BasicGood? deleted = await _manager.DeleteGood(id);

            return Ok(deleted);
        }

        //[HttpPost("api/goods/export")]
        //public async Task<IActionResult> Export([FromBody] FileExportRequest<BasicGood, IBasicGoodFilter > request)
        //{
        //    IPage<BasicGood> goods = await _manager.Find(request.Filter);
        //    FileBytes file = await _fileExporter.Export(goods, request.Configuration);

        //    return Ok(file);
        //}

        [HttpPost("api/goods/find")]
        public async Task<IActionResult> Find([FromBody] BasicGoodFilter filter)
        {
            IPage<BasicGood> goods = await _manager.Find(filter);

            return Ok(goods);
        }

        [HttpGet("api/goods/{id:guid}")]
        public async Task<IActionResult> Getgood([FromRoute] Guid id)
        {
            BasicGood? good = await _manager.GetGood(id);

            return Ok(good);
        }

        [HttpPut("api/goods/{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] BasicGood good)
        {
            BasicGood updated = await _manager.Update(good);

            return Ok(updated);
        }
    }
}
