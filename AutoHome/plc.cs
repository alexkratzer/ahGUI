using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using cpsLIB; //frames
using System.Timers;

namespace AutoHome
{
    //enum plc_state { undefined, initialising, connected, disconnected}
    [Serializable]
    class plc
    {
        
        #region vars public [Serialized]
        private const string plc_default_name = "PLC not named";

        private string _ip;
        public string IPplc
        {
            get
            {
                if (_ip != null)
                    return _ip;
                else
                    return "no IP set jet";
            }
            set
            {
                System.Net.IPAddress valid_ip;
                if (System.Net.IPAddress.TryParse(value, out valid_ip))
                    _ip = valid_ip.ToString();
            }
        }

        private int _port;
        public string PortPlc
        {
            get
            {
                if (_ip != null)
                    return _port.ToString();
                else
                    return "no port set jet";
                
            }
            set
            {
                int valid_port;
                if (int.TryParse(value, out valid_port))
                    _port = valid_port;
            }
        }
        
        private string _PLC_Name = plc_default_name;
        public string NamePlc
        {
            get { return _PLC_Name; }
            set { _PLC_Name = value; }
        }

        public udp_state ConnectionState
        {
            get
            {
                if (client_udp != null)
                    return client_udp.state;
                else
                    return udp_state.disconnected;
            }
            //set { _connectionState = value; }
        }

        public bool ConnectAtStartup = true;

        #region subscriptions which topics the plc has to send cyclic
        private bool _subscribe_ProzessData = false;
        public bool subscribe_ProzessData
        {
            get { return _subscribe_ProzessData; }
            set { _subscribe_ProzessData = value; }
        }
        private Int16 _ProzessDataTopics = 0;
        public Int16 ProzessDataTopics
        {
            get { return _ProzessDataTopics; }
            set { _ProzessDataTopics = value; }
        }
        private Int16 _ProzessDataRefreshCycle = 10;
        public Int16 ProzessDataRefreshCycle
        {
            get { return _ProzessDataRefreshCycle; }
            set { _ProzessDataRefreshCycle = value; }
        }

        private bool _subscribe_PlcManagementData = false;
        public bool subscribe_PlcManagementData
        {
            get { return _subscribe_PlcManagementData; }
            set { _subscribe_PlcManagementData = value; }
        }
        private Int16 _PlcManagementDataRefreshCycle = 10;
        public Int16 PlcManagementDataRefreshCycle
        {
            get { return _PlcManagementDataRefreshCycle; }
            set { _PlcManagementDataRefreshCycle = value; }
        }
        #endregion

        public int new_message_count = 0;
        public List<aktuator> ListAktuator;
        #endregion

        #region tmp vars [NonSerialized]
        [NonSerialized]
        private cpsLIB.CpsNet cpsNet = null;
        [NonSerialized]
        private cpsLIB.Client client_udp = null;

        //wird als temporäre variable in FrmMain benötigt
        [NonSerialized]
        public DateTime clockPlc;
        [NonSerialized]
        public DateTime clockLocal;
        [NonSerialized]
        public TimeSpan clockPlcJitter;
        [NonSerialized]
        Dictionary<Int16, float> DicSensorVal;
        [NonSerialized]
        private List<akt_DataPoint> ListRcvDatapoints;
        [NonSerialized]
        public int reconnect_counter = 0; //IBS connect counter
        //[NonSerialized]
        //bool dbg_flag_once = true;
        #endregion

        #region construktor / init 
        public plc(string ip, int port, string plc_name = "not named")
        {
            _ip = ip;
            _port = port;
            _PLC_Name = plc_name;
            client_udp = new Client(_ip, port.ToString());
            ListAktuator = new List<aktuator>();
            
        }
        //because deserialice doesnt make new client init is called at startup
        public void InitCps(CpsNet _cpsNet) {
            cpsNet = _cpsNet;

            if (client_udp != null)
            {
                if (client_udp.RemoteIp != _ip)
                    client_udp.RemoteIp = _ip;
                if (client_udp.RemotePort != _port)
                    client_udp.RemotePort = _port;
            }
            else
                client_udp = cpsNet.newClient(_ip, _port.ToString());

            ListRcvDatapoints = new List<akt_DataPoint>();
        }
        //region timer disabled
        /*
         private void initRequestTimer() {
             //log.msg(this, "initRequestTimer: " + NamePlc);
             System.Timers.Timer TimerInitRequest = new System.Timers.Timer();
             TimerInitRequest.Elapsed += new ElapsedEventHandler(OnTimeRequest);
             TimerInitRequest.Interval = var.timer_GetRequestInterval;
             TimerInitRequest.Enabled = true;
             //################# deswegen dürfte timer nicht laufen....          TimerInitRequest.Start();
         }

         //alle aktoren und alle sensoren status abfragen
         //TODO: aktuell nicht verwendet...
         private void OnTimeRequest(object source, ElapsedEventArgs e) {

             //********************************************************************************************************************
             //collect all visible controll IDs and send GetRequest @PLC
             //********************************************************************************************************************
                 ListSensorIDs = new List<short>();

             if(ListAktuator.Any())
                 foreach (aktuator a in ListAktuator)
                         //sensor controlls sammeln und in einzelnen management frame versenden
                         if (a.AktorType == aktor_type.sensor) //nur sensoren beachten
                             ListSensorIDs.Add(a.Index);
                         else
                             //alle aktoren anfragen werden einzeln ein eigenem frame versendet
                             a.plc_send_IO(DataIOType.GetState); //send GetRequest @PLC for all visible aktuator controll IDs


             //********************************************************************************************************************
             //send GetRequest @PLC
             //********************************************************************************************************************

                 if (client_udp != null && client_udp.state == udp_state.connected)
                 {
                     //send get Time request @PLC
                     send(Frame.MngData(client_udp, DataMngType.GetPlcTime));

                     //send sensor value request @plc
                     if (ListSensorIDs.Any())
                     {
                         ListSensorIDs.Insert(0, (Int16)DataMngType.GetPlcSensorValues);
                         send(FrameHeaderFlag.MngData, ListSensorIDs.ToArray());
                     }
                 }
         }
        */

        #endregion

        #region functions
        /// <summary>
        /// send new connect request to PLC
        /// and establish connection item
        /// </summary>
        /// <param name="_cpsNet"></param>
        public void connect()
        {
            reconnect_counter++;
            DicSensorVal = new Dictionary<short, float>();
            client_udp.state = udp_state.connected; //TODO: sollte eigentlich erst nach empfang einer antwort auf connected wechseln. wird aber zum disconnecten benutzt und da muss ein ungewolltes auf true setzten verriegelt werden
            sendSYNCconnect();
        }
        public void disconnect() {
            client_udp.state = udp_state.disconnected;
            sendSYNCdisconnect();
        }
        public bool client_subscribe(bool prozessData, bool MngData, Int16 prozessDataTopics, 
            Int16 _ProzessDataRefreshCycle, Int16 _PlcManagementDataRefreshCycle) {
            subscribe_ProzessData = prozessData;
            subscribe_PlcManagementData = MngData;
            ProzessDataTopics = prozessDataTopics;
            ProzessDataRefreshCycle = _ProzessDataRefreshCycle;
            PlcManagementDataRefreshCycle = _PlcManagementDataRefreshCycle;
            return sendSYNCsubscribe();
        }

        /// <summary>
        /// send frame to remote and log this frame at cpsNet
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public bool send(Frame f)
        {
            if (client_udp == null)
                return false;
            //client_udp.send(f);
            return cpsNet.send(f);
        }

        #region send frames
        private bool sendSYNCconnect()
        {
            Frame f = new Frame(client_udp, new short[] { 1 });
            f.SetHeaderFlag(FrameHeaderFlag.SYNC);
            return send(f);
        }
        private void sendSYNCdisconnect()
        {
            Frame f = new Frame(client_udp, new short[] { 2 });
            f.SetHeaderFlag(FrameHeaderFlag.SYNC);
            send(f);
        }

        //public bool sendSYNCsubscribe(bool subscribe_ProzessData = false, bool subscribe_PlcManagementData = false, Int16 prozessDataTopics = 0)
        private bool sendSYNCsubscribe()
        {
            Frame f = new Frame(client_udp, new short[] { 5, Convert.ToInt16(subscribe_ProzessData),
                Convert.ToInt16(subscribe_PlcManagementData), ProzessDataTopics, ProzessDataRefreshCycle, PlcManagementDataRefreshCycle });
            f.SetHeaderFlag(FrameHeaderFlag.SYNC);
            return send(f);
        }

        #endregion

        public override string ToString()
        { 
            if ((_PLC_Name == String.Empty) || (_PLC_Name == plc_default_name))
                return "[" + _ip + ":" + _port.ToString() + "]";
            else
                return "[" + _PLC_Name + "]";
        }

        public Client getClient()
        {
            return client_udp;
        }

        #endregion

        #region interprete data

        int DBG_processDataFramesRCV = 0;
        int DBG_processDataDataPointsRCV = 0;

        /// <summary>
        /// API für QueueRcvFromCps.cs
        /// </summary>
        /// <param name="f"></param>
        public bool interpreteFrame(Frame _f) {
            if (_f.client.RemoteIp == _ip)
            {
                try
                {
                    //reset reconnect counter on connection lose
                    reconnect_counter = 0;

                    if (_f.GetHeaderFlag(FrameHeaderFlag.SYNC))
                        interpreteSYNCacknowlege(_f);
                    else if (_f.GetHeaderFlag(FrameHeaderFlag.MngData))
                        interpreteDataMng(_f);
                    //log.msg(this, "interpreteFrame(), plc.cs: rcv FrameHeaderFlag.MngData");
                    else if (_f.GetHeaderFlag(FrameHeaderFlag.ACKN))
                        log.msg(this, "interpreteFrame(), plc.cs: rcv FrameHeaderFlag.ACKN");
                    else if (_f.GetHeaderFlag(FrameHeaderFlag.PdataIO))
                        if (_f.GetHeaderFlag(FrameHeaderFlag.containering))
                            interpreteAktuatorContainerData(_f, _f.GetIndex());
                        else
                            interpreteAktuatorSensorValue(_f, _f.GetIndex());
                    //log.msg(this, "interpreteFrame(), plc.cs: rcv FrameHeaderFlag.PdataIO");
                    else
                        log.msg(this, "interpreteFrame(), plc.cs: rcv with UNKNOWN FrameHeaderFlag");
                }
                catch (Exception e)
                {
                    log.exception(this, "interprete_frame_fkt()", e);
                }
                return true;
            }
            else
                return false;
        }

        private void interpreteDataMng(Frame f)
        {
            if (f.getPayload(0) == (Int16)DataMngType.GetPlcTime)
            {
                clockPlc = new DateTime(f.getPayload(1), f.getPayload(2), f.getPayload(3), f.getPayload(4), f.getPayload(5), f.getPayload(6));
                clockLocal = DateTime.Now;
                clockPlcJitter = clockLocal - clockPlc;
                //if (DateTime.Now.Subtract(new TimeSpan(0, 0, var.MngData_AcceptedClockDelay)) > clockPlc)
                //    clockPlcJitter = DateTime.Now - clockPlc;
                //else if (DateTime.Now.Add(new TimeSpan(0, 0, var.MngData_AcceptedClockDelay)) < clockPlc)
                //    clockPlcJitter = clockPlc - DateTime.Now;
            }
            else if (f.getPayload(0) == (Int16)DataMngType.SetPlcTime)
            {
                Int16 retval = f.getPayload(1);
                if (retval > 0)
                    log.msg(this, "++ ERROR ++ interpreteDataMng() DataMngType.SetPlcTime -> see TIA Help [WR_SYS_T: Set time-of-day]: " + retval.ToString());
                //MessageBox.Show("retval: " + f.getPayload(1) + Environment.NewLine + " see TIA Help [WR_SYS_T: Set time-of-day]", "SetPlcTime: ERROR");
            }
            else if (f.getPayload(0) == (Int16)DataMngType.GetPlcSensorValues)
            {
                //evtl update_SensorControl() über timer aufrufen und nicht via event
                //komplettes frame durchgehen und auspacken. für jeden sensorwert entsprechendes controll befüllen

                /*
                for (int i = 3; i < (f.getPayloadIntLengt()); i = i + 3)
                {
                    float SensorValue;
                    if (f.getPayload(i + 2) != 0)
                        SensorValue = (float)f.getPayload(i + 1) / (float)f.getPayload(i + 2);
                    else
                        SensorValue = f.getPayload(i + 1);

                    if (DicSensorVal.ContainsKey(f.getPayload(i)))
                        DicSensorVal[f.getPayload(i)] = SensorValue;
                    else
                        DicSensorVal.Add(f.getPayload(i), SensorValue);
                }

                //sensor value in entsprechenden aktuator ablegen
                foreach (aktuator a in ListAktuator) 
                    if (DicSensorVal.ContainsKey(a.Index))
                        a.SensorValue = DicSensorVal[a.Index];
                        */
            }

            //platform p_selected = (platform)comboBox_platform.SelectedItem;
            //if (p_selected != null)
                //p_selected.update_SensorControl(f);
        }

        const int DataPointHeaderLength = 2;
        
        private void interpreteAktuatorContainerData(Frame f, int items)
        {
                //log.msg(this, "at interpreteAktuatorContainerData; items: " + items.ToString());
                //log.msg(this, f.ToString());
               
            DBG_processDataFramesRCV++;
            //seperate rcv frame in datapoint frames and send to aktuator
            //payload data
            //data[0] = int length of datapoint
            //data[1] = int type of aktuator

            int GetPayloadIndex = 0; //itterator of position in payload of frame
            int items_interpretet = 0;
            //while (GetPayloadIndex < f.getPayloadIntLengt())
            while (items_interpretet < items)
            {
                items_interpretet++;
                DBG_processDataDataPointsRCV++;
                try
                {
                    int datapointLength = f.getPayload(GetPayloadIndex);
                    aktor_type akt = (aktor_type)f.getPayload(GetPayloadIndex + 1);
                    //log.msg(this, "datapointLength: " + datapointLength.ToString() + " DataPointHeaderLength: " + DataPointHeaderLength.ToString());
                    Int16[] tmp = new Int16[datapointLength - DataPointHeaderLength];
                    
                        //string dbg_data = "";
                        for (int i = 0; i < datapointLength - DataPointHeaderLength; i++)
                        {
                            tmp[i] = f.getPayload(GetPayloadIndex + i + 2);
                          //  dbg_data = dbg_data + tmp[i].ToString() + ", ";
                        }

                        //log.msg(this, "DataPoint " + items_interpretet.ToString() + " " + dbg_data);
                    
                    akt_DataPoint tmp_aktDP = new akt_DataPoint(akt, datapointLength, tmp[0], tmp);
                    ListRcvDatapoints.Add(tmp_aktDP);
                    GetPayloadIndex = GetPayloadIndex + datapointLength;

                    foreach (aktuator a in ListAktuator)
                    {
                        if (a.Index == tmp_aktDP.aktuator_index)
                        {
                            if (!a.AktorType.Equals(tmp_aktDP.aktor_type))
                                log.msg(this, "plc.cs/interpreteAktuatorData() " + "RCV AktorType "
                                    + a.AktorType.ToString() + " not projected at interface ID: " + tmp_aktDP.aktuator_index);
                            a.lastUpdateTimestamp = DateTime.Now;
                            a.plcProcessDatapoint = tmp_aktDP.rawValue;
                            break;
                        }
                    }
                }
                catch (Exception ex) {
                    log.exception(this, "interpreteAktuatorData() payload data wrong length... ", ex);
                    throw;
                }
                //log.msg(this, "plc.cs, interpreteAktuatorData -> no aktuator found for index: " + tmp_aktDP.aktuator_index.ToString());
            }
            
            //old protocol type
            /*
            foreach (aktuator a in ListAktuator)
            {
                if (f.isIOIndex(a.Index))
                {
                    a.lastUpdateTimestamp = DateTime.Now;
                    if (f.getPayload(1) == (int)DataIOType.GetState)
                        a.ValueStateRunning = f.getPayload();
                    else if (f.getPayload(1) == (int)DataIOType.GetParam)
                        a.ConfigAktuatorValuesRunning = f.getPayload();
                    else
                        log.msg(this, "SetAktuatorData(), plc.cs: unknown DataIOType: [" + f.getPayload(2).ToString() + "]");
                }
            }
            */
        }
        
        private void interpreteAktuatorSensorValue(Frame f, int items)
        {
            try
            {
                int interpretet_items = 0;
                aktor_type akt = aktor_type.sensor;

                while (interpretet_items <= items)
                {
                    foreach (aktuator a in ListAktuator)
                    {
                        if (a.Index == f.getPayload(interpretet_items*2))
                        {
                            if (!a.AktorType.Equals(akt))
                                log.msg(this, "plc.cs/interpreteAktuatorData() " + "RCV AktorType "
                                    + a.AktorType.ToString() + " not projected at interface ID: " + f.getPayload(interpretet_items*2));
                            a.lastUpdateTimestamp = DateTime.Now;
                            a.sensor_value = f.getPayload(interpretet_items*2 + 1);
                            break;
                        }
                    }
                    interpretet_items++;
                }
                
            }
            catch (Exception ex)
            {
                log.exception(this, "interpreteAktuatorSensorValue()", ex);
                throw;
            }

            //log.msg(this, "plc.cs, interpreteAktuatorData -> no aktuator found for index: " + tmp_aktDP.aktuator_index.ToString());
             
        }
        

        private void interpreteSYNCacknowlege(Frame f) {
            //log.msg(this, "interpreteFrame(), plc.cs: rcv FrameHeaderFlag.SYNC -> " + f.ToString());
        }
        #endregion

        #region running startup config
        public string ShowRunningConfig()
        {
            string s= "ShowRunningConfig @" + _PLC_Name + Environment.NewLine;
            //string text = "";
            foreach (aktuator a in ListAktuator)
            {
                s += a.AktorType.ToString() + " / " + a.Name + " [" ;
                if (a.ConfigAktuatorValuesRunning != null)
                    foreach (Int16 i in a.ConfigAktuatorValuesRunning)
                        s += i.ToString() + ", ";
                else
                    s +="XX, ";
                s += "]" + Environment.NewLine;
            }
            //s += text + Environment.NewLine;
            return s;
        }
        /// <summary>
        /// send get request to all aktuators
        /// </summary>
        public void ReadRunningConfig() {
            foreach (aktuator a in ListAktuator) {
                if (a.AktorType == aktor_type.sensor) //sensor aktuatoren haben keine running config
                    continue;
                Frame f = new Frame(getClient(), new Int16[] { a.Index, (int)DataIOType.GetParam });
                f.SetHeaderFlag(FrameHeaderFlag.PdataIO);
                send(f);
            } 
        }

        public void copyRunningToStartConfig() {
            foreach (aktuator a in ListAktuator)
                a.copyRunningToStartConfig();
        }
        #endregion
    }

}


