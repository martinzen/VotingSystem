using Microsoft.EntityFrameworkCore;

namespace SandBox.EFCore
{
    public class AppDbContext : DbContext 
    {
 

       public DbSet<Fruit> Fruits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Database");
        }
    }

    public class Fruit 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
            var ctx = new AppDbContext();

            var oragne = new Fruit { Name = "Orange" };

            ctx.Add(oragne);


            var fruit = ctx.Fruits.FirstOrDefault();

            Console.ReadLine();

            


        }
    }
}
