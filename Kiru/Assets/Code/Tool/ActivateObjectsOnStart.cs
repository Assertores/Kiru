using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsserTOOLres {
	public class ActivateObjectsOnStart : MonoBehaviour {
		[SerializeField] GameObject[] activeObjects = null;
		[SerializeField] GameObject[] disabledObjects = null;
		void Start() {
			foreach(var it in activeObjects) {
				it.SetActive(true);
			}
			foreach(var it in disabledObjects) {
				it.SetActive(false);
			}

			Destroy(this);
		}
	}
}
