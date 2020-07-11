﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class Branch : IBranch {

		[SerializeField] Transform[] _slots = null;
		[SerializeField] Animation _growAnimation = null;
		[SerializeField] Animation _cutAnimatin = null;
		[SerializeField] float _cutLiveTime = 10;
		bool _isActive = false;

		public override bool DoCut() {
			if(!GetCutValidator().Validate(this))
				return false;

			transform.parent = transform.root;
			//TODO: cut stuff
			var rb = gameObject.AddComponent<Rigidbody>();

			if(_cutAnimatin) {
				_cutAnimatin.Play();
			}

			StartCoroutine(IEDelayed(_cutLiveTime, () => { Destroy(gameObject); }));
			_isActive = false;
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
			if(_growAnimation == null) {
				_isActive = true;
				return;
			}
			_isActive = false;
			_growAnimation.Play();
			StartCoroutine(IEDelayed(_growAnimation.clip.length, () => { _isActive = true; }));
		}
	}
}
