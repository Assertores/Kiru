using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Kiru {
	[CreateAssetMenu(fileName = "BranchFactoryDepthScale", menuName = "Game/IBranchFactory/BranchFactoryDepthScale")]
	public class BranchFactoryDepthScale : IBranchFactory {

		[SerializeField] GameObject[] _branches = null;
		[SerializeField] AnimationCurve _scaleCurve = null;
		public override IBranch DoCreateBranch(IBranch origin) {
			GameObject element = Instantiate(_branches[Random.Range(0, _branches.Length - 1)]);
			IBranch ret = element.GetComponent<IBranch>();
			if(ret == null) {
				Destroy(element);
			}

			float scale = _scaleCurve.Evaluate(origin.GetDepth());
			element.transform.localScale = new Vector3(scale, scale, scale);

			return ret;
		}
	}
}
