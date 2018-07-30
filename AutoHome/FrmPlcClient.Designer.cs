namespace AutoHome
{
    partial class FrmPlcClient
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
            this.label_CpsStatus = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_status = new System.Windows.Forms.Button();
            this.button_setTime = new System.Windows.Forms.Button();
            this.button_ReadRunningConfig = new System.Windows.Forms.Button();
            this.button_CopyRunningToStartupConfig = new System.Windows.Forms.Button();
            this.button_CopyStartupToRunningConfig = new System.Windows.Forms.Button();
            this.button_send_ibs = new System.Windows.Forms.Button();
            this.label_plc_time = new System.Windows.Forms.Label();
            this.label_timeJitterDesc = new System.Windows.Forms.Label();
            this.label_time_difference = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_headerFlag = new System.Windows.Forms.ComboBox();
            this.panel_sendMsg = new System.Windows.Forms.Panel();
            this.panel_IOdata = new System.Windows.Forms.Panel();
            this.textBox_aktuatorID = new System.Windows.Forms.TextBox();
            this.label_aktuatorID = new System.Windows.Forms.Label();
            this.textBox_payload = new System.Windows.Forms.TextBox();
            this.label_reconnect_counter = new System.Windows.Forms.Label();
            this.label_display_reconnect_counter = new System.Windows.Forms.Label();
            this.button_send_get_request = new System.Windows.Forms.Button();
            this.groupBox_subscribe = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ManagementDataCycle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_prozessDataCycle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_prozessDataTopics = new System.Windows.Forms.TextBox();
            this.button_subscribe_topics = new System.Windows.Forms.Button();
            this.checkBox_subscribe_PlcManagementData = new System.Windows.Forms.CheckBox();
            this.checkBox_subscribeProzessData = new System.Windows.Forms.CheckBox();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBox_connectAtStartup = new System.Windows.Forms.CheckBox();
            this.panel_sendMsg.SuspendLayout();
            this.panel_IOdata.SuspendLayout();
            this.groupBox_subscribe.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_CpsStatus
            // 
            this.label_CpsStatus.AutoSize = true;
            this.label_CpsStatus.Location = new System.Drawing.Point(4, 7);
            this.label_CpsStatus.Name = "label_CpsStatus";
            this.label_CpsStatus.Size = new System.Drawing.Size(58, 13);
            this.label_CpsStatus.TabIndex = 0;
            this.label_CpsStatus.Text = "Cps Status";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(12, 43);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 1;
            this.button_connect.Text = "connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_status
            // 
            this.button_status.Enabled = false;
            this.button_status.Location = new System.Drawing.Point(12, 72);
            this.button_status.Name = "button_status";
            this.button_status.Size = new System.Drawing.Size(75, 23);
            this.button_status.TabIndex = 2;
            this.button_status.Text = "status";
            this.button_status.UseVisualStyleBackColor = true;
            this.button_status.Click += new System.EventHandler(this.button_status_Click);
            // 
            // button_setTime
            // 
            this.button_setTime.Location = new System.Drawing.Point(12, 101);
            this.button_setTime.Name = "button_setTime";
            this.button_setTime.Size = new System.Drawing.Size(75, 23);
            this.button_setTime.TabIndex = 3;
            this.button_setTime.Text = "set PLC time";
            this.button_setTime.UseVisualStyleBackColor = true;
            this.button_setTime.Click += new System.EventHandler(this.button_setTime_Click);
            // 
            // button_ReadRunningConfig
            // 
            this.button_ReadRunningConfig.Location = new System.Drawing.Point(111, 43);
            this.button_ReadRunningConfig.Name = "button_ReadRunningConfig";
            this.button_ReadRunningConfig.Size = new System.Drawing.Size(175, 23);
            this.button_ReadRunningConfig.TabIndex = 4;
            this.button_ReadRunningConfig.Text = "read running config";
            this.button_ReadRunningConfig.UseVisualStyleBackColor = true;
            this.button_ReadRunningConfig.Click += new System.EventHandler(this.button_ReadRunningConfig_Click);
            // 
            // button_CopyRunningToStartupConfig
            // 
            this.button_CopyRunningToStartupConfig.Location = new System.Drawing.Point(111, 72);
            this.button_CopyRunningToStartupConfig.Name = "button_CopyRunningToStartupConfig";
            this.button_CopyRunningToStartupConfig.Size = new System.Drawing.Size(175, 23);
            this.button_CopyRunningToStartupConfig.TabIndex = 5;
            this.button_CopyRunningToStartupConfig.Text = "copy running to startup config";
            this.button_CopyRunningToStartupConfig.UseVisualStyleBackColor = true;
            this.button_CopyRunningToStartupConfig.Click += new System.EventHandler(this.button_CopyRunningToStartupConfig_Click);
            // 
            // button_CopyStartupToRunningConfig
            // 
            this.button_CopyStartupToRunningConfig.Location = new System.Drawing.Point(111, 101);
            this.button_CopyStartupToRunningConfig.Name = "button_CopyStartupToRunningConfig";
            this.button_CopyStartupToRunningConfig.Size = new System.Drawing.Size(175, 23);
            this.button_CopyStartupToRunningConfig.TabIndex = 6;
            this.button_CopyStartupToRunningConfig.Text = "copy startup to running config";
            this.button_CopyStartupToRunningConfig.UseVisualStyleBackColor = true;
            this.button_CopyStartupToRunningConfig.Click += new System.EventHandler(this.button_CopyStartupToRunningConfig_Click);
            // 
            // button_send_ibs
            // 
            this.button_send_ibs.Location = new System.Drawing.Point(7, 93);
            this.button_send_ibs.Name = "button_send_ibs";
            this.button_send_ibs.Size = new System.Drawing.Size(121, 23);
            this.button_send_ibs.TabIndex = 7;
            this.button_send_ibs.Text = "IBS send";
            this.button_send_ibs.UseVisualStyleBackColor = true;
            this.button_send_ibs.Click += new System.EventHandler(this.button_send_ibs_Click);
            // 
            // label_plc_time
            // 
            this.label_plc_time.AutoSize = true;
            this.label_plc_time.Location = new System.Drawing.Point(64, 5);
            this.label_plc_time.Name = "label_plc_time";
            this.label_plc_time.Size = new System.Drawing.Size(43, 13);
            this.label_plc_time.TabIndex = 9;
            this.label_plc_time.Text = "plc time";
            // 
            // label_timeJitterDesc
            // 
            this.label_timeJitterDesc.AutoSize = true;
            this.label_timeJitterDesc.Location = new System.Drawing.Point(9, 27);
            this.label_timeJitterDesc.Name = "label_timeJitterDesc";
            this.label_timeJitterDesc.Size = new System.Drawing.Size(54, 13);
            this.label_timeJitterDesc.TabIndex = 10;
            this.label_timeJitterDesc.Text = "difference";
            // 
            // label_time_difference
            // 
            this.label_time_difference.AutoSize = true;
            this.label_time_difference.Location = new System.Drawing.Point(64, 27);
            this.label_time_difference.Name = "label_time_difference";
            this.label_time_difference.Size = new System.Drawing.Size(43, 13);
            this.label_time_difference.TabIndex = 11;
            this.label_time_difference.Text = "xx:xx:xx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "plc time";
            // 
            // comboBox_headerFlag
            // 
            this.comboBox_headerFlag.FormattingEnabled = true;
            this.comboBox_headerFlag.Location = new System.Drawing.Point(7, 40);
            this.comboBox_headerFlag.Name = "comboBox_headerFlag";
            this.comboBox_headerFlag.Size = new System.Drawing.Size(121, 21);
            this.comboBox_headerFlag.TabIndex = 13;
            this.comboBox_headerFlag.SelectedIndexChanged += new System.EventHandler(this.comboBox_headerFlag_SelectedIndexChanged);
            // 
            // panel_sendMsg
            // 
            this.panel_sendMsg.Controls.Add(this.panel_IOdata);
            this.panel_sendMsg.Controls.Add(this.textBox_payload);
            this.panel_sendMsg.Controls.Add(this.comboBox_headerFlag);
            this.panel_sendMsg.Controls.Add(this.button_send_ibs);
            this.panel_sendMsg.Controls.Add(this.label_CpsStatus);
            this.panel_sendMsg.Location = new System.Drawing.Point(12, 217);
            this.panel_sendMsg.Name = "panel_sendMsg";
            this.panel_sendMsg.Size = new System.Drawing.Size(501, 131);
            this.panel_sendMsg.TabIndex = 14;
            // 
            // panel_IOdata
            // 
            this.panel_IOdata.Controls.Add(this.textBox_aktuatorID);
            this.panel_IOdata.Controls.Add(this.label_aktuatorID);
            this.panel_IOdata.Location = new System.Drawing.Point(141, 40);
            this.panel_IOdata.Name = "panel_IOdata";
            this.panel_IOdata.Size = new System.Drawing.Size(121, 27);
            this.panel_IOdata.TabIndex = 17;
            this.panel_IOdata.Visible = false;
            // 
            // textBox_aktuatorID
            // 
            this.textBox_aktuatorID.Location = new System.Drawing.Point(31, 3);
            this.textBox_aktuatorID.Name = "textBox_aktuatorID";
            this.textBox_aktuatorID.Size = new System.Drawing.Size(23, 20);
            this.textBox_aktuatorID.TabIndex = 15;
            this.textBox_aktuatorID.Text = "0";
            // 
            // label_aktuatorID
            // 
            this.label_aktuatorID.AutoSize = true;
            this.label_aktuatorID.Location = new System.Drawing.Point(4, 6);
            this.label_aktuatorID.Name = "label_aktuatorID";
            this.label_aktuatorID.Size = new System.Drawing.Size(21, 13);
            this.label_aktuatorID.TabIndex = 16;
            this.label_aktuatorID.Text = "ID:";
            // 
            // textBox_payload
            // 
            this.textBox_payload.Location = new System.Drawing.Point(7, 67);
            this.textBox_payload.Name = "textBox_payload";
            this.textBox_payload.Size = new System.Drawing.Size(187, 20);
            this.textBox_payload.TabIndex = 14;
            // 
            // label_reconnect_counter
            // 
            this.label_reconnect_counter.AutoSize = true;
            this.label_reconnect_counter.Location = new System.Drawing.Point(150, 27);
            this.label_reconnect_counter.Name = "label_reconnect_counter";
            this.label_reconnect_counter.Size = new System.Drawing.Size(97, 13);
            this.label_reconnect_counter.TabIndex = 15;
            this.label_reconnect_counter.Text = "reconnect counter:";
            // 
            // label_display_reconnect_counter
            // 
            this.label_display_reconnect_counter.AutoSize = true;
            this.label_display_reconnect_counter.Location = new System.Drawing.Point(253, 27);
            this.label_display_reconnect_counter.Name = "label_display_reconnect_counter";
            this.label_display_reconnect_counter.Size = new System.Drawing.Size(28, 13);
            this.label_display_reconnect_counter.TabIndex = 16;
            this.label_display_reconnect_counter.Text = "XXX";
            // 
            // button_send_get_request
            // 
            this.button_send_get_request.Location = new System.Drawing.Point(111, 130);
            this.button_send_get_request.Name = "button_send_get_request";
            this.button_send_get_request.Size = new System.Drawing.Size(175, 23);
            this.button_send_get_request.TabIndex = 17;
            this.button_send_get_request.Text = "send get request for plc values";
            this.button_send_get_request.UseVisualStyleBackColor = true;
            this.button_send_get_request.Click += new System.EventHandler(this.button_send_get_request_Click);
            // 
            // groupBox_subscribe
            // 
            this.groupBox_subscribe.Controls.Add(this.label4);
            this.groupBox_subscribe.Controls.Add(this.textBox_ManagementDataCycle);
            this.groupBox_subscribe.Controls.Add(this.label3);
            this.groupBox_subscribe.Controls.Add(this.textBox_prozessDataCycle);
            this.groupBox_subscribe.Controls.Add(this.label2);
            this.groupBox_subscribe.Controls.Add(this.textBox_prozessDataTopics);
            this.groupBox_subscribe.Controls.Add(this.button_subscribe_topics);
            this.groupBox_subscribe.Controls.Add(this.checkBox_subscribe_PlcManagementData);
            this.groupBox_subscribe.Controls.Add(this.checkBox_subscribeProzessData);
            this.groupBox_subscribe.Location = new System.Drawing.Point(312, 23);
            this.groupBox_subscribe.Name = "groupBox_subscribe";
            this.groupBox_subscribe.Size = new System.Drawing.Size(277, 156);
            this.groupBox_subscribe.TabIndex = 18;
            this.groupBox_subscribe.TabStop = false;
            this.groupBox_subscribe.Text = "subscribe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "s cycle";
            // 
            // textBox_ManagementDataCycle
            // 
            this.textBox_ManagementDataCycle.Location = new System.Drawing.Point(187, 40);
            this.textBox_ManagementDataCycle.Name = "textBox_ManagementDataCycle";
            this.textBox_ManagementDataCycle.Size = new System.Drawing.Size(34, 20);
            this.textBox_ManagementDataCycle.TabIndex = 25;
            this.textBox_ManagementDataCycle.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "s cycle";
            // 
            // textBox_prozessDataCycle
            // 
            this.textBox_prozessDataCycle.Location = new System.Drawing.Point(187, 17);
            this.textBox_prozessDataCycle.Name = "textBox_prozessDataCycle";
            this.textBox_prozessDataCycle.Size = new System.Drawing.Size(34, 20);
            this.textBox_prozessDataCycle.TabIndex = 23;
            this.textBox_prozessDataCycle.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "topics";
            // 
            // textBox_prozessDataTopics
            // 
            this.textBox_prozessDataTopics.Location = new System.Drawing.Point(108, 16);
            this.textBox_prozessDataTopics.Name = "textBox_prozessDataTopics";
            this.textBox_prozessDataTopics.Size = new System.Drawing.Size(34, 20);
            this.textBox_prozessDataTopics.TabIndex = 21;
            this.textBox_prozessDataTopics.Text = "0";
            // 
            // button_subscribe_topics
            // 
            this.button_subscribe_topics.Location = new System.Drawing.Point(6, 127);
            this.button_subscribe_topics.Name = "button_subscribe_topics";
            this.button_subscribe_topics.Size = new System.Drawing.Size(175, 23);
            this.button_subscribe_topics.TabIndex = 20;
            this.button_subscribe_topics.Text = "subscribe topics";
            this.button_subscribe_topics.UseVisualStyleBackColor = true;
            this.button_subscribe_topics.Click += new System.EventHandler(this.button_subscribe_topics_Click);
            // 
            // checkBox_subscribe_PlcManagementData
            // 
            this.checkBox_subscribe_PlcManagementData.AutoSize = true;
            this.checkBox_subscribe_PlcManagementData.Location = new System.Drawing.Point(16, 42);
            this.checkBox_subscribe_PlcManagementData.Name = "checkBox_subscribe_PlcManagementData";
            this.checkBox_subscribe_PlcManagementData.Size = new System.Drawing.Size(126, 17);
            this.checkBox_subscribe_PlcManagementData.TabIndex = 1;
            this.checkBox_subscribe_PlcManagementData.Text = "PlcManagementData";
            this.checkBox_subscribe_PlcManagementData.UseVisualStyleBackColor = true;
            this.checkBox_subscribe_PlcManagementData.CheckedChanged += new System.EventHandler(this.checkBox_subscribe_PlcManagementData_CheckedChanged);
            // 
            // checkBox_subscribeProzessData
            // 
            this.checkBox_subscribeProzessData.AutoSize = true;
            this.checkBox_subscribeProzessData.Location = new System.Drawing.Point(16, 19);
            this.checkBox_subscribeProzessData.Name = "checkBox_subscribeProzessData";
            this.checkBox_subscribeProzessData.Size = new System.Drawing.Size(86, 17);
            this.checkBox_subscribeProzessData.TabIndex = 0;
            this.checkBox_subscribeProzessData.Text = "ProzessData";
            this.checkBox_subscribeProzessData.UseVisualStyleBackColor = true;
            this.checkBox_subscribeProzessData.CheckedChanged += new System.EventHandler(this.checkBox_subscribeProzessData_CheckedChanged);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(111, 156);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(175, 23);
            this.button_disconnect.TabIndex = 19;
            this.button_disconnect.Text = "disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(608, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(470, 459);
            this.listBox1.TabIndex = 20;
            // 
            // checkBox_connectAtStartup
            // 
            this.checkBox_connectAtStartup.AutoSize = true;
            this.checkBox_connectAtStartup.Location = new System.Drawing.Point(12, 194);
            this.checkBox_connectAtStartup.Name = "checkBox_connectAtStartup";
            this.checkBox_connectAtStartup.Size = new System.Drawing.Size(169, 17);
            this.checkBox_connectAtStartup.TabIndex = 21;
            this.checkBox_connectAtStartup.Text = "connect to plc client at startup";
            this.checkBox_connectAtStartup.UseVisualStyleBackColor = true;
            this.checkBox_connectAtStartup.CheckedChanged += new System.EventHandler(this.checkBox_connectAtStartup_CheckedChanged);
            // 
            // FrmPlcClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 505);
            this.Controls.Add(this.checkBox_connectAtStartup);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.groupBox_subscribe);
            this.Controls.Add(this.button_send_get_request);
            this.Controls.Add(this.label_display_reconnect_counter);
            this.Controls.Add(this.label_reconnect_counter);
            this.Controls.Add(this.panel_sendMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_time_difference);
            this.Controls.Add(this.label_timeJitterDesc);
            this.Controls.Add(this.label_plc_time);
            this.Controls.Add(this.button_CopyStartupToRunningConfig);
            this.Controls.Add(this.button_CopyRunningToStartupConfig);
            this.Controls.Add(this.button_ReadRunningConfig);
            this.Controls.Add(this.button_setTime);
            this.Controls.Add(this.button_status);
            this.Controls.Add(this.button_connect);
            this.Name = "FrmPlcClient";
            this.Text = "FrmPlcClient";
            this.panel_sendMsg.ResumeLayout(false);
            this.panel_sendMsg.PerformLayout();
            this.panel_IOdata.ResumeLayout(false);
            this.panel_IOdata.PerformLayout();
            this.groupBox_subscribe.ResumeLayout(false);
            this.groupBox_subscribe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CpsStatus;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_status;
        private System.Windows.Forms.Button button_setTime;
        private System.Windows.Forms.Button button_ReadRunningConfig;
        private System.Windows.Forms.Button button_CopyRunningToStartupConfig;
        private System.Windows.Forms.Button button_CopyStartupToRunningConfig;
        private System.Windows.Forms.Button button_send_ibs;
        private System.Windows.Forms.Label label_plc_time;
        private System.Windows.Forms.Label label_timeJitterDesc;
        private System.Windows.Forms.Label label_time_difference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_headerFlag;
        private System.Windows.Forms.Panel panel_sendMsg;
        private System.Windows.Forms.TextBox textBox_payload;
        private System.Windows.Forms.Panel panel_IOdata;
        private System.Windows.Forms.TextBox textBox_aktuatorID;
        private System.Windows.Forms.Label label_aktuatorID;
        private System.Windows.Forms.Label label_reconnect_counter;
        private System.Windows.Forms.Label label_display_reconnect_counter;
        private System.Windows.Forms.Button button_send_get_request;
        private System.Windows.Forms.GroupBox groupBox_subscribe;
        private System.Windows.Forms.CheckBox checkBox_subscribeProzessData;
        private System.Windows.Forms.CheckBox checkBox_subscribe_PlcManagementData;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Button button_subscribe_topics;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_prozessDataTopics;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ManagementDataCycle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_prozessDataCycle;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox checkBox_connectAtStartup;
    }
}