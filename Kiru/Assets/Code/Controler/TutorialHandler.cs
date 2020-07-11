using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class TutorialHandler : ICommand {
		static bool _hasSeenTutorial = false;

		[SerializeField] GameObject _tutorialHolder = null;

		public override void Execute() {
			_hasSeenTutorial = true;
			_tutorialHolder.SetActive(false);
		}

		private void Start() {
			_tutorialHolder.SetActive(!_hasSeenTutorial);
		}
	}
}
