using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class Branch : MonoBehaviour, IBranch {

		[SerializeField] Transform[] _slots;
		[SerializeField] Animation _animation;

		IBranch _parent = null;
		ICutValidate _cutValidator = null;
		IGrothValidate _grothValidator = null;
		bool _isActive = false;

		public bool Cut() {
			if(!_isActive)
				return false;

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
			if(!_isActive)
				return false;

			var slots = GetSlots();
			var slot = slots[Random.Range(0, slots.Length)];
			var branch = GetBranchFromSlot(slot);

			if(branch != null) {
				return branch.Grow(factory);
			}
			if(!GetGrothValidator().Validate(this, slot))
				return false;

			var newBranch = factory.CreateBranch();
			var nBTrans = newBranch.GetTransform();

			nBTrans.parent = slot;
			nBTrans.localPosition = Vector3.zero;
			nBTrans.localRotation = Quaternion.identity;

			newBranch.Init();

			return true;
		}

		public void Init() {
			_isActive = false;
			_animation.Play();
			StartCoroutine(IEDelayed(_animation.clip.length, () => { _isActive = true; }));
		}

		IEnumerator IEDelayed(float time, System.Action lamda) {
			yield return new WaitForSeconds(time);
			lamda();
		}
	}
}
