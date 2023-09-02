using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FishShooting;
using SplashKitSDK;


namespace FishShooting
{
    public class GameMain : ObjectTimer
    {
        private List<IMove> MovingObjects;
        private List<IMove> ObjRemove;
        private int shootingNum = 0;


        public GameMain() : base(2000, "FireTimer")
        {
            MovingObjects = new List<IMove>();
            ObjRemove = new List<IMove>();
        }


        // Delete objects in ObjRemove list
        public void ObjectDelete()
        {
            foreach (IMove obj in ObjRemove)
            {
                MovingObjects.Remove(obj);
            }
        }

        // Add Obstacles and Fire to MovingObjects list
        public void ObjectAdd()
        {
            string[] s = new string[] { "barrel", "stone", "heart", "bomb" };
            foreach (string v in s)
            {
                if (v == "heart")
                { 
                    if (SplashKit.Rnd(0, 1000) % 450 == 0)
                    {
                        IMove obs = ObstacleFactory.getInstance().GetObstacles(v);
                        MovingObjects.Add(obs);
                    }
                }
                else
                {
                    if (SplashKit.Rnd(0, 1000) % 100 == 0)
                    {
                        IMove obs = ObstacleFactory.getInstance().GetObstacles(v);
                        MovingObjects.Add(obs);
                    }
                }
            }
        }

        //Add speed of movement for game objects
        public void ObjectMove()
        {
            foreach (IMove obj in MovingObjects)
            {
                if (obj.GetType() != typeof(Fire))
                {
                    obj.MoveLeft(-3f);
                }
                if (obj.GetType() == typeof(Fire))
                {
                    obj.MoveLeft(10f);
                }
            }
        }

        //Draw the objects
        public void ObjectDraw()
        {
            foreach (GameObjects obj in MovingObjects)
            {
                obj.Draw();
            }
        }

        // Impact when fish collides with each obstacle
        public void Collide(Fish fish)
        {
            foreach (GameObjects obj in MovingObjects)
            {
                if (obj is Obstacle)
                {
                    Obstacle ob = (Obstacle)obj;
                    if (ob.DoesCollide(fish) && fish.protect == false)
                    {
                        ob.Impact(fish);
                        ObjRemove.Add(ob);
                    }
                    else if (ob.DoesCollide(fish) && fish.protect == true)
                    {
                        if (ob.GetType() == typeof(Bomb))
                        {
                            ob.Impact(fish);
                            ObjRemove.Add(ob);
                        }
                        else
                        {
                            ObjRemove.Add(ob);
                        }
                    }
                    for (int i = 0; i < MovingObjects.Count; i++)
                    {
                        IMove f = MovingObjects[i];
                        if (f is Fire)
                        {
                            Fire? fi = f as Fire;
                            if (fi.DoesCollide(ob) && ob.GetType() != typeof(Heart))
                            {
                                ObjRemove.Add(ob);
                                ObjRemove.Add(fi);
                                fish.Score += 1;
                            }
                        }
                    }
                }
            }
        }

        // Add fire for fish
        public void FireAdd(Fish f)
        {
            if (shootingNum < 5)
            {
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    if (f.doubleshot == false)
                    {
                        Fire b = new(f.X + f.Width, f.Y + f.Height / 2 - 17);
                        MovingObjects.Add(b);
                    }
                    if (f.doubleshot == true)
                    {
                        for (int i = 1; i < 3; i++)
                        {
                            Fire b = new(f.X + f.Width + 15 - 68 + 34 * i, f.Y + f.Height / 2 - 17);
                            MovingObjects.Add(b);
                        }
                    }
                    shootingNum += 1;
                    if (shootingNum == 5)
                    {
                        Timer.Start();
                    }
                }
            }
            else
            {
                Terminate(f);
            }
        }

        // Stop the timer and reset number of shooting
        public override void Terminate(Fish f)
        {
            if (ExistTime <= Timer.Ticks)
            {
                Timer.Stop();
                shootingNum = 0;
            }
        }

        // Inpsect if the objects are still on the screen, if not delete them
        public void Inspect()
        {
            foreach (IMove obj in MovingObjects)
            {
                if (obj.X < 0 || obj.X > SplashKit.ScreenWidth())
                {
                    ObjRemove.Add(obj);
                }
                if (obj is Fire)
                {
                    Fire fire = obj as Fire;
                    if (fire.Y < 0 || fire.Y > SplashKit.ScreenHeight() || fire.X < 0 || fire.X > SplashKit.ScreenWidth())
                    {
                        ObjRemove.Add(fire);
                    }
                }
            }
        }
    }
}