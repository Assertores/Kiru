using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class Branch : MonoBehaviour, IBranch {

		[SerializeField] Transform[] _slots;

		IBranch _parent = null;
		ICutValidate _cutValidator = null;
		IGrothValidate _grothValidator = null;

		public bool Cut() {
			if(!GetCutValidator().Validate(this))
				return false;

			//TODO: cut stuff
			Destroy(gameObject);

			_parent = null;

			return true;
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
			if(_cutValidator == null)
				_cutValidator = GetParent().GetCutValidator();

			return _cutValidator;
		}

		public IGrothValidate GetGrothValidator() {
			if(_grothValidator == null)
				_grothValidator = GetParent().GetGrothValidator();

			return _grothValidator;
		}

		public IBranch GetParent() {
			if(_parent != null)
				return _parent;

			_parent = transform.parent.parent.GetComponent<IBranch>();

			return _parent;
		}

		public Transform[] GetSlots() {
			return _slots;
		}

		public Transform GetTransform() {
			return transform;
		}

		IBranch GetBranchFromSlot(Transform slot) {
			if(slot.childCount <= 0)
				return null;
			return slot.GetChild(0).GetComponent<IBranch>();
		}

		public bool Grow(IBranchFactory factory) {
			var slots = GetSlots();
			var slot = slots[Random.Range(0, slots.Length)];
			var branch = GetBranchFromSlot(slot);

			if(branch != null) {
				return branch.Grow(factory);
			}

			slot = GetGrothValidator().Validate(this);
			if(slot == null)
				return false;

			var newBranch = factory.CreateBranch().GetTransform();

			newBranch.parent = slot;
			newBranch.localPosition = Vector3.zero;
			newBranch.localRotation = Quaternion.identity;


			return true;
		}
	}
}
