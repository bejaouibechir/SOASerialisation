using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace SOA.MonWinService
{
    internal class Worker
    {
        int _Delay;
        bool _Stopped;
        ManualResetEvent _ResetEvent;
        private readonly object _ThreadLock = new object();
        public Worker()
        {
            _Delay = 10000;//10 S
            //_Delay = int.Parse(ConfigurationManager.AppSettings["duration"].ToString());
            _Stopped = false;
            _ResetEvent = new ManualResetEvent(false);
        }

        public bool Stopped
        {
            get
            { lock (_ThreadLock) { return _Stopped; } }
            set
            {
                lock (_ThreadLock)
                {
                    _Stopped = value;
                    _ResetEvent.Set();
                }
            }
        }

        public int Delay
        {
            get { lock (_ThreadLock) { return _Delay; } }
            set
            {
                lock (_ThreadLock) { _Delay = value; }
            }
        }

        public void Work()
        {
            DateTime date = DateTime.Now;
            while (!Stopped)
            {
                try
                {
                    EventLog.WriteEntry("Application", $"Service triggered  at {date.Hour}:{date.Minute}:{date.Second}", EventLogEntryType.Information);
                }
                catch (Exception ex)
                {
                    string error = $"Windows service called with error: {ex.Message}";
                    if (ex.InnerException != null)
                        error = error + $" inner exception: {ex.InnerException.Message}";
                    EventLog.WriteEntry("Application", error, EventLogEntryType.Error);
                }

                if (_ResetEvent.WaitOne(Delay))
                    break;
            }
        }
    }
}
