using NUnit.Framework;
using System;

namespace CSCI106.Tests
{
    public class TheSvgBuilder
    {
        [Test]
        public void BuildsSvgsWithTheCorrectSize()
        {
            var svg = SvgBuilder.New((123, 456)).Build();

            Assert.That(svg, Does.Contain("width=\"123\""));
            Assert.That(svg, Does.Contain("height=\"456\""));
        }

        [Test]
        public void BuildsRectangles()
        {
            var svgBuilder = SvgBuilder.New((500, 500));

            svgBuilder.AddRectangle(7, 9, 1, 2, "red", "");

            var svg = svgBuilder.Build();

            Assert.That(svg, Does.Contain("rect"));
            Assert.That(svg, Does.Contain("width=\"1\""));
            Assert.That(svg, Does.Contain("height=\"2\""));
            Assert.That(svg, Does.Contain("x=\"7\""));
            Assert.That(svg, Does.Contain("y=\"9\""));
        }

        [Test]
        public void ThrowsOnInvalidRectangle()
        {
            var svgBuilder = SvgBuilder.New((500, 500));

            Assert.Throws<ArgumentException>(() =>
                svgBuilder.AddRectangle(-10, -20, 1, 1, " ", " "));
        }
    }
}