using PlayAPI.Model;

namespace PlayAPI.Utilities
{
    public interface IPlayGame
    {
        public PlayResponse DecideWinner(int playerMove);
    }
}
