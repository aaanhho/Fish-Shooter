using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishShooting;
using SplashKitSDK;

namespace FishShooting
{
    public class Skills : ObjectTimer
    {
        private ISkills _skill;

        public Skills() : base(5000, "SkillTimer") { }

        public void Set(ISkills f)
        {
            this._skill = f;
        }

        public void Apply(Fish f)
        {
            _skill.Execute(f);
            Timer.Start();
        }

        //Skill terminate if the time runs out
        public override void Terminate(Fish f)
        {
            if (ExistTime <= Timer.Ticks)
            {
                Timer.Stop();
                f.protect = false;
                f.doubleshot = false;
                f.speed = 5;
            }
        }
    }
}


