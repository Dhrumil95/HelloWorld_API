using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAPI.Tests
{
	[TestClass()]
	public class APITests
	{
		String ExpectedResult = "Hello World";

		[TestMethod()]
		public void GetMessageTest_ConsoleAPI()
		{

			ConsoleAPI CAPI = new ConsoleAPI();
			CAPI.SetMessage(ExpectedResult);
			String GetMessage = CAPI.GetMessage();
			
			Assert.IsTrue(GetMessage.Equals(ExpectedResult));
		}

		[TestMethod()]
		public void GetMessageTest_DatabaseAPI()
		{
			DatabaseAPI DAPI = new DatabaseAPI();
			DAPI.SetMessage(ExpectedResult);
			String GetMessage = DAPI.GetMessage();


			Assert.IsTrue(GetMessage.Equals(ExpectedResult));
		}


		[TestMethod()]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetMessageTest_MobileAPI()
		{
			MobileAPI MAPI = new MobileAPI();
			MAPI.GetMessage();
		}


		[TestMethod()]
		public void GetMessageTest_WebAPI()
		{
			WebAPI WAPI = new WebAPI();
			WAPI.SetMessage(ExpectedResult);
			String GetMessage = WAPI.GetMessage();


			Assert.IsTrue(GetMessage.Equals(ExpectedResult));
		}


		[TestMethod()]
		public void GetMessageTest_WindowsSericeAPI()
		{
			WindowsSericeAPI WSAPI = new WindowsSericeAPI();
			WSAPI.SetMessage(ExpectedResult);
			String GetMessage = WSAPI.GetMessage();


			Assert.IsTrue(GetMessage.Equals(ExpectedResult));
		}
	}
}