namespace ITI.SFMLExample.Model
{
    public class GameContext
    {
        readonly Player _player;

        public GameContext()
        {
            _player = new Player(this);
        }

        public Player Player
        {
            get { return _player; }
        }

        public void Update()
        {
            _player.Update();
        }
    }
}
