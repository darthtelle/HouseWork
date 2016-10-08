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
		m_GridList = new Grid[m_GridSize.x * m_GridSize.y];

		for(int xIndex = 0; xIndex < m_GridSize.x; xIndex++)
		{
			int ID = xIndex;

			Vector3 position = new Vector3(m_SquareSize.x * xIndex, 0.0f, 0.0f);

			m_GridList[ID] = new Grid() { m_ID = ID, m_Position = position };
		}
	}

	private void OnDrawGizmos()
	{
		for(int yIndex = 0; yIndex < m_GridSize.y; yIndex++)
		{
			for(int xIndex = 0; xIndex < m_GridSize.x; xIndex++)
			{
				Vector3 position = new Vector3(m_SquareSize.x * xIndex, 0.0f, m_SquareSize.y * yIndex);
				Gizmos.DrawWireCube(position, new Vector3(m_SquareSize.x, 0.0f, m_SquareSize.y));
			}
		}
	}

	private struct Grid
	{
		public int m_ID;
		public Vector3 m_Position;
	}
}
