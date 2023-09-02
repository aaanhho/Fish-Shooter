using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FishShooting
{
    class BlueFish : Fish
    {
        public BlueFish() : base()
        {
            Image = SplashKit.LoadBitmap("bf", "bluefish.png");
            ObjectSprite = new Sprite(Image);
            X = 0; Y = 250 - this.Height / 2;
        }
        
        public override void SkillUpdate()
        {
            //Heal skill
            if (this.Score > 10)
            {
                if (SplashKit.KeyTyped(KeyCode.WKey))
                {
                    skill.Set(new Heal());
                    skill.Apply(this);
                }
            }

            //Protect skill
            if (this.Score > 5)
            {
                if (SplashKit.KeyTyped(KeyCode.EKey))
                {
                    skill.Set(new Protect());
                    skill.Apply(this);
                }
            }

            //Speed Up skill
            if (this.Score > 5)
            {
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    skill.Set(new SpeedUp());
                    skill.Apply(this);
                }
            }

            skill.Terminate(this);
        }
       
        //  bluefish has sepcial draw method since it has protect skill
        public override void Draw()
        {
            if (protect == false)
            {
                SplashKit.DrawSprite(this.ObjectSprite);
            }
            else
            {
                SplashKit.DrawSprite(this.ObjectSprite);
                SplashKit.DrawCircle(Color.Blue, this.X + this.Width / 2, this.Y + this.Height / 2, this.Width / 2);
            }
        }
    }
}