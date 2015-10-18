using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsTimeSyncLib
{
    internal class DateTimeContainer
    {
        #region Properties

        public string Date { get; private set; }
        public string Time { get; private set; }

        #endregion

        #region Public Methods

        public DateTimeContainer(string date, string time)
        {
            Date = date;
            Time = time;
        } // end method

        #endregion
    } // end class
} // end namespace
