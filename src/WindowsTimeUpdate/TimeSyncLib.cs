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

        public TimeSyncLib()
        {
            webClient_m = new WebClient();
        } // end method

        public DateTimeContainer GetDateTime()
        {
            try
            {
                string response = webClient_m.DownloadString(syncUrl_c);

                JavaScriptSerializer jsonManager = new JavaScriptSerializer();
                Dictionary<string, string> ob = jsonManager.Deserialize<Dictionary<string, string>>(response);

                DateTimeContainer container = new DateTimeContainer(ob["date"], ob["time"]);
                return container;
            }
            catch (Exception e)
            {
                // log this somewhere
                Console.WriteLine(e.Message);
            } // end try-catch

            return null;
        } // end method

        public void Dispose()
        {
            if (webClient_m != null)
            {
                webClient_m.Dispose();
            } // end if
        } // end method

        #endregion

        #region Private Data

        private const string syncUrl_c = @"http://www.portvisibility.co.uk/visibility/tools/showTime.php";

        private WebClient webClient_m;

        #endregion

    } // end class
} // end namespace
