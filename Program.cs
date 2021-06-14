using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Asyncawait
    

{
    public class Employee
    {
        public async Task<string> GetDataAsync()
        {
            HttpClient client = new HttpClient();
            Uri apiAddress = new Uri("https://jsonplaceholder.typicode.com/todos");

            var task = await client.GetAsync(apiAddress);
            if (task.IsSuccessStatusCode)
            {
                var data = await task.Content.ReadAsStringAsync();
                return data;
            }
            else
            {
                return null;
            }
        }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            Employee emp = new Employee();

            //var task =  emp.GetDataAsync().Result; //synchronous call to method

            var task = await emp.GetDataAsync(); //asynchronous call to method
            Console.WriteLine(task);
        }
    }
}
