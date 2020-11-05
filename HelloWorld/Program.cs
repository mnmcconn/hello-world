using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;

            try
            {
                result = GetMessage().Result;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                Console.WriteLine(e.Message);
            }
            System.Diagnostics.Debug.WriteLine(result);
            Console.WriteLine(result);
            Console.WriteLine("Press Any Key To End Hello World...");
            Console.ReadKey();
        }

        static async Task<string> GetMessage()
        {
            string result = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Data.Properties.Settings.Default.LocalHost);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(Data.Properties.Settings.Default.Path);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return result;
        }
    }
}
