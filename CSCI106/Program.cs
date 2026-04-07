namespace CSCI106
{
    internal class Program
    {
        static void Main()
        {
            var svgBuilder = SvgBuilder.New((500, 500));
            svgBuilder.addRectangle(7, 9, 7, 9, "red", "");
            
            var svg = svgBuilder.Build();

            Console.Write("Absolute path to save SVG at: ");
            var path = Console.ReadLine() ?? "";

            using (var fileWriter = FileWriter.FromAbsolutePath(path))
                fileWriter.WriteLine(svg);
        }
    }
}
