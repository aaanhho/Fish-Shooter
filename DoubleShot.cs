using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishShooting;

namespace FishShooting
{
    class DoubleShot : ISkills
    {
        public DoubleShot() { }

        public void Execute(Fish s)
        {
            s.doubleshot = true;
            s.Score -= 5;
        }
    }
}