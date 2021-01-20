using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simply.Seacrh.Api.Commands;
using System;
using Simply.Search.Services;

namespace Simply.Search.Api.Handlers
{
    public class SearchHandler : IRequestHandler<SearchRequest, string>
    {
        private readonly IGoogleService _googleService;

        public SearchHandler(IGoogleService googleService)
        {
            _googleService = googleService;
        }

        public async Task<string> Handle(SearchRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var GoogleSearchResultUrls = await _googleService.Search(request);
                return GoogleSearchResultUrls;
            }

            catch (Exception ex)
            {
                // Logger.log(ex.Message);
            }
            return "exception occured, we are looking into it";

        }

    }
}