using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kiru {
	public class PointToTitle : MonoBehaviour {

		[SerializeField] TextMeshProUGUI[] _textField = null;
		[System.Serializable]
		struct Title {
			public string name;
			public float point;
		}
		[SerializeField] List<Title> _titles = null;
		[SerializeField] string _highestTitle = "";
		int currentTitleIndex = 0;

		void Start() {
			_titles.Sort((Title lhs, Title rhs) => { return lhs.point.CompareTo(rhs.point); });
			_titles.Add(new Title { name = _highestTitle, point = int.MaxValue });

			GameData.s_instance.OnPointsChange += Print;
		}

		private void OnDestroy() {
			if(!GameData.Exists())
				return;

			GameData.s_instance.OnPointsChange -= Print;
		}

		void Print() {
			while(_titles[currentTitleIndex].point < GameData.s_instance.points) {
				currentTitleIndex++;
			}

			foreach(var it in _textField) {
				it.text = _titles[currentTitleIndex].name;
			}
		}
	}
}
