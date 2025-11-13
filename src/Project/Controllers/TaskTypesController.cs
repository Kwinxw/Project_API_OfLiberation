using Domain.Interfaces;
using DataAccess.Models;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts.TaskType;
using Mapster;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTypesController : ControllerBase
    {
        private ITaskTypesService _taskTypesService;

        public TaskTypesController(ITaskTypesService taskTypesService)
        {
            _taskTypesService = taskTypesService;
        }

        /// <summary>
        /// Получение всех типов заданий
        /// </summary>
        /// <returns>Список всех типов заданий</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var taskTypes = await _taskTypesService.GetAll();
            var response = taskTypes.Adapt<List<GetTaskTypeResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение типа задания по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор типа задания</param>
        /// <returns>Тип задания</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _taskTypesService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetTaskTypeResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового типа задания
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /TaskTypes
        ///     {
        ///        "idТипаЗадания" : 0,
        ///        "кодЗадания" : "TASK001",
        ///        "название" : "Практическое задание",
        ///        "описание" : "Описание практического задания",
        ///        "максБалл" : 100
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Тип задания</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateTaskTypeRequest request)
        {
            var taskTypeDto = request.Adapt<ТипыЗаданий>();
            await _taskTypesService.Create(taskTypeDto);
            return Ok();
        }

        /// <summary>
        /// Обновление типа задания
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /TaskTypes
        ///     {
        ///        "idТипаЗадания" : 1,
        ///        "кодЗадания" : "TASK001",
        ///        "название" : "Обновленное задание",
        ///        "описание" : "Обновленное описание задания",
        ///        "максБалл" : 150
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Тип задания</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTaskTypeRequest request)
        {
            var taskTypeDto = request.Adapt<ТипыЗаданий>();
            await _taskTypesService.Update(taskTypeDto);
            return Ok();
        }

        /// <summary>
        /// Удаление типа задания
        /// </summary>
        /// <param name="id">Идентификатор типа задания</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskTypesService.Delete(id);
            return Ok();
        }
    }
}