using System;
using Simply.Seacrh.Api.Commands;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;

namespace Simply.Search.Services
{
    public interface IGoogleService
    {
        Task<string> GoogleSearchResultUrls(SearchRequest request);

    }
}

