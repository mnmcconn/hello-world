using System.Data.Entity;

namespace HelloWorld.Data
{
    /// <summary>
    /// DataContext: Common Data Definitions mapping Entities to data tables
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext() : base("HelloWorldEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
       
        public DbSet<HelloWorld> HelloWorlds { get; set; }      
    }
}
