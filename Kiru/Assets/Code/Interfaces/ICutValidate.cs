using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public abstract class ICutValidate : MonoBehaviour {
		public abstract bool Validate(IBranch element);
	}
}
