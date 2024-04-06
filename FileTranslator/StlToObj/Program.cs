using ComputationalGeometry;
using GeometryUtils;

namespace FileTranslator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // prompt user to enter the file path of STL file
            Console.WriteLine("Enter .stl filepath");
            string inputFilePath = Console.ReadLine();

            // constructing output file path for STL file & creating output directory if it doesn't exist
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Output");
            string outputFilePath = Path.Combine(outputDirectory, "cube.obj");
            Directory.CreateDirectory(outputDirectory);

            // creating instances of following classes - FileTypeChecker, Triangulation, Reader & Writer
            FileTypeChecker checker = new FileTypeChecker();
            Triangulation triangulationObject = new Triangulation();
            Reader readerObject = new Reader();
            Writer writerObject = new Writer();

            // check if the input file is an STL file
            if (!checker.IsStlFile(inputFilePath))
            {
                Console.WriteLine("Error! Input file is not a .stl file.");
                Console.WriteLine("---------------------------------------------------");
                return;
            }

            // reading STL file and populating triangulation object
            readerObject.Read(inputFilePath, triangulationObject);

            // writing triangulation data to an OBJ file
            writerObject.Write(outputFilePath, triangulationObject);

            Console.WriteLine("***************************************************");
        }
    }
}
