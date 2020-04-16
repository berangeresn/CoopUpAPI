using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Articles
{
    public class List
    {
        public class Query : IRequest<List<ArticleDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<ArticleDto>>
        {
            private readonly CoopUpContext _context;
            private readonly IMapper _mapper;

            public Handler(CoopUpContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<ArticleDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var articles = await _context.Articles.ToListAsync();

                return _mapper.Map<List<Article>, List<ArticleDto>>(articles);
            }
        }
    }
}