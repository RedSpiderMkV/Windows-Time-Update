using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

using WindowsTimeSyncLib;

namespace WindowsTimeUpdate
{
    class Program
    {
        private static bool isNetworkActive()
        {
            int count = 0;
            while (!NetworkInterface.GetIsNetworkAvailable())
            {
                if (count > 3)
                {
                    return false;
                } // end if

                System.Threading.Thread.Sleep(10);
                count++;
            } // end while

            return true;
        } // end method

        static void Main(string[] args)
        {
            if (isNetworkActive())
            {
                using (TimeSyncLib syncLib = new TimeSyncLib())
                {
                    DateTimeContainer dateTimeContainer = syncLib.GetDateTime();
                    DateTimeProcessRunner processRunner = new DateTimeProcessRunner();

                    if (dateTimeContainer != null)
                    {
                        processRunner.RunDateTimeCommandProcess("/C time " + dateTimeContainer.DateTime.ToShortTimeString());
                        processRunner.RunDateTimeCommandProcess("/C date " + dateTimeContainer.DateTime.ToShortDateString());
                    } // end if
                } // end using
            } // end if
        } // end method
    } // end class
} // end namespace
