using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.Collections;
using static System.Formats.Asn1.AsnWriter;


namespace FishShooting
{
    //Factory pattern
    public class ObstacleFactory
    {
        private static ObstacleFactory instance;

        public static ObstacleFactory getInstance()
        {
            if (instance == null)
                instance = new ObstacleFactory();
            return instance;
        }

        //Singleton: only 1 factory 
        private ObstacleFactory() { }

        public IMove GetObstacles(string key)
        {
            if (key == "barrel")
            {
                return new Barrel(900, SplashKit.Rnd(50, 450));
            }
            else if (key == "stone")
            {
                return new Wheel(900, SplashKit.Rnd(50, 450));
            }
            else if (key == "bomb")
            {
                return new Bomb(900, SplashKit.Rnd(50, 450));
            }
            else if (key == "heart")
            {
                return new Heart(900, SplashKit.Rnd(50, 450));
            }
            else
            {
                return null;
            }
        }
    }
}
