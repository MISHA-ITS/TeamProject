namespace WebWorker.Models.Users;

//Модель для створення користувача
public class UserCreateModel
{
    public string? FirstName { get; set; } = null;
    public string? LastName { get; set; } = null;
    public string Email { get; set; } = string.Empty;
}
