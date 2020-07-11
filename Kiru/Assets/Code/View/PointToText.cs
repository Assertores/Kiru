using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kiru {
	public class PointToText : MonoBehaviour {

		[SerializeField] TextMeshProUGUI _textField = null;

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
			_textField.text = GameData.s_instance.points.ToString("000");
		}
	}
}
