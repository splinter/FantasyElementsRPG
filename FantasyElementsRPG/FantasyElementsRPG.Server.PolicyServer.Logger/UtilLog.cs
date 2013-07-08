using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FantasyElementsRPG.Server.PolicyServer.Logger
{
    class UtilLog
    {
        //file location
        string fileLocation = "Logs/";
        string errLocation = "ErrorLogs/";
        string fileName = "";
        string errorFileName = "";
        /// <summary>
        /// Log file creator BL = if file exists delete it(to clear the log) then remake the file (empty log)
        /// </summary>
        /// <returns></returns>
        public bool CreateFile()
        {
            FileStream fs = null;



            fileName = fileLocation + "log-" + DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss") + ".txt";
            using (fs = File.Create(fileName))
            {

            }
            return true;
        }

        /// <summary>
        /// The function that actually writes to the file, writes the form name as well
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool WriteLog(string formName, string log)
        {

            File.AppendAllText(fileName, Environment.NewLine + DateTime.Now + ": Form Name:" + formName + ", Log: " + log);
            return true;
        }

        /// <summary>
        /// Create an error log in the ErrorLog Folder
        /// </summary>
        /// <returns></returns>
        public bool CreateErrorLog()
        {
            FileStream fs = null;
            errorFileName = errLocation + "errorlog-" + DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss") + ".txt";
            using (fs = File.Create(errorFileName))
            {

            }
            return true;
        }

        /// <summary>
        /// Write to the error log file
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool WriteErrorLog(string formName, string log)
        {
            File.AppendAllText(errorFileName, Environment.NewLine + DateTime.Now + ": Form Name:" + formName + ", Log: " + log);
            return true;
        }
    }
}
