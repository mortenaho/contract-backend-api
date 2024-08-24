using System.ComponentModel.DataAnnotations;

namespace Entities;

public class User
{
    [Key]
    public long UserId { set; get; }
    [Required]
    public string Username { set; get; }
    [Required]
    public string Password { set; get; }

    public bool IsActive { set; get; } = true;
    public string Fullname { set; get; }
}