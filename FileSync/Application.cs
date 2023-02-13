using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSync.Action;
using System.Linq;

namespace FileSync
{
	class Application
	{
		public void Run(string[] args)
		{
			AppAction action = new AppActionMapper().Map(args[1], args.ToList().GetRange(2, args.Length - 2));
			action.Perform();
		}
	}
}
