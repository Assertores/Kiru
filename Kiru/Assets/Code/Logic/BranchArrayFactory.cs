using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	[CreateAssetMenu(fileName = "BranchArrayFactory", menuName = "Game/IBranchFactory/BranchArrayFactory")]
	public class BranchArrayFactory : ScriptableObject, IBranchFactory {

		[SerializeField] GameObject[] _branches;

		public IBranch CreateBranch() {
			GameObject element = Instantiate(_branches[Random.Range(0, _branches.Length - 1)]);
			IBranch ret = element.GetComponent<IBranch>();
			if(ret == null) {
				Destroy(element);
			}
			return ret;
		}
	}
}
