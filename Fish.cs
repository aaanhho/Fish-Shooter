using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FishShooting;

namespace FishShooting
{
    public abstract class Fish : GameObjects
    {
        private int _hearts = 3;
        private int _score = 0;
        protected Skills skill;
        public bool doubleshot = false;
        public bool protect = false;
        public int speed = 5;


        public int Hearts {
            get { return _hearts; }
            set { _hearts = value; }
        }

        public int Score {
            get { return _score; }
            set { _score = value; }
        }


        public Fish() : base()
        {
            skill = new Skills();
        }

        // move update for fish
        public void MoveUpdate()
        {
            if (SplashKit.KeyDown(KeyCode.UpKey)) { Y -= speed; }
          
            if (SplashKit.KeyDown(KeyCode.DownKey)) { Y += speed; }
          
            if (SplashKit.KeyDown(KeyCode.RightKey)) { X += speed; }
           
            if (SplashKit.KeyDown(KeyCode.LeftKey)) { X -= speed; }
            

            if (X > 900 - Image.Width)
            {
                X = 900 - Image.Width;
            }
            else if (X < 0)
            {
                X = 0;
            }
            if (Y > 500 - Image.Height)
            {
                Y = 500 - Image.Height;
            }
            else if (Y < 0)
            {
                Y = 0;
            }

            SplashKit.SpriteSetX(ObjectSprite, X);
            SplashKit.SpriteSetY(ObjectSprite, Y);
        }

        //  Each fish has unique skills
        public abstract void SkillUpdate();
    }
}