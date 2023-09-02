using SplashKitSDK;

namespace FishShooting
{
    public abstract class Obstacle : GameObjects, IMove
    {
        public Obstacle(float x, float y) : base(x, y) { }
       
        //  Left movement for obstacle
        public void MoveLeft(float speed)
        {
            SplashKit.SpriteSetX(ObjectSprite, SplashKit.SpriteX(ObjectSprite) + speed);
        }

        //  Impact of obstacles on fish when they collide
        public abstract void Impact(Fish f);
    }
}

