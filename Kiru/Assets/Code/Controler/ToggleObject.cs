using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class ToggleObject : ICommand {
		[SerializeField] GameObject target = null;

		public override void Execute() {
			target.SetActive(!target.activeSelf);
		}
	}
}
