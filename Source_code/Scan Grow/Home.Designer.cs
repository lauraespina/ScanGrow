namespace ScanGrow
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btnStart = new System.Windows.Forms.Button();
            this.cbScanner = new System.Windows.Forms.ComboBox();
            this.form1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.systemDevicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbResolution = new System.Windows.Forms.ComboBox();
            this.nudIntervalMinutes = new System.Windows.Forms.NumericUpDown();
            this.nudNumberOfImages = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flip_test = new System.Windows.Forms.Button();
            this.crop_Test = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTag = new System.Windows.Forms.Button();
            this.tbExcel = new System.Windows.Forms.TextBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSequence = new System.Windows.Forms.Button();
            this.btnShowGraphs = new System.Windows.Forms.Button();
            this.PanelAdvanced = new System.Windows.Forms.Panel();
            this.lblSelectImage = new System.Windows.Forms.Label();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.lbSession = new System.Windows.Forms.Label();
            this.tbWorkingDir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnWorkingDirectory = new System.Windows.Forms.Button();
            this.folderBrowserDialogWorkingDirectory1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbFlipImage = new System.Windows.Forms.CheckBox();
            this.btnOffline = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnWorkingDirectory2 = new System.Windows.Forms.Button();
            this.BTNGroupImages = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tbWorkingDir2 = new System.Windows.Forms.TextBox();
            this.BTWFTest2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnWorkingDirectory3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbWorkingDir3 = new System.Windows.Forms.TextBox();
            this.BtnWorkingDirectory4 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbWorkingDir4 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemDevicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfImages)).BeginInit();
            this.PanelAdvanced.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(319, 212);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // cbScanner
            // 
            this.cbScanner.DataSource = this.form1BindingSource1;
            this.cbScanner.FormattingEnabled = true;
            this.cbScanner.Location = new System.Drawing.Point(113, 35);
            this.cbScanner.Margin = new System.Windows.Forms.Padding(2);
            this.cbScanner.Name = "cbScanner";
            this.cbScanner.Size = new System.Drawing.Size(183, 21);
            this.cbScanner.TabIndex = 1;
            this.cbScanner.SelectedIndexChanged += new System.EventHandler(this.CbScanner_SelectedIndexChanged);
            // 
            // systemDevicesBindingSource
            // 
            this.systemDevicesBindingSource.DataSource = typeof(DNTScanner.Core.SystemDevices);
            // 
            // cbResolution
            // 
            this.cbResolution.FormattingEnabled = true;
            this.cbResolution.Location = new System.Drawing.Point(113, 1);
            this.cbResolution.Margin = new System.Windows.Forms.Padding(2);
            this.cbResolution.Name = "cbResolution";
            this.cbResolution.Size = new System.Drawing.Size(183, 21);
            this.cbResolution.TabIndex = 2;
            this.cbResolution.Visible = false;
            // 
            // nudIntervalMinutes
            // 
            this.nudIntervalMinutes.Location = new System.Drawing.Point(231, 70);
            this.nudIntervalMinutes.Margin = new System.Windows.Forms.Padding(2);
            this.nudIntervalMinutes.Name = "nudIntervalMinutes";
            this.nudIntervalMinutes.Size = new System.Drawing.Size(65, 20);
            this.nudIntervalMinutes.TabIndex = 3;
            // 
            // nudNumberOfImages
            // 
            this.nudNumberOfImages.Location = new System.Drawing.Point(231, 104);
            this.nudNumberOfImages.Margin = new System.Windows.Forms.Padding(2);
            this.nudNumberOfImages.Name = "nudNumberOfImages";
            this.nudNumberOfImages.Size = new System.Drawing.Size(65, 20);
            this.nudNumberOfImages.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Scanner:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Resolution:";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Interval (minutes):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of Scans:";
            // 
            // flip_test
            // 
            this.flip_test.Location = new System.Drawing.Point(12, 63);
            this.flip_test.Name = "flip_test";
            this.flip_test.Size = new System.Drawing.Size(75, 23);
            this.flip_test.TabIndex = 9;
            this.flip_test.Text = "Flip Image";
            this.flip_test.UseVisualStyleBackColor = true;
            this.flip_test.Click += new System.EventHandler(this.Flip_Test_Click);
            // 
            // crop_Test
            // 
            this.crop_Test.Location = new System.Drawing.Point(93, 63);
            this.crop_Test.Name = "crop_Test";
            this.crop_Test.Size = new System.Drawing.Size(75, 23);
            this.crop_Test.TabIndex = 10;
            this.crop_Test.Text = "Split Image";
            this.crop_Test.UseVisualStyleBackColor = true;
            this.crop_Test.Click += new System.EventHandler(this.Crop_Test_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(12, 28);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(294, 20);
            this.tbFileName.TabIndex = 11;
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(313, 28);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 12;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.Btn_Open_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(477, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "1. Tag spectra values to images";
            // 
            // btnTag
            // 
            this.btnTag.Location = new System.Drawing.Point(12, 157);
            this.btnTag.Name = "btnTag";
            this.btnTag.Size = new System.Drawing.Size(75, 23);
            this.btnTag.TabIndex = 14;
            this.btnTag.Text = "Tag Images";
            this.btnTag.UseVisualStyleBackColor = true;
            this.btnTag.Click += new System.EventHandler(this.BtnTag_Click);
            // 
            // tbExcel
            // 
            this.tbExcel.Location = new System.Drawing.Point(12, 118);
            this.tbExcel.Name = "tbExcel";
            this.tbExcel.ReadOnly = true;
            this.tbExcel.Size = new System.Drawing.Size(294, 20);
            this.tbExcel.TabIndex = 15;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(313, 118);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 16;
            this.btnExcel.Text = "Open";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Select Excel File:";
            // 
            // btnSequence
            // 
            this.btnSequence.Location = new System.Drawing.Point(251, 157);
            this.btnSequence.Name = "btnSequence";
            this.btnSequence.Size = new System.Drawing.Size(137, 23);
            this.btnSequence.TabIndex = 20;
            this.btnSequence.Text = "Flip, split and tag images";
            this.btnSequence.UseVisualStyleBackColor = true;
            this.btnSequence.Click += new System.EventHandler(this.BtnSequence_Click);
            // 
            // btnShowGraphs
            // 
            this.btnShowGraphs.Location = new System.Drawing.Point(239, 212);
            this.btnShowGraphs.Name = "btnShowGraphs";
            this.btnShowGraphs.Size = new System.Drawing.Size(75, 35);
            this.btnShowGraphs.TabIndex = 22;
            this.btnShowGraphs.Text = "Show Graphs";
            this.btnShowGraphs.UseVisualStyleBackColor = true;
            this.btnShowGraphs.Click += new System.EventHandler(this.BtnShowGraphs_Click);
            // 
            // PanelAdvanced
            // 
            this.PanelAdvanced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelAdvanced.Controls.Add(this.btnSequence);
            this.PanelAdvanced.Controls.Add(this.btnTag);
            this.PanelAdvanced.Controls.Add(this.btnExcel);
            this.PanelAdvanced.Controls.Add(this.tbExcel);
            this.PanelAdvanced.Controls.Add(this.label6);
            this.PanelAdvanced.Controls.Add(this.crop_Test);
            this.PanelAdvanced.Controls.Add(this.flip_test);
            this.PanelAdvanced.Controls.Add(this.btn_Open);
            this.PanelAdvanced.Controls.Add(this.lblSelectImage);
            this.PanelAdvanced.Controls.Add(this.tbFileName);
            this.PanelAdvanced.Location = new System.Drawing.Point(469, 36);
            this.PanelAdvanced.Name = "PanelAdvanced";
            this.PanelAdvanced.Size = new System.Drawing.Size(482, 204);
            this.PanelAdvanced.TabIndex = 23;
            // 
            // lblSelectImage
            // 
            this.lblSelectImage.AutoSize = true;
            this.lblSelectImage.Location = new System.Drawing.Point(14, 9);
            this.lblSelectImage.Name = "lblSelectImage";
            this.lblSelectImage.Size = new System.Drawing.Size(72, 13);
            this.lblSelectImage.TabIndex = 21;
            this.lblSelectImage.Text = "Select Image:";
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Location = new System.Drawing.Point(18, 212);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(75, 35);
            this.btnAdvanced.TabIndex = 24;
            this.btnAdvanced.Text = "Show Advanced";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.BtnAdvanced_Click);
            // 
            // lbSession
            // 
            this.lbSession.AutoSize = true;
            this.lbSession.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbSession.Location = new System.Drawing.Point(9, 9);
            this.lbSession.Name = "lbSession";
            this.lbSession.Size = new System.Drawing.Size(0, 13);
            this.lbSession.TabIndex = 25;
            // 
            // tbWorkingDir
            // 
            this.tbWorkingDir.Location = new System.Drawing.Point(113, 137);
            this.tbWorkingDir.Name = "tbWorkingDir";
            this.tbWorkingDir.ReadOnly = true;
            this.tbWorkingDir.Size = new System.Drawing.Size(183, 20);
            this.tbWorkingDir.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Working Directory:";
            // 
            // BtnWorkingDirectory
            // 
            this.BtnWorkingDirectory.Location = new System.Drawing.Point(319, 135);
            this.BtnWorkingDirectory.Name = "BtnWorkingDirectory";
            this.BtnWorkingDirectory.Size = new System.Drawing.Size(75, 22);
            this.BtnWorkingDirectory.TabIndex = 28;
            this.BtnWorkingDirectory.Text = "Select";
            this.BtnWorkingDirectory.UseVisualStyleBackColor = true;
            this.BtnWorkingDirectory.Click += new System.EventHandler(this.BtnWorkingDirectory_Click);
            // 
            // cbFlipImage
            // 
            this.cbFlipImage.AutoSize = true;
            this.cbFlipImage.Checked = true;
            this.cbFlipImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFlipImage.Location = new System.Drawing.Point(302, 4);
            this.cbFlipImage.Name = "cbFlipImage";
            this.cbFlipImage.Size = new System.Drawing.Size(74, 17);
            this.cbFlipImage.TabIndex = 30;
            this.cbFlipImage.Text = "Flip Image";
            this.cbFlipImage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.cbFlipImage.UseVisualStyleBackColor = true;
            this.cbFlipImage.Visible = false;
            // 
            // btnOffline
            // 
            this.btnOffline.Location = new System.Drawing.Point(399, 9);
            this.btnOffline.Name = "btnOffline";
            this.btnOffline.Size = new System.Drawing.Size(79, 36);
            this.btnOffline.TabIndex = 22;
            this.btnOffline.Text = "Run Offline";
            this.btnOffline.UseVisualStyleBackColor = true;
            this.btnOffline.Click += new System.EventHandler(this.BtnOffline_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(466, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "3. Test the model";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.BtnWorkingDirectory2);
            this.panel2.Controls.Add(this.BTNGroupImages);
            this.panel2.Location = new System.Drawing.Point(469, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 60);
            this.panel2.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Working Directory:";
            // 
            // BtnWorkingDirectory2
            // 
            this.BtnWorkingDirectory2.Location = new System.Drawing.Point(307, 16);
            this.BtnWorkingDirectory2.Name = "BtnWorkingDirectory2";
            this.BtnWorkingDirectory2.Size = new System.Drawing.Size(75, 22);
            this.BtnWorkingDirectory2.TabIndex = 33;
            this.BtnWorkingDirectory2.Text = "Select";
            this.BtnWorkingDirectory2.UseVisualStyleBackColor = true;
            this.BtnWorkingDirectory2.Click += new System.EventHandler(this.BtnWorkingDirectory2_Click);
            // 
            // BTNGroupImages
            // 
            this.BTNGroupImages.Location = new System.Drawing.Point(396, 10);
            this.BTNGroupImages.Name = "BTNGroupImages";
            this.BTNGroupImages.Size = new System.Drawing.Size(75, 36);
            this.BTNGroupImages.TabIndex = 18;
            this.BTNGroupImages.Text = "Group Images";
            this.BTNGroupImages.UseVisualStyleBackColor = true;
            this.BTNGroupImages.Click += new System.EventHandler(this.BTNGroupImages_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(476, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(170, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "2. Group images by spectra values";
            // 
            // tbWorkingDir2
            // 
            this.tbWorkingDir2.Location = new System.Drawing.Point(572, 283);
            this.tbWorkingDir2.Name = "tbWorkingDir2";
            this.tbWorkingDir2.ReadOnly = true;
            this.tbWorkingDir2.Size = new System.Drawing.Size(183, 20);
            this.tbWorkingDir2.TabIndex = 31;
            // 
            // BTWFTest2
            // 
            this.BTWFTest2.Location = new System.Drawing.Point(400, 8);
            this.BTWFTest2.Name = "BTWFTest2";
            this.BTWFTest2.Size = new System.Drawing.Size(75, 37);
            this.BTWFTest2.TabIndex = 37;
            this.BTWFTest2.Text = "Test Model";
            this.BTWFTest2.Click += new System.EventHandler(this.BTWFTest2_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnWorkingDirectory3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.BTWFTest2);
            this.panel1.Controls.Add(this.tbWorkingDir3);
            this.panel1.Location = new System.Drawing.Point(467, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 56);
            this.panel1.TabIndex = 25;
            // 
            // BtnWorkingDirectory3
            // 
            this.BtnWorkingDirectory3.Location = new System.Drawing.Point(309, 17);
            this.BtnWorkingDirectory3.Name = "BtnWorkingDirectory3";
            this.BtnWorkingDirectory3.Size = new System.Drawing.Size(75, 22);
            this.BtnWorkingDirectory3.TabIndex = 36;
            this.BtnWorkingDirectory3.Text = "Select";
            this.BtnWorkingDirectory3.UseVisualStyleBackColor = true;
            this.BtnWorkingDirectory3.Click += new System.EventHandler(this.BtnWorkingDirectory3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Working Directory:";
            // 
            // tbWorkingDir3
            // 
            this.tbWorkingDir3.Location = new System.Drawing.Point(111, 17);
            this.tbWorkingDir3.Name = "tbWorkingDir3";
            this.tbWorkingDir3.ReadOnly = true;
            this.tbWorkingDir3.Size = new System.Drawing.Size(183, 20);
            this.tbWorkingDir3.TabIndex = 34;
            // 
            // BtnWorkingDirectory4
            // 
            this.BtnWorkingDirectory4.Location = new System.Drawing.Point(308, 18);
            this.BtnWorkingDirectory4.Name = "BtnWorkingDirectory4";
            this.BtnWorkingDirectory4.Size = new System.Drawing.Size(75, 22);
            this.BtnWorkingDirectory4.TabIndex = 36;
            this.BtnWorkingDirectory4.Text = "Select";
            this.BtnWorkingDirectory4.UseVisualStyleBackColor = true;
            this.BtnWorkingDirectory4.Click += new System.EventHandler(this.BtnWorkingDirectory4_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Working Directory:";
            // 
            // tbWorkingDir4
            // 
            this.tbWorkingDir4.Location = new System.Drawing.Point(110, 18);
            this.tbWorkingDir4.Name = "tbWorkingDir4";
            this.tbWorkingDir4.ReadOnly = true;
            this.tbWorkingDir4.Size = new System.Drawing.Size(183, 20);
            this.tbWorkingDir4.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.BtnWorkingDirectory4);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tbWorkingDir4);
            this.panel3.Controls.Add(this.btnOffline);
            this.panel3.Location = new System.Drawing.Point(466, 440);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(482, 56);
            this.panel3.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(466, 424);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Run Offline";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(457, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(502, 417);
            this.panel4.TabIndex = 40;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel5.Location = new System.Drawing.Point(429, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 487);
            this.panel5.TabIndex = 41;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 273);
            this.Controls.Add(this.PanelAdvanced);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbWorkingDir2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbFlipImage);
            this.Controls.Add(this.BtnWorkingDirectory);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbWorkingDir);
            this.Controls.Add(this.lbSession);
            this.Controls.Add(this.btnAdvanced);
            this.Controls.Add(this.btnShowGraphs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudNumberOfImages);
            this.Controls.Add(this.nudIntervalMinutes);
            this.Controls.Add(this.cbResolution);
            this.Controls.Add(this.cbScanner);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.Text = "ScanGrow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemDevicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfImages)).EndInit();
            this.PanelAdvanced.ResumeLayout(false);
            this.PanelAdvanced.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbScanner;
        private System.Windows.Forms.BindingSource systemDevicesBindingSource;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.BindingSource form1BindingSource1;
        private System.Windows.Forms.ComboBox cbResolution;
        private System.Windows.Forms.NumericUpDown nudIntervalMinutes;
        private System.Windows.Forms.NumericUpDown nudNumberOfImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button flip_test;
        private System.Windows.Forms.Button crop_Test;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTag;
        private System.Windows.Forms.TextBox tbExcel;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSequence;
        private System.Windows.Forms.Button btnShowGraphs;
        private System.Windows.Forms.Panel PanelAdvanced;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.Label lbSession;
        private System.Windows.Forms.Label lblSelectImage;
        private System.Windows.Forms.TextBox tbWorkingDir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnWorkingDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogWorkingDirectory1;
        private System.Windows.Forms.CheckBox cbFlipImage;
        private System.Windows.Forms.Button btnOffline;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnWorkingDirectory2;
        private System.Windows.Forms.Button BTNGroupImages;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbWorkingDir2;
        private System.Windows.Forms.Button BTWFTest2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnWorkingDirectory3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbWorkingDir3;
        private System.Windows.Forms.Button BtnWorkingDirectory4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbWorkingDir4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}

