using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Articles
{
    // permet à l'utilisateur de signaler sa présence à un événement
    
    public class Attend
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly CoopUpContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(CoopUpContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var article = await _context.Articles.FindAsync(request.Id);

                if (article == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Article = "Article introuvable" });

                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());

                var attendance = await _context.UserArticles.SingleOrDefaultAsync(x => x.ArticleId == article.Id && x.AppUserId == user.Id);

                if (attendance == null)
                    throw new RestException(HttpStatusCode.BadRequest, new {Attendance = "déjà associé(e) à cet article"});
                
                attendance = new UserArticle
                {
                    Article = article,
                    AppUser = user,
                    IsHost = false,
                    DateJoined = DateTime.Now
                };

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Erreur survenue pendant la sauvegarde des données");
            }
        }
    }
}