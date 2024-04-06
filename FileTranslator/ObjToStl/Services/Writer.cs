using ComputationalGeometry;
using Geometry;
using Shapes3D;

namespace GeometryUtils
{
    public class Writer
    {   
        // writes triangulation data to an STL file
        public void Write(string inFilePath, Triangulation inTriangulationObject)
        {
            // using StreamWriter to write to the file
            using (StreamWriter outFile = new StreamWriter(inFilePath))
            {
                // extracting points, triangles, and normals from triangulation object
                List<Point3D> points = inTriangulationObject.UniquePoints;
                List<Triangle> triangles = inTriangulationObject.Triangles;
                List<Point3D> normals = inTriangulationObject.UniqueNormals;

                outFile.WriteLine("solid");

                // iterating each triangle's index to write its corresponding point
                foreach (Triangle triangle in triangles)
                {
                    outFile.WriteLine($"  facet normal {normals[triangle.NormalIndex].X} {normals[triangle.NormalIndex].Y} {normals[triangle.NormalIndex].Z}");
                    outFile.WriteLine("    outer loop");
                    outFile.WriteLine($"      vertex {points[triangle.Index1].X} {points[triangle.Index1].Y} {points[triangle.Index1].Z}");
                    outFile.WriteLine($"      vertex {points[triangle.Index2].X} {points[triangle.Index2].Y} {points[triangle.Index2].Z}");
                    outFile.WriteLine($"      vertex {points[triangle.Index3].X} {points[triangle.Index3].Y} {points[triangle.Index3].Z}");
                    outFile.WriteLine("    endloop");
                    outFile.WriteLine("  endfacet");
                }
                outFile.WriteLine("endsolid");
                Console.WriteLine("Data writing (from .obj to .stl) completed successful!");
            }
        }

    }
}
