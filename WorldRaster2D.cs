using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NaughtyAttributes;

namespace MushyOS.Packages.RasterData
{

    /// <summary>
    /// The base class for rasters that use the Grid component. Indexes using Vector3Int but ignores the z value. Use WorldRaster3D for 3-dimensional indexing.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public class WorldRaster2D<T> : Raster<T>, IWorldRaster<T>
    {

        #region Constructors

        /// <summary>
        /// Creates a new world raster.
        /// </summary>
        /// <param name="width">The width, in cells.</param>
        /// <param name="height">The height, in cells.</param>
        /// <param name="grid">The grid component.</param>
        /// <param name="suppressDuplicateCells">Whether to warn if cells are on top of each other. Use WorldRaster3D if this is necessary.</param>
        public WorldRaster2D(int width, int height, Grid grid) : base(width, height)
        {
            this.grid = grid;
        }

        #endregion

        #region Fields

        [SerializeField, AllowNesting(), Tooltip("The Grid component this raster uses."), Required()]
        private Grid grid;

        #endregion

        #region Properties

        public float WorldWidth
        {
            get { return World(Vector3Int.right * Width).x; }
        }

        public float WorldHeight
        {
            get { return World(Vector3Int.up * Height).y; }
        }

        public Vector3 CornerTopLeft
        {
            get
            {
                return World(new Vector3Int(0, Height));
            }
        }

        public Vector3 CornerTopRight { 
            get {
                return World(new Vector3Int(Width, Height));
            }
        }

        public Vector3 CornerBottomRight
        {
            get
            {
                return World(new Vector3Int(Width, 0));
            }
        }

        public Vector3 Origin
        {
            get
            {
                return World(Vector3Int.zero);
            }
        }

        public Grid Grid
        {
            get { return grid; }
            protected set { grid = value; }
        }

        #endregion

        #region Indexers

        public virtual T this[Vector3Int gridPosition] { 
            get
            {
                return this[gridPosition.x, gridPosition.y];
            }
            set
            {
                this[gridPosition.x, gridPosition.y] = value;
            }
        }

        #endregion

        #region Methods

        public virtual Vector3 World (Vector3Int gridPosition)
        {
            return Grid.CellToWorld(Grid.LocalToCell(Grid.Swizzle(Grid.cellSwizzle, gridPosition)));
        }

        public virtual Vector3 WorldCenter(Vector3Int gridPosition)
        {
            return Grid.GetCellCenterWorld(Grid.LocalToCell(Grid.Swizzle(Grid.cellSwizzle, gridPosition)));
        }

        #endregion

        #region Debug

        /// <summary>
        /// Renders the border gizmos. Must be called in OnDrawGizmos or OnDrawGizmosSelected
        /// </summary>
        [DrawGizmo(GizmoType.Selected)]
        public void DrawBorderGizmos ()
        {
            Gizmos.color = Color.green;

            if (!Grid) return;

            // Draw border
            Gizmos.DrawLine(Origin, CornerTopLeft); // Left
            Gizmos.DrawLine(CornerTopLeft, CornerTopRight); // Top
            Gizmos.DrawLine(CornerTopRight, CornerBottomRight); // Right
            Gizmos.DrawLine(Origin, CornerBottomRight); // Bottom
        }

        #endregion
    
    }

}
