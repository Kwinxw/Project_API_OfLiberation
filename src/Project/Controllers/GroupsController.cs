using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts.Groups;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IGroupsService _groupService;

        public GroupController(IGroupsService groupService)
        {
            _groupService = groupService;
        }

        /// <summary>
        /// Получение всех групп
        /// </summary>
        /// <returns>Список всех групп</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupService.GetAll();
            var response = groups.Adapt<List<GetGroupsResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение группы по ID
        /// </summary>
        /// <param name="id">ID группы</param>
        /// <returns>Группа с указанным ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _groupService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetGroupsResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой группы
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Group
        ///     {
        ///        "idГруппы" : 0,
        ///        "название" : "ИТ-21",
        ///        "idСпециальности" : 1,
        ///        "курс" : 2,
        ///        "годПоступления" : 2022
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Группа</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateGroupsRequest request)
        {
            var groupDto = request.Adapt<Группы>();
            await _groupService.Create(groupDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных группы
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Group
        ///     {
        ///        "idГруппы" : 1,
        ///        "название" : "ИТ-21",
        ///        "idСпециальности" : 1,
        ///        "курс" : 3,
        ///        "годПоступления" : 2022
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Группа</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateGroupsRequest request)
        {
            var groupDto = request.Adapt<Группы>();
            await _groupService.Update(groupDto);
            return Ok();
        }

        /// <summary>
        /// Удаление группы по ID
        /// </summary>
        /// <param name="id">ID группы</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupService.Delete(id);
            return Ok();
        }
    }
}