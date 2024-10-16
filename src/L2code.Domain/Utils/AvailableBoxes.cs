using L2code.Domain.Models;

namespace L2code.Utils
{
    public static class AvailableBoxes
    {
        public static List<Box> GetBoxes()
        {
            return new List<Box>
            {
                new Box("Caixa 1",30,40,80),
                new Box("Caixa 2",80,50,40),
                new Box("Caixa 3",50,80,60)
            };
        }
    }
}