using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace HelloWorld.Data
{
    public class RepositoryBase<T> where T : class
    {
        public DataContext db = null;
        protected DbSet<T> DbSet { get; set; }
        //-------------------------------------------------------------------------------------------------  
        //-------------------------------------------------------------------------------------------------  
        public RepositoryBase(DataContext DB)
        {
            if (db == null)
                db = DB;
            DbSet = db.Set<T>();
        }
        //-------------------------------------------------------------------------------------------------  
        #region Base Functions
        //-------------------------------------------------------------------------------------------------  
        public virtual T Get(int id)
        {
            return DbSet.Find(id);
        }
        //-------------------------------------------------------------------------------------------------  
        //--------------------------------------------------------------------------------------------  ADD
        public virtual T Add(T entity)
        {
            DbEntityEntry dbEntityEntry = db.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }

            return entity;
        }
        //-------------------------------------------------------------------------------------------------  
        //-----------------------------------------------------------------------------------------  UPDATE
        public virtual T Update(T entity)
        {
            DbEntityEntry dbEnitityEntry = db.Entry(entity);
            if (dbEnitityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEnitityEntry.State = EntityState.Modified;
            return entity;
        }
        //-------------------------------------------------------------------------------------------------  
        //----------------------------------------------------------------------------------------  DESTROY
        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEnitityEntry = db.Entry(entity);
            if (dbEnitityEntry.State != EntityState.Deleted)
            {
                dbEnitityEntry.State = EntityState.Deleted;
            }
        }
        //-------------------------------------------------------------------------------------------------  
        #endregion
        //-------------------------------------------------------------------------------------------------
    }
}
