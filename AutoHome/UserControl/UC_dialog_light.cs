﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cpsLIB; //frames

namespace AutoHome
{
    public partial class UC_dialog_light : UserControl, IdialogUpdate
    {
        aktuator _aktor = null;
        public UC_dialog_light(object aktor)
        {
            InitializeComponent();
            _aktor = (aktuator)aktor;
            _aktor.plc_send_IO(DataIOType.GetParam);
            //_aktor.plc_send(new Frame(Frame.GET_PARAM(_aktor.Index)));
        }
        public void LoadData(object _value)
        {
            Int16[] value = (Int16[])_value;
            log.msg(this, "LoadData UC_dialog_light.cs ID: " + value[0].ToString());
            if (!checkBox_EditLock.Checked) { 
                
                if (value.Length > 1)
                {
 
                        if (Convert.ToBoolean(value[3]))
                            label_current_state.Text = "state: ON";
                        else
                            label_current_state.Text = "state: OFF";

                        checkBox_light_enable_lux.Checked = Convert.ToBoolean(value[5]);
                        textBox_light_lux_off.Text = value[7].ToString();
                        checkBox_light_enable_timer.Checked = Convert.ToBoolean(value[4]);
                    textBox_auto_off_time.Text = value[7].ToString();
                    label_remaining_on.Text = value[9].ToString();
                        //textBox_light_time_h.Text = value[6].ToString();
                        //textBox_light_time_m.Text = value[7].ToString();
                        //textBox_light_time_s.Text = value[8].ToString();
                    //if (value.Length > 9)
                    //    label_remaining_on.Text =
                    //        value[9].ToString("##") + ":" +
                    //        value[10].ToString("##") + ":" +
                    //        value[11].ToString("##");
                }
                else
                    log.msg(this, "LoadData with empty value @RunningConfig");
            }
        }

        private void button_switch_Click(object sender, EventArgs e)
        {
            //TODO: implement Frame SetState
            //_aktor.plc_send(new Frame(Frame.SET_STATE(_aktor.Index, true)));
            _aktor.plc_send_IO(DataIOType.SetState, new Int16[] {1});
        }

        private void button_switch_off_Click(object sender, EventArgs e)
        {
            _aktor.plc_send_IO(DataIOType.SetState, new Int16[] { 0 });
        }

        private void checkBox_light_enable_timer_CheckedChanged(object sender, EventArgs e)
        {
            textBox_light_time_h.Enabled = checkBox_light_enable_timer.Checked;
            textBox_light_time_m.Enabled = checkBox_light_enable_timer.Checked;
            textBox_light_time_s.Enabled = checkBox_light_enable_timer.Checked;
        }

        private void checkBox_light_enable_lux_CheckedChanged(object sender, EventArgs e)
        {
            textBox_light_lux_off.Enabled = checkBox_light_enable_lux.Checked;
        }

        private void button_set_param_Click(object sender, EventArgs e)
        {
            _aktor.plc_send_IO(DataIOType.SetParam, new Int16[] {
                -1,
                Convert.ToInt16(checkBox_light_enable_lux.Checked),
                Convert.ToInt16(textBox_light_lux_off.Text),
                Convert.ToInt16(checkBox_light_enable_timer.Checked),
                Convert.ToInt16(textBox_light_time_h.Text),
                Convert.ToInt16(textBox_light_time_m.Text), 
                Convert.ToInt16(textBox_light_time_s.Text) 
            });
        }

        private void checkBox_EditLock_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_EditLock.Checked)
                panel_edit.Enabled = true;
            else
                panel_edit.Enabled = false;

        }
    }
}
