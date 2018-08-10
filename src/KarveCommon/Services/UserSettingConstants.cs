using System;

namespace KarveCommon.Services
{

    public static class UserSettingConstants
    {
        public static Uri BookingClientGridColumnsKey = new Uri("karve://booking/settings/clientgrid");
        public static Uri ClientDriverGridColumnsKey = new Uri("karve://client/settings/drivergrid");
        public static Uri BookingDriverGridColumnsKey = new Uri("karve://booking/settings/drivergrid");
        public static Uri VehicleSummaryGridColumnsKey = new Uri("karve://vehicles/settings/summarygrid");
        public static Uri DefaultEmailAddress = new Uri("karve://global/settings/emailaddress");
        public static Uri DefaultConnectionString = new Uri("karve://global/settings/connection");

    }

}