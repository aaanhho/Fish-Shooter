using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FishShooting
{
    public class Heal : ISkills
    {
        public Heal() { }

        public void Execute(Fish f)
        {
            f.Hearts += 1;
            f.Score -= 10;
        }
    }
}