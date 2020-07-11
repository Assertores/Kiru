using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class MockGrowValidator : MonoBehaviour, IGrothValidate {
		public bool Validate(IBranch element, Transform slot) {
			return true;
		}
	}
}
