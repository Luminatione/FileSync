using System;
using System.Collections.Generic;
using System.Configuration;
using CloudService;

namespace Utility.Action
{
	class Configure : IAppAction
	{
		private enum Option
		{
			Set, Get, Remove, Add, ShowAll, New
		}

		private readonly string settingName;
		private readonly string value;
		private readonly Option option;

		public Configure(List<string> args)
		{
			if (args.Count > 1)
			{
				settingName = args[1];
			}

			if (args.Count > 2)
			{
				value = args[2];
			}

			if (!Enum.TryParse(args[0], true, out option))
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
						Properties.Utility.Default[settingName] = value;
						break;
					case Option.Get:
						Console.WriteLine(Properties.Utility.Default[settingName]);
						break;
					case Option.Remove:
						Properties.Utility.Default.Properties.Remove(settingName);
						break;
					case Option.New:
						AddNewSetting(settingName, value);
						break;
					case Option.ShowAll:
						ShowAll();
						break;
					case Option.Add:
						Properties.Utility.Default[settingName] += ";" + value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				Properties.Utility.Default.Save();
				Properties.Utility.Default.Reload();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return IResponseDecoder.Result.Failure;
			}

			return IResponseDecoder.Result.Success;
		}

		private void AddNewSetting(string settingName, string value)
		{
			SettingsProperty settingsProperty = new SettingsProperty(settingName);
			settingsProperty.PropertyType = typeof(string);
			settingsProperty.Attributes.Add(typeof(UserScopedSettingAttribute), new UserScopedSettingAttribute());
			settingsProperty.Provider = Properties.Utility.Default.Providers["LocalFileSettingsProvider"];
			settingsProperty.SerializeAs = SettingsSerializeAs.String;
			settingsProperty.ThrowOnErrorDeserializing = false;
			settingsProperty.ThrowOnErrorSerializing = false;
			settingsProperty.IsReadOnly = false;
			settingsProperty.DefaultValue = value;
			Properties.Utility.Default.Properties.Add(settingsProperty);
		}

		private void ShowAll()
		{
			foreach (SettingsProperty settingsProperty in Properties.Utility.Default.Properties)
			{
				Console.WriteLine($"{settingsProperty.Name}: {Properties.Utility.Default[settingsProperty.Name]}");
			}
		}
	}
}
