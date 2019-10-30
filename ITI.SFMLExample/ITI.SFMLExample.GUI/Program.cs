using ITI.SFMLExample.Model;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ITI.SFMLExample.GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Example", Styles.Close | Styles.Titlebar))
            {
                GameController gameController = new GameController(window, new GameContext());
                window.Closed += (s, e) =>
                {
                    window.Close();
                };

                window.KeyPressed += (s, e) =>
                {
                    if (e.Code == Keyboard.Key.Escape) window.Close();
                };

                while (window.IsOpen)
                {
                    window.DispatchEvents();
                    gameController.Update();
                    window.Clear();
                    gameController.Display();
                    window.Display();
                }
            }
        }
    }
}
