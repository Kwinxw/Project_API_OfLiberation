using Domain.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Project.Contracts.Load;
using Mapster;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadController : ControllerBase
    {
        private ILoadService _нагрузкаService;

        public LoadController(ILoadService нагрузкаService)
        {
            _нагрузкаService = нагрузкаService;
        }

        /// <summary>
        /// Получение списка всей нагрузки
        /// </summary>
        /// <returns>Список записей нагрузки</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loads = await _нагрузкаService.GetAll();
            var response = loads.Adapt<List<GetLoadResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение нагрузки по ID
        /// </summary>
        /// <param name="id">ID нагрузки</param>
        /// <returns>Запись нагрузки</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _нагрузкаService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetLoadResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой записи нагрузки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Load
        ///     {
        ///        "idНагрузки" : 0,
        ///        "idПреподавателя" : 1,
        ///        "idГруппы" : 1,
        ///        "семестр" : 1,
        ///        "учебныйГод" : 2024
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Объект нагрузки</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateLoadRequest request)
        {
            var loadDto = request.Adapt<Нагрузка>();
            await _нагрузкаService.Create(loadDto);
            return Ok();
        }

        /// <summary>
        /// Обновление записи нагрузки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Load
        ///     {
        ///        "idНагрузки" : 1,
        ///        "idПреподавателя" : 1,
        ///        "idГруппы" : 1,
        ///        "семестр" : 2,
        ///        "учебныйГод" : 2024
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Объект нагрузки</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateLoadRequest request)
        {
            var loadDto = request.Adapt<Нагрузка>();
            await _нагрузкаService.Update(loadDto);
            return Ok();
        }

        /// <summary>
        /// Удаление записи нагрузки по ID
        /// </summary>
        /// <param name="id">ID нагрузки</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _нагрузкаService.Delete(id);
            return Ok();
        }
    }
}