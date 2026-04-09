namespace CSCI106
{
    internal class Program
    {
        static void Main()
        {
            var svgBuilder = SvgBuilder.New((500, 500));

            svgBuilder.addRectangle(7, 9, 7, 9, "red", "");

            try
            {
                svgBuilder.addRectangle(-600, 0, 50, 50, "blue", "black");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            var svg = svgBuilder.Build();

            Console.Write("Absolute path to save SVG at: ");
            var path = Console.ReadLine() ?? "";

            using (var fileWriter = FileWriter.FromAbsolutePath(path))
                fileWriter.WriteLine(svg);
        }
    }
}