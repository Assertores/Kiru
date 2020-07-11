using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class GameData : MonoBehaviour {
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
	}
}
