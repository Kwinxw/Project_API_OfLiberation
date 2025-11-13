using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts.Teachers;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private ITeachersService _преподавателиService;

        public TeachersController(ITeachersService преподавателиService)
        {
            _преподавателиService = преподавателиService;
        }

        /// <summary>
        /// Получение всех преподавателей
        /// </summary>
        /// <returns>Список всех преподавателей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _преподавателиService.GetAll();
            var response = teachers.Adapt<List<GetTeacherResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение преподавателя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор преподавателя</param>
        /// <returns>Данные преподавателя</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _преподавателиService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetTeacherResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового преподавателя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Teachers
        ///     {
        ///        "idПреподавателя" : 1,
        ///        "фамилия" : "Иванов",
        ///        "имя" : "Иван",
        ///        "отчество" : "Иванович",
        ///        "должность" : "Доцент",
        ///        "ставка" : 1.0
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Объект преподавателя</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateTeacherRequest request)
        {
            var teacherDto = request.Adapt<Преподаватели>();
            await _преподавателиService.Create(teacherDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных преподавателя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Teachers
        ///     {
        ///        "idПреподавателя" : 1,
        ///        "фамилия" : "Петров",
        ///        "имя" : "Петр",
        ///        "отчество" : "Петрович",
        ///        "должность" : "Профессор",
        ///        "ставка" : 1.5
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Объект преподавателя с обновленными данными</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeacherRequest request)
        {
            var teacherDto = request.Adapt<Преподаватели>();
            await _преподавателиService.Update(teacherDto);
            return Ok();
        }

        /// <summary>
        /// Удаление преподавателя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор преподавателя</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _преподавателиService.Delete(id);
            return Ok();
        }
    }
}