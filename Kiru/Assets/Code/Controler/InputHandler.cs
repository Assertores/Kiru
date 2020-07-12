using AsserTOOLres;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class InputHandler : Singleton<InputHandler> {

		public Action<Vector2> OnClick = null;
		public Action<float, float> OnDrage = null;

		[SerializeField] float _dragDistanceThreashhold = 10;

		Vector2 startPos = Vector2.zero;
		float diagonal = 0;

		private void Start() {
			diagonal = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight).magnitude;
		}

		void Update() {
			PC();
			Phone();
		}

		void PC() {
			if(Input.GetMouseButtonDown(0)) {
				OnClick?.Invoke(Input.mousePosition);
			}
			OnDrage?.Invoke(Input.GetAxis("Horizontal"), Time.deltaTime);
		}

		void Phone() {
			if(Input.touchCount != 1)
				return;

			var touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began) {
				startPos = touch.position;
			}
			if(touch.phase == TouchPhase.Ended) {
				if(Vector2.Distance(startPos, touch.position) <= _dragDistanceThreashhold) {
					OnClick?.Invoke(touch.position);
				}
			}

			OnDrage?.Invoke((touch.deltaPosition.x / -diagonal) * 25, touch.deltaTime);
		}
	}
}
