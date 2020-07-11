using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {

	[CreateAssetMenu(fileName = "IBranchFactory", menuName = "Game/IBranchFactory/IBranchFactory")]
	public abstract class IBranchFactory : ScriptableObject {
		public abstract IBranch CreateBranch();
	}
}
