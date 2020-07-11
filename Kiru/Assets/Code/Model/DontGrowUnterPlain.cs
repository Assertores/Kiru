using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class DontGrowUnterPlain : IGrothValidate {
		public override bool Validate(IBranch element, Transform slot) {
			return slot.position.y > transform.position.y;
		}
	}
}
