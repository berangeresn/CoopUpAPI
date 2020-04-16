using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Articles
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Content { get; set; }
            public string Category { get; set; }
            public DateTime? Date { get; set; }
            public string Image { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Category).NotEmpty();
                RuleFor(x => x.Content).NotEmpty();
                RuleFor(x => x.Date).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly CoopUpContext _context;

            public Handler(CoopUpContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var article = await _context.Articles.FindAsync(request.Id);

                if (article == null)
                    throw new RestException(HttpStatusCode.NotFound, new {article = "introuvable"});

                article.Title = request.Title ?? article.Title;
                article.Description = request.Description ?? article.Description;
                article.Content = request.Content ?? article.Content;
                article.Category = request.Category ?? article.Category;
                article.Date = request.Date ?? article.Date;
                article.Image = request.Image ?? article.Image;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Erreur survenue pendant la modification de l'article");
            }
        }
    }
}