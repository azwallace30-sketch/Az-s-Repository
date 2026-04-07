namespace CSCI106.Tests
{
    public class TheSvgBuilder
    {
        [Test]
        public void BuildsSvgsWithTheCorrectSize()
        {
            var svg = SvgBuilder.New((123, 456)).Build();

            Assert.That(svg, Contains.Substring("width=\"123\""));
            Assert.That(svg, Contains.Substring("height=\"456\""));
        }
         [Test]
        public void buildsRectangles()
        {
            var svgBuilder = SvgBuilder.New((500, 500));
            svgBuilder.addRectangle(7, 9, 1, 2, "red", "");
            
            var svg = svgBuilder.Build(); 

            Assert.That(svg, Contains.Substring("rect"));
            Assert.That(svg, Contains.Substring("width=\"1\""));
            Assert.That(svg, Contains.Substring("height=\"2\""));
            Assert.That(svg, Contains.Substring("x=\"7\""));
            Assert.That(svg, Contains.Substring("y=\"9\""));

        }
    }
}
