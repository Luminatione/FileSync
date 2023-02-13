using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudService;

namespace FileSync.Action
{
	class Download : IAppAction
	{
		private readonly ICloudService cloudService;
		private readonly IResponseDecoder responseDecoder;

		public Download(ICloudService cloudService, IResponseDecoder responseDecoder)
		{
			this.cloudService = cloudService;
			this.responseDecoder = responseDecoder;
		}

		public IResponseDecoder.Result Perform()
		{
			return responseDecoder.Decode(cloudService.Download(Properties.FileSync.Default.Properties));
		}
	}
}
