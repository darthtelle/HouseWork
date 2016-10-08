using UnityEngine;
using UnityEditor;

namespace ChantelleTools
{
	public class SpriteProcessor_Tool : AssetPostprocessor 
	{
		private void OnPostprocessTexture(Texture2D texture)
		{
			string lowerCaseAssetPath = assetPath.ToLower();
			bool isInSpritesDirectory = lowerCaseAssetPath.IndexOf("/sprites/") != -1;

			if(isInSpritesDirectory)
			{
				TextureImporter textureImporter = (TextureImporter)assetImporter;
				textureImporter.textureType = TextureImporterType.Sprite;
			}
		}
	}
}