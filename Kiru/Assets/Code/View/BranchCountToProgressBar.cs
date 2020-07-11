using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kiru {
	public class BranchCountToProgressBar : MonoBehaviour {

		[SerializeField] Slider _slider = null;
		[SerializeField] Image _fill = null;
		[SerializeField] int _maxCount = 50;
		[SerializeField] int _lowerEdge = 20;
		[SerializeField] int _upperEdghe = 70;
		[SerializeField] Color _lowerColor = Color.yellow;
		[SerializeField] Color _sweetSpotColor = Color.green;
		[SerializeField] Color _upperColor = Color.red;

		void Start() {
			_slider.minValue = 0;
			_slider.maxValue = _maxCount;
			GameData.s_instance.OnBranchCountChange += Print;
			Print();
		}

		private void OnDestroy() {
			if(!GameData.Exists())
				return;

			GameData.s_instance.OnBranchCountChange -= Print;
		}

		void Print() {
			_slider.value = GameData.s_instance.branchCount;
			if(_slider.value <= _lowerEdge) {
				_fill.color = _lowerColor;
			} else if(_slider.value > _upperEdghe) {
				_fill.color = _upperColor;
			} else {
				_fill.color = _sweetSpotColor;
			}
		}
	}
}
