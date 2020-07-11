using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class Branch : IBranch {

		[SerializeField] Transform[] _slots;
		[SerializeField] Animation _animation;

		IBranch _parent = null;
		ICutValidate _cutValidator = null;
		IGrothValidate _grothValidator = null;
		bool _isActive = false;

		public override bool Cut() {
			if(!_isActive)
				return false;

			if(!GetCutValidator().Validate(this))
				return false;

			//TODO: cut stuff
			Destroy(gameObject);

			_parent = null;

			return true;
		}

		public override Transform[] GetSlots() {
			return _slots;
		}

		public override bool Grow(IBranchFactory factory) {
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

		public override void Init() {
			_isActive = false;
			_animation.Play();
			StartCoroutine(IEDelayed(_animation.clip.length, () => { _isActive = true; }));
		}
	}
}
