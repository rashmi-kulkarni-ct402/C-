namespace Shapes3D
{
    public class Point3D : IComparable<Point3D>
    {
        // properties for x, y, z coordinates 
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        // parameterized constructor with default values 
        // (act as both a default constructor and a parameterized constructor)
        public Point3D(double inX = 0, double inY = 0, double inZ = 0)
        {
            X = inX;
            Y = inY;
            Z = inZ;
        }

        // compares two points based on their coordinates
        public int CompareTo(Point3D other)
        {
            if (X != other.X)
                return X.CompareTo(other.X);
            if (Y != other.Y)
                return Y.CompareTo(other.Y);
            return Z.CompareTo(other.Z);
        }
    }
}
