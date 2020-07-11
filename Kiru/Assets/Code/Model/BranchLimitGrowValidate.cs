using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class BranchLimitGrowValidate : IGrothValidate {

		[SerializeField] int _maxCount = 50;

		public override bool Validate(IBranch element, Transform slot) {
			if(GameData.s_instance.branchCount >= _maxCount) {
				GameData.s_instance.isAlive = false;
				return false;
			}
			return true;
		}
	}
}
