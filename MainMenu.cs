using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FishShooting
{
    class MainMenu : IState
    {
        public MainMenu() { }

        public void Update(FishShooter s)
        {
            SplashKit.DrawText("Welcome to Fish Shooting Game!!!", Color.Black, 150, 150);
            SplashKit.DrawText("Press space to continue!!!", Color.Black, 150, 170);
        }

        public void StateChange(FishShooter s)
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                s.NextState(new Tutorial());
            }
        }
    }
}