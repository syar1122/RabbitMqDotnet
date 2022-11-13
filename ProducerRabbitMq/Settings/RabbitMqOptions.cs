namespace ProducerRabbitMq.Settings;

public class RabbitMqOptions
{
 public const string Config = "RabbitMq";

 public string Host { get; set; } = string.Empty;
 public string Password { get; set; } = string.Empty;
 public string Username { get; set; } = string.Empty;

}