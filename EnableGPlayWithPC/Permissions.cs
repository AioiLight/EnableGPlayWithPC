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
            "READ_LOGS",
            "GET_APP_OPS_STATS"
        };

        internal static string[] GSF = new string[]
        {
            "DUMP",
            "WRITE_SECURE_SETTINGS",
            "INTERACT_ACROSS_USERS"
        };
    }
}
