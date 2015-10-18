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
            TimeSyncLib syncLib = new TimeSyncLib();
            DateTimeContainer dateTimeContainer = syncLib.GetDateTime();

            if (dateTimeContainer != null)
            {
                Console.WriteLine(dateTimeContainer.Date);
                Console.WriteLine(dateTimeContainer.Time);
            } // end if

            Console.ReadKey();
        } // end method
    } // end class
} // end namespace
