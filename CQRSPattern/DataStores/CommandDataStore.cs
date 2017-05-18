using System.Collections.Generic;

namespace CQRSPattern
{
    public static class CommandDataStore
    {
        static CommandDataStore()
        {
            CarDetails = new List<CarDetails>();
        }
        public static List<CarDetails> CarDetails { get; set; }
    }
}
