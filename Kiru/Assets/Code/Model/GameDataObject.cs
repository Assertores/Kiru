using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	[System.Serializable]
	public struct title {
		public string name;
		public float point;
	}

	[System.Serializable]
	public struct clipSet {
		public string name;
		public AudioClip[] clips;
	}

	[CreateAssetMenu(fileName = "GameDataObject", menuName = "Game/GameDataObject")]
	public class GameDataObject : ScriptableObject {
		public int maxBranchCount = 50;
		public List<title> titles = null;
		public string lowestTitle = "";
		public clipSet[] growSFX = null;
		public clipSet[] cutSFX = null;
		public clipSet[] backgroundSFX = null;
		public clipSet[] music = null;
	}
}
