using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsserTOOLres;

namespace Kiru {
	public class GameData : Singleton<GameData> {


		System.Action OnIsAliveChange = null;
		public bool _isAlive = true;
		public bool isAlive { get {
				return _isAlive;
			} set {
				if(_isAlive == value)
					return;
				_isAlive = value;
				OnIsAliveChange?.Invoke();
			}
		}

		System.Action OnBranchCountChange = null;

		public int _branchCount = 0;
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
	}
}
