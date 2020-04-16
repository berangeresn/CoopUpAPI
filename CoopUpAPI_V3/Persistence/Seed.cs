using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(CoopUpContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "1",
                        DisplayName = "Solaine Lamare",
                        UserName = "solaine",
                        Email = "solaine.lamare@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "2",
                        DisplayName = "Colette Pirouet",
                        UserName = "colette",
                        Email = "cosette.pirouet@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "3",
                        DisplayName = "Bernard Coulombe",
                        UserName = "bernard",
                        Email = "bernard.coulombe@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "4",
                        DisplayName = "Victor Barjavel",
                        UserName = "victor",
                        Email = "victor.bargavel@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "5",
                        DisplayName = "Nicole Auberjonois",
                        UserName = "nicole",
                        Email = "nicole.auberjonois@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "6",
                        DisplayName = "Carlotta Mouret",
                        UserName = "carlotta",
                        Email = "carlotta.mouret@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "7",
                        DisplayName = "Carine Loisel",
                        UserName = "carine",
                        Email = "carine.loisel@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "8",
                        DisplayName = "William Barrientos",
                        UserName = "william",
                        Email = "william.barrientos@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "9",
                        DisplayName = "Martin Leroux",
                        UserName = "martin",
                        Email = "martin.leroux@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "10",
                        DisplayName = "Audrey Masset",
                        UserName = "audrey",
                        Email = "audrey.masset@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "11",
                        DisplayName = "Gaël Henrichon",
                        UserName = "gael",
                        Email = "gael.henrichon@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "12",
                        DisplayName = "Richard Goncalves",
                        UserName = "richard",
                        Email = "richard.goncalves@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "13",
                        DisplayName = "Léon Jacquot",
                        UserName = "leon",
                        Email = "leon.jacquot@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "14",
                        DisplayName = "Eléonore Durand",
                        UserName = "eleonore",
                        Email = "eleonore.durand777@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "15",
                        DisplayName = "Alix Henry",
                        UserName = "alix",
                        Email = "alix@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "16",
                        DisplayName = "Thibault Leblanc",
                        UserName = "thibault",
                        Email = "thibault.leblanc@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "17",
                        DisplayName = "Patricia Lebreton",
                        UserName = "patricia",
                        Email = "patricia@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "18",
                        DisplayName = "Pauline Mallet",
                        UserName = "pauline",
                        Email = "pauline@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "19",
                        DisplayName = "Laurent Lambert",
                        UserName = "laurent",
                        Email = "laurent.lambert@gmail.com",
                    },
                    new AppUser
                    {
                        Id = "20",
                        DisplayName = "Susan Colas",
                        UserName = "susan",
                        Email = "susan.colas@gmail.com",
                    }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!context.Articles.Any())
            {
                var articles = new List<Article>
                {
                    new Article
                    {
                        Title = "Bienvenue à la coopérative Coop'Up ! L'Expérience Entreprendre !",
                        Description = "Vous recherchez des professionnels indépendants ?",
                        Category = "Général",
                        Content = "Contenu de l'article 1 Bienvenue à la coopérative Coop'Up ! L'Expérience Entreprendre !",
                        Date = DateTime.Now.AddMonths(-3),
                        Image = "Image 01",
                        UserArticles = new List<UserArticle>
                        {
                            new UserArticle
                            {
                                AppUserId = "7",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-3)
                            }
                        }
                    },
                    new Article
                    {
                        Title = "Réunions d'informations",
                        Description = "Vous souhaitez en savoir plus ?",
                        Category = "Général",
                        Content = "Contenu de l'article 2 Réunions d'informations",
                        Date = DateTime.Now.AddMonths(-3),
                        Image = "Image 02",
                        UserArticles = new List<UserArticle>
                        {
                            new UserArticle
                            {
                                AppUserId = "7",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-3)
                            }
                        }
                    },
                    new Article
                    {
                        Title = "Mettez en ligne votre besoin !",
                        Description = "Remplissez votre annonce",
                        Category = "Général",
                        Content = "Contenu de l'article 3 Mettez en ligne votre besoin",
                        Date = DateTime.Now.AddMonths(-3),
                        Image = "Image 03",
                        UserArticles = new List<UserArticle>
                        {
                            new UserArticle
                            {
                                AppUserId = "7",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-3)
                            }
                        }
                    },
                    new Article
                    {
                        Title = "Les meilleurs coopérateurs se trouvent ici !",
                        Description = "Qui recherchez-vous ?",
                        Category = "Général",
                        Content = "Contenu de l'article 4 Les meilleurs coopérateurs se trouvent ici !",
                        Date = DateTime.Now.AddMonths(-3),
                        Image = "Image 04",
                        UserArticles = new List<UserArticle>
                        {
                            new UserArticle
                            {
                                AppUserId = "7",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-3)
                            }
                        }
                    },
                    new Article
                    {
                        Title = "Entrepreneurs, sécurisez vos activités By Coop'Up !",
                        Description = "Sécurisez vos activités en toute confiance",
                        Category = "Général",
                        Content = "Contenu de l'article 5 Entrepreneurs, sécurisez vos activités By Coop'Up !",
                        Date = DateTime.Now.AddMonths(-3),
                        Image = "Image 05",
                        UserArticles = new List<UserArticle>
                        {
                            new UserArticle
                            {
                                AppUserId = "7",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-3)
                            }
                        }
                    },
                    new Article
                    {
                        Title = "Qu'est-ce que la coopérative Coop'Up ?",
                        Description = "Coop'Up est une coopérative d'activités et d'emplois",
                        Category = "Général",
                        Content = "Contenu de l'article 6 Entrepreneurs, Qu'est-ce que la coopérative Coop'Up ?",
                        Date = DateTime.Now.AddMonths(-3),
                        Image = "Image 06",
                        UserArticles = new List<UserArticle>
                        {
                            new UserArticle
                            {
                                AppUserId = "7",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-3)
                            }
                        }
                    },
                    new Article
                    {
                        Title = "La coopérative: la réponse au changement de mode de travail ?",
                        Description = "En quoi une coopérative est la réponse au changement de modèle dans le travail salarié des années à venir ?",
                        Category = "Blog",
                        Content = "Contenu de l'article 7 En quoi une coopérative est la réponse au changement de modèle dans le travail salarié des années à venir ?",
                        Date = DateTime.Now.AddMonths(-2),
                        Image = "Image 07",
                        UserArticles = new List<UserArticle>
                        {
                            new UserArticle
                            {
                                AppUserId = "7",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-2)
                            }
                        }
                    },
                    new Article
                    {
                        Title = "Comment fonctionne la coopérative ?",
                        Description = " ",
                        Category = "Général",
                        Content = "Contenu de l'article 8 Comment fonctionne la coopérative ?",
                        Date = DateTime.Now.AddMonths(-3),
                        Image = "Image 08",
                        UserArticles = new List<UserArticle>
                        {
                            new UserArticle
                            {
                                AppUserId = "7",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-3)
                            }
                        }
                    },
                    new Article
                    {
                        Title = "Le Concept de la SCOP CAE",
                        Description = "Qu'est-ce qu'une coopérative ?",
                        Category = "Général",
                        Content = "Contenu de l'article 9 Le Concept de la SCOP CAE",
                        Date = DateTime.Now.AddMonths(-3),
                        Image = "Image 09",
                        UserArticles = new List<UserArticle>
                        {
                            new UserArticle
                            {
                                AppUserId = "7",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-3)
                            }
                        }
                    },
                    new Article
                    {
                        Title = "Comment fonctionne la plateforme ?",
                        Description = "Présentation de la plateforme",
                        Category = "Général",
                        Content = "Contenu de l'article 10 Comment fonctionne la plateforme ?",
                        Date = DateTime.Now.AddMonths(-3),
                        Image = "Image 10",
                        UserArticles = new List<UserArticle>
                        {
                            new UserArticle
                            {
                                AppUserId = "7",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-3)
                            }
                        }
                    }
                };

                context.AddRange(articles);
                context.SaveChanges();
            }
        }
    }
}
