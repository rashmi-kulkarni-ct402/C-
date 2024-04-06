using ComputationalGeometry;
using Geometry;
using Shapes3D;


namespace GeometryUtils
{
    public class Reader
    {
        // reads the STL file
        public void Read(string inFilePath, Triangulation inTriangulationObject)
        {
            using (StreamReader file = new StreamReader(inFilePath))
            {
                int count = 0;
                int index1 = 0;
                int index2 = 0;
                int index3 = 0;
                int normalIndex = 0;
                string line;

                // maps to store unique points and normals with their corresponding indices
                Dictionary<Point3D, int> pointIndexMap = new Dictionary<Point3D, int>();
                Dictionary<Point3D, int> normalIndexMap = new Dictionary<Point3D, int>();

                while ((line = file.ReadLine()) != null)
                {
                    // process facet normal line
                    if (line.Contains("facet normal"))
                    {
                        string[] tokens = line.Split(' ');
                        double x = Convert.ToDouble(tokens[2]);
                        double y = Convert.ToDouble(tokens[3]);
                        double z = Convert.ToDouble(tokens[4]);
                        
                        Point3D facetNormal = new Point3D(x, y, z);

                        // add unique normals to the triangulation object
                        if (!normalIndexMap.TryGetValue(facetNormal, out normalIndex))
                        {
                            normalIndex = inTriangulationObject.UniqueNormals.Count;
                            normalIndexMap.Add(facetNormal, normalIndex);
                            inTriangulationObject.AddUniqueNormalToTriangulation(facetNormal);
                        }
                    }

                    // process vertex line
                    if (line.Contains("vertex"))
                    {
                        string[] tokens = line.Split(' ');
                        double x = Convert.ToDouble(tokens[1]);
                        double y = Convert.ToDouble(tokens[2]);
                        double z = Convert.ToDouble(tokens[3]);
                        
                        Point3D point = new Point3D(x, y, z);

                        // add unique points to the triangulation object
                        if (!pointIndexMap.TryGetValue(point, out int index))
                        {
                            index = inTriangulationObject.UniquePoints.Count;
                            pointIndexMap.Add(point, index);
                            inTriangulationObject.AddUniquePointToTriangulation(point);
                        }

                        // store indices for forming a triangle
                        switch (count)
                        {
                            case 0:
                                index1 = index;
                                count++;
                                break;

                            case 1:
                                index2 = index;
                                count++;
                                break;
                            
                            case 2:
                                index3 = index;
                                count++;
                                break;

                            default:
                                break;
                        }

                        // add the triangle to the triangulation object
                        if (count == 3)
                        {
                            Triangle triangle = new Triangle(index1, index2, index3);
                            
                            triangle.NormalIndex = normalIndex;
                            inTriangulationObject.AddTriangleToTriangulation(triangle);
                            count = 0;
                        }
                    }
                }
                Console.WriteLine("Data reading from .stl file completed successfully");
            }
        }
    }
}
