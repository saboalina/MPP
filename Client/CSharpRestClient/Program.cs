using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CSharpRestClient
{
	class MainClass
	{
		static HttpClient client = new HttpClient();

		public static void Main(string[] args)
		{
			RunAsync().Wait();
		}


		static async Task RunAsync()
		{
			client.BaseAddress = new Uri("http://localhost:8080/flightagency/flights");
			client.DefaultRequestHeaders.Accept.Clear();
			//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			int id = 1;
			Console.WriteLine("Get flight {0}", id);
			Flight result = await GetFlightAsync("http://localhost:8080/flightagency/flights/"+ id);
			Console.WriteLine("Am primit {0}", result);
			Console.ReadLine();

		}
		
		
		static async Task<Flight> GetFlightAsync(string path)
		{
			Flight product = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				product = await response.Content.ReadAsAsync<Flight>();
			}
			return product;
		}


	}
	public class Flight
	{
		public int id { get; set; }
		public string destination { get; set; }
		public string departureDate { get; set; }
		public string departureTime { get; set; }
		public string airport { get; set; }
		public int availableSeats { get; set; }
		
		public override string ToString()
		{
			return string.Format("[Flight: id={0}, destination={1}, departureDate={2}, airport={3}]", id, destination, departureDate, airport);
		}
	}
	
}
