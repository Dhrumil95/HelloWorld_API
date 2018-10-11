using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace MessageAPI
{
	public abstract class Message : IMessage
	{

		protected string message;
	    string IMessage.MessageText { get => message; set => message = value; }

		public abstract string GetMessage(); 
		public virtual void SetMessage(String Message)
		{
			this.message = Message;
		}
		
		public void ResetMessage()
		{
			message = null;
		}
	}


	public class ConsoleAPI : Message
	{
		public override string GetMessage()
		{
			return message; // Just print the message to Console/Screen
		}

		// Additional Methods
		public void ChangeForeGroundColor(ConsoleColor consoleColor)
		{
			Console.ForegroundColor = consoleColor;
		}

		public void ResetColor()
		{
			Console.ResetColor();
		}
	}

	public class DatabaseAPI : Message
	{
		private ConnectionStringSettings ConnectionStringSettings;
		private DbProviderFactory dpf;

		/* Can move this SetConnection() methods to Interface */
		// Manually Load DB info
		public void SetConnection(String Conn, DbProviderFactory Dpf)
		{
			this.ConnectionStringSettings.ConnectionString = Conn;
			this.dpf = Dpf;
		}

		// Load from App.Config
		public void SetConnection()
		{
			this.ConnectionStringSettings = ConfigurationManager.ConnectionStrings["DBName"];
			this.dpf = DbProviderFactories.GetFactory(ConnectionStringSettings.ProviderName);
		}

		// GtMessage
		public override string GetMessage()
		{
			Console.WriteLine(String.Format("Fetched {0} from DB", message));
			return message;
		}

		// GtMessage
		public override void SetMessage(String Message)
		{
			Console.WriteLine(String.Format("Inserting {0} in DB", Message));
			message = Message;
		}
	}


	public class MobileAPI : Message
	{
		public override string GetMessage()
		{
			throw new NotImplementedException();
		}
	}

	
	public class WebAPI : Message
	{
		public override string GetMessage()
		{
			return message;
		}

		// Convert the message to HTML header format
		public void CovertToHeader()
		{
			message = String.Format("<h> {0} </h>", message);
		}
	}

	public class WindowsSericeAPI : Message
	{
		public override string GetMessage()
		{
			return message.ToString();
		}
	}


}
