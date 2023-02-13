using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudService;

namespace Utility.Action
{
	class Configure : IAppAction
	{
		private enum Option
		{
			Set, Get, Remove, Add, ShowAll
		}

		private readonly string settingName;
		private readonly string value;
		private readonly Option option;

		public Configure(string option, string settingName, string value)
		{
			this.settingName = settingName;
			this.value = value;

			if (!Enum.TryParse(option, true, out this.option))
			{
				throw new ArgumentException("Invalid option");
			}
		}

		public IResponseDecoder.Result Perform()
		{
			try
			{
				switch (option)
				{
					case Option.Set:
						Properties.FileSync.Default[settingName] = option;
						break;
					case Option.Get:
						Console.WriteLine(Properties.FileSync.Default[settingName]);
						break;
					case Option.Remove:
						Properties.FileSync.Default.Properties.Remove(settingName);
						break;
					case Option.Add:
						AddNewSetting(settingName, value);
						break;
					case Option.ShowAll:
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return IResponseDecoder.Result.Failure;
			}

			Properties.FileSync.Default.Save();
			Properties.FileSync.Default.Reload();

			return IResponseDecoder.Result.Success;
		}

		private void AddNewSetting(string settingName, string value)
		{
			SettingsProperty settingsProperty = new SettingsProperty(settingName);
			settingsProperty.PropertyType = typeof(string);
			settingsProperty.Attributes.Add(typeof(UserScopedSettingAttribute), new UserScopedSettingAttribute());
			settingsProperty.Provider = Properties.FileSync.Default.Providers["LocalFileSettingsProvider"];
			settingsProperty.SerializeAs = SettingsSerializeAs.String;
			settingsProperty.ThrowOnErrorDeserializing = false;
			settingsProperty.ThrowOnErrorSerializing = false;
			settingsProperty.IsReadOnly = false;
			settingsProperty.DefaultValue = value;
			Properties.FileSync.Default.Properties.Add(settingsProperty);
		}
	}
}
