using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kiru {
	public class PointToTitle : MonoBehaviour {

		[SerializeField] TextMeshProUGUI _textField = null;
		//int currentTitleIndex = 0;

		void Start() {
			GameData.s_instance.OnPointsChange += Print;
			Print();
		}

		private void OnDestroy() {
			if(!GameData.Exists())
				return;

			GameData.s_instance.OnPointsChange -= Print;
		}

		void Print() {
			int currentTitleIndex = 0;
			if(GameData.s_instance.data.titles[GameData.s_instance.data.titles.Count-1].point <= GameData.s_instance.points) {
				currentTitleIndex = GameData.s_instance.data.titles.Count - 1;
			} else {
				while(currentTitleIndex - 1 < GameData.s_instance.data.titles.Count && GameData.s_instance.data.titles[currentTitleIndex + 1].point < GameData.s_instance.points) {
					currentTitleIndex++;
				}
			}

			_textField.text = GameData.s_instance.data.titles[currentTitleIndex].name;
		}
	}
}
