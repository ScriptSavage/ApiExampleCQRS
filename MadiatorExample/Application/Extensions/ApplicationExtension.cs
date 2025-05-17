using Application.Commands.CreateAuthor;
using Application.Commands.CreateBook;
using Application.Commands.CreateGenre;
using Application.Commands.CreateNewUser;
using Application.Commands.LoginUser;
using Application.Queries.GetAllBooks;
using Application.Queries.GetAllGenres;
using Application.Queries.GetBookDetails;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ApplicationExtension
{

    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateAuthorCommand));
        services.AddMediatR(typeof(CreateGenreCommand));
        
        services.AddMediatR(typeof(GetAllBooksQuery));
        services.AddMediatR(typeof(GetGenresQuery));
        services.AddMediatR(typeof(GetBookDetailsQuery));

        services.AddMediatR(typeof(CreateNewUserCommand));
        services.AddMediatR(typeof(LoginUserCommand));
    }
    
    
}