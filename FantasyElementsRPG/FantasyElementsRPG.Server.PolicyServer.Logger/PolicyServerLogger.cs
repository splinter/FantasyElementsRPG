using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace FantasyElementsRPG.Server.PolicyServer.Logger
{
    public sealed class PolicyServerLogger
    {
        #region singleton region
        //private instance
        private static volatile PolicyServerLogger iLog;
        private static object syncRoot = new Object();
        //private instance
        private PolicyServerLogger()
        {
            uLog.CreateFile();
        }

        //public getter
        public static PolicyServerLogger PolicyServerLog
        {
            get
            {
                if (iLog == null)
                {
                    lock (syncRoot)
                    {
                        if (iLog == null)
                            iLog = new PolicyServerLogger();
                    }
                }

                return iLog;
            }
        }
        #endregion

        #region processes

        #region variables
        private RichTextBox itextbox = new RichTextBox();
        private UtilLog uLog = new UtilLog();
        #endregion

        public void SetTextBox(RichTextBox itextbox)
        {
            this.itextbox = itextbox;
        }

        /// <summary>
        /// create file method to access the uLog util
        /// </summary>
        /// <returns></returns>
        public bool CreateFile()
        {
            return uLog.CreateFile();
        }

        /// <summary>
        /// write to log method to acces the util class, this sends in the Name as well
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool WriteLog(string Name, string log)
        {
            
            FlowDocument mcFlowDoc = new FlowDocument();
            mcFlowDoc = itextbox.Document;
            Paragraph pr = new Paragraph();
            pr.Inlines.Add(Environment.NewLine + DateTime.Now + ": " +log);
            mcFlowDoc.Blocks.Add(pr);
            itextbox.Document = mcFlowDoc;

            return uLog.WriteLog(Name, log);
        }

        /// <summary>
        /// Creates an error log file
        /// </summary>
        /// <returns></returns>
        public bool CreateErrorLog()
        {
            return uLog.CreateErrorLog();
        }

        /// <summary>
        /// Writes to the error log file
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool WriteErrorLog(string Name, string log)
        {
            FlowDocument mcFlowDoc = new FlowDocument();
            mcFlowDoc = itextbox.Document;
            Paragraph pr = new Paragraph();
            pr.Inlines.Add(Environment.NewLine + DateTime.Now + " Error: " +log);
            mcFlowDoc.Blocks.Add(pr);
            itextbox.Document = mcFlowDoc;

            return uLog.WriteErrorLog(Name, log);
        }

        #endregion
    }
}
