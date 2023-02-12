
namespace MushyOS.Packages.RasterData
{

    /// <summary>
    /// The base interface for raster data.
    /// </summary>
    /// <typeparam name="T">The data type.</typeparam>
    public interface IRaster<T>
    {

        /// <summary>
        /// Accesses a cell position at index x and y.
        /// </summary>
        /// <param name="x">The x position of the cell.</param>
        /// <param name="y">The y position of the cell.</param>
        /// <returns>The cell at index.</returns>
        public T this[int x, int y] { get; set; }

        /// <summary>
        /// Clears the raster data to the default value.
        /// </summary>
        public void Clear();

        /// <summary>
        /// Invokes a callback on all cells in area.
        /// </summary>
        /// <param name="fromX"></param>
        /// <param name="toX"></param>
        /// <param name="fromY"></param>
        /// <param name="toY"></param>
        /// <param name="callback"></param>
        public void InvokeCells(int fromX, int toX, int fromY, int toY, System.Action<int, int> callback);

    }

}
