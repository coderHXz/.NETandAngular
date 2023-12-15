using Domain;

namespace Business_Logic_Layer.Interfaces
{
    public interface ILoginService
    {
        Task<UserModel> ValidateUserCredentials(string username, string password);
        string GenerateJwtToken(UserModel user);
    }
}
