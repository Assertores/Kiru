using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class SwitchMenus : ICommand {

		[SerializeField] GameObject _origin = null;
		[SerializeField] GameObject _target = null;

		public override void Execute() {
			_origin.SetActive(false);
			_target.SetActive(true);
		}
	}
}
