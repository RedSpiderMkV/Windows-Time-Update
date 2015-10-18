using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace WindowsTimeSyncLib
{
    internal class TimeSyncLib : IDisposable
    {
        #region Public Methods

        /// <summary>
        /// Instantiate a new time sync lib object to retrieve an object representing
        /// the date and time on the server.
        /// </summary>
        public TimeSyncLib()
        {
            webClient_m = new WebClient();
        } // end method

        /// <summary>
        /// Get date time container object with date and time set from values
        /// on server.
        /// </summary>
        /// <returns>Date time container.</returns>
        public DateTimeContainer GetDateTime()
        {
            try
            {
                string response = webClient_m.DownloadString(syncUrl_c);

                JavaScriptSerializer jsonManager = new JavaScriptSerializer();
                Dictionary<string, string> ob = jsonManager.Deserialize<Dictionary<string, string>>(response);

                string dateTimeStr = ob["date"] + " " + ob["time"].Replace(" UTC", "");
                DateTime dateTime = DateTime.ParseExact(dateTimeStr, "yyyy-MM-dd HH:mm:ss", null);

                TimeZoneInfo zone = TimeZoneInfo.Local;
                dateTime = dateTime.AddSeconds(zone.GetUtcOffset(new DateTime()).Seconds);

                if (zone.IsDaylightSavingTime(dateTime))
                {
                    dateTime = dateTime.AddHours(1);
                } // end if

                return new DateTimeContainer(dateTime);
            }
            catch (Exception e)
            {
                // log this somewhere
                Console.WriteLine(e.Message);
            } // end try-catch

            return null;
        } // end method

        /// <summary>
        /// Dispose of the time sync library.
        /// </summary>
        public void Dispose()
        {
            if (webClient_m != null)
            {
                webClient_m.Dispose();
            } // end if
        } // end method

        #endregion

        #region Private Data

        // Server url.
        private const string syncUrl_c = @"http://www.portvisibility.co.uk/visibility/tools/showTime.php";
        
        // Web client used to access server.
        private WebClient webClient_m;

        #endregion

    } // end class
} // end namespace
