using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class Trunk : MonoBehaviour, IBranch {


		[SerializeField] ScriptableObject _cutValidatorObj;
		ICutValidate _cutValidator = null;
		[SerializeField] ScriptableObject _grothValidatorObj;
		IGrothValidate _grothValidator = null;
		[SerializeField] ScriptableObject _factoryObj;
		IBranchFactory _factory = null;

		[SerializeField] Transform[] _slots;
		[SerializeField] AnimationCurve _growCurve;
		int _currentGrowCount = 0;

		private void Start() {
			_cutValidator = _cutValidatorObj as ICutValidate;
			_grothValidator = _grothValidatorObj as IGrothValidate;
			_factory = _factoryObj as IBranchFactory;
		}

		private void FixedUpdate() {
			var val = Mathf.RoundToInt(_growCurve.Evaluate(Time.timeSinceLevelLoad));
			for(int i = 0; i < val-_currentGrowCount; i++) {
				Grow(_factory);
			}
			_currentGrowCount = val;
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
			var childs = GetChildren();

			Transform slot = null;
			while((slot = GetGrothValidator().Validate(this)) == null) {
				if(childs.Length > 0 && childs[Random.Range(0, childs.Length)].Grow(factory))
					return true;
			}

			var newBranch = factory.CreateBranch().GetTransform();

			newBranch.parent = slot;
			newBranch.localPosition = Vector3.zero;
			newBranch.localRotation = Quaternion.identity;


			return true;
		}

		public Transform[] GetSlots() {
			return _slots;
		}
	}
}
