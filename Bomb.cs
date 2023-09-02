using SplashKitSDK;
using static System.Net.Mime.MediaTypeNames;

namespace FishShooting
{
    public class Bomb : Obstacle
    {
        public Bomb(float x, float y) : base(x, y)
        {
            Image = SplashKit.LoadBitmap("bomb", "Bomb.png");
            ObjectSprite = new Sprite(Image);
            SplashKit.SpriteSetX(ObjectSprite, x);
            SplashKit.SpriteSetY(ObjectSprite, y);
        }

        //  Impact of obstacles on fish when they collide
        public override void Impact(Fish f)
        {
            f.Hearts = 0;
        }
    }
}