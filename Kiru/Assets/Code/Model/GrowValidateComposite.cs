using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class GrowValidateComposite : IGrothValidate {

		[SerializeField] IGrothValidate[] _validators = null;

		public override bool Validate(IBranch element, Transform slot) {
			bool allTrue = true;
			foreach(var it in _validators) {
				if(!it.Validate(element, slot)) {
					allTrue = false;
				}
			}

			return allTrue;
		}
	}
}
