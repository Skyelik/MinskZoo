using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Admin")]
public class Admin
{
    [Key]
    public int Id { get; set; }
    [Column("Login")]

    public string Login { get; set; }
    [Column("Password")]

    public string Password { get; set; }
   
    public Admin() { }

    public Admin(string login, string password)
    {
        Login = login;
        Password = password;
    }


}
