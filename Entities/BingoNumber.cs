using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class BingoNumber
    {
        public int Id { get; set; }
        public string NumValue { get; set; }
        public bool IsPlayed { get; set; }
        public int BingoGameId { get; set; }
        public BingoGame BingoGame { get; set; }
    }
    /* With this implementation you insert rows based on the game config.
    Then the admin starts a process that updates the BingoNumbers to isPlayed every so often
     */
}