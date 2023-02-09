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

namespace SOA.ArithmetiqueHost
{
    public partial class ArithemtiqueWinService : ServiceBase
    {
        ServiceHost _host;
        DateTime _now;
        public ArithemtiqueWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                using (_host = new ServiceHost(typeof(SOA.ArithmetqueService.ArithmetiqueService)))
                {
                    _host.Open();
                    _now = DateTime.Now;
                    EventLog.WriteEntry("Application", $"Le service ArithmetiqueService" +
                        $" est lancé à {_now.Hour}:{_now.Minute} \n", EventLogEntryType.Information);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "Une erreur est survenue lors du " +
                    $"lancement du service ArithmetiqueService exception:{ex.Message} ", EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            _host.Close();
            EventLog.WriteEntry("Application", $"Le service ArithmetiqueService" +
                        $" est arrêté à {_now.Hour}:{_now.Minute} \n", EventLogEntryType.Information);
        }
    }
}
