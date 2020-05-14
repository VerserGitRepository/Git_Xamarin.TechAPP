using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace TechApp2
{
   public static class Settings
    {

  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string LastUserIdKey = "LastUserId_key";
        private const string LastUserPasswordKey = "LastUserPassword_key";
        private static readonly string SettingsDefault = string.Empty;      
        
        //API EndPoint Configurations
        private static readonly string Base = "https://customers.verser.com.au/";

        //production API Endpoint
        private static readonly string ProdService = "AssetManagementService";
        
        private static readonly string DevService = "AssetManagementServiceDev";

        public static string AMSBaseTechAPPURL = $"{Base}{DevService}/inventorycontrol/TechAPP/";
        public static string AMSBaseInventoryURL = $"{Base}{DevService}/inventorycontrol/";
        #endregion

        public static string LastUsedUserId
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastUserIdKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastUserIdKey, value);
            }
        }

        public static string LastUsedUserPassword
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastUserPasswordKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastUserPasswordKey, value);
            }
        }
    }
 }

