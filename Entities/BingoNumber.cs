using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class BingoNumber
    {
        public int Id { get; set; }
        public string NumValue { get; set; }
        public bool IsPlayed { get; set; }
        public int BingoGameId { get; set; }
        [ForeignKey("BingoGameId")]
        public BingoGame BingoGame { get; set; }
    }
}