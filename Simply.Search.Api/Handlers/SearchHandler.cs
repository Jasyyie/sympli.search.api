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
            return null;

        }



        // public Task<string> Handle(SearchRequest request, CancellationToken cancellationToken)
        //         {
        //             string apiKey = "AIzaSyA827f-ygOXWTxnijDIZBKAeNkGlKCXnYU";
        //         string cx = "07182cfc5009105d5";
        //         string query = "e-settlement";

        //         var svc = new Google.Apis.Customsearch.v1.CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
        //         var listRequest = svc.Cse.List();
        //         listRequest.Q = query;
        //             listRequest.Cx = cx;

        //             var lookupResults = new List<Google.Apis.Customsearch.v1.Data.Result>();

        //         var search = listRequest.Execute();
        //         lookupResults.AddRange(search.Items);

        //             while (search.Queries.NextPage != null)
        //             {
        //                 listRequest.Start = search.Queries.NextPage[0].StartIndex;
        //                 search = listRequest.Execute();
        //                 lookupResults.AddRange(search.Items);
        //             }

        //             // for (int i = 0; i <= 10; i++)
        //             // {
        //             //     if (search.Queries.NextPage != null)
        //             //     {
        //             //         listRequest.Start = search.Queries.NextPage[0].StartIndex;
        //             //         lookupResults.AddRange(search.Items);
        //             //     }
        //             //     else
        //             //     {
        //             //         break;
        //             //     }
        //             // }

        //             foreach (var result in lookupResults)
        //             {


        //             }
        // return null;

        //         }
    }
}