using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts.ReasonsForLiberation;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReasonsForLiberationController : ControllerBase
    {
        private IReasonsForLiberationService _reasonsForLiberationService;

        public ReasonsForLiberationController(IReasonsForLiberationService reasonsForLiberationService)
        {
            _reasonsForLiberationService = reasonsForLiberationService;
        }

        /// <summary>
        /// Получение всех причин освобождения
        /// </summary>
        /// <returns>Список всех причин освобождения</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reasons = await _reasonsForLiberationService.GetAll();
            var response = reasons.Adapt<List<GetReasonsForLiberationResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение причины освобождения по ID
        /// </summary>
        /// <param name="id">ID причины освобождения</param>
        /// <returns>Данные причины освобождения</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _reasonsForLiberationService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetReasonsForLiberationResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой причины освобождения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /ReasonsForLiberation
        ///     {
        ///        "idПричины" : 1,
        ///        "кодПричины" : "B-01",
        ///        "название" : "Заболевание",
        ///        "максДней" : 30,
        ///        "требуетСправку" : true
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Причина освобождения</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateReasonsForLiberationRequest request)
        {
            var reasonDto = request.Adapt<ПричиныОсвобождения>();
            await _reasonsForLiberationService.Create(reasonDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных причины освобождения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /ReasonsForLiberation
        ///     {
        ///        "idПричины" : 1,
        ///        "кодПричины" : "B-01",
        ///        "название" : "Заболевание (обновленное)",
        ///        "максДней" : 45,
        ///        "требуетСправку" : true
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Причина освобождения</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateReasonsForLiberationRequest request)
        {
            var reasonDto = request.Adapt<ПричиныОсвобождения>();
            await _reasonsForLiberationService.Update(reasonDto);
            return Ok();
        }

        /// <summary>
        /// Удаление причины освобождения
        /// </summary>
        /// <param name="id">ID причины освобождения</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reasonsForLiberationService.Delete(id);
            return Ok();
        }
    }
}