namespace jurni_web_app_api.Models;

/**
 * This class represents the user model of a user of the application.
 * A user model has the following properties:
 * - FirstName: The first name of the user.
 * - LastName: The last name of the user.
 * - Email: The email of the user.
 * - Password: The password of the user.
 */
public class UserModel
{
    [StringLength(45, MinimumLength = 1)]
    public string? FirstName { get; set; }

    [StringLength(45, MinimumLength = 1, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    public string? LastName { get; set; }

    [StringLength(90, MinimumLength = 5)]
    public string? Email { get; set; }
    public string? Password { get; set; }
}