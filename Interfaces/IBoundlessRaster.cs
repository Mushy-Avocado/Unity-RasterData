using UnityEngine;

namespace MushyOS.Packages.RasterData
{
    /// <summary>
    /// An interface for an unconstrained raster with no width or height.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBoundlessRaster<T> : IRaster<T>
    {
        /// <summary>
        /// Accesses a cell at cell position.
        /// </summary>
        /// <param name="cellPosition">The cell position.</param>
        /// <returns>The cell.</returns>
        public T this[Vector2Int cellPosition] { get; set; }

        /// <summary>
        /// Accesses a cell at cell position. The z value is ignored.
        /// </summary>
        /// <param name="cellPosition">The cell position.</param>
        /// <returns>The cell.</returns>
        public T this[Vector3Int cellPosition] { get; set; }
    }

}
