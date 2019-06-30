using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class BingoGame
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ICollection<BingoNumber> Numbers { get; set; }
    }
}