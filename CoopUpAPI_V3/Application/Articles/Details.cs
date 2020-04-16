using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Articles
{
    public class Details
    {
        public class Query : IRequest<ArticleDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ArticleDto>
        {
            private readonly CoopUpContext _context;
            private readonly IMapper _mapper;
            public Handler(CoopUpContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ArticleDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var article = await _context.Articles
                    .FindAsync(request.Id);

                if (article == null)
                    throw new RestException(HttpStatusCode.NotFound, new { article = "introuvable" });
                
                var articleToReturn = _mapper.Map<Article, ArticleDto>(article);

                return articleToReturn;
            }
        }
    }
}