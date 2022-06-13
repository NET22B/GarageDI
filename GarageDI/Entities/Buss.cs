using GarageDI.Attributes;

namespace GarageDI.Entities
{
    class Buss : Vehicle
    {
        [Include]
        public int Seats { get; set; }
    }
}
