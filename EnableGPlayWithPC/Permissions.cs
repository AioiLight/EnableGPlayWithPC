namespace EnableGPlayWithPC
{
    internal static class Permissions
    {
        internal static string Prefix = "android.permission.";

        internal static string[] Vending = new string[] 
        {
            "BATTERY_STATS",
            "DUMP",
            "GET_APP_OPS_STATS",
            "WRITE_SECURE_SETTINGS",
            "INTERACT_ACROSS_USERS"
        };

        internal static string[] GMS = new string[]
        {
            "DUMP",
            "READ_LOGS",
            "WRITE_SECURE_SETTINGS",
            "INTERACT_ACROSS_USERS",
            "CHANGE_WIMAX_STATE",
            "CLEAR_APP_CACHE",
            "CLEAR_APP_USER_DATA",
            "CONFIGURE_WIFI_DISPLAY",
            "CONNECTIVITY_INTERNAL",
            "CONTROL_KEYGUARD",
            "CONTROL_LOCATION_UPDATES",
            "CONTROL_WIFI_DISPLAY",
            "COPY_PROTECTED_DATA",
            "CREATE_USERS",
            "CRYPT_KEEPER",
            "DELETE_CACHE_FILES",
            "DELETE_PACKAGES",
            "DEVICE_POWER"
        };
    }
}
