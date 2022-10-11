# HyRhi

Welcome to HyRhi — Hypar's open source library for conversion between Hypar and Rhino's Geometry types. This library is designed for use with Hypar functions, so it does not depend on a running instance of Rhino. Instead, it relies on Rhino3dm primarily, and RhinoCompute for a few operations not provided by Rhino3dm.

## Setup

If you want to rely on all of the RhinoCompute functionality, you will need to provide your own RhinoCompute Authentication Token, in a file in the root of this project called AuthToken.txt. You can obtain an authentication token at https://www.rhino3d.com/compute/login.

Please also note that McNeel has retired their self-hosted Compute server referenced in `RhinoCompute.cs` — you'll need to supply your own.

The library will generally work without this; mostly functions converting from Hypar to Rhino will run into trouble, like `Face.ToRgBrep()`, `Extrude.ToBrep`, `ExtrudeBrep(Brep, Vector3d)`, and `Profile.ToSurface()`. In the other direction (Rhino => Hypar) the only one with an issue is `Brep.ToMesh()`.
