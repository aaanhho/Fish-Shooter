using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishShooting;
using SplashKitSDK;

namespace FishShooting
{
    public class FishShooter
    {
        public IState _state;
        public FishShooter()
        {
            _state = new MainMenu();
        }
        public void NextState(IState state)
        {
            _state = state;
        }

        public void Run()
        {
            new Window("Fish Shooting", 900, 500);
            while (!SplashKit.WindowCloseRequested("Fish Shooting"))
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                _state.Update(this);
                _state.StateChange(this);

                SplashKit.RefreshScreen(60);

                if (SplashKit.KeyTyped(KeyCode.QKey))
                {
                    SplashKit.CloseCurrentWindow();
                }
            }
        }
    }
}