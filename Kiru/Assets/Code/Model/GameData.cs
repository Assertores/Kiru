using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsserTOOLres;

namespace Kiru {
	public class GameData : Singleton<GameData> {

		public System.Action OnIsAliveChange = null;
		bool _isAlive = false;
		public bool isAlive { get {
				return _isAlive;
			} set {
				if(_isAlive == value)
					return;
				_isAlive = value;
				OnIsAliveChange?.Invoke();
			}
		}

		public System.Action OnBranchCountChange = null;
		int _branchCount = 0;
		public int branchCount {
			get {
				return _branchCount;
			}
			set {
				if(_branchCount == value) {
					_branchCount = value;
				} else {
					_branchCount = value;
					OnBranchCountChange?.Invoke();
				}
			}
		}

		public System.Action OnPointsChange = null;
		float _points = 0;
		public float points {
			get {
				return _points;
			}
			set {
				if(_points == value) {
					_points = value;
				} else {
					_points = value;
					OnPointsChange?.Invoke();
				}
			}
		}

		public float maxBranchCount { get; private set; }
		public title[] titles { get; private set; }

		protected override void OnMyAwake() {
			var values = Resources.Load<GameDataObject>("GameDataObject");
			var tmpTitles = new List<title>(values.titles.ToArray()); // make copy
			tmpTitles.Sort((title lhs, title rhs) => { return lhs.point.CompareTo(rhs.point); });
			tmpTitles.Insert(0, new title { name = values.lowestTitle, point = 0 });

			maxBranchCount = values.maxBranchCount;
			titles = tmpTitles.ToArray();

			MyReset();
		}

		public void MyReset() {

			branchCount = 0;
			points = 0;
		}
	}
}
