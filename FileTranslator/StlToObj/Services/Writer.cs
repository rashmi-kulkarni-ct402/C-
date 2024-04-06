using ComputationalGeometry;

namespace GeometryUtils
{
    public class Writer
    {
        // writes triangulation data to an OBJ file
        public void Write(string inFilePath, Triangulation inTriangulationObject)
        {           
            // using StreamWriter to write to the file
            using (StreamWriter outFile = new StreamWriter(inFilePath))
            {
                // iterating each point from uniquePoints list to write points
                foreach (var point in inTriangulationObject.UniquePoints)
                {
                    outFile.WriteLine($"v {point.X} {point.Y} {point.Z}");
                }

                outFile.WriteLine();

                // iterating each normal from uniqueNormals list to write normals
                foreach (var normal in inTriangulationObject.UniqueNormals)
                {
                    outFile.WriteLine($"vn {normal.X} {normal.Y} {normal.Z}");
                }

                outFile.WriteLine();

                // iterating each triangle from triangles list to write indices
                foreach (var triangle in inTriangulationObject.Triangles)
                {
                    outFile.WriteLine($"f {triangle.Index1 + 1}//{triangle.NormalIndex + 1} " +
                                      $"{triangle.Index2 + 1}//{triangle.NormalIndex + 1} " +
                                      $"{triangle.Index3 + 1}//{triangle.NormalIndex + 1}");
                }
                Console.WriteLine("Data writing (from .stl to .obj file) completed successfully");
            }
        }
    }
}
