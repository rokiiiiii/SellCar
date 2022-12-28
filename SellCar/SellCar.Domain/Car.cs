using System;


namespace SellCar.Domain
{
    internal class Car
    {
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }
    }
}
