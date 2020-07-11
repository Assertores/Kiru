using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class TriggerInRandomInterval : MonoBehaviour {

		[SerializeField] ICommand _command = null;
		[SerializeField] float _min = 10;
		[SerializeField] float _max = 100;

		bool _stop = false;

		private void Start() {
			if(_command == null)
				return;

			StartCoroutine(IERandomInterval(_min, _max));
		}

		IEnumerator IERandomInterval(float min, float max) {

			yield return new WaitForSeconds(Random.Range(min, max));
			if(_stop) {
				yield break;
			}

			_command.Execute();

			StartCoroutine(IERandomInterval(min, max));
		}
	}
}
