namespace KSPControllerTest
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.outerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.innerNavViewPanel = new System.Windows.Forms.TableLayoutPanel();
            this.navLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gameSceneLabel = new System.Windows.Forms.Label();
            this.navButtonLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.spaceCenterButton = new System.Windows.Forms.Button();
            this.flightButton = new System.Windows.Forms.Button();
            this.trackingStationButton = new System.Windows.Forms.Button();
            this.vabButton = new System.Windows.Forms.Button();
            this.sphButton = new System.Windows.Forms.Button();
            this.viewPortLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.resourceLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.scienceResourceLabel = new System.Windows.Forms.Label();
            this.fundsResourceLabel = new System.Windows.Forms.Label();
            this.reputationResourceLabel = new System.Windows.Forms.Label();
            this.timeResourceLabel = new System.Windows.Forms.Label();
            this.connectionStatusLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.outerPanel.SuspendLayout();
            this.innerNavViewPanel.SuspendLayout();
            this.navLayoutPanel.SuspendLayout();
            this.navButtonLayoutPanel.SuspendLayout();
            this.viewPortLayoutPanel.SuspendLayout();
            this.resourceLayoutPanel.SuspendLayout();
            this.connectionStatusLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConnectionBackgroundWorker_DoWork);
            // 
            // outerPanel
            // 
            this.outerPanel.ColumnCount = 1;
            this.outerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerPanel.Controls.Add(this.innerNavViewPanel, 0, 0);
            this.outerPanel.Controls.Add(this.connectionStatusLayoutPanel, 0, 2);
            this.outerPanel.Controls.Add(this.logTextBox, 0, 1);
            this.outerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerPanel.Location = new System.Drawing.Point(0, 0);
            this.outerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.RowCount = 3;
            this.outerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.outerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.outerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.outerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.outerPanel.Size = new System.Drawing.Size(850, 596);
            this.outerPanel.TabIndex = 0;
            // 
            // innerNavViewPanel
            // 
            this.innerNavViewPanel.ColumnCount = 2;
            this.innerNavViewPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.innerNavViewPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.innerNavViewPanel.Controls.Add(this.navLayoutPanel, 0, 0);
            this.innerNavViewPanel.Controls.Add(this.viewPortLayoutPanel, 1, 0);
            this.innerNavViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerNavViewPanel.Location = new System.Drawing.Point(0, 0);
            this.innerNavViewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.innerNavViewPanel.Name = "innerNavViewPanel";
            this.innerNavViewPanel.RowCount = 1;
            this.innerNavViewPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.innerNavViewPanel.Size = new System.Drawing.Size(850, 389);
            this.innerNavViewPanel.TabIndex = 0;
            // 
            // navLayoutPanel
            // 
            this.navLayoutPanel.ColumnCount = 1;
            this.navLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navLayoutPanel.Controls.Add(this.gameSceneLabel, 0, 0);
            this.navLayoutPanel.Controls.Add(this.navButtonLayoutPanel, 0, 1);
            this.navLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.navLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.navLayoutPanel.Name = "navLayoutPanel";
            this.navLayoutPanel.RowCount = 2;
            this.navLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.navLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navLayoutPanel.Size = new System.Drawing.Size(212, 389);
            this.navLayoutPanel.TabIndex = 0;
            // 
            // gameSceneLabel
            // 
            this.gameSceneLabel.AutoSize = true;
            this.gameSceneLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameSceneLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameSceneLabel.Location = new System.Drawing.Point(0, 0);
            this.gameSceneLabel.Margin = new System.Windows.Forms.Padding(0);
            this.gameSceneLabel.Name = "gameSceneLabel";
            this.gameSceneLabel.Size = new System.Drawing.Size(212, 30);
            this.gameSceneLabel.TabIndex = 0;
            this.gameSceneLabel.Text = "Game Scene:";
            this.gameSceneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // navButtonLayoutPanel
            // 
            this.navButtonLayoutPanel.ColumnCount = 1;
            this.navButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navButtonLayoutPanel.Controls.Add(this.spaceCenterButton, 0, 0);
            this.navButtonLayoutPanel.Controls.Add(this.flightButton, 0, 1);
            this.navButtonLayoutPanel.Controls.Add(this.trackingStationButton, 0, 2);
            this.navButtonLayoutPanel.Controls.Add(this.vabButton, 0, 3);
            this.navButtonLayoutPanel.Controls.Add(this.sphButton, 0, 4);
            this.navButtonLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navButtonLayoutPanel.Location = new System.Drawing.Point(0, 40);
            this.navButtonLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.navButtonLayoutPanel.Name = "navButtonLayoutPanel";
            this.navButtonLayoutPanel.RowCount = 6;
            this.navButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.navButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.navButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.navButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.navButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.navButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navButtonLayoutPanel.Size = new System.Drawing.Size(212, 349);
            this.navButtonLayoutPanel.TabIndex = 1;
            // 
            // spaceCenterButton
            // 
            this.spaceCenterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spaceCenterButton.Location = new System.Drawing.Point(0, 5);
            this.spaceCenterButton.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.spaceCenterButton.Name = "spaceCenterButton";
            this.spaceCenterButton.Size = new System.Drawing.Size(212, 40);
            this.spaceCenterButton.TabIndex = 0;
            this.spaceCenterButton.Text = "Space Center";
            this.spaceCenterButton.UseVisualStyleBackColor = true;
            // 
            // flightButton
            // 
            this.flightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flightButton.Location = new System.Drawing.Point(0, 55);
            this.flightButton.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flightButton.Name = "flightButton";
            this.flightButton.Size = new System.Drawing.Size(212, 40);
            this.flightButton.TabIndex = 1;
            this.flightButton.Text = "Flight";
            this.flightButton.UseVisualStyleBackColor = true;
            // 
            // trackingStationButton
            // 
            this.trackingStationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackingStationButton.Location = new System.Drawing.Point(0, 105);
            this.trackingStationButton.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.trackingStationButton.Name = "trackingStationButton";
            this.trackingStationButton.Size = new System.Drawing.Size(212, 40);
            this.trackingStationButton.TabIndex = 2;
            this.trackingStationButton.Text = "Tracking Station";
            this.trackingStationButton.UseVisualStyleBackColor = true;
            // 
            // vabButton
            // 
            this.vabButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vabButton.Location = new System.Drawing.Point(0, 155);
            this.vabButton.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.vabButton.Name = "vabButton";
            this.vabButton.Size = new System.Drawing.Size(212, 40);
            this.vabButton.TabIndex = 3;
            this.vabButton.Text = "VAB";
            this.vabButton.UseVisualStyleBackColor = true;
            // 
            // sphButton
            // 
            this.sphButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sphButton.Location = new System.Drawing.Point(0, 205);
            this.sphButton.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.sphButton.Name = "sphButton";
            this.sphButton.Size = new System.Drawing.Size(212, 40);
            this.sphButton.TabIndex = 4;
            this.sphButton.Text = "SPH";
            this.sphButton.UseVisualStyleBackColor = true;
            // 
            // viewPortLayoutPanel
            // 
            this.viewPortLayoutPanel.ColumnCount = 1;
            this.viewPortLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewPortLayoutPanel.Controls.Add(this.resourceLayoutPanel, 0, 0);
            this.viewPortLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPortLayoutPanel.Location = new System.Drawing.Point(212, 0);
            this.viewPortLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewPortLayoutPanel.Name = "viewPortLayoutPanel";
            this.viewPortLayoutPanel.RowCount = 2;
            this.viewPortLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.viewPortLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewPortLayoutPanel.Size = new System.Drawing.Size(638, 389);
            this.viewPortLayoutPanel.TabIndex = 1;
            // 
            // resourceLayoutPanel
            // 
            this.resourceLayoutPanel.ColumnCount = 4;
            this.resourceLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.resourceLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.resourceLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.resourceLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.resourceLayoutPanel.Controls.Add(this.scienceResourceLabel, 0, 0);
            this.resourceLayoutPanel.Controls.Add(this.fundsResourceLabel, 1, 0);
            this.resourceLayoutPanel.Controls.Add(this.reputationResourceLabel, 2, 0);
            this.resourceLayoutPanel.Controls.Add(this.timeResourceLabel, 3, 0);
            this.resourceLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.resourceLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.resourceLayoutPanel.Name = "resourceLayoutPanel";
            this.resourceLayoutPanel.RowCount = 1;
            this.resourceLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resourceLayoutPanel.Size = new System.Drawing.Size(638, 30);
            this.resourceLayoutPanel.TabIndex = 0;
            // 
            // scienceResourceLabel
            // 
            this.scienceResourceLabel.AutoSize = true;
            this.scienceResourceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scienceResourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scienceResourceLabel.Location = new System.Drawing.Point(2, 0);
            this.scienceResourceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.scienceResourceLabel.Name = "scienceResourceLabel";
            this.scienceResourceLabel.Size = new System.Drawing.Size(138, 30);
            this.scienceResourceLabel.TabIndex = 0;
            this.scienceResourceLabel.Text = "Science:";
            this.scienceResourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fundsResourceLabel
            // 
            this.fundsResourceLabel.AutoSize = true;
            this.fundsResourceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fundsResourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fundsResourceLabel.Location = new System.Drawing.Point(142, 0);
            this.fundsResourceLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.fundsResourceLabel.Name = "fundsResourceLabel";
            this.fundsResourceLabel.Size = new System.Drawing.Size(139, 30);
            this.fundsResourceLabel.TabIndex = 1;
            this.fundsResourceLabel.Text = "Funds:";
            this.fundsResourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reputationResourceLabel
            // 
            this.reputationResourceLabel.AutoSize = true;
            this.reputationResourceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reputationResourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reputationResourceLabel.Location = new System.Drawing.Point(283, 0);
            this.reputationResourceLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.reputationResourceLabel.Name = "reputationResourceLabel";
            this.reputationResourceLabel.Size = new System.Drawing.Size(139, 30);
            this.reputationResourceLabel.TabIndex = 2;
            this.reputationResourceLabel.Text = "Rep:";
            this.reputationResourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeResourceLabel
            // 
            this.timeResourceLabel.AutoSize = true;
            this.timeResourceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeResourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeResourceLabel.Location = new System.Drawing.Point(424, 0);
            this.timeResourceLabel.Margin = new System.Windows.Forms.Padding(1, 0, 2, 0);
            this.timeResourceLabel.Name = "timeResourceLabel";
            this.timeResourceLabel.Size = new System.Drawing.Size(212, 30);
            this.timeResourceLabel.TabIndex = 3;
            this.timeResourceLabel.Text = "Time:";
            this.timeResourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // connectionStatusLayoutPanel
            // 
            this.connectionStatusLayoutPanel.ColumnCount = 3;
            this.connectionStatusLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.connectionStatusLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.connectionStatusLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.connectionStatusLayoutPanel.Controls.Add(this.connectButton, 0, 0);
            this.connectionStatusLayoutPanel.Controls.Add(this.disconnectButton, 1, 0);
            this.connectionStatusLayoutPanel.Controls.Add(this.connectionLabel, 2, 0);
            this.connectionStatusLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionStatusLayoutPanel.Location = new System.Drawing.Point(0, 555);
            this.connectionStatusLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.connectionStatusLayoutPanel.Name = "connectionStatusLayoutPanel";
            this.connectionStatusLayoutPanel.RowCount = 1;
            this.connectionStatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.connectionStatusLayoutPanel.Size = new System.Drawing.Size(850, 41);
            this.connectionStatusLayoutPanel.TabIndex = 1;
            // 
            // connectButton
            // 
            this.connectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectButton.Location = new System.Drawing.Point(0, 0);
            this.connectButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(280, 41);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.disconnectButton.Location = new System.Drawing.Point(286, 0);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(280, 41);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionLabel.Location = new System.Drawing.Point(566, 0);
            this.connectionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(284, 41);
            this.connectionLabel.TabIndex = 2;
            this.connectionLabel.Text = "Connection Status:";
            this.connectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logTextBox
            // 
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.Location = new System.Drawing.Point(1, 390);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(848, 164);
            this.logTextBox.TabIndex = 2;
            this.logTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 596);
            this.Controls.Add(this.outerPanel);
            this.Name = "Form1";
            this.Text = "KSP Controller";
            this.Load += new System.EventHandler(this.Form1_load);
            this.outerPanel.ResumeLayout(false);
            this.innerNavViewPanel.ResumeLayout(false);
            this.navLayoutPanel.ResumeLayout(false);
            this.navLayoutPanel.PerformLayout();
            this.navButtonLayoutPanel.ResumeLayout(false);
            this.viewPortLayoutPanel.ResumeLayout(false);
            this.resourceLayoutPanel.ResumeLayout(false);
            this.resourceLayoutPanel.PerformLayout();
            this.connectionStatusLayoutPanel.ResumeLayout(false);
            this.connectionStatusLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel outerPanel;
        private System.Windows.Forms.TableLayoutPanel innerNavViewPanel;
        private System.Windows.Forms.TableLayoutPanel navLayoutPanel;
        private System.Windows.Forms.Label gameSceneLabel;
        private System.Windows.Forms.TableLayoutPanel navButtonLayoutPanel;
        private System.Windows.Forms.Button spaceCenterButton;
        private System.Windows.Forms.Button flightButton;
        private System.Windows.Forms.Button trackingStationButton;
        private System.Windows.Forms.Button vabButton;
        private System.Windows.Forms.Button sphButton;
        private System.Windows.Forms.TableLayoutPanel viewPortLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel resourceLayoutPanel;
        private System.Windows.Forms.Label scienceResourceLabel;
        private System.Windows.Forms.Label fundsResourceLabel;
        private System.Windows.Forms.Label reputationResourceLabel;
        private System.Windows.Forms.Label timeResourceLabel;
        private System.Windows.Forms.TableLayoutPanel connectionStatusLayoutPanel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.RichTextBox logTextBox;
    }
}

