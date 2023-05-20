namespace jurni_web_app_api.Data.Entities;

/**
 * This class represents a blog, created by a user.
 * A blog has the following properties:
 * - Id: The unique identifier of the blog.
 * - Title: The title of the blog.
 * - Description: The description of the blog.
 * - AuthorId: The unique identifier of the author.
 * - Author: The author of the blog.
 * - CreatedAt: The date and time when the blog was created.
 * - UpdatedAt: The date and time when the blog was last updated.
 */
public class Blog
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [StringLength(90, MinimumLength = 1, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    public string Title { get; set; }

    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [StringLength(500, MinimumLength = 10, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    public string Description { get; set; }

    public int AuthorId { get; set; }
    public User Author { get; set; }
    public int Likes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}