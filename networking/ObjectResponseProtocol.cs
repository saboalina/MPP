using System;
using System.Collections;
using System.Collections.Generic;
using model;

namespace networking
{
	public interface Response 
	{
	}

	[Serializable]
	public class OkResponse : Response
	{
		
	}

    [Serializable]
	public class ErrorResponse : Response
	{
		private string message;

		public ErrorResponse(string message)
		{
			this.message = message;
		}

		public virtual string Message
		{
			get
			{
				return message;
			}
		}
	}

	[Serializable]
	public class GetAllExcursieResponse : Response
	{
		private IEnumerable<Excursie> excursii;

		public GetAllExcursieResponse(IEnumerable<Excursie> excursii)
		{
			this.excursii = excursii;
		}

		public virtual IEnumerable<Excursie> Excursii
		{
			get
			{
				return excursii;
			}
		}
	}
	
	[Serializable]
	public class GetAllExcursieByNameTimeResponse : Response
	{
		private List<Excursie> excursii;

		public GetAllExcursieByNameTimeResponse(List<Excursie> excursii)
		{
			this.excursii = excursii;
		}

		public virtual List<Excursie> Excursii
		{
			get
			{
				return excursii;
			}
		}
	}
	public interface UpdateResponse : Response
	{
	}
	
	[Serializable]
	public class NewRezervareResponse : UpdateResponse
	{
		private Ticket rezervare;

		public NewRezervareResponse(Ticket rezervare)
		{
			this.rezervare = rezervare;
		}

		public virtual Ticket Rezervare
		{
			get
			{
				return rezervare;
			}
		}
	}

}