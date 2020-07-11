using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class SwitchMenus : ICommand {

		[SerializeField] GameObject _origin;
		[SerializeField] GameObject _target;

		public override void Execute() {
			_origin.SetActive(false);
			_target.SetActive(true);
		}
	}
}
