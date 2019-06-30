using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IBingoService
    {
        IEnumerable<BingoNumber> GetNumbers(bool isPlayed);
        BingoGame Start(string gameName = "standard");
        //BingoNumber Create(BingoNumber number);
        void Update(string numValue, bool isPlayed = true);
        void Delete(string numValue);
    }

    public class BingoService : IBingoService
    {
        private DataContext _context;

        public BingoService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<BingoNumber> GetNumbers(bool isPlayed)
        {
            return _context.BingoNumbers.Where( b => b.IsPlayed == isPlayed).ToList();
        }

        private BingoNumber[] initNumbers(string gameName)
        {
            switch (gameName)
            {
                default: // standard
                    List<BingoNumber> numbers = new List<BingoNumber>();
                    for (var i = 1; i < 76; i++)
                    {
                        var num = "B";
                        if (i >= 16) num = "I";
                        if (i >= 31) num = "N";
                        if (i >= 46) num = "G";
                        if (i >= 61) num = "O";
                        numbers.Append(new BingoNumber { NumValue = num + i.ToString() });
                    }
                    return numbers.ToArray();
            }
        }

        public BingoGame Start(String gameName)
        {
            var numbers = initNumbers(gameName);
            var game = new BingoGame()
            {
                StartTime = new DateTime(),
                Numbers = numbers
            };
            _context.BingoNumbers.AddRange(numbers);
            _context.SaveChanges();
            return game;
        }

        //public BingoNumber Create(BingoNumber number)
        //{
        //    _context.BingoNumbers.Add(number);
        //    _context.SaveChanges();
        //    return number;
        //}
        // Call Update
        public void Update(string numValue, bool isPlayed = true)
        {
            var myNumber = _context.BingoNumbers.Where( b => b.NumValue == numValue).SingleOrDefault();
            myNumber.IsPlayed = isPlayed;
            _context.BingoNumbers.Update(myNumber);
            _context.SaveChanges();
        }

        public void Delete(string numValue)
        {
            var number = _context.BingoNumbers.Where( b => b.NumValue == numValue).SingleOrDefault();
            if (number != null)
            {
                _context.BingoNumbers.Remove(number);
                _context.SaveChanges();
            }
        }
        }
    }
}