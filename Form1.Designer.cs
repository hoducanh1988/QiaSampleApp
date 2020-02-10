namespace QiaSample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpenTree = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTreeFileName = new System.Windows.Forms.Label();
            this.buttonRunTree = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonRunLastFolder = new System.Windows.Forms.Button();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClearText = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDebugMessages = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPageDebugMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenTree
            // 
            this.buttonOpenTree.Location = new System.Drawing.Point(15, 12);
            this.buttonOpenTree.Name = "buttonOpenTree";
            this.buttonOpenTree.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenTree.TabIndex = 0;
            this.buttonOpenTree.Text = "Open Tree";
            this.buttonOpenTree.UseVisualStyleBackColor = true;
            this.buttonOpenTree.Click += new System.EventHandler(this.buttonOpenTree_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Test Tree:";
            // 
            // labelTreeFileName
            // 
            this.labelTreeFileName.AutoSize = true;
            this.labelTreeFileName.Location = new System.Drawing.Point(84, 53);
            this.labelTreeFileName.Name = "labelTreeFileName";
            this.labelTreeFileName.Size = new System.Drawing.Size(73, 13);
            this.labelTreeFileName.TabIndex = 2;
            this.labelTreeFileName.Text = "TreeFileName";
            // 
            // buttonRunTree
            // 
            this.buttonRunTree.Location = new System.Drawing.Point(15, 96);
            this.buttonRunTree.Name = "buttonRunTree";
            this.buttonRunTree.Size = new System.Drawing.Size(75, 23);
            this.buttonRunTree.TabIndex = 3;
            this.buttonRunTree.Text = "Run Tree";
            this.buttonRunTree.UseVisualStyleBackColor = true;
            this.buttonRunTree.Click += new System.EventHandler(this.buttonRunTree_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(96, 96);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop Tree";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonRunLastFolder
            // 
            this.buttonRunLastFolder.Location = new System.Drawing.Point(177, 96);
            this.buttonRunLastFolder.Name = "buttonRunLastFolder";
            this.buttonRunLastFolder.Size = new System.Drawing.Size(113, 23);
            this.buttonRunLastFolder.TabIndex = 5;
            this.buttonRunLastFolder.Text = "Run Last Folder";
            this.buttonRunLastFolder.UseVisualStyleBackColor = true;
            this.buttonRunLastFolder.Click += new System.EventHandler(this.buttonRunLastFolder_Click);
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStatus.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.ReadOnly = true;
            this.richTextBoxStatus.Size = new System.Drawing.Size(737, 330);
            this.richTextBoxStatus.TabIndex = 6;
            this.richTextBoxStatus.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Status:";
            // 
            // buttonClearText
            // 
            this.buttonClearText.Location = new System.Drawing.Point(272, 123);
            this.buttonClearText.Name = "buttonClearText";
            this.buttonClearText.Size = new System.Drawing.Size(75, 23);
            this.buttonClearText.TabIndex = 8;
            this.buttonClearText.Text = "Clear Text";
            this.buttonClearText.UseVisualStyleBackColor = true;
            this.buttonClearText.Click += new System.EventHandler(this.buttonClearText_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageDebugMessages);
            this.tabControl1.Location = new System.Drawing.Point(15, 152);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(751, 362);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageDebugMessages
            // 
            this.tabPageDebugMessages.Controls.Add(this.richTextBoxStatus);
            this.tabPageDebugMessages.Location = new System.Drawing.Point(4, 22);
            this.tabPageDebugMessages.Name = "tabPageDebugMessages";
            this.tabPageDebugMessages.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDebugMessages.Size = new System.Drawing.Size(743, 336);
            this.tabPageDebugMessages.TabIndex = 0;
            this.tabPageDebugMessages.Text = "Debug Messages";
            this.tabPageDebugMessages.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(22, 519);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(135, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 547);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonClearText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRunLastFolder);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonRunTree);
            this.Controls.Add(this.labelTreeFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpenTree);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageDebugMessages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTreeFileName;
        private System.Windows.Forms.Button buttonRunTree;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonRunLastFolder;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonClearText;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDebugMessages;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

