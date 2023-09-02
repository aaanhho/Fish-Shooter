using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FishShooting
{
    class HorseFish : Fish
    {
        public HorseFish() : base()
        {
            Image = SplashKit.LoadBitmap("hf", "fish.png");
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

            //Double Shot skill
            if (this.Score > 5)
            {
                if (SplashKit.KeyTyped(KeyCode.EKey))
                {
                    skill.Set(new DoubleShot());
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
    }
}