using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudService;

namespace FileSync.Action
{
	interface IAppAction
	{
		IResponseDecoder.Result Perform();
	}
}
