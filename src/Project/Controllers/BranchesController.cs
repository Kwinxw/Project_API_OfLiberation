using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts.Branches;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private IBranchesService _branchesService;

        public BranchesController(IBranchesService branchesService)
        {
            _branchesService = branchesService;
        }

        /// <summary>
        /// Получение всех отделений
        /// </summary>
        /// <returns>Список всех отделений</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branches = await _branchesService.GetAll();
            var response = branches.Adapt<List<GetBranchesResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение отделения по ID
        /// </summary>
        /// <param name="id">ID отделения</param>
        /// <returns>Данные отделения</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _branchesService.GetById(id);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GetBranchesResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового отделения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Branches
        ///     {
        ///        "idОтделения" : 1,
        ///        "название" : "Терапевтическое отделение",
        ///        "заведующий" : "Иванов Иван Иванович",
        ///        "датаСоздания" : "2024-01-15T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Отделение</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateBranchesRequest request)
        {
            var branchDto = request.Adapt<Отделения>();
            await _branchesService.Create(branchDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных отделения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Branches
        ///     {
        ///        "idОтделения" : 1,
        ///        "название" : "Терапевтическое отделение (обновленное)",
        ///        "заведующий" : "Петров Петр Петрович",
        ///        "датаСоздания" : "2024-01-15T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Отделение</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBranchesRequest request)
        {
            var branchDto = request.Adapt<Отделения>();
            await _branchesService.Update(branchDto);
            return Ok();
        }

        /// <summary>
        /// Удаление отделения по ID
        /// </summary>
        /// <param name="id">ID отделения</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _branchesService.Delete(id);
            return Ok();
        }
    }
}