using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using Simply.Seacrh.Api.Commands;
using MediatR;

namespace Simply.Search.Api.Controllers
{
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
