using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MushyOS.Packages.RasterData
{

    /// <summary>
    /// An unconstrained raster with no width or height of O(N) notation. Should not be used for large amounts of data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BoundlessRaster<T> : IBoundlessRaster<T>
    {
        private Dictionary<Vector2Int, T> data = new();

        public Dictionary<Vector2Int, T> Data
        {
            get
            {
                return data;
            }
            protected set
            {
                data = value;
            }
        }

        public T this[Vector2Int cellPosition]
        {
            get
            {
                return Data[cellPosition];
            }
            set
            {
                Data[cellPosition] = value;
            }
        }

        public T this[Vector3Int cellPosition]
        {
            get
            {
                return Data[(Vector2Int)cellPosition];
            }
            set
            {
                Data[(Vector2Int)cellPosition] = value;
            }
        }

        public T this[int x, int y]
        {
            get
            {
                return Data[new Vector2Int(x, y)];
            }
            set
            {
                Data[new Vector2Int(x, y)] = value;
            }
        }

        public void Clear()
        {
            Data = new();
        }

        public void InvokeCells(int fromX, int toX, int fromY, int toY, Action<int, int> callback)
        {
            for (int y = fromY; y <= toY; y++)
            {
                for (int x = fromX; x <= toX; x++)
                {
                    callback(x, y);
                }
            }
        }

    }

}
