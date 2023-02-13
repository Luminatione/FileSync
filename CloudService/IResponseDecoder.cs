using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudService
{
	public interface IResponseDecoder
	{
		enum Result
		{
			Success = 0,
			Failure = 1
		}

		Result Decode(string response);
	}
}
