using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class ClickOnBranchStrategy : OnClickStrategy {
		public override bool HandleEvent(GameObject target) {
			var element = target.GetComponent<IBranch>();
			if(element == null)
				return false;

			element.Cut();

			return true;
		}
	}
}
