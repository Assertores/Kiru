using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class ReactToKey : MonoBehaviour {
		
		[SerializeField] ICommand _command = null;
		[SerializeField] KeyCode _key = KeyCode.Escape;

		private void Update() {
			if(Input.GetKeyUp(_key)) {
				_command.Execute();
			}
		}
	}
}
