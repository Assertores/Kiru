using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class MockGrowValidator : IGrothValidate {
		public override bool Validate(IBranch element, Transform slot) {
			return true;
		}
	}
}
