using AsserTOOLres;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class ClickHandler : MonoBehaviour {
		[SerializeField] OnClickStrategy[] _strategys = null;

		void Update() {
			if(!GameData.s_instance.isAlive)
				return;

			if(Input.GetMouseButtonDown(0)) {
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
						out RaycastHit hit)) {
					GameObject target = hit.collider.gameObject;
					var re = target.GetComponent<Redirect>();
					if(re) {
						target = re.target;
					}
					foreach(var it in _strategys) {
						if(it.HandleEvent(target)) {
							break;
						}
					}
				}
			}
		}
	}
}
