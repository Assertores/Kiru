using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {

	[CreateAssetMenu(fileName = "IBranchFactory", menuName = "Game/IBranchFactory/IBranchFactory")]
	public abstract class IBranchFactory : ScriptableObject {

		public IBranch CreateBranch(IBranch origin) {
			var element = DoCreateBranch(origin);
			if(element) {
				GameData.s_instance.branchCount++;
			}
			return element;
		}

		public abstract IBranch DoCreateBranch(IBranch origin);
	}
}
