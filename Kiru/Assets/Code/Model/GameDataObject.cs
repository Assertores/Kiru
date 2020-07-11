using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	[System.Serializable]
	public struct title {
		public string name;
		public float point;
	}

	[CreateAssetMenu(fileName = "GameDataObject", menuName = "Game/GameDataObject")]
	public class GameDataObject : ScriptableObject {
		public int maxBranchCount = 50;
		public List<title> titles = null;
		public string lowestTitle = "";
	}
}
