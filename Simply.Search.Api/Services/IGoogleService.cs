using Simply.Seacrh.Api.Commands;
using System.Threading.Tasks;

namespace Simply.Search.Services
{
    public interface IGoogleService
    {
        Task<string> Search(SearchRequest request);


    }
}

