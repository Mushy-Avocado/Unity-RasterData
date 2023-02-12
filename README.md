# Unity-RasterData
A package containing a library of classes and methods for storing data in a raster in Unity. For Unity 2021.3.15f1 or higher. May work on older versions but not guaranteed.

IRaster<T>
==========

`IRaster<T>` is an interface for raster data in the `MushyOS.Packages.RasterData` namespace. The interface provides methods for accessing and manipulating data stored in a 2D grid structure.

Indexer
-------

c#Copy code

`public T this[int x, int y] { get; set; }`

### Description

The `this` indexer allows you to access a cell at a specific position in the raster data.

### Parameters

*   `x`: The x position of the cell.
*   `y`: The y position of the cell.

### Returns

The cell at the specified index.

Clear
-----

c#Copy code

`public void Clear();`

### Description

The `Clear` method is used to clear the raster data to the default value.

InvokeCells
-----------

c#Copy code

`public void InvokeCells(int fromX, int toX, int fromY, int toY, System.Action<int, int> callback);`

### Description

The `InvokeCells` method invokes a callback on all cells in a specified area.

### Parameters

*   `fromX`: The starting x position of the area.
*   `toX`: The ending x position of the area.
*   `fromY`: The starting y position of the area.
*   `toY`: The ending y position of the area.
*   `callback`: The callback to invoke on each cell in the specified area. The callback takes two parameters: the x and y position of the cell.
