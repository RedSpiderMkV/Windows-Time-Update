using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WindowsTimeSyncLib;

namespace WindowsTimeUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TimeSyncLib syncLib = new TimeSyncLib())
            {
                DateTimeContainer dateTimeContainer = syncLib.GetDateTime();
                DateTimeProcessRunner processRunner = new DateTimeProcessRunner();

                if (dateTimeContainer != null)
                {
                    processRunner.RunDateTimeCommandProcess("/C time " + dateTimeContainer.Time.ToShortTimeString());
                    processRunner.RunDateTimeCommandProcess("/C date " + dateTimeContainer.Date.ToShortDateString());
                } // end if
            } // end using

        } // end method
    } // end class
} // end namespace
