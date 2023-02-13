using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
	internal static class SettingsExtension
	{
		internal static Dictionary<string, string> ToDictionary(this Properties.Utility properties)
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			foreach (SettingsProperty settingsProperty in properties.Properties)
			{
				result.Add(settingsProperty.Name, properties[settingsProperty.Name].ToString());
			}

			return result;
		}
	}
}
