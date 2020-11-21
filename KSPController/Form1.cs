#define DEBUG

using System;
using System.Reflection;
using NLog;
using NLog.Config;
using NLog.Windows.Forms;
using KRPC.Client;
using KRPC.Client.Services.KRPC;
using KRPC.Client.Services.SpaceCenter;
using System.Net;
using System.Runtime.CompilerServices;
using SpaceCenterService = KRPC.Client.Services.SpaceCenter.Service;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace KSPControllerTest
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        #region Private Class Variables
        private SpaceCenterService _spaceCenter;
        private Connection _connection;
        private Logger _logger;
        private KSPManager kspMgr;
        private string _connectionLabel;
        private string _universalTime;
        private string _funds;
        private string _science;
        private string _reputation;
        private GameScene _scene;
        #endregion

        #region Properties for Data Binding
        public Connection Connection
        {
            get { return this._connection; }
            set
            {
                if (value != this._connection)
                {
                    this._connection = value;
                    SpaceCenter = Connection.SpaceCenter();
                }
            }
        }
        public SpaceCenterService SpaceCenter
        {
            get { return this._spaceCenter; }
            set
            {
                if (value != this._spaceCenter)
                {
                    this._spaceCenter = value;
                }
            }
        }
        public string ConnectionLabel
        {
            get
            {
                return this._connectionLabel;
            }
            set
            {
                if (value != this._connectionLabel)
                {
                    this._connectionLabel = value;
                    NotifyPropertyChanged("ConnectionLabel");
                }
            }
        }
        public string FundsResourceLabel
        {
            get
            {
                return this._funds;
            }
            set
            {
                if (value != this._funds)
                {
                    this._funds = value;
                    NotifyPropertyChanged("FundsResourceLabel");
                }
            }
        }
        public string ReputationResourceLabel
        {
            get
            {
                return this._reputation;
            }
            set
            {
                if (value != this._reputation)
                {
                    this._reputation = value;
                    NotifyPropertyChanged("ReputationResourceLabel");
                }
            }
        }
        public string ScienceResourceLabel
        {
            get
            {
                return this._science;
            }
            set
            {
                if (value != this._science)
                {
                    this._science = value;
                    NotifyPropertyChanged("ScienceResourceLabel");
                }
            }
        }
        public GameScene GameSceneLabel
        {
            get
            {
                return this._scene;
            }
            set
            {
                if (value != this._scene)
                {
                    this._scene = value;
                    NotifyPropertyChanged("GameSceneLabel");
                }
            }
        }
        public string TimeResourceLabel
        {
            get
            {
                return this._universalTime;
            }
            set
            {
                if(value != this._universalTime)
                {
                    this._universalTime = value;
                    NotifyPropertyChanged("TimeResourceLabel");
                }
            }
        }
        public string Version { get; set; }
        public KSPManager KSPManager
        {
            get { return this.kspMgr; }
            set
            {
                if (value != this.kspMgr)
                {
                    this.kspMgr = value;
                }
            }
        }
        #endregion

        #region Streams & Tags
        // Temporarily hold these streams until I can figure out a better way of tearing them down.
        public Stream<double> Time { get; set; }
        public int TimeTag { get; set; }
        public Stream<float> Science { get; set; }
        public int ScienceTag { get; set; }
        public Stream<double> Funds { get; set; }
        public int FundsTag { get; set; }
        public Stream<float> Reputation { get; set; }
        public int ReputationTag { get; set; }
        public Stream<GameScene> GameScene { get; set; }
        public int GameSceneTag { get; set; }
        #endregion

        #region Buttons
        // Oh look buttons
        public Button SpaceCenterButton { get; set; }
        public Button FlightButton { get; set; }
        public Button TrackingStationButton { get; set; }
        public Button VABButton { get; set; }
        public Button SPHButton { get; set; }
        public Button ConnectButton { get; set; }
        public Button DisconnectButton { get; set; }
        #endregion


        public Form1()
        {
            Application.ApplicationExit += new System.EventHandler(OnApplicationExit);
            InitializeComponent();
        }
        private void Form1_load(object sender, EventArgs e)
        {
            // Logging
            _logger = InitRichTextBoxLogging("KSP Controller", new RichTextBoxTarget(), "logTextBox", "Form1");

            // Connection
            connectionLabel.DataBindings.Add(new Binding("Text", this, "ConnectionLabel"));
            
            // Navigation
            gameSceneLabel.DataBindings.Add(new Binding("Text", this, "GameSceneLabel"));

            // Resource
            scienceResourceLabel.DataBindings.Add(new Binding("Text", this, "ScienceResourceLabel"));
            fundsResourceLabel.DataBindings.Add(new Binding("Text", this, "FundsResourceLabel"));
            reputationResourceLabel.DataBindings.Add(new Binding("Text", this, "ReputationResourceLabel"));
            timeResourceLabel.DataBindings.Add(new Binding("Text", this, "TimeResourceLabel"));

            //spaceCenterButton.DataBindings.Add(new Binding("Enabled", this, "SpaceCenterButtonEnabled"));

            SpaceCenterButton = spaceCenterButton;
            FlightButton = flightButton;
            TrackingStationButton = trackingStationButton;
            VABButton = vabButton;
            SPHButton = sphButton;
            ConnectButton = connectButton;
            DisconnectButton = disconnectButton;

            ResetButtons();
        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            _logger.Trace($"Executing connection background worker");
            backgroundWorker1.RunWorkerAsync(2000);
        }
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            CloseOut();
            ResetButtons();
            ResetControls();
            KSPManager = null;
            ConnectButton.Enabled = true;
        }

        #region Background Workers
        private void ConnectionBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;

            int arg = (int)e.Argument;

            e.Result = ConnectionBackgroundProcessor(helperBW, arg);

            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        private int ConnectionBackgroundProcessor(BackgroundWorker bw, int a)
        {
            _logger.Info($"Beginning background connection handler");

            if (this.KSPManager is null)
            {
                _logger.Trace($"kspMgr was null, creating connection");

                var kspMgr = new KSPManager("KSPController", IPAddress.Parse("192.168.1.71"), _logger);

                if (!(kspMgr.Connection?.KRPC()?.GetStatus()?.Version is null))
                {
                    Stream<float> science = kspMgr.Connection.AddStream(() => kspMgr.Connection.SpaceCenter().Science);
                    Stream<double> funds = kspMgr.Connection.AddStream(() => kspMgr.Connection.SpaceCenter().Funds);
                    Stream<float> reputation = kspMgr.Connection.AddStream(() => kspMgr.Connection.SpaceCenter().Reputation);
                    Stream<GameScene> scene = kspMgr.Connection.AddStream(() => kspMgr.Connection.KRPC().CurrentGameScene);

                    int scienceTag = science.AddCallback((float x) => { UpdateScienceResourceLabel(Math.Round(x, 0).ToString()); });
                    int fundsTag = funds.AddCallback((double x) => { UpdateFundsResourceLabel(Math.Round(x, 0).ToString()); });
                    int reputationTag = reputation.AddCallback((float x) => { UpdateReputationResourceLabel(Math.Round(x, 0).ToString()); });
                    int sceneTag = scene.AddCallback((GameScene x) => { UpdateGameSceneLabel(x); UpdateButtons(); });

                    science.Start();
                    funds.Start();
                    reputation.Start();
                    scene.Start();

                    TouchScience(science, scienceTag);
                    TouchFunds(funds, fundsTag);
                    TouchReputation(reputation, reputationTag);
                    TouchGameScene(scene, sceneTag);

                    UpdateManager(kspMgr);
                    UpdateConnection(kspMgr.Connection);
                    UpdateConnectionLabel($"{kspMgr.Connection.KRPC().GetStatus().Version}");

                    UpdateButtons();
                }
            }
            return 0;
        }
        #endregion

        #region Cross Thread Update support
        private void TouchTime(Stream<double> s, int tag)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");

            if (Time is null)
            {
                this.Invoke(new MethodInvoker(() => Time = s));
                this.Invoke(new MethodInvoker(() => TimeTag = tag));
            }
        }
        private void TouchScience(Stream<float> s, int tag)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");

            if (Science is null)
            {
                this.Invoke(new MethodInvoker(() => Science = s));
                this.Invoke(new MethodInvoker(() => ScienceTag = tag));
            }
        }
        private void TouchFunds(Stream<double> s, int tag)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");

            if (Funds is null)
            {
                this.Invoke(new MethodInvoker(() => Funds = s));
                this.Invoke(new MethodInvoker(() => FundsTag = tag));
            }
        }
        private void TouchReputation(Stream<float> s, int tag)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");

            if (Reputation is null)
            {
                this.Invoke(new MethodInvoker(() => Reputation = s));
                this.Invoke(new MethodInvoker(() => ReputationTag = tag));
            }
        }
        private void TouchGameScene(Stream<GameScene> s, int tag)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");

            if (GameScene is null)
            {
                this.Invoke(new MethodInvoker(() => GameScene = s));
                this.Invoke(new MethodInvoker(() => GameSceneTag = tag));
            }
        }
        private void UpdateManager(KSPManager m)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => KSPManager = m));
        }
        private void UpdateVersion(string text)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => Version = text));
        }
        private void UpdateConnection(Connection c)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => Connection = c));
        }
        private void UpdateGameSceneLabel(GameScene s)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => GameSceneLabel = s));
        }
        private void UpdateTimeResourceLabel(string text)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => TimeResourceLabel = $"Time: {text}"));
        }
        private void UpdateConnectionLabel(string text)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => ConnectionLabel = $"Server Version: {text}"));
        }
        private void UpdateFundsResourceLabel(string text)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => FundsResourceLabel = $"Funds: {text}"));
        }
        private void UpdateScienceResourceLabel(string text)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => ScienceResourceLabel = $"Science: {text}"));
        }
        private void UpdateReputationResourceLabel(string text)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => ReputationResourceLabel = $"Reputation: {text}"));
        }
        private void UpdateSpaceCenterButton(bool enabled)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => SpaceCenterButton.Enabled = enabled));
        }
        private void UpdateFlightButton(bool enabled)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => FlightButton.Enabled = enabled));
        }
        private void UpdateTrackingStationButton(bool enabled)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => TrackingStationButton.Enabled = enabled));
        }
        private void UpdateVABButton(bool enabled)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => VABButton.Enabled = enabled));
        }
        private void UpdateSPHButton(bool enabled)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => SPHButton.Enabled = enabled));
        }
        private void UpdateConnectButton(bool enabled)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => ConnectButton.Enabled = enabled));
        }
        private void UpdateDisconnectButton(bool enabled)
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => DisconnectButton.Enabled = enabled));
        }
        private void RemoteThreadResetButtons()
        {
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
            this.Invoke(new MethodInvoker(() => ResetButtons()));
        }
        private void UpdateButtons()
        {
            RemoteThreadResetButtons();

            switch (this.GameSceneLabel)
            {
                case KRPC.Client.Services.KRPC.GameScene.SpaceCenter:
                    _logger.Trace($"Scene is Space Center");
                    UpdateSpaceCenterButton(true);
                    UpdateDisconnectButton(true);
                    UpdateConnectButton(false);
                    break;
                case KRPC.Client.Services.KRPC.GameScene.Flight:
                    _logger.Trace($"Scene is Flight");
                    UpdateFlightButton(true);
                    UpdateDisconnectButton(true);
                    UpdateConnectButton(false);
                    break;
                case KRPC.Client.Services.KRPC.GameScene.TrackingStation:
                    _logger.Trace($"Scene is Tracking Station");
                    UpdateTrackingStationButton(true);
                    UpdateDisconnectButton(true);
                    UpdateConnectButton(false);
                    break;
                case KRPC.Client.Services.KRPC.GameScene.EditorVAB:
                    _logger.Trace($"Scene is VAB");
                    UpdateVABButton(true);
                    UpdateDisconnectButton(true);
                    UpdateConnectButton(false);
                    break;
                case KRPC.Client.Services.KRPC.GameScene.EditorSPH:
                    _logger.Trace($"Scene is SPH");
                    UpdateSPHButton(true);
                    UpdateDisconnectButton(true);
                    UpdateConnectButton(false);
                    break;
            }
        }
        #endregion

        #region Utility
        private void ResetControls()
        {
            GameSceneLabel = KRPC.Client.Services.KRPC.GameScene.SpaceCenter;
            ScienceResourceLabel = "";
            FundsResourceLabel = "";
            ReputationResourceLabel = "";
            TimeResourceLabel = "";
            ConnectionLabel = "Disconnected";
        }
        private void ResetButtons()
        {
            if (!(SpaceCenterButton is null))
                SpaceCenterButton.Enabled = false;
            if (!(FlightButton is null))
                FlightButton.Enabled = false;
            if(!(TrackingStationButton is null))
                TrackingStationButton.Enabled = false;
            if(!(VABButton is null))
                VABButton.Enabled = false;
            if(!(SPHButton is null))
                SPHButton.Enabled = false;
            if(!(DisconnectButton is null))
                DisconnectButton.Enabled = false;
        }
        private void CloseOut()
        {
            CloseAllStreams();
            KRPCDisposeConnection();
            ResetControls();
            ResetButtons();
        }
        private void CloseAllStreams()
        {
            _logger.Info($"Closing streams");
            if(!(Time is null))
            {
                Time.RemoveCallback(TimeTag);
                Time.Remove();
                _logger.Info($"Time Closed");
            }
            if(!(Science is null))
            {
                Science.RemoveCallback(ScienceTag);
                Science.Remove();
                _logger.Info($"Science Closed");
            }
            if(!(Funds is null))
            {
                Funds.RemoveCallback(FundsTag);
                Funds.Remove();
                _logger.Info($"Funds Closed");
            }
            if(!(Reputation is null))
            {
                Reputation.RemoveCallback(ReputationTag);
                Reputation.Remove();
                _logger.Info($"Reputation Closed");
            }
            if(!(GameScene is null))
            {
                GameScene.RemoveCallback(GameSceneTag);
                GameScene.Remove();
                _logger.Info($"GameScene Closed");
            }
        }
        private void KRPCDisposeConnection()
        {
            if (!(Connection is null))
            {
                Connection.Dispose();
                _logger.Info($"KRPC Disposed");
            }
        }
        // Handle connection cleanups when we exit the application
        private void OnApplicationExit(object sender, EventArgs e)
        {
            if (!(Connection is null))
            {
                _logger.Trace("Disposing stream");
                Thread.Sleep(1000);
                Connection.Dispose();
            }
        }
        // Notify the interface of changed values
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            #region Debug
#if DEBUG
            if (!(_logger is null))
                //_logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
#endif
            #endregion
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                #region Debug
#if DEBUG
                //_logger.Trace($"Property changed: {propertyName}");
#endif
                #endregion
            }
        }
        // Interface implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Logging Configuration
        // NLog RichTextBox logging configuration
        Logger InitRichTextBoxLogging(string loggerName, RichTextBoxTarget rtbTarget, string rtbTargetName, string formName)
        {
            // Setup config
            LoggingConfiguration logConfig = new LoggingConfiguration();

            // Add our rich text box information
            logConfig.AddTarget(rtbTargetName, rtbTarget);

            // Form to look at
            rtbTarget.FormName = formName;

            // Control Name
            rtbTarget.ControlName = rtbTargetName;

            // Use default color rules
            rtbTarget.UseDefaultRowColoringRules = true;

            rtbTarget.MaxLines = 500;

            // Custom log entry format
            rtbTarget.Layout = "${date:format=HH\\:MM\\:ss} [${logger}]: ${message}";

            // all logs to go to the rich text box
            LoggingRule richTextBoxRule = new LoggingRule("*", LogLevel.Trace, rtbTarget);

            // Add rule
            logConfig.LoggingRules.Add(richTextBoxRule);

            // Apply configuration
            LogManager.Configuration = logConfig;

            // Get the new logger
            var logger = LogManager.GetLogger(loggerName);

            // Log logging initialization
            logger.Trace($"Logger [{loggerName}] initialized");

            return logger;
        }
        #endregion
    }
}
