using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class ToggleAndimode : ICommand {
		public override void Execute() {
			GameData.s_instance.andimode = !GameData.s_instance.andimode;
		}
	}
}
