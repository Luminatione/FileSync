using System.Linq;
using Utility.Action;

namespace Utility
{
	class Application
	{
		public void Run(string[] args)
		{
			IAppAction action = new AppActionMapper().Map(args[0], args.ToList().GetRange(1, args.Length - 1));
			action.Perform();
		}
	}
}
