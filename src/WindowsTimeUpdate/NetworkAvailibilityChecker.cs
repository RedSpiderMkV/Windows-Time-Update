using System;
using System.Net.NetworkInformation;
using System.Threading;

namespace NetworkCheck
{
    internal class NetworkAvailibilityChecker
    {
        #region Public Methods

        /// <summary>
        /// Instantiate new network availability testing object.
        /// </summary>
        /// <param name="maxTry">Maximum connection attempts before network fail reported.</param>
        public NetworkAvailibilityChecker(int maxTry)
        {
            maxTry_m = maxTry;
        } // end method

        /// <summary>
        /// Check if network connectivity can be achieved.
        /// </summary>
        /// <returns>True if network is up and running.</returns>
        public bool IsNetworkActive()
        {
            int count = 0;
            while (!NetworkInterface.GetIsNetworkAvailable())
            {
                if (count > maxTry_m)
                {
                    return false;
                } // end if

                Thread.Sleep(10);
                count++;
            } // end while

            return true;
        } // end method

        #endregion

        #region Private Data

        private int maxTry_m;

        #endregion
    } // end class
} // end namespace
