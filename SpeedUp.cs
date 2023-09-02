using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishShooting;

namespace FishShooting
{
    public class SpeedUp : ISkills
    {
        public SpeedUp() { }

        public void Execute(Fish f)
        {
            f.speed = 15;
            f.Score -= 5;
        }
    }
}

