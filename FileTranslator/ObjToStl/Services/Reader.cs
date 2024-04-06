using ComputationalGeometry;
using Geometry;
using Shapes3D;

namespace GeometryUtils
{
    public class Reader
    {
        // reads the OBJ file
        public void Read(string inFilePath, Triangulation inTriangulationObject)
        {           
            using (StreamReader file = new StreamReader(inFilePath))
            {
                string line;
                int normalIndex = 0;

                while ((line = file.ReadLine()) != null)
                {
                    string[] tokens = line.Split(' ');

                    // process vertex line
                    if (tokens[0] == "v")
                    {
                        double x = double.Parse(tokens[1]);
                        double y = double.Parse(tokens[2]);
                        double z = double.Parse(tokens[3]);
                        Point3D point = new Point3D(x, y, z);
                        inTriangulationObject.AddUniquePointToTriangulation(point);
                    }
                    // process vertex normal line
                    else if (tokens[0] == "vn") 
                    {
                        double x = double.Parse(tokens[1]);
                        double y = double.Parse(tokens[2]);
                        double z = double.Parse(tokens[3]);
                        Point3D normal = new Point3D(x, y, z);
                        inTriangulationObject.AddUniqueNormalToTriangulation(normal);
                    }
                    // process face line
                    else if (tokens[0] == "f")
                    {
                        int vertex1 = int.Parse(tokens[1].Split('/')[0]) - 1;
                        int vertex2 = int.Parse(tokens[2].Split('/')[0]) - 1;
                        int vertex3 = int.Parse(tokens[3].Split('/')[0]) - 1;

                        int normalVertex1 = int.Parse(tokens[1].Split('/')[2]) - 1;
                        int normalVertex2 = int.Parse(tokens[2].Split('/')[2]) - 1;
                        int normalVertex3 = int.Parse(tokens[3].Split('/')[2]) - 1;

                        Triangle triangle = new Triangle(vertex1, vertex2, vertex3);
                        triangle.NormalIndex = normalVertex1;
                        inTriangulationObject.AddTriangleToTriangulation(triangle);
                    }
                }
            }
            Console.WriteLine("Data reading from .obj file completed successfully");
        }    
    }
}
