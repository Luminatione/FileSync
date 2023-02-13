using CloudService;

namespace Utility.Action
{
	interface IAppAction
	{
		IResponseDecoder.Result Perform();
	}
}
