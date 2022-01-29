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
using networking;

namespace networking
{
	public class ChatServerProxy : IServices
	{
		private string host;
		private int port;

		private IObserver client;

		private NetworkStream stream;
		
        private IFormatter formatter;
		private TcpClient connection;

		private Queue<Response> responses;
		private volatile bool finished;
        private EventWaitHandle _waitHandle;
		public ChatServerProxy(string host, int port)
		{
			this.host = host;
			this.port = port;
			responses=new Queue<Response>();
		}

		public virtual void LogIn(Employee user, IObserver client)
		{
			initializeConnection();
			sendRequest(new LoginRequest(user));
			Response response =readResponse();
			if (response is OkResponse)
			{
				this.client=client;
				return;
			}
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				closeConnection();
				throw new ServiceException(err.Message);
			}
		}

		public virtual void AddRezervare(String numeClient, String nrTelefon, int nrBilete, Excursie excursie)
		{
			Ticket rezervare = new Ticket()
			{
				ClientName = numeClient,
				TouristsName = nrTelefon,
				NoSeats = nrBilete,
				Excursie = excursie
			};
			sendRequest(new AddRezervareRequest(rezervare));
			Response response =readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				throw new ServiceException(err.Message);
			}
		}

	public virtual void LogOut(Employee user, IObserver client)
		{
			sendRequest(new LogoutRequest(user));
			Response response =readResponse();
			closeConnection();
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				throw new ServiceException(err.Message);
			}
		}

	
		public virtual IEnumerable<Excursie> FindAllExcursie()
		{
			sendRequest(new GetAllExcursieRequest());
			Response response =readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				throw new ServiceException(err.Message);
			}
			GetAllExcursieResponse resp =(GetAllExcursieResponse)response;
			IEnumerable<Excursie> excursii = resp.Excursii;
			return excursii;
		}
		
		public virtual List<Excursie> FindByNameAndTimeExcursie(String name)
		{
			ExcursieDTO excursieDto = new ExcursieDTO()
			{
				obiectivTuristic = name,
			};
			sendRequest(new GetExcursieByNameTimeRequest(excursieDto));
			Response response =readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				throw new ServiceException(err.Message);
			}
			GetAllExcursieByNameTimeResponse resp =(GetAllExcursieByNameTimeResponse)response;
			List<Excursie> excursii = resp.Excursii;
			return excursii;
		}

		private void closeConnection()
		{
			finished=true;
			try
			{
				stream.Close();
				//output.close();
				connection.Close();
                _waitHandle.Close();
				client=null;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}

		}

		private void sendRequest(Request request)
		{
			try
			{
                formatter.Serialize(stream, request);
                stream.Flush();
			}
			catch (Exception e)
			{
				throw new ServiceException("Error sending object "+e);
			}

		}

		private Response readResponse()
		{
			Response response =null;
			try
			{
                _waitHandle.WaitOne();
				lock (responses)
				{
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();
                
				}
				

			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
			return response;
		}
		private void initializeConnection()
		{
			 try
			 {
				connection=new TcpClient(host,port);
				stream=connection.GetStream();
                formatter = new BinaryFormatter();
				finished=false;
                _waitHandle = new AutoResetEvent(false);
				startReader();
			 }
			 catch (Exception e)
			 {
				 Console.WriteLine(e.StackTrace);
			 }
		}
		private void startReader()
		{
			Thread tw =new Thread(run);
			tw.Start();
		}


		private void handleUpdate(UpdateResponse update)
		{
			if (update is NewRezervareResponse)
			{
				NewRezervareResponse rezRsp = (NewRezervareResponse) update;
				Ticket rezervare = rezRsp.Rezervare;
				try
				{
					client.rezervareAdded(rezervare);
				}
				catch (ServiceException e)
				{
					Console.WriteLine(e.StackTrace);
				}
			}
		}
		public virtual void run()
		{
			while(!finished)
			{
				try
				{
					object response = formatter.Deserialize(stream);
					Console.WriteLine("response received "+response);
					if (response is UpdateResponse)
					{
						handleUpdate((UpdateResponse)response);
					}
					else
					{
						lock (responses)
						{
							responses.Enqueue((Response) response);
						}
						_waitHandle.Set();
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Reading error "+e);
				}
			}
		}
	}

}