using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User
{
    [Key]
    public int Id { get; set; }
    [Column("Login")]

    public string Login { get; set; }
    [Column("Password")]

    public string Password { get; set; }

    public User() { }

    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }


}
