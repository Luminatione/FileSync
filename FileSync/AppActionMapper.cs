using System;
using System.Collections.Generic;
using CloudService;
using Utility.Action;
using Utility.CloudService;

namespace Utility
{
	class AppActionMapper
	{
		public virtual IAppAction Map(string actionName, List<string> args)
		{
			ICloudService cloudService;
			IResponseDecoder responseDecoder;

			switch (actionName)
			{
				case "download":
					(cloudService, responseDecoder) = new CloudServiceResolver().GetCloudServiceAndResponseDecoder(args[0]);
					return new Download(cloudService, responseDecoder);
				case "upload":
					(cloudService, responseDecoder) = new CloudServiceResolver().GetCloudServiceAndResponseDecoder(args[0]);
					return new Upload(cloudService, responseDecoder);
				case "configure":
					return new Configure(args);
				default:
					throw new NotImplementedException();
			}
		}
	}
}
