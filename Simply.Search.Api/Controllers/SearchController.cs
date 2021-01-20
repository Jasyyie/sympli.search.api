using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simply.Seacrh.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Cors;

namespace Simply.Search.Api.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get(string searchKeyword, string searchUrl)
        {
            var searchRequest = new SearchRequest();
            searchRequest.Search = searchKeyword;
            searchRequest.SearchUrl = searchUrl;
            var response = await _mediator.Send(searchRequest);
            return response;


        }

    }
}
