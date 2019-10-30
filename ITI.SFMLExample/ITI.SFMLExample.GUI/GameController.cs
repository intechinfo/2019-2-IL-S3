using System.Reflection;
using ITI.SFMLExample.Model;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ITI.SFMLExample.GUI
{
    class GameController
    {
        readonly Texture _playerTexture;
        readonly RenderWindow _window;
        readonly GameContext _gameContext;

        public GameController(RenderWindow window, GameContext gameContext)
        {
            _window = window;
            _gameContext = gameContext;

            window.KeyPressed += OnKeyPressed;
            window.KeyReleased += OnKeyReleased;

            Assembly assembly = Assembly.GetExecutingAssembly();
            _playerTexture = new Texture(assembly.GetManifestResourceStream("ITI.SFMLExample.GUI.Resources.Player.png"));
        }

        void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Right) _gameContext.Player.StartMove(0.0005f, 0.0f);
            else if (e.Code == Keyboard.Key.Left) _gameContext.Player.StartMove(-0.0005f, 0.0f);
            else if (e.Code == Keyboard.Key.Up) _gameContext.Player.StartMove(0.0f, -0.0005f);
            else if (e.Code == Keyboard.Key.Down) _gameContext.Player.StartMove(0.0f, 0.0005f);
        }

        void OnKeyReleased(object sender, KeyEventArgs e)
        {
            if(e.Code == Keyboard.Key.Right || e.Code == Keyboard.Key.Left || e.Code == Keyboard.Key.Up || e.Code== Keyboard.Key.Down)
            {
                _gameContext.Player.StopMove();
            }
        }

        public void Update()
        {
            _gameContext.Update();
        }

        public void Display()
        {
            RectangleShape playerShape = new RectangleShape(new Vector2f(0.25f, 0.35f));
            playerShape.Position = new Vector2f(_gameContext.Player.X, _gameContext.Player.Y);
            playerShape.Texture = _playerTexture;
            
            View camera1 = new View(new Vector2f(0.0f, 0.0f), new Vector2f(2.0f, 2.0f));
            camera1.Rotation = 90.0f;
            camera1.Viewport = new FloatRect(0.0f, 0.0f, 0.5f, 1.0f);
            _window.SetView(camera1);

            playerShape.Draw(_window, RenderStates.Default);

            View camera2 = new View(new Vector2f(0.0f, 0.0f), new Vector2f(2.0f, 2.0f));
            camera2.Viewport = new FloatRect(0.5f, 0.0f, 0.5f, 1.0f);
            _window.SetView(camera2);

            playerShape.Draw(_window, RenderStates.Default);
        }
    }
}
