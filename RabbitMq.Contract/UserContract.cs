namespace RabbitMq.Contract;

public class UserContract
{

    public record UserCreated(int Id, string Name, int Age);

    public record UserUpdated(int Id, string Name, int Age);

    public record UserDelete(int Id);
}