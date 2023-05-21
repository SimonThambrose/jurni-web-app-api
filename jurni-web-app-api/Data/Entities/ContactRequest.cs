namespace jurni_web_app_api.Data.Entities;

/**
 * This class represents a contact request, created by a user. A user does not have to be signed in to create a contact request.
 * A contact request has the following properties:
 * - Id: The unique identifier of the contact request.
 * - FirstName: The first name of the user who created the contact request.
 * - LastName: The last name of the user who created the contact request.
 * - Email: The email of the user who created the contact request.
 * - Message: The message of the contact request.
 * - IsEnterprisePlan: A boolean value indicating whether the user is interested in the enterprise plan.
 * - Status: The status of the contact request. If IsEnterprisePlan is true, the status can be either "Pending", "Approved" or "Denied".
 * - CreatedOn: The date and time when the contact request was created.
 * - UpdatedOn: The date and time when the contact request was last updated.
 */
public class ContactRequest
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [StringLength(45, MinimumLength = 1, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [StringLength(45, MinimumLength = 1, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    public string LastName { get; set; }

    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [StringLength(90, MinimumLength = 5, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    [EmailAddress(ErrorMessage = EntityValidations.EmailFormatMessage)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [StringLength(500, MinimumLength = 10, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    public string Message { get; set; }
    public bool IsEnterprisePlan { get; set; }
    
    [Column(TypeName = "varchar(8)")]
    public string? Status { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }
}