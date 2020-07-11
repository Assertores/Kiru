using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	[CreateAssetMenu(fileName = "MockCutValidator", menuName = "Game/ICutValidate/MockCutValidator")]
	public class MockCutValidator : ScriptableObject, ICutValidate {
		public bool Validate(IBranch element) {
			return element.GetChildren().Length <= 0;
		}
	}
}
