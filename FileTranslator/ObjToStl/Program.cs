using System;
using ComputationalGeometry;
using System.Xml;
using GeometryUtils;

namespace FileTranslator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // prompt user to enter the file path of OBJ file
            Console.WriteLine("Enter .obj filepath");
            string inputFilePath = Console.ReadLine();

            // constructing output file path for OBJ file & creating output directory if it doesn't exist
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Output");
            string outputFilePath = Path.Combine(outputDirectory, "cube.stl");
            Directory.CreateDirectory(outputDirectory);

            // creating instances of following classes - FileTypeChecker, Triangulation, Reader & Writer
            FileTypeChecker checker = new FileTypeChecker();
            Triangulation triangulationObject = new Triangulation();
            Reader readerObject = new Reader();
            Writer writerObject = new Writer();

            // check if the input file is an OBJ file
            if (!checker.IsObjFile(inputFilePath))
            {
                Console.WriteLine("Error! Input file is not a .obj file.");
                Console.WriteLine("---------------------------------------------------");
                return;
            }

            // reading OBJ file and populating triangulation object
            readerObject.Read(inputFilePath, triangulationObject);

            // writing triangulation data to an STL file
            writerObject.Write(outputFilePath, triangulationObject);

            Console.WriteLine("***************************************************");
        }
    }
}
