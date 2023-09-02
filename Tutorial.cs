using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishShooting;
using SplashKitSDK;

namespace FishShooting
{
    class Tutorial : IState
    {
        public Tutorial() { }

        public void Update(FishShooter s)
        {
            SplashKit.DrawText("Achieving the best score possible is your goal.", Color.Red, 150, 120);
            SplashKit.DrawText("You must eliminate the obstacles to attain this.", Color.Blue, 150, 150);
            SplashKit.DrawText("Collision with barrel --> lose 1 heart.", Color.Black, 150, 180);
            SplashKit.DrawText("Collision with wheel --> lose 3 heart.", Color.Black, 150, 210);
            SplashKit.DrawText("Collision with bomb --> lose the game.", Color.Black, 150, 240);
            SplashKit.DrawText("Collision with heart --> gain 1 heart.", Color.Black, 150, 270);
            SplashKit.DrawText("You have 4 skills: Heal, Speed Up, Protect, Double Shots.", Color.Black, 150, 300);
            SplashKit.DrawText("Press space to shoot.", Color.Black, 150, 330);
            SplashKit.DrawText("Press B to play with Blue Fish with Heal, Shield, and Speed Up skills.!", Color.Purple, 150, 360);
            SplashKit.DrawText("Press H to play with Horse Fish with Heal, Double Shots, and Speed Up skills!", Color.Purple, 150, 390);
        }

        public void StateChange(FishShooter s)
        {
            if (SplashKit.KeyTyped(KeyCode.HKey))
            {
                s.NextState(new Playing(new HorseFish()));
            }
            if (SplashKit.KeyTyped(KeyCode.BKey))
            {
                s.NextState(new Playing(new BlueFish()));
            }

        }
    }
}