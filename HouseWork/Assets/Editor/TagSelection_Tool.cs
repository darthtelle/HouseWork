using UnityEngine;
using UnityEditor;

namespace ChantelleTools
{
	public class TagSelection_Tool : ScriptableWizard
	{
		public string m_SearchTag = "Tag name";

		[MenuItem("AmazingChantelleTools/Tag Selection")]
		private static void TagSelectionMenu()
		{
			ScriptableWizard.DisplayWizard<TagSelection_Tool>("Tag Selection", "Search");
		}

		private void OnWizardCreate()
		{
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(m_SearchTag);
			Selection.objects = gameObjects;
		}
	}
}