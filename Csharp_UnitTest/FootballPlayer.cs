using System;

namespace Csharp_UnitTest
{
    public class FootballPlayer
    {
        public static int GlobalId { get; set; }
        public int Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {              
                try
                {
                    if (value.Length < 4) throw new ArgumentOutOfRangeException();
                    _name = value;
                }
                catch (NullReferenceException)
                {
                    throw new NullReferenceException();
                }               
            }
        }
        string _name;
        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException();
                _price = value;

            }
        }
        double _price;
        public int ShirtNumber
        {
            get => _shirtNumber;
            set
            {
                if (value < 1 || value > 100) throw new ArgumentOutOfRangeException();
                _shirtNumber = value;

            }
        }
        int _shirtNumber;

        public FootballPlayer()
        {

        }

        public FootballPlayer(string name, double price, int shirtNumber)
        {
            Id = GlobalId++;
            Name = name;
            Price = price;
            ShirtNumber = shirtNumber;
        }

        public override string ToString()
        {
            return $"id: {Id}, name: {Name}, price: {Price}, shirt number: {ShirtNumber}";
        }
    }
}
