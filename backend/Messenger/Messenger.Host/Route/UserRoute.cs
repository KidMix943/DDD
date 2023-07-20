
using Messenger.Domain;

namespace Messenger.Host.Route
{
    public static class UserRoute
    {
        public static WebApplication AddUserRouter(this WebApplication app)
        {
            var routeGroup = app.MapGroup("/api/users");
            routeGroup.MapGet("/", GetAllUsers);
            routeGroup.MapGet("/{id:long}", GetUserById);
            routeGroup.MapGet("/info/{id:long}", UserInfo);
            routeGroup.MapPost("/", CreateUser);
            routeGroup.MapPut("/", UpdateUser);
            routeGroup.MapDelete( "/{id:long}", DeleteUser);
            return app;
        }

        private static async Task<IResult> GetAllUsers(IUserManager userManager)
        {
            var users = await userManager.GetAll();
            return Results.Ok(users);
        }
        private static async Task<IResult> GetUserById(long id, IUserManager userManager)
        {
            var user = await userManager.GetById(id);
            return user is null
                ? Results.NotFound()
                : Results.Ok(user);
        }
        private static async Task<IResult> UserInfo(long id, IUserManager userManager)
        {
            var user = await userManager.Info(id);
            return user is null
                ? Results.NotFound()
                : Results.Ok(user);
        }
        private static async Task<IResult> CreateUser(User user, IUserManager userManager)
        {
            var createdUser = await userManager.Create(user);
            return Results.Ok(createdUser);
        }
        private static async Task<IResult> UpdateUser(long id, User user, IUserManager userManager)
        {
            var updatedUser = await userManager.Update(id, user);
            return updatedUser is null
                ? Results.NotFound()
                : Results.Ok(updatedUser);
        }

        private static async Task<IResult> DeleteUser(long id, IUserManager userManager)
        {
            var deletedUser = await userManager.Delete(id);
            return deletedUser is null
                ? Results.NotFound()
                : Results.Ok(deletedUser);
        }
    }
}
