using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Action;

namespace Utility
{
	class Application
	{
		public void Run(string[] args)
		{
			IAppAction action = new AppActionMapper().Map(args[1], args.ToList().GetRange(2, args.Length - 2));
			action.Perform();
		}
	}
}
