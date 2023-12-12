using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace OnlineStoresManager.API.Controllers
{
    [ApiController]
    [Authorize]
    public class ScenariosController : ControllerBase
    {
        private readonly FileExporter _fileExporter;
        private readonly IScenarioManager _manager;

        public ScenariosController(FileExporter fileExporter, IScenarioManager manager)
        {
            _fileExporter = fileExporter;
            _manager = manager;
        }

        [HttpPost("api/scenarios/{scenarioId}/asset-scenarios")]
        public async Task<IActionResult> Create([FromRoute] string scenarioId, [FromBody] AssetScenario scenario)
        {
            scenario.ScenarioId = scenarioId;
            AssetScenario created = await _manager.Create(scenario);

            return Ok(created);
        }

        [HttpPost("api/scenarios")]
        public async Task<IActionResult> Create([FromBody] Scenario scenario)
        {
            Scenario created = await _manager.Create(scenario);

            return Ok(created);
        }

        [HttpDelete("api/scenarios/{scenarioId}/asset-scenarios/{id}")]
        public async Task<IActionResult> DeleteAssetScenario([FromRoute] string scenarioId, [FromRoute] string id)
        {
            AssetScenario? deleted = null;
            if (AssetScenarioId.TryParse(id, out AssetScenarioId? assetScenarioId))
            {
                deleted = await _manager.DeleteAssetScenario(assetScenarioId!);
            }

            return Ok(deleted);
        }

        [HttpDelete("api/scenarios/{id}")]
        public async Task<IActionResult> DeleteScenario([FromRoute] string id)
        {
            Scenario? deleted = await _manager.DeleteScenario(id);

            return Ok(deleted);
        }

        [HttpDelete("api/scenarios/{scenarioId}/optimization-runs/{id}")]
        public async Task<IActionResult> DeleteOptimizationRun([FromRoute] string scenarioId, [FromRoute] string id)
        {
            OptimizationRun? deleted = await _manager.DeleteOptimizationRun(id);

            return Ok(deleted);
        }

        [HttpPost("api/scenarios/{scenarioId}/asset-scenarios/export")]
        public async Task<IActionResult> Export([FromBody] FileExportRequest<AssetScenario, AssetScenarioFilter> request)
        {
            IPage<AssetScenario> scenarios = await _manager.Find(request.Filter);
            FileBytes file = await _fileExporter.Export(scenarios, request.Configuration);

            return Ok(file);
        }

        [HttpPost("api/scenarios/{scenarioId}/market-scenarios/export")]
        public async Task<IActionResult> Export([FromBody] FileExportRequest<MarketScenario, MarketScenarioFilter> request)
        {
            IPage<MarketScenario> scenarios = await _manager.Find(request.Filter);
            FileBytes file = await _fileExporter.Export(scenarios, request.Configuration);

            return Ok(file);
        }

        [HttpPost("api/scenarios/{scenarioId}/optimization-runs/export")]
        public async Task<IActionResult> Export([FromBody] FileExportRequest<OptimizationRun, OptimizationRunFilter> request)
        {
            IPage<OptimizationRun> optimizationRuns = await _manager.Find(request.Filter);
            FileBytes file = await _fileExporter.Export(optimizationRuns, request.Configuration);

            return Ok(file);
        }

        [HttpPost("api/scenarios/{scenarioId}/optimization-runs/{runId}/logs/export")]
        public async Task<IActionResult> Export([FromRoute] string scenarioId, [FromRoute] string runId, [FromBody] FileExportRequest<OptimizationRunLog, OptimizationRunLogFilter> request)
        {
            request.Filter.RunId = runId;
            IPage<OptimizationRunLog> logs = await _manager.Find(request.Filter);
            FileBytes file = await _fileExporter.Export(logs, request.Configuration);

            return Ok(file);
        }

        [HttpPost("api/scenarios/export")]
        public async Task<IActionResult> Export([FromBody] FileExportRequest<Scenario, ScenarioFilter> request)
        {
            IPage<Scenario> scenarios = await _manager.Find(request.Filter);
            FileBytes file = await _fileExporter.Export(scenarios, request.Configuration);

            return Ok(file);
        }

        [HttpPost("api/scenarios/find")]
        public async Task<IActionResult> Find([FromBody] ScenarioFilter filter)
        {
            IPage<Scenario> scenarios = await _manager.Find(filter);

            return Ok(scenarios);
        }

        [HttpPost("api/scenarios/{scenarioId}/asset-scenarios/find")]
        public async Task<IActionResult> Find([FromRoute] string scenarioId, [FromBody] AssetScenarioFilter filter)
        {
            filter.ScenarioId = scenarioId;
            IPage<AssetScenario> assets = await _manager.Find(filter);

            return Ok(assets);
        }

        [HttpPost("api/scenarios/{scenarioId}/market-scenarios/find")]
        public async Task<IActionResult> Find([FromRoute] string scenarioId, [FromBody] MarketScenarioFilter filter)
        {
            filter.ScenarioId = scenarioId;
            IPage<MarketScenario> scenarios = await _manager.Find(filter);

            return Ok(scenarios);
        }

        [HttpPost("api/scenarios/{scenarioId}/optimization-runs/find")]
        public async Task<IActionResult> Find([FromRoute] string scenarioId, [FromBody] OptimizationRunFilter filter)
        {
            filter.ScenarioId = scenarioId;
            IPage<OptimizationRun> scenarios = await _manager.Find(filter);

            return Ok(scenarios);
        }

        [HttpPost("api/scenarios/{scenarioId}/optimization-runs/{runId}/logs/find")]
        public async Task<IActionResult> Find([FromRoute] string scenarioId, [FromRoute] string runId, [FromBody] OptimizationRunLogFilter filter)
        {
            filter.RunId = runId;
            IPage<OptimizationRunLog> logs = await _manager.Find(filter);

            return Ok(logs);
        }

        [HttpPost("api/scenarios/{scenarioId}/optimization-runs/find-info")]
        public async Task<IActionResult> FindInfo([FromRoute] string scenarioId, [FromBody] OptimizationRunFilter filter)
        {
            filter.ScenarioId = scenarioId;
            IPage<OptimizationRunInfo> scenarios = await _manager.Find<OptimizationRunInfo>(filter);

            return Ok(scenarios);
        }

        [HttpGet("api/scenarios/{scenarioId}/asset-scenarios/{id}")]
        public async Task<IActionResult> GetAssetScenario([FromRoute] string scenarioId, [FromRoute] string id)
        {
            Scenario? scenario = null;
            if (AssetScenarioId.TryParse(id, out AssetScenarioId? assetScenarioId))
            {
                scenario = await _manager.GetScenario(id);
            }

            return Ok(scenario);
        }

        [HttpGet("api/scenarios/{id}")]
        public async Task<IActionResult> GetScenario([FromRoute] string id)
        {
            Scenario? scenario = await _manager.GetScenario(id);

            return Ok(scenario);
        }

        [HttpPost("api/scenarios/{id}/run")]
        public async Task<IActionResult> Run([FromRoute] string id)
        {
            string? jobId = await _manager.Run(id);

            return !string.IsNullOrEmpty(jobId) ? Ok(jobId) : BadRequest();
        }

        [HttpPut("api/scenarios/{scenarioId}/asset-scenarios/{id}")]
        public async Task<IActionResult> Update([FromRoute] string scenarioId, [FromRoute] string id, [FromBody] AssetScenario scenario)
        {
            AssetScenario updated = await _manager.Update(scenario);

            return Ok(updated);
        }

        [HttpPut("api/scenarios/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Scenario scenario)
        {
            Scenario updated = await _manager.Update(scenario);

            return Ok(updated);
        }

        [HttpPut("api/scenarios/{scenarioId}/market-scenarios/{id}")]
        public async Task<IActionResult> Update([FromRoute] string scenarioId, [FromRoute] string id, [FromBody] MarketScenario scenario)
        {
            MarketScenario updated = await _manager.Update(scenario);

            return Ok(updated);
        }
    }
}
