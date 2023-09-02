using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShooting
{
    public interface IState
    {
        public void StateChange(FishShooter f) { }
   
        public void Update(FishShooter f) { }
    }
}