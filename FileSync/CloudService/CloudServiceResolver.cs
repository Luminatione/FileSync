using System;
using System.Linq;
using System.Reflection;
using CloudService;

namespace Utility.CloudService
{
	class CloudServiceResolver
	{
		public (ICloudService, IResponseDecoder) GetCloudServiceAndResponseDecoder(string sourceName)
		{
			Assembly serviceAssembly = Assembly.LoadFrom(sourceName + ".dll");
			Type cloudServiceType = serviceAssembly.GetTypes().First(e => e.Name == sourceName);
			Type responseDecoderType = serviceAssembly.GetTypes().First(e => e.Name == sourceName + "ResponseDecoder");

			ICloudService cloudService = (ICloudService) Activator.CreateInstance(cloudServiceType);
			IResponseDecoder responseDecoder = (IResponseDecoder) Activator.CreateInstance(responseDecoderType);
			return (cloudService, responseDecoder);
		}
	}
}
