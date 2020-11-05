using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HelloWorld.API;
using System.Collections.Generic;
namespace HelloWorld.Test
{
    [TestClass]
    public class TestHelloWorld
    {
        [TestMethod]
        public void TestHelloWorldGetAPI()
        {
            string result = string.Empty;

            try
            {
                API.Controllers.HelloWorldController controller = new API.Controllers.HelloWorldController();
                result = controller.Get(1);
                Assert.IsTrue(Data.Properties.Settings.Default.MessageList.Contains(result));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                Console.WriteLine(e.Message);
            }
        }
        [TestMethod]
        public void TestHelloWorldListAllAPI()
        {
            List<string> results = new List<string>();            
            try
            {
                API.Controllers.HelloWorldController controller = new API.Controllers.HelloWorldController();
                results = controller.List();
                Assert.IsTrue(Data.Properties.Settings.Default.MessageList.Count == results.Count);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                Console.WriteLine(e.Message);
            }
        }
    }
}

