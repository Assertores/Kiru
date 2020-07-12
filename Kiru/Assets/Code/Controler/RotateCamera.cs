using UnityEngine;

namespace Kiru {
	public class RotateCamera : MonoBehaviour {

		[SerializeField] float _speed = 50;
		[SerializeField] float _autospeed = 25;

		private void Start() {
			InputHandler.s_instance.OnDrage += HandleDrag;
		}

		private void OnDestroy() {
			if(!InputHandler.Exists())
				return;

			InputHandler.s_instance.OnDrage -= HandleDrag;
		}

		void Update() {
			if(!GameData.s_instance.isAlive) {
				transform.Rotate(Vector3.up, -_autospeed * Time.deltaTime);
			}
		}

		void HandleDrag(float amount, float deltaTime) {
			if(!GameData.s_instance.isAlive)
				return;
			if(GameData.s_instance.isInTutorial)
				return;

			transform.Rotate(Vector3.up, -amount * deltaTime * _speed);
		}
	}
}
