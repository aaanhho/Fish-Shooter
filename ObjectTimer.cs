using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FishShooting;

namespace FishShooting
{
    public abstract class ObjectTimer
    {
        private Timer _timer;
        private int _existTimeSkill;

        //Create differnt timers by taking its name as input
        public ObjectTimer(int time, string name)
        {
            _timer = new Timer(name);
            _existTimeSkill = time;
        }

        public int ExistTime {
            get { return _existTimeSkill; }
            set { _existTimeSkill = value; } }

        public Timer Timer
        {
            get { return _timer; }
            set { _timer = value; }
        }

        public virtual void Terminate(Fish f) { }
    }
}

