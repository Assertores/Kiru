using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class SyncActivation : MonoBehaviour {
		[SerializeField] GameObject _target;

		private void Awake() {
			_target.SetActive(gameObject.activeSelf);
		}

		private void OnEnable() {
			_target.SetActive(true);
		}
		private void OnDisable() {
			_target.SetActive(false);
		}
	}
}