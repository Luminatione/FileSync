using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync.CloudService
{
	interface ICloudService
	{
		string Download();
		string Upload();
	}
}
