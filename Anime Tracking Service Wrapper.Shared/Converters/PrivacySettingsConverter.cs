using AnimeTrackingServiceWrapper.Service_Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Converters
{
    public static class PrivacySettingsConverter
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

        public static PrivacySettings BoolToPrivacySettings(string privacySettingsString)
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


    }
}
