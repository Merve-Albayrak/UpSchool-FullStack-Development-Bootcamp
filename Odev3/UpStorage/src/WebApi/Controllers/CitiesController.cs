
using Application.Features.Cities.Queries.GetAll;
using Application.Features.Excel.Commands.ReadCities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers                                                      
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ApiControllerBase
    {
        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> AddAsync(ExcelReadCitiesCommand command)
        {
           
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(CityGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await Mediator.Send(new CityGetAllQuery(id,false                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            )));
        }

    }
}
