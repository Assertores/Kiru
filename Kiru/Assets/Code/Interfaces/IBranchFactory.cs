using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public interface IBranchFactory {
		IBranch CreateBranch();
	}
}
