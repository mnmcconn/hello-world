using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld.Data
{

    public class HelloWorldRepository : RepositoryBase<HelloWorld>
    {
        private List<HelloWorld> helloWorlds = new List<HelloWorld>();

        public HelloWorldRepository(DataContext DB) : base(DB)
        {
            Populate();
        }

        // ***************************************************************//
        // *** Future Enhancement *** SQL Server Entity Framework Backend  
        //
        // At this time the Get method only returns a message in an in-memory array.
        //
        // ***************************************************************//
        public override HelloWorld Get(int id)
        {
            return helloWorlds.Where(h => h.ID == id).FirstOrDefault();
        }

        public List<HelloWorld> ListAll()
        {
            return helloWorlds.ToList();
        }
        public override HelloWorld Add(HelloWorld entity)
        {
            entity.CreatedBy = "SYSTEM";
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
            return entity;
        }
        private void Populate()
        {
            int index = 1;
            foreach (string msg in Properties.Settings.Default.MessageList)
            {
                helloWorlds.Add(new HelloWorld
                {
                    ID = index,
                    Message = msg
            });
                index += 1;
            }
        }
    }
}
