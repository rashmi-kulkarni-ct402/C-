namespace GeometryUtils
{
    public class FileTypeChecker
    {
        // checks if the input file type is an .stl file or not
        public bool IsStlFile(string inFilename)
        {
            // check if the input filename is null or empty
            if (string.IsNullOrEmpty(inFilename))
            {
                Console.WriteLine("Please enter a valid file path");
                return false;
            }

            // find the position of last dot in filename
            int dotPosition = inFilename.LastIndexOf('.');
            if (dotPosition == -1 || dotPosition == inFilename.Length - 1)
            {
                return false;
            }

            // extract the file extension and convert it to lowercase
            string extension = inFilename.Substring(dotPosition + 1);
            extension = extension.ToLower();
            return (extension == "stl");
        }
    }
}
