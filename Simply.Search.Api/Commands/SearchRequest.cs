using MediatR;

namespace Simply.Seacrh.Api.Commands
{
    public class SearchRequest : IRequest<string>
    {
        public string Search { get; set; }
        public string SearchUrl { get; set; }
    }
}