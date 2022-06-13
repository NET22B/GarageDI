using GarageDI.Attributes;

namespace GarageDI.Entities
{
    class Boat : Vehicle
    {
        [Include]
        public int Length { get; set; }
    }
}
