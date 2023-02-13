using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSync.Action;

namespace FileSync
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 3)
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
