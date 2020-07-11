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

		public void MyReset() {
			branchCount = 0;
			points = 0;
		}
	}
}
