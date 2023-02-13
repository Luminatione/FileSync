using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudService;
using Utility.CloudService;

namespace Utility.Action
{
	class Upload : IAppAction
	{
		private readonly ICloudService cloudService;
		private readonly IResponseDecoder responseDecoder;

		public Upload(ICloudService cloudService, IResponseDecoder responseDecoder)
		{
			this.cloudService = cloudService;
			this.responseDecoder = responseDecoder;
		}

		public IResponseDecoder.Result Perform()
		{
			return responseDecoder.Decode(cloudService.Upload(Properties.FileSync.Default.Properties));
		}
	}
}
