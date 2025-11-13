using Domain.Interfaces;
using DataAccess.Models;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts.Specialities;
using Mapster;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private ISpecialtiesService _specialtiesService;

        public SpecialtiesController(ISpecialtiesService specialtiesService)
        {
            _specialtiesService = specialtiesService;
        }

        /// <summary>
        /// Получение всех специальностей
        /// </summary>
        /// <returns>Список всех специальностей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var specialties = await _specialtiesService.GetAll();
            var response = specialties.Adapt<List<GetSpecialitiesResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение специальности по ID
        /// </summary>
        /// <param name="id">ID специальности</param>
        /// <returns>Данные специальности</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _specialtiesService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetSpecialitiesResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой специальности
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Specialties
        ///     {
        ///        "idСпециальности" : 0,
        ///        "кодСпециальности" : "09.02.07",
        ///        "название" : "Информационные системы и программирование",
        ///        "idОтделения" : 1
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Специальность</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateSpecialitiesRequest request)
        {
            var specialtyDto = request.Adapt<Специальности>();
            await _specialtiesService.Create(specialtyDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных специальности
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Specialties
        ///     {
        ///        "idСпециальности" : 1,
        ///        "кодСпециальности" : "09.02.07",
        ///        "название" : "Информационные системы и программирование (обновленное)",
        ///        "idОтделения" : 1
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Специальность</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSpecialitiesRequest request)
        {
            var specialtyDto = request.Adapt<Специальности>();
            await _specialtiesService.Update(specialtyDto);
            return Ok();
        }

        /// <summary>
        /// Удаление специальности по ID
        /// </summary>
        /// <param name="id">ID специальности</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _specialtiesService.Delete(id);
            return Ok();
        }
    }
}