using System;
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

                    window.Clear();

                    RectangleShape rectangleShape = new RectangleShape(new Vector2f(30, 50));
                    rectangleShape.FillColor = Color.Red;
                    rectangleShape.Position = new Vector2f(400, 300);

                    rectangleShape.Draw(window, RenderStates.Default);

                    window.Display();
                }
            }
        }
    }
}
