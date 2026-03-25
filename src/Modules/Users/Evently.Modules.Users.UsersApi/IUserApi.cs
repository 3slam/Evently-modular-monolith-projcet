namespace Evently.Modules.Users.UsersApi;

public interface IUserApi
{
   Task<UserReponse?> GetUserAsync(Guid id);
}
