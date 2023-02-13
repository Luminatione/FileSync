using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync.Action
{
	interface AppAction
	{
		enum Result
		{
			Success = 0,
			Failure = 1
		}

		Result Perform(string url);
	}
}
