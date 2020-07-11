using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class QuitGame : ICommand {
		public override void Execute() {
			Application.Quit();
#if UNITY_EDITOR
			Debug.Break();
#endif
		}
	}
}
