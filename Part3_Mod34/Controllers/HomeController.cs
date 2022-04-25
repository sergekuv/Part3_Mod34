using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Part3_Mod34.Configuration;
using Part3_Mod34.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_Mod34.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        // Инициализация конфигурации при вызове конструктора
        public HomeController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод для получения информации о доме
        /// </summary>
        [HttpGet] // Для обслуживания Get-запросов
        [Route("info")] // Настройка маршрута с помощью атрибутов
        public IActionResult Info()
        {
            // Получим запрос, "смапив" конфигурацию на модель запроса
            var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
            // Вернём ответ
            return StatusCode(200, infoResponse);
        }
    }
}
