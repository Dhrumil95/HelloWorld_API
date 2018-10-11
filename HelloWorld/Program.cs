using System;
using MessageAPI;

namespace HelloWorld
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleAPI CAPI = new ConsoleAPI();
			CAPI.SetMessage("Hello World");

			Console.WriteLine(CAPI.GetMessage());

			Console.ReadKey(); // Demo...
		}
	}
}
