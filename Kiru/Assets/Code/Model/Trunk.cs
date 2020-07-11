using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class Trunk : MonoBehaviour, IBranch {


		[SerializeField] MonoBehaviour _cutValidatorObj;
		ICutValidate _cutValidator = null;
		[SerializeField] MonoBehaviour _grothValidatorObj;
		IGrothValidate _grothValidator = null;
		[SerializeField] ScriptableObject _factoryObj;
		IBranchFactory _factory = null;
		[SerializeField] GameData _game;

		[SerializeField] Transform[] _slots;
		[SerializeField] AnimationCurve _growCurve;
		int _currentGrowCount = 0;
		float _integratedGrowValue = 0;

		private void Start() {
			_cutValidator = _cutValidatorObj as ICutValidate;
			_grothValidator = _grothValidatorObj as IGrothValidate;
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

		public bool Cut() {
			Debug.LogWarning("trunk was asked to be cut");
			return false;
		}

		public IBranch[] GetChildren() {
			List<IBranch> ret = new List<IBranch>();

			foreach(Transform it in GetSlots()) {
				if(it.childCount <= 0)
					continue;

				IBranch element = it.GetChild(0).GetComponent<IBranch>();

				ret.Add(element);
			}

			return ret.ToArray();
		}

		public ICutValidate GetCutValidator() {
			if(_cutValidator == null) {
				Debug.LogError("cut validator is not set on trunk");
			}

			return _cutValidator;
		}

		public IGrothValidate GetGrothValidator() {
			if(_grothValidator == null) {
				Debug.LogError("groth validator is not set on trunk");
			}

			return _grothValidator;
		}

		public IBranch GetParent() {
			Debug.LogWarning("trunk was asked for parent");
			return null;
		}

		public Transform GetTransform() {
			return transform;
		}

		public bool Grow(IBranchFactory factory) {
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

		Transform GetRandomSlot() {
			var slots = GetSlots();
			return slots[Random.Range(0, slots.Length)];
		}

		IBranch GetBranchFromSlot(Transform slot) {
			if(slot.childCount <= 0)
				return null;
			return slot.GetChild(0).GetComponent<IBranch>();
		}

		public Transform[] GetSlots() {
			return _slots;
		}

		public void Init() {
		}
	}
}
