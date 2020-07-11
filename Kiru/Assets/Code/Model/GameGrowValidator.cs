using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class GameGrowValidator : IGrothValidate {

		[SerializeField] Transform _sphere = null;
		[SerializeField] float _radius = 3;

		public override bool Validate(IBranch element, Transform slot) {
			if(Vector3.Distance(slot.position, _sphere.position) > _radius) {
				GameData.s_instance.isAlive = false;
				return false;
			}
			return true;
		}
	}
}
