using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helper
{
    public class Scheduler
    {
        private Action _handler;
        //ms
        private int _scheduling;

        private bool _stop = false;

        public bool Stop
        {
            get { return _stop; }
            set { _stop = value; }
        }

        public void Init(Action handler, int scheduling)
        {
            _handler = handler;
            _scheduling = scheduling;
        }

        public void Start()
        {
            while(true)
            {
                if (_stop == true)
                    break;

                _handler();
                Thread.Sleep(500);
            }
        }
    }
}
