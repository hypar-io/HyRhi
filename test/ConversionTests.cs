using System;
using Xunit;
using HyRhi;
using Elements;
using Rhino.FileIO;
using rg = Rhino.Geometry;
using Elements.Geometry;
using Elements.Geometry.Solids;

namespace HyRhi.Test
{
    public class ConversionTests
    {
        [Fact]
        public void ConvertsExtrusion()
        {
            var file = File3dm.Read("../../../TestFiles/Extrusion.3dm");
            foreach (var obj in file.Objects)
            {
                if (obj.Geometry is rg.Extrusion extrusion)
                {
                    var extrude = extrusion.ToExtrude(out var transform);
                    var mass = new Mass(extrude.Profile, extrude.Height, BuiltInMaterials.Mass, transform, new Representation(new[] { extrude }));
                }
            }
        }

        // This one uses RhinoCompute, so if you don't have an authtoken, it will fail.
        [Fact]
        public void ConvertsToRhino()
        {
            var profile = new Profile(Polygon.Rectangle(5, 5));
            var extrude = new Extrude(profile, 10, Vector3.ZAxis, false);
            var rhinoBrep = extrude.ToRgBrep();
        }
    }
}
