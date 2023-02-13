
namespace Utility
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 2)
			{
				ShowHelp();
				return;
			}

			Application app = new Application();
			app.Run(args);
		}

		private static void ShowHelp()
		{

		}
	}
}
