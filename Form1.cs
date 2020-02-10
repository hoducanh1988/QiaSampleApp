using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QC.QSPRSchedulerWrapper;
using QC.QTMInterface;
using System.IO;

namespace QiaSample
{
    public partial class Form1 : Form
    {
        #region Private members

        QSPRScheduler _scheduler;
        QSPRTestTree _testTree;
        bool closeAfterRun = false;

        #endregion

        #region Constructor

        public Form1(string[] args)
        {
            InitializeComponent();

            progressBar1.Visible = false;
            buttonRunTree.Enabled = false;
            buttonRunLastFolder.Enabled = false;
            buttonStop.Enabled = false;

            _scheduler = new QSPRScheduler();
            _scheduler.OnDebugMessage += new QSPRScheduler.OnDebugMessageEventHandler(_scheduler_OnDebugMessage);
            _scheduler.OnTestMessage += new QSPRScheduler.OnTestMessageEventHandler(_scheduler_OnTestMessage);
            _scheduler.LoadWorkspaceConfig(@"C:\Qualcomm\QSPR\QSPRConfigurations\Workspace.config");


            if (args.Length > 0)
            {
                ParseCmdArgs(args);
            }
        }

        #endregion

        #region Private methods

        private void ParseCmdArgs(string[] args)
        {
            string xttFileName = args[0];
            if (File.Exists(xttFileName) && xttFileName.ToLower().EndsWith(".xtt"))
            {
                _testTree = _scheduler.OpenXTT(xttFileName);
                _testTree.RunTree();

                foreach (string arg in args)
                {
                    if (arg.ToLower() == "/close")
                    {
                        closeAfterRun = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Error in command line arguments. The first cmd argument should be an xtt filename that exists.");
            }
        }

        private void UpdateUI(bool treeRunning)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate { UpdateUI(treeRunning); }));
                return;
            }

            buttonRunLastFolder.Enabled = !treeRunning;
            buttonOpenTree.Enabled = !treeRunning;
            buttonRunTree.Enabled = !treeRunning;
            buttonStop.Enabled = treeRunning;
            progressBar1.Visible = treeRunning;
        }

        private void _scheduler_OnDebugMessage(string strWin, string strText, int traceLevel, bool NoEndOfLine)
        {
            UpdateStatusWindow(strWin + ": " + strText);
        }

        private void _scheduler_OnTestMessage(int messageType, QSPRTestMessage messageData)
        {
            switch ((TestMsgTypes)messageType)
            {
                case TestMsgTypes.ON_UNIT_START:
                    {
                        string sn = messageData.GetValue(TestMsgItemNames.SN);
                        string testCount = messageData.GetValue(TestMsgItemNames.TEST_COUNT);
                        UpdateStatusWindow("Tree contains " + testCount + " tests and was started with serial number: " + sn);
                        break;
                    }
                case TestMsgTypes.ON_UNIT_END:
                    {
                        string errorCode = messageData.GetValue(TestMsgItemNames.ERROR_CODE);
                        string testResult = messageData.GetValue(TestMsgItemNames.TESTRESULT);
                        UpdateStatusWindow("Tree finished with result: " + testResult + " and error code: " + errorCode);
                        if (closeAfterRun == true)
                        {
                            if (this.InvokeRequired)
                            {
                                this.BeginInvoke(new MethodInvoker(delegate { this.Close(); }));
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        break;
                    }
                case TestMsgTypes.ON_TEST_START:
                    {
                        string testName = messageData.GetValue(TestMsgItemNames.TESTNAME);
                        string startTime = messageData.GetValue(TestMsgItemNames.START_TIME);
                        UpdateStatusWindow("Test started: " + testName + " at: " + startTime);
                        break;
                    }
                case TestMsgTypes.ON_TEST_RESULT:
                    {
                        string testName = messageData.GetValue(TestMsgItemNames.TESTNAME);
                        string testResult = messageData.GetValue(TestMsgItemNames.TESTRESULT);
                        string loopInfo = messageData.GetValue(TestMsgItemNames.LOOP_DETAILS);
                        UpdateStatusWindow("Test finished: " + testName + " with result: " + testResult + " LOOP_DETAILS=" + loopInfo ?? "");

                        string[] msgItemNames = messageData.GetItemNames();

                        foreach (string itemName in msgItemNames)
                        {
                            // if the item is an output parameter
                            if(itemName.StartsWith(TestMsgItemNames.OUTPUT_PARAM_PREFIX))
                            {
                                string outParamValue = messageData.GetValue(itemName);
                            }
                        }

                        break;
                    }
            }
        }

        private void buttonOpenTree_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select a test tree (.xtt) to open";
            dlg.Filter = "Test Tree Files | *.xtt";
            dlg.DefaultExt = "xtt";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                labelTreeFileName.Text = dlg.FileName;
                _testTree = _scheduler.OpenXTT(dlg.FileName);
                _testTree.RunTreeDone += new QSPRTestTree.RunTreeDoneEventHandler(_testTree_RunTreeDone);

                buttonRunTree.Enabled = true;
                buttonRunLastFolder.Enabled = true;
            }
        }

        private void _testTree_RunTreeDone(bool treePassed)
        {
            UpdateUI(false);
        }

        private void buttonRunTree_Click(object sender, EventArgs e)
        {
            if (_testTree != null)
            {
                ClearStatusWindow();
                _scheduler.SetGlobalVariable("SN", "123");
                _testTree.RunTree();
                UpdateUI(true);
            }
        }

        private void UpdateStatusWindow(string msg)
        {
            if (this.InvokeRequired == true)
            {
                this.BeginInvoke(new MethodInvoker(delegate { UpdateStatusWindow(msg); }));
                return;
            }

            richTextBoxStatus.AppendText(msg + Environment.NewLine);
        }

        private void ClearStatusWindow()
        {
            if (this.InvokeRequired == true)
            {
                this.BeginInvoke(new MethodInvoker(delegate { ClearStatusWindow(); }));
                return;
            }

            richTextBoxStatus.Clear();
        }

        private void buttonClearText_Click(object sender, EventArgs e)
        {
            ClearStatusWindow();
        }

        private void buttonRunLastFolder_Click(object sender, EventArgs e)
        {
            string[] subFolders;
            int folderCount = 0;

            // get all the folders under the Root
            _testTree.GetAllFolderTests("", out subFolders, out folderCount);

            // run the last folder under the root
            if(folderCount > 0)
                _testTree.RunTest(subFolders[folderCount - 1]);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _testTree.StopTest();
        }

        #endregion
    }
}
