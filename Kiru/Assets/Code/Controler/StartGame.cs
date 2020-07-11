using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class StartGame : ICommand {

		[SerializeField] SwitchMenus _menuSwitcher = null;

		public override void Execute() {
			GameData.s_instance.MyReset();
			GameData.s_instance.isAlive = true;
			_menuSwitcher.Execute();
		}
	}
}
