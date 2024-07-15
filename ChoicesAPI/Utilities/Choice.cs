using ChoicesAPI.Model;
using System;
using System.Drawing;

namespace ChoicesAPI.Utilities
{
    public class Choice : IChoice
    {
        public List<ChoiceDto> GetChoices()
        {
            return GetChoiceDtos<ChoiceEnum>(); ;
        }

        public ChoiceDto GetRandomChoice()
        {
            Array values = Enum.GetValues(typeof(ChoiceEnum));
            Random random = new Random();
            var index = random.Next(values.Length);
            return new ChoiceDto
            {
                Id = index,
                Choice = values.GetValue(index).ToString()
            };

        }

        private static List<ChoiceDto> GetChoiceDtos<ChoiceEnum>()
        {
            var listOfChoices = new List<ChoiceDto>();
            var enumValues = Enum.GetValues(typeof(ChoiceEnum));
            foreach(var enumValue in enumValues)
            {
                int number = (int)enumValue;
                listOfChoices.Add(new ChoiceDto
                {
                    Id = number,
                    Choice = enumValue.ToString()
                });

            }
            return listOfChoices; 
        }
    }
}
