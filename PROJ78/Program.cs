using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

//232006030
namespace PROJ78
{
    public class Ship
    {
        public int mmsi { get; set; }
        public string name { get; set; }
        public string shipType { get; set; }
    }

    class Program
    {
        static void Main()
        {
            RunAsync().Wait();
            Console.Read();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://backenddev.teqplay.nl/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("ship/232006030");
                if (response.IsSuccessStatusCode)
                {
                    Ship ship = await response.Content.ReadAsAsync<Ship>();
                    Console.WriteLine(ship.mmsi);
                    Console.WriteLine(ship.name);
                    Console.WriteLine(ship.shipType);
                }


            }
       
        }

        
    }

}
