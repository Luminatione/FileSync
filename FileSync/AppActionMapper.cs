using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudService;
using FileSync.Action;
using FileSync.CloudService;

namespace FileSync
{
	class AppActionMapper
	{
		public virtual IAppAction Map(string actionName, List<string> args)
		{
			ICloudService cloudService;
			IResponseDecoder responseDecoder;
			(cloudService, responseDecoder) = new CloudServiceResolver().GetCloudServiceAndResponseDecoder(args[1]);
			return actionName switch
			{
				"download" => new Download(cloudService, responseDecoder),
				"upload" => new Upload(cloudService, responseDecoder),
				"configure" => new Configure(args[0], args[1], args[2]),
				_ => throw new NotImplementedException()
			};
		}
	}
}
