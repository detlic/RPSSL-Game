using PlayAPI.Model;

namespace PlayAPI.Utilities
{
    public class PlayGame : IPlayGame
    {
        public PlayResponse DecideWinner(int playerMove)
        {
            var rules = GameRules();
            Random random = new Random();
            var computerMove = random.Next(1, rules.Count + 1);
            PlayResponse playResponse = new PlayResponse();

            List<MoveDto> moves = new();
            moves.Add(new MoveDto
            {
                Id = playerMove,
                Player = "player",
                Move = rules[playerMove - 1].Name
            });
            moves.Add(new MoveDto
            {
                Id = computerMove,
                Player = "computer",
                 Move = rules[computerMove - 1].Name
            });
            playResponse.Moves = moves;
           
            if (playerMove == computerMove)
            {
                playResponse.Result = "draw";
                return playResponse;
            }
 
            if (rules[playerMove-1].Beats.Contains(computerMove))
            {
                playResponse.Result = "win";
                return playResponse;
            }
            
            playResponse.Result = "lost";
            return playResponse;

            

        }

        private List<ChoiceRule> GameRules()
        {
            var listRules = new List<ChoiceRule>();
            listRules.Add(new ChoiceRule
            {
                Id = 1,
                Name = "rock",
                Beats = [3, 5]
            });
            listRules.Add(new ChoiceRule
            {
                Id = 2,
                Name = "paper",
                Beats = [1, 4]
            });
            listRules.Add(new ChoiceRule
            {
                Id = 3,
                Name = "scissors",
                Beats = [2, 5]
            });
            listRules.Add(new ChoiceRule
            {
                Id = 4,
                Name = "spock",
                Beats = [1, 3]
            });
            listRules.Add(new ChoiceRule
            {
                Id = 5,
                Name = "lizard",
                Beats = [2, 4]
            });

            return listRules;
        }

    }
}
