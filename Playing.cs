using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;
using FishShooting;
using System.Runtime.ConstrainedExecution;

namespace FishShooting
{
    public class Playing : IState
    {
        Bitmap background = SplashKit.LoadBitmap("background", "background.jpeg");
        GameMain g = new GameMain();
        public static Fish f;

        public Playing(Fish fish)
        {
            f = fish;
        }
    
        public void Update(FishShooter f)
        {
            if (Playing.f.Hearts > 0)
            {

                SplashKit.HideMouse();
                SplashKit.DrawBitmap(background, 0, 0);

                SplashKit.DrawText("Hearts: " + Playing.f.Hearts, Color.Red, 5, 10);
                SplashKit.DrawText("Score: " + Playing.f.Score, Color.Red, 5, 30);


                Playing.f.Draw();
                Playing.f.MoveUpdate();
                Playing.f.SkillUpdate();


                g.ObjectDraw();
                g.ObjectAdd();
                g.FireAdd(Playing.f);
                g.ObjectMove();
                g.Collide(Playing.f);
                if (Playing.f.Hearts < 0)
                {
                    Playing.f.Alive = false;
                }
                g.Inspect();
                g.ObjectDelete();

                SplashKit.RefreshScreen(60);
            }
        }

        public void StateChange(FishShooter f)
        {
            if (Playing.f.Hearts <= 0)
            {
                f.NextState(new GameOver());
            }
        }
    }
}