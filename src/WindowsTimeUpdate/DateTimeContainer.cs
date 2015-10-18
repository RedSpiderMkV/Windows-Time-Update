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
        /// Date time.
        /// </summary>
        public DateTime DateTime { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Instantiate new date time container.
        /// </summary>
        /// <param name="dateTime">Date and time.</param>
        public DateTimeContainer(DateTime dateTime)
        {
            DateTime = dateTime;
        } // end method

        #endregion
    } // end class
} // end namespace
