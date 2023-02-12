using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MushyOS.Packages.RasterData
{

    /// <summary>
    /// The base interface for rasters that use the Grid component.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWorldRaster<T> : IRaster<T>
    {

        /// <summary>
        /// The width of the raster in world space.
        /// </summary>
        public float WorldWidth { get; }

        /// <summary>
        /// The height of the raster in world space.
        /// </summary>
        public float WorldHeight { get; }

        /// <summary>
        /// The Unity grid this raster uses.
        /// </summary>
        public Grid Grid { get; }

        /// <summary>
        /// Get/set a cell from grid postion.
        /// </summary>
        /// <param name="index">The grid position.</param>
        /// <returns>The cell.</returns>
        public T this[Vector3Int index] { get; set; }

        /// <summary>
        /// Converts a grid position to world space.
        /// </summary>
        /// <param name="gridPosition">The grid position.</param>
        /// <returns>The world position.</returns>
        public Vector3 World(Vector3Int gridPosition);

        /// <summary>
        /// Converts a grid position to world space.
        /// </summary>
        /// <param name="gridPosition">The grid position.</param>
        /// <returns>The centered world position.</returns>
        public Vector3 WorldCenter(Vector3Int gridPosition);

        /// <summary>
        /// Returns the top left corner in world space.
        /// </summary>
        public Vector3 CornerTopLeft { get; }

        /// <summary>
        /// Returns the top right corner in world space.
        /// </summary>
        public Vector3 CornerTopRight { get; }

        /// <summary>
        /// Returns the bottom right corner in world space.
        /// </summary>
        public Vector3 CornerBottomRight { get; }

        /// <summary>
        /// Returns the origin in world space in world space.
        /// </summary>
        public Vector3 Origin { get; }

    }

}
