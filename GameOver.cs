using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FishShooting
{
    class GameOver : IState
    {
        private int highestScore;

        public GameOver()
        {
            GameDatabase db = GameDatabase.GetDatabase();
            QueryResult qr = db.Query("INSERT INTO scores VALUES (" + (Playing.f.Score) + ");");
            highestScore = db.Query("SELECT MAX(score) FROM scores;").QueryColumnForInt(0);
        }
        
        public void Update(FishShooter s)
        {
            SplashKit.DrawText("Game Over", Color.Black, 70, 150);
            SplashKit.DrawText("Highest Score: " + highestScore, Color.Black, 70, 170);
            SplashKit.DrawText("Your Score: " + Playing.f.Score, Color.Black, 70, 190);

            SplashKit.DrawText("Press Space to replay", Color.Purple, 70, 360);
            SplashKit.DrawText("Press Q to quit", Color.Purple, 70, 390);

            SplashKit.ShowMouse();
        }

        public void StateChange(FishShooter s)
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                s.NextState(new Tutorial());
            }

            if (SplashKit.KeyTyped(KeyCode.QKey))
            {
                SplashKit.CloseCurrentWindow();
            }
        }
    }
}