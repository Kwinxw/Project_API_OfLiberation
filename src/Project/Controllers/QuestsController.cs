using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts.Quests;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestsController : ControllerBase
    {
        private IQuestsService _questsService;

        public QuestsController(IQuestsService questsService)
        {
            _questsService = questsService;
        }

        /// <summary>
        /// Получение всех заданий
        /// </summary>
        /// <returns>Список всех заданий</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quests = await _questsService.GetAll();
            var response = quests.Adapt<List<GetQuestsResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение задания по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор задания</param>
        /// <returns>Задание</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _questsService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetQuestsResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Получение заданий по идентификатору студента
        /// </summary>
        /// <param name="studentId">Идентификатор студента</param>
        /// <returns>Список заданий студента</returns>
        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            var quests = await _questsService.GetByStudentId(studentId);
            var response = quests.Adapt<List<GetQuestsResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение заданий по идентификатору освобождения
        /// </summary>
        /// <param name="liberationId">Идентификатор освобождения</param>
        /// <returns>Список заданий для освобождения</returns>
        [HttpGet("liberation/{liberationId}")]
        public async Task<IActionResult> GetByLiberationId(int liberationId)
        {
            var quests = await _questsService.GetByLiberationId(liberationId);
            var response = quests.Adapt<List<GetQuestsResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение просроченных заданий
        /// </summary>
        /// <returns>Список просроченных заданий</returns>
        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdueQuests()
        {
            var quests = await _questsService.GetOverdueQuests();
            var response = quests.Adapt<List<GetQuestsResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового задания
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Quests
        ///     {
        ///        "idОсвобождения" : 1,
        ///        "idТипаЗадания" : 2,
        ///        "датаНазначения" : "2024-01-15",
        ///        "срокСдачи" : "2024-02-01",
        ///        "тема" : "Математический анализ",
        ///        "описание" : "Решить задачи по интегралам"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Задание</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestsRequest request)
        {
            var questDto = request.Adapt<Задания>();
            await _questsService.Create(questDto);
            return Ok(new { message = "Задание успешно создано" });
        }

        /// <summary>
        /// Обновление задания
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Quests
        ///     {
        ///        "idЗадания" : 1,
        ///        "idОсвобождения" : 1,
        ///        "idТипаЗадания" : 2,
        ///        "датаНазначения" : "2024-01-15",
        ///        "срокСдачи" : "2024-02-05",
        ///        "тема" : "Математический анализ - обновлено",
        ///        "описание" : "Решить задачи по интегралам и производным"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Задание</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuestsRequest request)
        {
            var questDto = request.Adapt<Задания>();
            await _questsService.Update(questDto);
            return Ok(new { message = "Задание успешно обновлено" });
        }

        /// <summary>
        /// Удаление задания
        /// </summary>
        /// <param name="id">Идентификатор задания</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _questsService.Delete(id);
            return Ok(new { message = "Задание успешно удалено" });
        }
    }
}