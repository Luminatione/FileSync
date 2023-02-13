using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudService;

namespace GoogleCloudService
{
	class Google : ICloudService
	{
		public string Download(Dictionary<string, string> settings)
		{
			return "Success";
		}

		public string Upload(Dictionary<string, string> settings)
		{
			return "Success";
		}
	}
}
