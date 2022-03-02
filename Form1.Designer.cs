
namespace Clip2Key.Net
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.txtClip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cboKey = new System.Windows.Forms.ComboBox();
            this.chkAddDelay = new System.Windows.Forms.CheckBox();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(12, 185);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(146, 51);
            this.cmdRefresh.TabIndex = 1;
            this.cmdRefresh.Text = "View Clipboard";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // txtClip
            // 
            this.txtClip.Location = new System.Drawing.Point(12, 12);
            this.txtClip.Multiline = true;
            this.txtClip.Name = "txtClip";
            this.txtClip.Size = new System.Drawing.Size(467, 136);
            this.txtClip.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Types the contents of the clipboard when Right-CTRL is pressed";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Clip2Key";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // cboKey
            // 
            this.cboKey.FormattingEnabled = true;
            this.cboKey.Location = new System.Drawing.Point(170, 185);
            this.cboKey.Name = "cboKey";
            this.cboKey.Size = new System.Drawing.Size(309, 21);
            this.cboKey.TabIndex = 4;
            this.cboKey.SelectedIndexChanged += new System.EventHandler(this.cboKey_SelectedIndexChanged);
            // 
            // chkAddDelay
            // 
            this.chkAddDelay.AutoSize = true;
            this.chkAddDelay.Location = new System.Drawing.Point(261, 162);
            this.chkAddDelay.Name = "chkAddDelay";
            this.chkAddDelay.Size = new System.Drawing.Size(218, 17);
            this.chkAddDelay.TabIndex = 5;
            this.chkAddDelay.Text = "Add the entered delay to each keystroke";
            this.chkAddDelay.UseVisualStyleBackColor = true;
            this.chkAddDelay.CheckedChanged += new System.EventHandler(this.chkAddDelay_CheckedChanged);
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(127, 160);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(92, 20);
            this.txtDelay.TabIndex = 6;
            this.txtDelay.Text = "250";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Keystroke delay in ms";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 248);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDelay);
            this.Controls.Add(this.chkAddDelay);
            this.Controls.Add(this.cboKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClip);
            this.Controls.Add(this.cmdRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Clip2Key";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.TextBox txtClip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox cboKey;
        private System.Windows.Forms.CheckBox chkAddDelay;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Label label2;
    }
}

