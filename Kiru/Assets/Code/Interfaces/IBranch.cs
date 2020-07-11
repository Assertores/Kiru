using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public abstract class IBranch : MonoBehaviour {

		private IBranch _parent = null;
		private IGrothValidate _grothValidator = null;
		private ICutValidate _cutValidator = null;
		private bool _isCut = false;
		private int _depth = 0;

		public virtual void Init(int depth) {
			_depth = depth;
		}

		public abstract Transform[] GetSlots();

		// may neet do work in bredfirstsearch
		public abstract bool Grow(IBranchFactory factory);

		public bool Cut() {
			if(_isCut)
				return false;
			if(!DoCut())
				return false;
			_isCut = true;
			_parent = null;

			GameData.s_instance.branchCount--;

			return true;
		}

		public abstract bool DoCut();

		public abstract void Remove();

		public Transform GetTransform() {
			return transform;
		}

		public int GetDepth() {
			return _depth;
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

		public IBranch GetParent() {
			if(_isCut)
				return null;
			if(_parent != null)
				return _parent;

			Transform current = transform;
			do {
				current = current.parent;
				_parent = current.GetComponent<IBranch>();
			} while(current != transform.root && _parent == null);

			return _parent;
		}

		public virtual IGrothValidate GetGrothValidator() {
			if(_grothValidator == null)
				_grothValidator = GetParent().GetGrothValidator();

			return _grothValidator;
		}

		public virtual ICutValidate GetCutValidator() {
			if(_cutValidator == null)
				_cutValidator = GetParent().GetCutValidator();

			return _cutValidator;
		}

		protected IEnumerator IEDelayed(float time, System.Action lamda) {
			yield return new WaitForSeconds(time);
			lamda();
		}

		protected IBranch GetBranchFromSlot(Transform slot) {
			if(slot.childCount <= 0)
				return null;
			return slot.GetChild(0).GetComponent<IBranch>();
		}

		protected Transform GetRandomSlot() {
			var slots = GetSlots();
			return slots[Random.Range(0, slots.Length)];
		}
	}
}
