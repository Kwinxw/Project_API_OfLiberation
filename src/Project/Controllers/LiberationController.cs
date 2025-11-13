using Domain.Interfaces;
using DataAccess.Models;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts.Liberation;
using Mapster;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiberationController : ControllerBase
    {
        private ILiberationService _liberationService;

        public LiberationController(ILiberationService liberationService)
        {
            _liberationService = liberationService;
        }

        /// <summary>
        /// Получение всех освобождений
        /// </summary>
        /// <returns>Список всех освобождений</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var liberations = await _liberationService.GetAll();
            var response = liberations.Adapt<List<GetLiberationResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение освобождения по ID
        /// </summary>
        /// <param name="id">ID освобождения</param>
        /// <returns>Освобождение с указанным ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _liberationService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetLiberationResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового освобождения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Liberation
        ///     {
        ///        "idСтудента" : 1,
        ///        "idПричины" : 2,
        ///        "датаНачала" : "2024-01-15",
        ///        "датаОкончания" : "2024-01-20",
        ///        "номерСправки" : "СП-123456",
        ///        "кемВыдано" : "Поликлиника №1",
        ///        "примечание" : "ОРВИ"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Данные освобождения</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateLiberationRequest request)
        {
            var liberationDto = request.Adapt<Освобождения>();
            await _liberationService.Create(liberationDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных освобождения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Liberation
        ///     {
        ///        "idОсвобождения" : 1,
        ///        "idСтудента" : 1,
        ///        "idПричины" : 2,
        ///        "датаНачала" : "2024-01-15",
        ///        "датаОкончания" : "2024-01-25",
        ///        "номерСправки" : "СП-123456",
        ///        "кемВыдано" : "Поликлиника №1",
        ///        "примечание" : "ОРВИ с осложнениями"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Обновленные данные освобождения</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateLiberationRequest request)
        {
            var liberationDto = request.Adapt<Освобождения>();
            await _liberationService.Update(liberationDto);
            return Ok();
        }

        /// <summary>
        /// Удаление освобождения по ID
        /// </summary>
        /// <param name="id">ID освобождения для удаления</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _liberationService.Delete(id);
            return Ok();
        }
    }
}