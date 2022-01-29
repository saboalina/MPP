using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using services;
using model;
namespace networking
{
	public class ChatClientWorker :  IObserver //, Runnable
	{
		private IServices server;
		private TcpClient connection;

		private NetworkStream stream;
		private IFormatter formatter;
		private volatile bool connected;
		public ChatClientWorker(IServices server, TcpClient connection)
		{
			this.server = server;
			this.connection = connection;
			try
			{
				
				stream=connection.GetStream();
                formatter = new BinaryFormatter();
				connected=true;
			}
			catch (Exception e)
			{
                Console.WriteLine(e.StackTrace);
			}
		}

		public virtual void run()
		{
			while(connected)
			{
				try
				{
                    object request = formatter.Deserialize(stream);
					object response =handleRequest((Request)request);
					if (response!=null)
					{
					   sendResponse((Response) response);
					}
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.StackTrace);
				}
				
				try
				{
					Thread.Sleep(1000);
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.StackTrace);
				}
			}
			try
			{
				stream.Close();
				connection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error "+e);
			}
		}

		public virtual void rezervareAdded(Ticket rezervare)
		{
			Console.WriteLine("Rezervare received " + rezervare);
			try
			{
				sendResponse(new NewRezervareResponse(rezervare));
			}
			catch (Exception e)
			{
				throw new ServiceException("Sending error: " + e);
			}
		}

		private Response handleRequest(Request request)
		{
			Response response =null;
			if (request is LoginRequest)
			{
				Console.WriteLine("Login request ...");
				LoginRequest logReq =(LoginRequest)request;
				Employee user =logReq.Agent;
				try
                {
                    lock (server)
                    {
                        server.LogIn(user, this);
                    }
					return new OkResponse();
				}
				catch (ServiceException e)
				{
					connected=false;
					return new ErrorResponse(e.Message);
				}
			}
			if (request is LogoutRequest)
			{
				Console.WriteLine("Logout request");
				LogoutRequest logReq =(LogoutRequest)request;
				Employee user =logReq.Agent;
				try
				{
                    lock (server)
                    {

                        server.LogOut(user, this);
                    }
					connected=false;
					return new OkResponse();

				}
				catch (ServiceException e)
				{
				   return new ErrorResponse(e.Message);
				}
			}
			if (request is GetAllExcursieRequest)
			{
				Console.WriteLine("GetAllExcursieRequest ...");
				try
				{
					IEnumerable<Excursie> excursii;
                    lock (server)
                    {
                        excursii = server.FindAllExcursie();
                    }
					return new GetAllExcursieResponse(excursii);
				}
				catch (ServiceException e)
				{
					return new ErrorResponse(e.Message);
				}
			}

			if (request is GetExcursieByNameTimeRequest)
			{
				Console.WriteLine("GetExcursieByNameTime Request ...");
				GetExcursieByNameTimeRequest getReq =(GetExcursieByNameTimeRequest)request;
				ExcursieDTO excursie = getReq.ExcursieDTO;
				try
				{
					List<Excursie> excursii;
                    lock (server)
                    {
	                    excursii = server.FindByNameAndTimeExcursie(excursie.obiectivTuristic);
                    }
                    return new GetAllExcursieByNameTimeResponse(excursii);
				}
				catch (ServiceException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is AddRezervareRequest)
			{
				Console.WriteLine("AddRezervareRequest ...");
				AddRezervareRequest senReq =(AddRezervareRequest)request;
				Ticket rezervare = senReq.Rezervare;
				try
				{
					lock (server)
					{
						server.AddRezervare(rezervare.ClientName, rezervare.TouristsName, rezervare.NoSeats, rezervare.Excursie);
					}
					return new OkResponse();
				}
				catch (ServiceException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			return response;
		}

	private void sendResponse(Response response)
		{
			Console.WriteLine("sending response "+response);
			lock (stream)
			{
				formatter.Serialize(stream, response);
				stream.Flush();
			}
		}
	}

}