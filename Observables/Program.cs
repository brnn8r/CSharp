using System;
using System.Net.Http;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Reactive.Concurrency;
using System.Threading.Tasks;

namespace Observables
{
    class Program
    {
        private static readonly string testUri = "https://generator.swagger.io/api/gen/clients";
        private static readonly string acceptHeader = "application/json";
        private static readonly HttpClient http = new HttpClient();

        public int i = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            http.DefaultRequestHeaders.Accept.ParseAdd(acceptHeader);  

            Console.WriteLine($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}");

            var me =new Program();

            var observableResult = Observable.StartAsync(() => http.GetStringAsync(testUri)).Wait();                                         
                // .Subscribe((t) => {                    
                //     Console.WriteLine($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}");                    
                //     Console.WriteLine(t);
                //     }
                //     ,() => Console.WriteLine("loaded client list"));
            Console.WriteLine(observableResult);
            Console.WriteLine($"Subscribe Finished: {me.i}");

            var taskResult = http.GetStringAsync(testUri).Result;
            Console.WriteLine("Writing taskResult");
            Console.WriteLine(taskResult);            

            Console.WriteLine($"Subscribe Finished: {me.i}");
        }

        private static async Task<Tuple<Program,string>> GetClients(Program val)
        {
            return Tuple.Create(val, await http.GetStringAsync(testUri));
        }
    }
}
