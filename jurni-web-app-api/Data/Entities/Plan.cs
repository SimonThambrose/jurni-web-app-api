namespace jurni_web_app_api.Data.Entities;

/**
 * This class represents a plan, which a user is able to subscribe to.
 * A plan has the following properties:
 * - Id: The unique identifier of the plan.
 * - Name: The name of the plan.
 * - Price: The price of the plan.
 * - Description: The description of the plan.
 * - Users: The users subscribed to the plan.
 */
public class Plan
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "varchar(45)")]
    public string Name { get; set; }
    public double? Price { get; set; }
    
    [Column(TypeName = "varchar(500)")]
    public string? Description { get; set; }
    public ICollection<User>? Users { get; set; }
}