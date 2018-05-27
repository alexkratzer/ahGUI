﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cpsLIB
{
    public partial class FrmStatusLog : Form
    {
        BindingList<log> ListLogFrontend;
        List<log> ListLogBackend;
        List<Client> ListClients;

        #region var
        private bool AutoScrollonUpdate = true;
        private bool UpdateGUIonNewEvent = true;
        #endregion

        public DataGridViewCellEventHandler dataGridView1_CellClick { get; set; }

        #region construktor
        public FrmStatusLog()
        {
            InitializeComponent();
            panel_filter.Visible = false;
            ListLogFrontend = new BindingList<log>();
            ListLogBackend = new List<log>();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ListLogFrontend;

            //dGV_Log.Dock = DockStyle.Bottom;
            dGV_Log.AutoGenerateColumns = false;
            AddColumns();

            dGV_Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dGV_Log.DataSource = bindingSource;

            foreach(LogType p in Enum.GetValues(typeof(LogType)))
                cLB_msgType.Items.Add(p,true);

            ListClients = new List<Client>();
        }

        private void AddColumns()
        {
            DataGridViewTextBoxColumn DGVtbtimestamp = new DataGridViewTextBoxColumn();
            DGVtbtimestamp.Name = "Time";
            DGVtbtimestamp.DataPropertyName = "Timestamp";
            DGVtbtimestamp.ReadOnly = true;
            //DGVtbtimestamp.ValueType = typeof(DateTime);
            dGV_Log.Columns.Add(DGVtbtimestamp);
            
            DataGridViewTextBoxColumn DGVtbcPrio = new DataGridViewTextBoxColumn();
            DGVtbcPrio.Name = "Level";
            DGVtbcPrio.DataPropertyName = "Prio";
            DGVtbcPrio.ReadOnly = true;
            
            dGV_Log.Columns.Add(DGVtbcPrio);

            DataGridViewTextBoxColumn DGVtbMsg = new DataGridViewTextBoxColumn();
            DGVtbMsg.Name = "Message";
            DGVtbMsg.DataPropertyName = "Msg";
            //DGVtbMsg.ValueType = typeof(string);
            dGV_Log.Columns.Add(DGVtbMsg);

            DataGridViewTextBoxColumn DGVtbcKey = new DataGridViewTextBoxColumn();
            DGVtbcKey.Name = "IP:INDEX";
            DGVtbcKey.DataPropertyName = "Key";
            DGVtbcKey.ReadOnly = true;
            dGV_Log.Columns.Add(DGVtbcKey);

            DataGridViewTextBoxColumn DGVtbcF = new DataGridViewTextBoxColumn();
            DGVtbcF.Name = "Frame";
            DGVtbcF.DataPropertyName = "F";
            DGVtbcF.ReadOnly = true;
            dGV_Log.Columns.Add(DGVtbcF);
            
            DataGridViewTextBoxColumn DGVtbcHeader = new DataGridViewTextBoxColumn();
            DGVtbcHeader.Name = "header";
            DGVtbcHeader.DataPropertyName = "Header";
            DGVtbcHeader.ReadOnly = true;
            dGV_Log.Columns.Add(DGVtbcHeader);

            DataGridViewTextBoxColumn DGVtbcPayloadInt = new DataGridViewTextBoxColumn();
            DGVtbcPayloadInt.Name = "payloadInt";
            DGVtbcPayloadInt.DataPropertyName = "PayloadInt";
            DGVtbcPayloadInt.ReadOnly = true;
            dGV_Log.Columns.Add(DGVtbcPayloadInt);

            DataGridViewTextBoxColumn DGVtbcPayload = new DataGridViewTextBoxColumn();
            DGVtbcPayload.Name = "payload";
            DGVtbcPayload.DataPropertyName = "Payload";
            DGVtbcPayload.ReadOnly = true;
            dGV_Log.Columns.Add(DGVtbcPayload);
            
        }
        #endregion

        private void FrmStatusLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        #region menue
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListLogFrontend.Clear();
        }
        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAllLog();
        }

        private void autoScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autoScrollToolStripMenuItem.Text == "auto scroll [off]")
            {
                AutoScrollonUpdate = true;
                autoScrollToolStripMenuItem.Text = "auto scroll [on]";
            }
            else
            {
                AutoScrollonUpdate = false;
                autoScrollToolStripMenuItem.Text = "auto scroll [off]";
            }
        }

        private void freezeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (freezeToolStripMenuItem.Text == "freeze [on]")
            {
                UpdateGUIonNewEvent = true;
                freezeToolStripMenuItem.Text = "freeze [off]";
            }
            else
            {
                UpdateGUIonNewEvent = false;
                freezeToolStripMenuItem.Text = "freeze [on]";
            }
        }

        
        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filterToolStripMenuItem.Text == "filter")
            {
                filterToolStripMenuItem.Text = "filter -hide-";
                panel_filter.Visible = true;
            }
            else
            {
                filterToolStripMenuItem.Text = "filter";
                panel_filter.Visible = false;
            }
        }

        private void button_hide_filter_Click(object sender, EventArgs e)
        {
            panel_filter.Visible = false;
            filterToolStripMenuItem.Text = "filter";
        }
        #endregion


        //###################################### code ##############################
        private void ShowAllLog()
        {
            ListLogFrontend.Clear();
            all_messages = ListLogBackend.Count;
            filtered_messages = 0;
            shown_messages = 0;
            foreach (log l in ListLogBackend)
            {
                filterMsg(l);
               // dGV_Log.FirstDisplayedScrollingRowIndex = dGV_Log.RowCount;
            }
        }

        /// <summary>
        /// log/error messages from udp server
        /// </summary>
        /// <param name="s"></param>
        private delegate void CpsLogCallback(log msg);
        public void AddLog(log msg)
        {
            try
            {
                this.Invoke(new CpsLogCallback(this.logMsg), new object[] { msg });
            }
            catch (Exception e)
            {
                //form closing throws exeption -> TODO catch
                //log.exception(this, "srv_msgCallback: writing to GUI failed", e);
                MessageBox.Show("CpsLogCallback: " + e.Message, "writing to GUI failed");
            }
        }
        public int filtered_messages = 0;
        public int all_messages = 0;
        public int shown_messages = 0;
 
        private void logMsg(log _log)
        {
            footer_TSSL_filtered.Text = "msg total: "+ all_messages+" / filtered: " + filtered_messages + " / shown: " + shown_messages;
            //store all log message in ListLogBackend
            ListLogBackend.Add(_log);
            all_messages++;

            //search _log message for new client and add to clientList if new
            if (_log.C != null)
                AddNewClient(_log.C);
            else if (_log.F != null && _log.F.client != null) 
                AddNewClient(_log.F.client);
            
            if (UpdateGUIonNewEvent)
                filterMsg(_log);   
        }

        private void AddNewClient(Client c) {
            //check if client is allready in list
            foreach (Client cl in ListClients)
                if (cl.RemoteIp == c.RemoteIp)
                    return;
            ListClients.Add(c);
            cLB_filter_clients.Items.Add(c, true);
        }

        int dbg_counter_no_client = 0;
        private void filterMsg(log _log) {
            CheckedListBox.CheckedItemCollection CC = cLB_filter_clients.CheckedItems;
            bool showMSG = false;
            if (_log.C != null && CC.Contains(_log.C))
                showMSG = true;
            else if (_log.F != null && _log.F.client != null && CC.Contains(_log.F.client))
                showMSG = true;
            else
                dbg_counter_no_client++;

            if (showMSG && !cLB_msgType.GetItemChecked((int)_log.Prio))
                showMSG = false;


            if (showMSG) {
                shown_messages++;
                ListLogFrontend.Add(_log);

                if (AutoScrollonUpdate)
                    dGV_Log.FirstDisplayedScrollingRowIndex = dGV_Log.RowCount - 1;
            }
            else
                filtered_messages++;

            label1.Text = "no client: " + dbg_counter_no_client.ToString();
        }

       
    }
}
