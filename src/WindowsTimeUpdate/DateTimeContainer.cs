using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsTimeSyncLib
{
    internal class DateTimeContainer
    {
        #region Properties

        /// <summary>
        /// Date.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Time.
        /// </summary>
        public DateTime Time { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Instantiate new date time container.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <param name="time">Time.</param>
        public DateTimeContainer(DateTime date, DateTime time)
        {
            Date = date;
            Time = time;
        } // end method

        #endregion
    } // end class
} // end namespace
