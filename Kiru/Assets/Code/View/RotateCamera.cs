using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace Kiru {
	public class RotateCamera : MonoBehaviour {

		[SerializeField] float _speed = 50;

		void Update() {
			transform.Rotate(Vector3.up, -Input.GetAxis("Horizontal") * _speed * Time.deltaTime);
		}
	}
}
