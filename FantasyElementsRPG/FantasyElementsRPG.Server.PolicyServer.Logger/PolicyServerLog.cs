using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace FantasyElementsRPG.Server.PolicyServer.Logger
{
    public sealed class PolicyServerLog
    {
        #region singleton region
        //private instance
        private static volatile PolicyServerLog iLog;
        private static object syncRoot = new Object();
        //private instance
        private PolicyServerLog()
        {
            uLog.CreateFile();
        }

        //public getter
        public static PolicyServerLog Log
        {
            get
            {
                if (iLog == null)
                {
                    lock (syncRoot)
                    {
                        if (iLog == null)
                            iLog = new PolicyServerLog();
                    }
                }

                return iLog;
            }
        }
        #endregion

        #region log work
        //uLog object
        private UtilLog uLog = new UtilLog();
        private RichTextBox iTextBox = new RichTextBox();
        /// <summary>
        /// create file method to access the uLog util
        /// </summary>
        /// <returns></returns>
        private bool CreateFile()
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
            mcFlowDoc = iTextBox.Document;
            Paragraph pr = new Paragraph();
            pr.Inlines.Add(DateTime.Now + ": " + log);
            mcFlowDoc.Blocks.Add(pr);
            iTextBox.Document = mcFlowDoc;

            return uLog.WriteLog(Name, log);
        }

        /// <summary>
        /// Creates an error log file
        /// </summary>
        /// <returns></returns>
        private bool CreateErrorLog()
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
            uLog.CreateErrorLog();

            FlowDocument mcFlowDoc = new FlowDocument();
            mcFlowDoc = iTextBox.Document;
            Paragraph pr = new Paragraph();
            pr.Inlines.Add(DateTime.Now + ": " + log);
            mcFlowDoc.Blocks.Add(pr);
            iTextBox.Document = mcFlowDoc;

            return uLog.WriteErrorLog(Name, log);
        }

        public void SetTextBox(RichTextBox iTextBox)
        {
            this.iTextBox = iTextBox;
        }
        #endregion
    }
}
