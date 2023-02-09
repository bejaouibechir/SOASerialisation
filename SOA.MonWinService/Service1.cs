using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOA.MonWinService
{
    public partial class Service1 : ServiceBase
    {

        private Thread _thread;
        private Worker _worker;
        
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _worker = new Worker();
            _thread = new Thread(_worker.Work)
            {
                IsBackground= true,
            };
            _thread.Start();
        }

        protected override void OnStop()
        {
            _worker.Stopped= true;
            _thread.Join(); //Je met le thread en standby
        }
    }
}
