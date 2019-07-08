using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using game_nation_admin_service.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace game_nation_admin_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly StatisticsRepository _statisticsRepository;
        
        public StatisticsController(StatisticsRepository statisticsRepository)
        {
            this._statisticsRepository = statisticsRepository;
        }
    }
}
