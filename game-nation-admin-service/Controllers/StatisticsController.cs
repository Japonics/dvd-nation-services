using game_nation_admin_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace game_nation_admin_service.Controllers
{
    [Route("api/admin/statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly StatisticsService _statisticsService;
        
        public StatisticsController(StatisticsService statisticsService)
        {
            this._statisticsService = statisticsService;
        }
    }
}
