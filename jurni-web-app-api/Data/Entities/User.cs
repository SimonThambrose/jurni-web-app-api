namespace jurni_web_app_api.Data.Entities;

/**
 * This class represents a user of the application.
 * A user has the following properties:
 * - Id: The unique identifier of the user.
 * - FirstName: The first name of the user.
 * - LastName: The last name of the user.
 * - Email: The email of the user.
 * - PasswordSalt: The salt of the password of the user.
 * - PasswordHash: The hash of the password of the user.
 * - PlanId: The unique identifier of the plan of the user.
 * - Plan: The plan of the user.
 * - IsAdmin: A boolean value indicating whether the user is an administrator.
 * - CreatedAt: The date and time when the user was created.
 * - UpdatedAt: The date and time when the user was last updated.
 * - Blogs: The blogs created by the user.
 */
public class User
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(45, MinimumLength = 1)]
    public string FirstName { get; set; }

    [Required, StringLength(45, MinimumLength = 1, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    public string LastName { get; set; }

    [Required, StringLength(90, MinimumLength = 5)]
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public int? PlanId { get; set; }
    public Plan? Plan { get; set; }
    public bool IsAdmin { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
    public ICollection<Blog>? Blogs { get; set; }
}