ConfigManager settings = new ConfigManager();

if (exist("%appdata%\keycounter\keycounter.config"))
{
	ConfigPath = %appdata%\keycounter\settings.config;
	settings.Load (ConfigPath);
}
else if (exist (AppDir() + "\keycounter.config"))
{
	ConfigPath = AppDir() + "\keycounter.config";
	settings.Load (ConfigPath);
}
else
{
	// initial Configuration
	settings.SetProperty ("Param1", 123);
	settings.SetProperty ("Param2", "asdf");
	settings.SetProperty ("Param3", true);
	
	if (HaveWriteAccess(AppDir()))
	{
		Ask ("save config file in %appdata%? otherwise config is saved in application dir (for use on usb drives for example)."); // yes/no
		{
			case yes: ConfigPath = "%appdata%\keycounter\settings.config"; break;
			case no: ConfigPath = AppDir() + "\keycounter.config"; break;
		}		
	}
	else
	{
		ConfigPath = "%appdata%\keycounter\settings.config";
	}
	
	settings.Save (ConfigPath);	
	Info("...");
}

keycounter.config
-----------------------------------------------------------
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <Property key="Param1" type="integer" value="123" />
    <Property key="Param2" type="string" value="asdf" />
    <Property key="Param3" type="boolean" value="true" />
  </appSettings>
</configuration>