using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

using WindowsTimeSyncLib;
using NetworkCheck;

namespace WindowsTimeUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkAvailibilityChecker networkChecker = new NetworkAvailibilityChecker(3);

            if (networkChecker.IsNetworkActive())
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
