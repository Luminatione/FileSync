using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSync.Action;

namespace FileSync
{
	class AppActionMapper
	{
		public virtual AppAction Map(string actionName, List<string> args)
		{
			return actionName switch
			{
				"download" => new Download(),
				"upload" => new Upload(),
				"configure" => new Configure(),
				_ => throw new NotImplementedException()
			};
		}
	}
}
