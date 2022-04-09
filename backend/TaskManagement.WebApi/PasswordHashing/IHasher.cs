namespace TaskManagement.WebApi.PasswordHashing
{
	public interface IHasher
    {
        string GetHashedPassword(string password);
        bool CheckPassword(string hash, string password);
    }
}