using CloudService;

namespace Utility.Action
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
			return responseDecoder.Decode(cloudService.Download(Properties.Utility.Default.ToDictionary()));
		}
	}
}
