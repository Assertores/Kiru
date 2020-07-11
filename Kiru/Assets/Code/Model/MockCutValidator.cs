using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class MockCutValidator : ICutValidate {
		public override bool Validate(IBranch element) {
			return element.GetChildren().Length <= 0;
		}
	}
}
