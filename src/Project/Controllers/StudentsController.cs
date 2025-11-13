using Azure.Core;
using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts.Student;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _userService;

        public StudentsController(IStudentsService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение списка всех студентов
        /// </summary>
        /// <returns>Список всех студентов</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _userService.GetAll();
            var response = students.Adapt<List<GetStudentResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение студента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор студента (IdСтудента)</param>
        /// <returns>Данные студента</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetStudentResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового студента
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Students
        ///     {
        ///        "idСтудента" : 0,
        ///        "фамилия" : "Иванов",
        ///        "имя" : "Иван",
        ///        "отчество" : "Иванович",
        ///        "idГруппы" : 1,
        ///        "номерЗачетки" : "АБВ123456",
        ///        "телефон" : "+7(999)123-45-67",
        ///        "email" : "ivanov@example.com",
        ///        "датаРегистрации" : "2024-01-15T10:30:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Объект студента</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateStudentRequest request)
        {
            var studentDto = request.Adapt<Студенты>();
            await _userService.Create(studentDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных студента
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Students
        ///     {
        ///        "idСтудента" : 1,
        ///        "фамилия" : "Петров",
        ///        "имя" : "Петр",
        ///        "отчество" : "Петрович",
        ///        "idГруппы" : 2,
        ///        "номерЗачетки" : "АБВ123456",
        ///        "телефон" : "+7(999)765-43-21",
        ///        "email" : "petrov@example.com",
        ///        "датаРегистрации" : "2024-01-15T10:30:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Объект студента с обновленными данными</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentRequest request)
        {
            var studentDto = request.Adapt<Студенты>();
            await _userService.Update(studentDto);
            return Ok();
        }

        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="id">Идентификатор студента (IdСтудента)</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}