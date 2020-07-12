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

		public System.Action OnIsInTutorial = null;
		bool _isInTutorial = true;
		public bool isInTutorial {
			get {
				return _isInTutorial;
			}
			set {
				if(_isInTutorial == value)
					return;
				_isInTutorial = value;
				OnIsInTutorial?.Invoke();
			}
		}

		public System.Action OnAndimodeChange = null;
		bool _andimode = true;
		public bool andimode {
			get {
				return _andimode;
			}
			set {
				if(_andimode == value)
					return;
				_andimode = value;
				OnAndimodeChange?.Invoke();
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

		public GameDataObject data { get; private set; }

		protected override void OnMyAwake() {
			var values = Resources.Load<GameDataObject>("GameDataObject");
			data = Instantiate(values);

			MyReset();
		}

		public void MyReset() {

			branchCount = 0;
			points = 0;
		}
	}
}
