using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class ClickHandler : MonoBehaviour {
		[SerializeField] OnClickStrategy[] _strategys = null;

		void Update() {
			if(Input.GetMouseButtonDown(0)) {
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
						out RaycastHit hit)) {
					foreach(var it in _strategys) {
						if(it.HandleEvent(hit.collider.gameObject)) {
							break;
						}
					}
				}
			}
		}
	}
}
