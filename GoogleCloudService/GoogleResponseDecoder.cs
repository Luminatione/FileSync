using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudService;

namespace GoogleCloudService
{
	class GoogleResponseDecoder : IResponseDecoder
	{
		public IResponseDecoder.Result Decode(string response)
		{
			Console.WriteLine(response);
			return IResponseDecoder.Result.Success;
		}
	}
}
