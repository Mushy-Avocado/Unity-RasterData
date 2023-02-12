# Unity-RasterData
A package containing a library of classes and methods for storing data in a raster in Unity. 

**Version**: Unity 2021.3.15f1 or higher. May work on older versions but not guaranteed.
**License**: MIT






# IRaster\<T\> interface

The `IRaster<T>` is an interface for raster data. The interface provides methods for accessing and manipulating data stored in a 2D grid structure.

Indexer
-------

`public T this[int x, int y] { get; set; }`

#### Description

The `this` indexer allows you to access a cell at a specific position in the raster data.

#### Parameters

*   `x`: The x position of the cell.
*   `y`: The y position of the cell.

#### Returns

The cell at the specified index.

Clear
-----

`public void Clear();`

#### Description

The `Clear` method is used to clear the raster data to the default value.

InvokeCells
-----------

`public void InvokeCells(int fromX, int toX, int fromY, int toY, System.Action<int, int> callback);`

#### Description

The `InvokeCells` method invokes a callback on all cells in a specified area.

#### Parameters

*   `fromX`: The starting x position of the area.
*   `toX`: The ending x position of the area.
*   `fromY`: The starting y position of the area.
*   `toY`: The ending y position of the area.
*   `callback`: The callback to invoke on each cell in the specified area. The callback takes two parameters: the x and y position of the cell.
  
  
  
  
  
  
# Raster\<T\> Class

The `Raster<T>` class is a base class for raster data. It stores data in a flattened array with the specified width and height and can be drawn in the inspector.

Constructor
-----------

### Raster(int width, int height)

Creates a new raster. Far corner of raster is located at \[width - 1, height - 1\].

#### Arguments

*   `width`: The width in cells.
*   `height`: The height in cells.

Properties
----------

### Data

*   Type: `T[]`

The 1D array of cell data.

### Width

*   Type: `int`

The width of the raster. The data is reset when changed.

### Height

*   Type: `int`

The height of the raster. The data is reset when changed.

Indexers
--------

### this\[int x, int y\]

*   Type: `T`

Gets or sets the data value of the cell at the specified position.

Methods
-------

### InvokeCells(int fromX, int toX, int fromY, int toY, System.Action<int, int> callback)

Invokes the specified action on all cells in the specified region.

#### Arguments

*   `fromX`: The x-coordinate of the starting position.
*   `toX`: The x-coordinate of the ending position.
*   `fromY`: The y-coordinate of the starting position.
*   `toY`: The y-coordinate of the ending position.
*   `callback`: The action to be invoked on each cell.

### Clear()

Clears the data array.

### ToString()

*   Return Type: `string`

Converts the raster to a string. Formatted to display correctly in the editor window. This method might be slow for large rasters.











IWorldRaster\<T\> Interface
=========================

The `IWorldRaster<T>` interface defines the basic functionality of a raster that uses the Unity `Grid` component. It extends the `IRaster<T>` interface, which defines basic functionality for rasters.

Properties
----------

### WorldWidth

The width of the raster in world space.

### WorldHeight

The height of the raster in world space.

### Grid

The Unity `Grid` component that this raster uses.

### this\[Vector3Int index\]

Gets or sets the cell at the specified grid position.

#### Parameters

*   `index`: The grid position.

### CornerTopLeft

Returns the top left corner of the raster in world space.

### CornerTopRight

Returns the top right corner of the raster in world space.

### CornerBottomRight

Returns the bottom right corner of the raster in world space.

### Origin

Returns the origin of the raster in world space.

Methods
-------

### World(Vector3Int gridPosition)

Converts a grid position to world space.

#### Parameters

*   `gridPosition`: The grid position to convert.

#### Returns

The corresponding world position.

### WorldCenter(Vector3Int gridPosition)

Converts a grid position to world space and returns the center of the cell.

#### Parameters

*   `gridPosition`: The grid position to convert.

#### Returns

The centered world position.










WorldRaster2D<\T\> Class
=================

The `WorldRaster2D` class is the base class for rasters that use the Grid component. It indexes using Vector3Int but ignores the z value.

Fields
-----

### grid

Type: `Grid`

The Grid component this raster uses.

Properties
----------

### WorldWidth

Type: `float`

Gets the world width of the raster, in cells.

### WorldHeight

Type: `float`

Gets the world height of the raster, in cells.

### CornerTopLeft

Type: `Vector3`

Gets the top-left corner of the raster in world space.

### CornerTopRight

Type: `Vector3`

Gets the top-right corner of the raster in world space.

### CornerBottomRight

Type: `Vector3`

Gets the bottom-right corner of the raster in world space.

### Origin

Type: `Vector3`

Gets the origin of the raster in world space.

### Grid

Type: `Grid`

Gets or sets the Grid component this raster uses.

Indexers
--------

### this\[Vector3Int gridPosition\]

Type: `T`

Gets or sets the value at the specified grid position.

Methods
-------

### World(Vector3Int gridPosition)

Converts a grid position to a world position.

#### Parameters

`gridPosition`: The grid position to convert.

#### Returns

A `Vector3` representing the world position.

### WorldCenter(Vector3Int gridPosition)

Gets the world center of a grid cell.

#### Parameters

`gridPosition`: The grid position of the cell.

#### Returns

A `Vector3` representing the world center of the cell.

### DrawBorderGizmos()

Renders the border gizmos for the raster. This method must be called in `OnDrawGizmos` or `OnDrawGizmosSelected`.
