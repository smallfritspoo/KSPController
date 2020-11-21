using System;
using System.Windows.Forms;
using System.Reflection;
using NLog;
using KRPC.Client;
using System.Net;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KSPControllerTest
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form f = new Form1();
            Application.Run(f);
        }
    }

    public class LabelText : INotifyPropertyChanged
    {

        #region private property variables
        private string _labelText;
        #endregion

        public string Label
        {
            get
            {
                return this._labelText;
            }
            set
            {
                this._labelText = value;
                NotifyPropertyChanged("Label");
            }
        }

        public LabelText(string label="")
        {
            Label = label; 
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class GenericData : INotifyPropertyChanged
    {
        private string _name;
        private string _value;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return this._name; }
            set
            {
                if(value != this._name)
                {
                    this._name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public string Value
        {
            get { return this._value; }
            set
            {
                if(value != this._value)
                {
                    this._value = value;
                    NotifyPropertyChanged("Value");
                }
            }
        }

        public GenericData(string name, string value)
        {
            Name = name;
            Value = value;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
         }
    }

    public class KSPManager
    {
        private Connection _connection;

        private Logger _logger;
        
        public Connection Connection
        {
            get { return this._connection; }
            set
            {
                if(value != this._connection)
                {
                    _connection = value;
                }
            }
        }

        public KSPManager(string name, IPAddress address, Logger logger)
        {
            if (logger == null)
            {
                throw new NullReferenceException("LOGGER IS NOT CONFIGURED");
            }
            
            this._logger = logger;

#if DEBUG
            _logger.Trace($"{MethodBase.GetCurrentMethod()} Invoked");
#endif

            _logger.Info("Constructing KSPManager");

            try
            {
                Connection = KSPConnection(name, address);
            }
            catch (Exception e)
            {
#if DEBUG
                _logger.Trace($"Exception handled. {e.GetBaseException()}");
#endif
                _logger.Warn($"Connection failed on provided address, attempting loopback");
                Connection = KSPConnection(name, IPAddress.Parse("127.0.0.1"));
            }

        }

        Connection KSPConnection(string name, IPAddress address)
        {
#if DEBUG
            _logger.Trace($"{MethodBase.GetCurrentMethod()} invoked");
#endif

            _logger.Info($"Attempting to connect to {address}:50000");
#if DEBUG
            _logger.Trace($"Client name: {name}, Client Address: {address}, RPCPort: 50000, Streaming Port: 50001");
#endif
            Connection conn;

            try
            {
                conn = new Connection(name, address);
            }
            catch (Exception e)
            {
                _logger.Error($"Failed to connect to KSP!");
#if DEBUG
                _logger.Trace($"Exception handled. {e.GetBaseException()}");
#endif
                conn = null;
            }

            if (conn is null)
            {
                conn = null;
            }
            else
            {
                Connection = conn;
            }

            return conn;
        }
    }
}
