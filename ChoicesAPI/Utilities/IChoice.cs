using ChoicesAPI.Model;

namespace ChoicesAPI.Utilities
{
    public interface IChoice
    {
        public List<ChoiceDto> GetChoices();
        public ChoiceDto GetRandomChoice();

    }
}
