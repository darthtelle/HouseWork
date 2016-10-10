using UnityEngine;
using System.Collections;

public class GridSystem : MonoBehaviour
{
	[SerializeField]
	private IntVector2 m_SquareSize;

	[SerializeField]
	private IntVector2 m_GridSize;

	private Grid[] m_GridList;

	private void Awake()
	{
		GenerateGrid(ref m_GridList, m_GridSize, m_SquareSize);
	}

	/// <summary>
	/// Generates a grid.
	/// </summary>
	/// <param name="grid">Grid.</param>
	/// <param name="gridSize">Grid size.</param>
	/// <param name="squareSize">Square size.</param>
	private void GenerateGrid(ref Grid[] grid, IntVector2 gridSize, IntVector2 squareSize)
	{
		grid = new Grid[gridSize.x * gridSize.y];

		Vector2 gridDimensions = new Vector3(gridSize.x * squareSize.x, gridSize.y * squareSize.y);
		Vector3 offset = new Vector3((gridDimensions.x * 0.5f) - (squareSize.x * 0.5f), 0.0f, (gridDimensions.y * 0.5f) - (squareSize.y * 0.5f));

		for(int yIndex = 0; yIndex < gridSize.y; yIndex++)
		{
			for(int xIndex = 0; xIndex < gridSize.x; xIndex++)
			{
				int index = xIndex + (yIndex * gridSize.x);
				IntVector2 ID = new IntVector2(xIndex, yIndex);
				Vector3 center = new Vector3(squareSize.x * xIndex, 0.0f, squareSize.y * yIndex) - offset;
				Vector3 size = new Vector3(squareSize.x, 0.0f, squareSize.y);

				grid[index] = new Grid(ID, center, size);
			}
		}
	}

#if UNITY_EDITOR

	private void OnDrawGizmos()
	{
		Grid[] grid = null;

		if(m_GridList == null)
		{
			GenerateGrid(ref grid, m_GridSize, m_SquareSize);
		}
		else
		{
			grid = m_GridList;
		}

		for(int squareIndex = 0; squareIndex < grid.Length; squareIndex++)
		{
			Gizmos.DrawWireCube(grid[squareIndex].m_Center, grid[squareIndex].m_Size);
		}
	}

#endif

	private struct Grid
	{
		public IntVector2 m_ID;
		public Vector3 m_Center;
		public Vector3 m_Size;

		public Grid(IntVector2 ID, Vector3 center, Vector3 size)
		{
			m_ID = ID;
			m_Center = center;
			m_Size = size;
		}
	}
}
