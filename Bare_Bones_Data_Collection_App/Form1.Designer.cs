namespace Bare_Bones_Data_Collection_App
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
            this.button_connection = new System.Windows.Forms.Button();
            this.comboBox_comPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_connectionStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_logExcel = new System.Windows.Forms.CheckBox();
            this.button_changePath = new System.Windows.Forms.Button();
            this.textBox_folderPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_dataIn = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_portRefresh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_connection
            // 
            this.button_connection.Location = new System.Drawing.Point(88, 88);
            this.button_connection.Name = "button_connection";
            this.button_connection.Size = new System.Drawing.Size(59, 37);
            this.button_connection.TabIndex = 0;
            this.button_connection.Text = "OPEN";
            this.button_connection.UseVisualStyleBackColor = true;
            this.button_connection.Click += new System.EventHandler(this.button_connection_Click);
            // 
            // comboBox_comPort
            // 
            this.comboBox_comPort.FormattingEnabled = true;
            this.comboBox_comPort.Location = new System.Drawing.Point(26, 52);
            this.comboBox_comPort.Name = "comboBox_comPort";
            this.comboBox_comPort.Size = new System.Drawing.Size(121, 21);
            this.comboBox_comPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connection Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose COM Port";
            // 
            // label_connectionStatus
            // 
            this.label_connectionStatus.AutoSize = true;
            this.label_connectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_connectionStatus.ForeColor = System.Drawing.Color.Red;
            this.label_connectionStatus.Location = new System.Drawing.Point(49, 166);
            this.label_connectionStatus.Name = "label_connectionStatus";
            this.label_connectionStatus.Size = new System.Drawing.Size(81, 20);
            this.label_connectionStatus.TabIndex = 5;
            this.label_connectionStatus.Text = "CLOSED";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.button_portRefresh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_connectionStatus);
            this.groupBox1.Controls.Add(this.button_connection);
            this.groupBox1.Controls.Add(this.comboBox_comPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 205);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connections";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.checkBox_logExcel);
            this.groupBox2.Controls.Add(this.button_changePath);
            this.groupBox2.Controls.Add(this.textBox_folderPath);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label_dataIn);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(204, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 205);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // checkBox_logExcel
            // 
            this.checkBox_logExcel.AutoSize = true;
            this.checkBox_logExcel.Location = new System.Drawing.Point(29, 90);
            this.checkBox_logExcel.Name = "checkBox_logExcel";
            this.checkBox_logExcel.Size = new System.Drawing.Size(89, 17);
            this.checkBox_logExcel.TabIndex = 9;
            this.checkBox_logExcel.Text = "Log To Excel";
            this.checkBox_logExcel.UseVisualStyleBackColor = true;
            this.checkBox_logExcel.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button_changePath
            // 
            this.button_changePath.Location = new System.Drawing.Point(26, 171);
            this.button_changePath.Name = "button_changePath";
            this.button_changePath.Size = new System.Drawing.Size(92, 25);
            this.button_changePath.TabIndex = 6;
            this.button_changePath.Text = "Change Path";
            this.button_changePath.UseVisualStyleBackColor = true;
            this.button_changePath.Click += new System.EventHandler(this.button_changePath_Click);
            // 
            // textBox_folderPath
            // 
            this.textBox_folderPath.Location = new System.Drawing.Point(21, 144);
            this.textBox_folderPath.Name = "textBox_folderPath";
            this.textBox_folderPath.ReadOnly = true;
            this.textBox_folderPath.Size = new System.Drawing.Size(105, 20);
            this.textBox_folderPath.TabIndex = 8;
            this.textBox_folderPath.Text = "C:\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Excel Folder Path";
            // 
            // label_dataIn
            // 
            this.label_dataIn.AutoSize = true;
            this.label_dataIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dataIn.Location = new System.Drawing.Point(54, 50);
            this.label_dataIn.Name = "label_dataIn";
            this.label_dataIn.Size = new System.Drawing.Size(27, 20);
            this.label_dataIn.TabIndex = 5;
            this.label_dataIn.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Data Live Feed";
            // 
            // button_portRefresh
            // 
            this.button_portRefresh.Location = new System.Drawing.Point(23, 88);
            this.button_portRefresh.Name = "button_portRefresh";
            this.button_portRefresh.Size = new System.Drawing.Size(59, 37);
            this.button_portRefresh.TabIndex = 6;
            this.button_portRefresh.Text = "Refresh Ports";
            this.button_portRefresh.UseVisualStyleBackColor = true;
            this.button_portRefresh.Click += new System.EventHandler(this.button_portRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "1. Choose your COM Port, refresh if you connected USB after starting App";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Instructions";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(340, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "2. Open the COM port connection, you should see data in the live feed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(321, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "4. Check the box to \'Log to Excel\' to start logging, uncheck to stop";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(281, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "3. Change the file path to wherever you want to store data";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 316);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Bare Bones Data Collection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_connection;
        private System.Windows.Forms.ComboBox comboBox_comPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_connectionStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_dataIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_logExcel;
        private System.Windows.Forms.Button button_changePath;
        private System.Windows.Forms.TextBox textBox_folderPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_portRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

