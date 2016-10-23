using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour 
{
	[SerializeField]
	private Texture2D m_LevelMap;

	[SerializeField]
	private ColourToPrefab[] m_PrefabList;

	private void Awake()
	{
		LoadMap();
	}

	private void EmptyMap()
	{
		while(gameObject.transform.childCount > 0)
		{
			Transform child = gameObject.transform.GetChild(0);
			child.SetParent(null);
			Destroy(child.gameObject);
		}
	}

	private void LoadMap()
	{
		EmptyMap();

		// Get the raw pixels from the level map image.
		Color32[] pixels = m_LevelMap.GetPixels32();

		int width = m_LevelMap.width;
		int height = m_LevelMap.height;

		for(int yIndex = 0; yIndex < height; yIndex++)
		{
			for(int xIndex = 0; xIndex < width; xIndex++)
			{
				int index = xIndex + (yIndex * width);
				SpawnTileAt(pixels[index], xIndex, yIndex);
			}
		}
	}

	private void SpawnTileAt(Color32 colour, int x, int y)
	{
		if(colour.a <= 0)
		{
			return;
		}

		for(int colourIndex = 0; colourIndex < m_PrefabList.Length; colourIndex++)
		{
			//if((m_PrefabList[colourIndex].m_Colour.r == colour.r) && (m_PrefabList[colourIndex].m_Colour.g == colour.g) && (m_PrefabList[colourIndex].m_Colour.b == colour.b))
			if(m_PrefabList[colourIndex].m_Colour.Equals(colour))
			{
				GameObject gameObject = (GameObject)Instantiate(m_PrefabList[colourIndex].m_Prefab, new Vector3(x, 0.0f, y), Quaternion.identity);
				gameObject.SetParent(gameObject);
				return;
			}
		}
	}
}

[System.Serializable]
public class ColourToPrefab
{
	public Color32 m_Colour;
	public GameObject m_Prefab;
}