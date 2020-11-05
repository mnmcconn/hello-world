using HelloWorld.Data;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;


namespace HelloWorld.API.Controllers
{
    // ***************************************************************//    
    // The Hello World messages originate from an in-memory array in HelloWorldRepository.
    // 
    // A future enhancement will be to switch this o a SQL Server / Entity Framework Backend  
    //
    // ***************************************************************//

    public class HelloWorldController : ApiController
    {
        // GET api/values/1
        public string Get(int id)
        {

            try
            {
                Data.HelloWorld helloWorld = new Data.HelloWorld();
                using (Uow db = new Uow(new DataContext()))
                {

                    helloWorld = db.HelloWorlds.Get(id);
                }
                return helloWorld.Message;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Not Found";
            }
        }

        // GET api/values
        public List<string> List()
        {

            try
            {
                List<Data.HelloWorld> helloWorld = new List<Data.HelloWorld>();
                using (Uow db = new Uow(new DataContext()))
                {

                    helloWorld = db.HelloWorlds.ListAll();
                }
                return helloWorld.Select(s => s.Message).ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<string> { "Not Found" };
            }            
        }

        // ***************************************************************//    
        // A future enhancement will be to switch this o a SQL Server / Entity Framework Backend  
        // At that time, full CRUD operations will be implemented.
        // ***************************************************************//

        // POST api/values
        public void Post([FromBody]Data.HelloWorld value)
        {

            //try
            //{
            //    using (Uow db = new Uow(new DataContext()))
            //    {
            //value.CreatedOn = DateTime.Now;
            //value.CreatedBy = "SYSTEM";
            //db.HelloWorlds.Add(value);
            //db.Commit();
            //    }
            //    catch (Exception e)
            //{
            // Log Exception
            //}

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Data.HelloWorld value)
        {
            //try
            //{
            //    using (Uow db = new Uow(new DataContext()))
            //    {
            //***Future Enhancement*** SQL Server Entity Framework Backend
            //Data.HelloWorld helloWorld = new Data.HelloWorld();
            //helloWorld = db.HelloWorlds.Get(id);
            //helloWorld.Message = value.Message;                        '
            //db.HelloWorlds.Update(helloWorld);
            //db.Commit();
            //    };
            //}
            //catch (Exception e)
            //{
            // Log Exception
            //}
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            //try
            //{
            //    using (Uow db = new Uow(new DataContext()))
            //    {
            //***Future Enhancement*** SQL Server Entity Framework Backend
            //Data.HelloWorld helloWorld = new Data.HelloWorld();
            //helloWorld = db.HelloWorlds.Get(id);                    
            //db.HelloWorlds.Delete(helloWorld);
            //db.Commit();
            //    };
            //}

            //catch (Exception e)
            //{
            // Log Exception
            //    }
        }
    }
}