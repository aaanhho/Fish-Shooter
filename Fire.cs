using SplashKitSDK;

namespace FishShooting
{
    public class Fire : GameObjects, IMove
    {
        public Fire(float x, float y) : base(x, y)
        {
            Image = SplashKit.LoadBitmap("fire", "Bubble_1.png");
            ObjectSprite = new Sprite(Image);
            SplashKit.SpriteSetX(ObjectSprite, x);
            SplashKit.SpriteSetY(ObjectSprite, y);
        }

        //Movement for Fire
        public void MoveLeft(float speed)
        {
            SplashKit.SpriteSetX(ObjectSprite, SplashKit.SpriteX(ObjectSprite) + speed);
        }
    }
}