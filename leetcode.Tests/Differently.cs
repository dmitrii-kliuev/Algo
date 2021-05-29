using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algo.Tests
{
    public class SelectMany
    {
        [Fact]
        public void A()
        {
            var report = new Report
            {
                Sections = new List<Section>
                {
                    new Section {
                        Subsections = new List<Subsection>
                        {
                            new Subsection
                            {
                                Parameters = new List<Parameter>
                                {
                                    new Parameter
                                    {
                                        Images = new List<Image>
                                        {
                                            new Image{ Img = true },
                                            new Image{ Img = true },
                                            new Image{ Img = true }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Section {
                        Subsections = new List<Subsection>
                        {
                            new Subsection
                            {
                                Parameters = new List<Parameter>
                                {
                                    new Parameter
                                    {
                                        Images = new List<Image>
                                        {
                                            new Image{ Img = false }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Section {
                        Subsections = new List<Subsection>
                        {
                            new Subsection
                            {
                                Parameters = new List<Parameter>
                                {

                                }
                            }
                        }
                    }
                }
            };

            var images = report.Sections
                .SelectMany(c => c.Subsections)
                .SelectMany(c => c.Parameters)
                .SelectMany(c => c.Images);
        }
    }

    public class Report
    {
        public List<Section> Sections { get; set; } = new List<Section>();
    }

    public class Section
    {
        public List<Subsection> Subsections { get; set; } = new List<Subsection>();
    }

    public class Subsection
    {
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();
    }

    public class Parameter
    {
        public List<Image> Images { get; set; } = new List<Image>();
    }

    public class Image
    {
        public bool Img { get; set; }
    }
}
