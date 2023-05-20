using System.Security.Cryptography;
using System.Text;

namespace jurni_web_app_api.Data;

public class jurni_web_app_apiDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<ContactRequest> ContactRequests { get; set; }
    
    /*
     * Constructor.
     * <param name="options">The options to be used by a <see cref="T:Microsoft.EntityFrameworkCore.DbContext"/>.</param>
     */
    public jurni_web_app_apiDbContext(DbContextOptions<jurni_web_app_apiDbContext> options) : base(options)
    {
        
    }

    /**
     * Seeder.
     * <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
     * define extension methods on this object that allow you to configure aspects of the model that are specific
     * to a given database.
     * </param>
     * <returns>void</returns>
     */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>(user => {
            user.Property(u => u.FirstName).IsRequired().HasMaxLength(45);
            user.Property(u => u.LastName).IsRequired().HasMaxLength(45);
            user.Property(u => u.Email).IsRequired().HasMaxLength(90);

            using (var hmac = new HMACSHA512()) {
                user.HasData(new User() {
                    Id = 1, FirstName = "FIRSTNAME", LastName = "LASTNAME", Email = "EMAIL", PasswordSalt = hmac.Key,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("PASSWORD")), IsAdmin = true,
                    CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
                });
            }
        });
        
        modelBuilder.Entity<Plan>(plan => {
            plan.Property(p => p.Name).IsRequired().HasMaxLength(45);
            plan.Property(p => p.Description).HasMaxLength(500);

            plan.HasData(new Plan() {
                Id = 1, Name = "Free", Price = 0, Description = "Limited to 10 matches per day."
            });
            plan.HasData(new Plan() {
                Id = 2, Name = "Basic", Price = 10,
                Description = "Limited to 50 matches per day, with additional features."
            });
            plan.HasData(new Plan() {
                Id = 3, Name = "Premium", Price = 20,
                Description = "Unlimited matches per day, with additional features and support."
            });
            plan.HasData(new Plan() {
                Id = 4, Name = "Enterprise",
                Description = "Unlimited matches per day, with additional features and support. Response within 72 hours."
            });
        });
        
        modelBuilder.Entity<Blog>(blog => {
            blog.Property(b => b.Title).IsRequired().HasMaxLength(90);
            blog.Property(b => b.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<ContactRequest>(contactRequest => {
            contactRequest.Property(cr => cr.FirstName).IsRequired().HasMaxLength(45);
            contactRequest.Property(cr => cr.LastName).IsRequired().HasMaxLength(45);
            contactRequest.Property(cr => cr.Email).IsRequired().HasMaxLength(90);
            contactRequest.Property(cr => cr.Message).IsRequired().HasMaxLength(500);
        });
        
        modelBuilder.Entity<Plan>().HasMany(p => p.Users).WithOne(u => u.Plan).HasForeignKey(u => u.PlanId);
        modelBuilder.Entity<User>().HasMany(u => u.Blogs).WithOne(b => b.Author).HasForeignKey(b => b.AuthorId);
    }
}