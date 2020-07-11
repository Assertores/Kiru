using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class PointEvaluator : MonoBehaviour {

		[SerializeField] AnimationCurve _branchkountToPoints = null;

		void FixedUpdate() {
			if(!GameData.s_instance.isAlive)
				return;

			GameData.s_instance.points += _branchkountToPoints.Evaluate((float)GameData.s_instance.branchCount/GameData.s_instance.data.maxBranchCount) * Time.fixedDeltaTime;
		}
	}
}
