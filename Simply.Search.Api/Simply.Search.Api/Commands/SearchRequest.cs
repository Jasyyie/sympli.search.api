using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;
using Simply.Search.Api.Models;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Simply.Seacrh.Api.Commands
{
    public class SearchRequest : IRequest<string>
    {
        public string Search { get; set; }
        public string SearchUrl { get; set; }
    }
}