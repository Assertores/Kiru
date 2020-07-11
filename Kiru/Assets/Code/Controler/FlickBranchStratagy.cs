using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class FlickBranchStratagy : OnClickStrategy {

		[SerializeField] float flickForce = 10;

		public override bool HandleEvent(GameObject target) {
			var rb = target.GetComponent<Rigidbody>();
			if(rb == null)
				return false;

			Vector3 force = Random.insideUnitSphere.normalized;
			force.y = Mathf.Abs(force.y);
			rb.AddForce(force * flickForce, ForceMode.Impulse);

			return true;
		}
	}
}
