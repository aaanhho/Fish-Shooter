using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishShooting;

namespace FishShooting
{
    public class Protect : ISkills
    {
        public Protect() { }

        public void Execute(Fish f)
        {
            f.protect = true;
            f.Score -= 5;
        }
    }
}