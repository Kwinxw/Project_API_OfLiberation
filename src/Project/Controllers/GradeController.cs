using Domain.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Project.Contracts.Grade;
using Mapster;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        /// <summary>
        /// Получение всех оценок
        /// </summary>
        /// <returns>Список всех оценок</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grades = await _gradeService.GetAll();
            var response = grades.Adapt<List<GetGradeResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение оценки по ID
        /// </summary>
        /// <param name="id">ID оценки</param>
        /// <returns>Оценка с указанным ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _gradeService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetGradeResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой оценки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Grade
        ///     {
        ///        "idОценки" : 1,
        ///        "idЗадания" : 5,
        ///        "балл" : 85,
        ///        "датаСдачи" : "2024-01-15",
        ///        "комментарий" : "Хорошая работа",
        ///        "преподаватель" : "Иванов И.И.",
        ///        "датаОценки" : "2024-01-16T10:30:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Оценка</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateGradeRequest request)
        {
            var gradeDto = request.Adapt<Оценки>();
            await _gradeService.Create(gradeDto);
            return Ok();
        }

        /// <summary>
        /// Обновление оценки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Grade
        ///     {
        ///        "idОценки" : 1,
        ///        "idЗадания" : 5,
        ///        "балл" : 90,
        ///        "датаСдачи" : "2024-01-15",
        ///        "комментарий" : "Отличная работа",
        ///        "преподаватель" : "Иванов И.И.",
        ///        "датаОценки" : "2024-01-16T10:30:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Оценка</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateGradeRequest request)
        {
            var gradeDto = request.Adapt<Оценки>();
            await _gradeService.Update(gradeDto);
            return Ok();
        }

        /// <summary>
        /// Удаление оценки по ID
        /// </summary>
        /// <param name="id">ID оценки</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _gradeService.Delete(id);
            return Ok();
        }
    }
}