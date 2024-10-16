namespace L2code.Domain.Models
{
    public class Box
    {
        public Box(string name, int height, int width, int length)
        {
            Name = name;
            Height = height;
            Width = width;
            Length = length;
        }

        public string Name { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Length { get; private set; }

        public List<string> Products { get; set; } = new List<string>();

        public decimal Volume()
        {
            return Length * Width * Height;
        }
    }
}