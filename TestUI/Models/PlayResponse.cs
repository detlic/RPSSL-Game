﻿namespace TestUI.Models
{
    public class PlayResponse
    {
        public List<MoveDto> Moves { get; set; }
        public string Result { get; set; } = string.Empty;
    }
}
