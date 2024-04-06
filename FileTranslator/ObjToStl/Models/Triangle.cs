namespace Geometry
{
    public class Triangle
    {
        // properties for triangle indices and normal index
        public int Index1 { get; }
        public int Index2 { get; }
        public int Index3 { get; }
        public int NormalIndex { get; set; }

        // parameterized constructor with default values 
        // (act as both a default constructor and a parameterized constructor)
        public Triangle(int inIndex1 = 0, int inIndex2 = 0, int inIndex3 = 0)
        {
            Index1 = inIndex1;
            Index2 = inIndex2;
            Index3 = inIndex3;
        }
    }
}
