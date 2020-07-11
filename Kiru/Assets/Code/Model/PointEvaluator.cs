using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class PointEvaluator : MonoBehaviour {

		[SerializeField] AnimationCurve _branchkountToPoints = null;
		[SerializeField] int _maxBranchCount = 50;

		void FixedUpdate() {
			GameData.s_instance.points += _branchkountToPoints.Evaluate((float)GameData.s_instance.branchCount/_maxBranchCount) * Time.fixedDeltaTime;
		}
	}
}
