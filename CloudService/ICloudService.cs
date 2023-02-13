using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudService
{
	public interface ICloudService
	{
		string Download(Dictionary<string, string> settings);
		string Upload(Dictionary<string, string> settings);
	}
}
