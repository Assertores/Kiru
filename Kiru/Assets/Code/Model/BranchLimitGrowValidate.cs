using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class BranchLimitGrowValidate : IGrothValidate {

		public override bool Validate(IBranch element, Transform slot) {
			if(GameData.s_instance.branchCount >= GameData.s_instance.data.maxBranchCount) {
				GameData.s_instance.isAlive = false;
				return false;
			}
			return true;
		}
	}
}
