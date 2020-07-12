using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class TutorialHandler : ICommand {
		bool _hasSeenTutorial = false;

		[SerializeField] GameObject _tutorialHolder = null;

		public override void Execute() {
			_hasSeenTutorial = true;
			_tutorialHolder.SetActive(false);
			GameData.s_instance.isInTutorial = false;
		}

		private void Start() {
			GameData.s_instance.isInTutorial = !_hasSeenTutorial;
			_tutorialHolder.SetActive(!_hasSeenTutorial);
		}
	}
}
