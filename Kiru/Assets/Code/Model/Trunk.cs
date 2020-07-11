using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class Trunk : IBranch {


		[SerializeField] ICutValidate __cutValidator = null;
		[SerializeField] IGrothValidate __grothValidator = null;
		[SerializeField] ScriptableObject _factoryObj = null;
		IBranchFactory _factory = null;
		[SerializeField] GameData _game = null;

		[SerializeField] Transform[] _slots = null;
		[SerializeField] AnimationCurve _growCurve = null;
		int _currentGrowCount = 0;
		float _integratedGrowValue = 0;

		private void Start() {
			_factory = _factoryObj as IBranchFactory;
		}

		private void FixedUpdate() {
			if(!_game.isAlive)
				return;

			_integratedGrowValue += _growCurve.Evaluate(Time.timeSinceLevelLoad) * Time.fixedDeltaTime;
			var val = Mathf.RoundToInt(_integratedGrowValue) - _currentGrowCount;
			for(int i = 0; i < val; i++) {
				Grow(_factory);
			}
			_currentGrowCount += val;
		}

		public override bool Cut() {
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

				var newBranch = factory.CreateBranch();
				var nBTrans = newBranch.GetTransform();

				nBTrans.parent = slot;
				nBTrans.localPosition = Vector3.zero;
				nBTrans.localRotation = Quaternion.identity;

				newBranch.Init();

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
