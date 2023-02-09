using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SOA.WindowsServiceHost
{
    public partial class Service1 : ServiceBase
    {
        ServiceHost _host;
        DateTime _now;
        public Service1()
        {
            InitializeComponent();

        }

        protected override void OnStart(string[] args)
        {

            try
            {
                using (_host = new ServiceHost(typeof(SOA.RHService.RHService)))
                {
                    _host.Open();
                    _now = DateTime.Now;
                    EventLog.WriteEntry("Application", $"Le service RHService" +
                        $" est lancé à {_now.Hour}:{_now.Minute} \n" +
                        $" http://localhost:9000/ " +
                        $"\nnet.tcp://localhost:9001/ ", EventLogEntryType.Information);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application","Une erreur est survenue lors du " +
                    $"lancement du service RHService exception:{ex.Message} ", EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            _host.Close();
            EventLog.WriteEntry("Application", $"Le service RHService" +
                        $" est arrêté à {_now.Hour}:{_now.Minute} \n", EventLogEntryType.Information);
        }
    }
}
