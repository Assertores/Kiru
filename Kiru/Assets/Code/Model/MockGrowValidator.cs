using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	[CreateAssetMenu(fileName = "MockGrowValidator", menuName = "Game/IGrothValidate/MockGrowValidator")]
	public class MockGrowValidator : ScriptableObject, IGrothValidate {
		public Transform Validate(IBranch element) {
			var slots = element.GetSlots();
			var slot = slots[Random.Range(0, slots.Length)];

			if(slot.childCount > 0 || Random.value > 0.3f)
				return null;
			return slot;
		}
	}
}
