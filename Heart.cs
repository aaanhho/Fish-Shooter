using SplashKitSDK;
using static System.Net.Mime.MediaTypeNames;

namespace FishShooting
{
    public class Heart : Obstacle
    {
        public Heart(float x, float y) : base(x, y)
        {
            Image = SplashKit.LoadBitmap("heart", "heart.png");
            ObjectSprite = new Sprite(Image);
            SplashKit.SpriteSetX(ObjectSprite, x);
            SplashKit.SpriteSetY(ObjectSprite, y);
        }

        //  Impact of obstacles on fish when they collide
        public override void Impact(Fish f)
        {
            f.Hearts += 1;
        }
    }
}