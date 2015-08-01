using AnimeTrackingServiceWrapper.UniversalServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

#if !DESKTOP
using Windows.UI.Xaml.Data;
#endif

namespace AnimeTrackingServiceWrapper.Converters
{
    public class PrivacySettingsConverter
#if !DESKTOP
        : IValueConverter
#endif
    {
        public static PrivacySettings BoolToPrivacySettings(bool privacySettingsBool)
        {
            switch (privacySettingsBool)
            {
                case true:  return PrivacySettings.Private;
                case false: 
                default:    return PrivacySettings.Public;
            }
        }

        public static PrivacySettings StringToPrivacySettings(string privacySettingsString)
        {
            switch (privacySettingsString)
            {
                case "private": return PrivacySettings.Private;
                case "public":
                default:        return PrivacySettings.Public;
            }
        }

        public static string PrivacySettingsToString(PrivacySettings privacySettings)
        {
            switch (privacySettings)
            {
                case PrivacySettings.Public: return "public";
                case PrivacySettings.Private: return "private";
                default: return "";
            }
        }

        public static bool PrivacySettingsToBool(PrivacySettings privacySettings)
        {
            switch (privacySettings)
            {
                case PrivacySettings.Private:   return true;
                case PrivacySettings.Public:    
                default:                        return false;
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is PrivacySettings)
                return PrivacySettingsToString((PrivacySettings)value);
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
                return StringToPrivacySettings((string)value);
            return PrivacySettings.Public;
        }
    }
}
