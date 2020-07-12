using AsserTOOLres;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class ClickHandler : MonoBehaviour {
		[SerializeField] OnClickStrategy[] _strategys = null;

		private void Start() {
			InputHandler.s_instance.OnClick += HandleClick;
		}

		private void OnDestroy() {
			if(!InputHandler.Exists())
				return;

			InputHandler.s_instance.OnClick -= HandleClick;
		}

		void HandleClick(Vector2 screenPos) {
			if(!GameData.s_instance.isAlive)
				return;
			if(GameData.s_instance.isInTutorial)
				return;

			if(Physics.Raycast(Camera.main.ScreenPointToRay(screenPos),
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
