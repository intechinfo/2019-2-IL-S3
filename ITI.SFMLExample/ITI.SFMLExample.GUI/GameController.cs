using ITI.SFMLExample.Model;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ITI.SFMLExample.GUI
{
    class GameController
    {
        readonly RenderWindow _window;
        readonly GameContext _gameContext;

        public GameController(RenderWindow window, GameContext gameContext)
        {
            _window = window;
            _gameContext = gameContext;

            window.KeyPressed += OnKeyPressed;
        }

        void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Right) _gameContext.Player.Move(0.05f, 0.0f);
            else if (e.Code == Keyboard.Key.Left) _gameContext.Player.Move(-0.05f, 0.0f);
            else if (e.Code == Keyboard.Key.Up) _gameContext.Player.Move(0.0f, -0.05f);
            else if (e.Code == Keyboard.Key.Down) _gameContext.Player.Move(0.0f, 0.05f);
        }

        public void Update()
        {
            _gameContext.Update();
        }

        public void Display()
        {
            RectangleShape playerShape = new RectangleShape(new Vector2f(50, 50));
            float x = (_gameContext.Player.X + 1.0f) * 400.0f;
            float y = (_gameContext.Player.Y + 1.0f) * 300.0f;
            playerShape.Position = new Vector2f(x, y);
            playerShape.Draw(_window, RenderStates.Default);
        }
    }
}
