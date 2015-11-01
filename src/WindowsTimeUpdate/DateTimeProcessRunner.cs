using System;
using System.Diagnostics;

namespace WindowsTimeUpdate
{
    internal class DateTimeProcessRunner
    {
        #region Public Methods

        /// <summary>
        /// Run date or time command to set system date/time.
        /// </summary>
        /// <param name="command">Command i.e. date or time followed by values.</param>
        public void RunDateTimeCommandProcess(string command)
        {
            using (Process dateTimeProcess = new Process())
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = command
                };

                dateTimeProcess.StartInfo = procStartInfo;

                try
                {
                    if (dateTimeProcess.Start())
                    {
                        dateTimeProcess.WaitForExit();
                    } // end if
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                } // end try-catch
            } // end using
        } // end method

        #endregion

    } // end class
} // end namespace
