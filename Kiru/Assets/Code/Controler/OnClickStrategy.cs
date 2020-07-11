using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public abstract class OnClickStrategy : MonoBehaviour {
		public abstract bool HandleEvent(GameObject target);
	}
}
