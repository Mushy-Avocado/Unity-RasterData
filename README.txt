Version: 2021.3.15f1 or higher. May work on older versions but not guaranteed.
License: MIT (https://opensource.org/licenses/MIT)
Version: 1.0

This package contains a library of classes that	store raster data in different formats.

Features:
	- A base class for storing basic raster data
	- A class for storing raster data that can be converted to a world position
	- World raster supports different cell layouts and swizzles on grid component
	- ToString() method for raster that allows for quick debugging
	- A class for a raster with no bounds
	- Interfaces for each class to allow for your own implementation

Table of contents:
	interface IRaster
	interface IWorldRaster : IRaster
	interface IBoundlessRaster
	class Raster : IRaster
	class WorldRaster : Raster, IWorldRaster
	class BoundlessRaster : IRaster


---- interface IRaster ----
Base interface for indexing and editing raster data.


Accesses a cell position at index x and y.
public this[int x, int y] { get; set; }

Clears all raster data.
public void Clear();

Invokes a callback on all cells from and to.
public void InvokeCells(int fromX, int toX, int fromY, int toY, System.Action<int, int> callback);


---- interface IWorldRaster : IRaster ----
Base interface for indexing and editing raster data, and for using world coordinates.


The width of the raster in world space.
public float WorldWidth { get; }

The height of the raster in world space.
public float WorldHeight { get; }
