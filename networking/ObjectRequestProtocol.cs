using System;
using model;

namespace networking
{
	public interface Request 
	{
	}


	[Serializable]
	public class LoginRequest : Request
	{
		private Employee user;

		public LoginRequest(Employee user)
		{
			this.user = user;
		}

		public virtual Employee Agent
		{
			get
			{
				return user;
			}
		}
	}

	[Serializable]
	public class LogoutRequest : Request
	{
		private Employee user;

		public LogoutRequest(Employee user)
		{
			this.user = user;
		}

		public virtual Employee Agent
		{
			get
			{
				return user;
			}
		}
		
	}

	[Serializable]
	public class AddRezervareRequest : Request
	{
		private Ticket rezervare;

		public AddRezervareRequest(Ticket rezervare)
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

	[Serializable]
	public class GetAllExcursieRequest : Request
	{
	}
	
	[Serializable]
	public class GetExcursieByNameTimeRequest : Request
	{
		private ExcursieDTO excursieDTO;

		public GetExcursieByNameTimeRequest(ExcursieDTO excursieDto)
		{
			this.excursieDTO = excursieDto;
		}

		public virtual ExcursieDTO ExcursieDTO
		{
			get
			{
				return excursieDTO;
			}
		}
	}


}