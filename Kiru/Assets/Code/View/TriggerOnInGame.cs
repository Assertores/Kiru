using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class TriggerOnInGame : MonoBehaviour {

		[SerializeField] ICommand _command = null;
		[SerializeField] bool _inGame = true;

		private void OnEnable() {
			GameData.s_instance.OnIsAliveChange += Trigger;
		}

		private void OnDisable() {
			if(!GameData.Exists())
				return;

			GameData.s_instance.OnIsAliveChange -= Trigger;
		}

		void Trigger() {
			if(GameData.s_instance.isAlive == _inGame)
				_command.Execute();
		}
	}
}
