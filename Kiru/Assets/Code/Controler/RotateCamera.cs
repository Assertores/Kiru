using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace Kiru {
	public class RotateCamera : MonoBehaviour {

		[SerializeField] float _speed = 50;
		[SerializeField] float _autospeed = 25;

		void Update() {
			if(GameData.s_instance.isAlive) {
				transform.Rotate(Vector3.up, -Input.GetAxis("Horizontal") * _speed * Time.deltaTime);
			} else {
				transform.Rotate(Vector3.up, -_autospeed * Time.deltaTime);
			}
		}
	}
}
