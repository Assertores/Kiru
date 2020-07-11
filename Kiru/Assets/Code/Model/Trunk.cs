using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class Trunk : IBranch {


		[SerializeField] ICutValidate __cutValidator = null;
		[SerializeField] IGrothValidate __grothValidator = null;
		[SerializeField] IBranchFactory _factory = null;

		[SerializeField] Transform[] _slots = null;
		[SerializeField] AnimationCurve _growCurve = null;
		int _currentGrowCount = 0;
		float _integratedGrowValue = 0;

		float _startTime = 0;

		private void Start() {
			GameData.s_instance.OnIsAliveChange += OnStart;
		}

		private void OnDestroy() {
			if(!GameData.Exists())
				return;

			GameData.s_instance.OnIsAliveChange -= OnStart;
		}

		private void FixedUpdate() {
			if(!GameData.s_instance.isAlive)
				return;

			_integratedGrowValue += _growCurve.Evaluate(Time.timeSinceLevelLoad - _startTime) * Time.fixedDeltaTime;
			var val = Mathf.RoundToInt(_integratedGrowValue) - _currentGrowCount;
			for(int i = 0; i < val; i++) {
				Grow(_factory);
			}
			_currentGrowCount += val;
		}

		void OnStart() {
			if(!GameData.s_instance.isAlive)
				return;

			_startTime = Time.timeSinceLevelLoad;

			Remove();
		}

		public override void Remove() {
			var branches = GetChildren();
			foreach(var it in branches) {
				it.Remove();
			}
		}

		public override bool DoCut() {
			Debug.LogWarning("trunk was asked to be cut");
			return false;
		}

		public override bool Grow(IBranchFactory factory) {
			bool hasGrowen = false;
			for(int i = 0; !hasGrowen && i < 100; i++) {
				var slot = GetRandomSlot();
				var branch = GetBranchFromSlot(slot);

				if(branch != null) {
					hasGrowen = branch.Grow(factory);
					continue;
				}
				if(!GetGrothValidator().Validate(this, slot))
					continue;

				var newBranch = factory.CreateBranch(this);
				var nBTrans = newBranch.GetTransform();

				nBTrans.parent = slot;
				nBTrans.localPosition = Vector3.zero;
				nBTrans.localRotation = Quaternion.identity;

				newBranch.Init(1);

				hasGrowen = true;
			}

			return hasGrowen;
		}

		public override Transform[] GetSlots() {
			return _slots;
		}

		public override IGrothValidate GetGrothValidator() {
			return __grothValidator;
		}

		public override ICutValidate GetCutValidator() {
			return __cutValidator;
		}
	}
}
