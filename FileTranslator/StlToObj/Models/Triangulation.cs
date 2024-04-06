using Geometry;
using Shapes3D;

namespace ComputationalGeometry
{
    public class Triangulation
    {
        // properties for list of uniquepoints, list of triangles & list of uniquenormals
        public List<Point3D> UniquePoints { get; private set; } = new List<Point3D>();
        public List<Triangle> Triangles { get; private set; } = new List<Triangle>();
        public List<Point3D> UniqueNormals { get; private set; } = new List<Point3D>();

        // adds unique point to triangulation
        public void AddUniquePointToTriangulation(Point3D inPoint)
        {
            UniquePoints.Add(inPoint);
        }

        // adds triangle to triangulation
        public void AddTriangleToTriangulation(Triangle inTriangle)
        {
            Triangles.Add(inTriangle);
        }

        // adds unique normal to triangulation
        public void AddUniqueNormalToTriangulation(Point3D inNormal)
        {
            UniqueNormals.Add(inNormal);
        }
    }
}
