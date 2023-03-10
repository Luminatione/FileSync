using CloudService;

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
			return responseDecoder.Decode(cloudService.Upload(Properties.Utility.Default.ToDictionary()));
		}
	}
}
