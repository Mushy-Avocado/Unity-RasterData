using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace MushyOS.Packages.RasterData
{

    /// <summary>
    /// The base class for raster data. Stores data in a flattened array with the specified width and height. Can be drawn in the inspector.
    /// </summary>
    [System.Serializable]
    public class Raster<T> : IRaster<T>
    {

        #region Constructor(s)

        /// <summary>
        /// Creates a new raster. 
        /// 
        /// Far corner of raster is located at [width - 1, height - 1]
        /// </summary>
        /// <param name="width">The width in cells.</param>
        /// <param name="height">The height in cells.</param>
        public Raster(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.Data = new T[this.width * this.height];
        }

        #endregion

        #region Fields

        /// <summary>
        /// The 1D array of cell data.
        /// </summary>
        protected T[] data;

        [SerializeField, Tooltip("The width of the raster in cells.")] private int width;
        [SerializeField, Tooltip("The height of the raster in cells.")] private int height;

        #endregion

        #region Properties

        /// <summary>
        /// The 1D array of cell data.
        /// </summary>
        public T[] Data
        {
            get
            {
                if (data == null || data.Length == 0 || data.Length != Width * Height) data = new T[Width * Height];
                return data;
            }
            protected set
            {
                data = value;
            }
        }

        /// <summary>
        /// The width of the raster. The data is reset when changed.
        /// </summary>
        public int Width
        {
            get { return width; }
            protected set { width = value; }
        }

        /// <summary>
        /// The height of the raster. The data is reset when changed.
        /// </summary>
        public int Height
        {
            get { return height; }
            protected set { height = value; }
        }

        #endregion

        #region Indexers

        public T this[int x, int y]
        {
            get { return Data[y * width + x]; }
            set { Data[y * width + x] = value; }
        }

        #endregion

        #region Methods

        public void InvokeCells (int fromX, int toX, int fromY, int toY, System.Action<int, int> callback)
        {
            for (int y = fromY; y <= toY; y++)
            {
                for (int x = fromX; x <= toX; x++)
                {
                    callback(x, y);
                }
            }
        }

        public void Clear ()
        {
            data = null;
        }

        /// <summary>
        /// Converts the raster to a string. Formatted to display correctly in the editor window. Might be slow for large rasters.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(string.Format("Width: {0}, height: {1}", Width, Height));
            stringBuilder.AppendLine();
            for (int y = 0; y < Height; y++)
            {
                var row = new string[Width];
                for (int x = 0; x < Width; x++)
                {
                    row[x] = this[x, y]?.ToString() ?? null;
                }
                stringBuilder.Append(("Row " + y).PadRight(15)).Append(string.Join(", ", row));
                if (y != Height - 1) stringBuilder.AppendLine();
            }
            return string.Format("[\n{0}\n]", stringBuilder.ToString());
        }

        #endregion

    }

}
