using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public abstract class IGrothValidate : MonoBehaviour {

		public abstract bool Validate(IBranch element, Transform slot);
	}
}
