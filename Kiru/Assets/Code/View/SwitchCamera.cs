using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class SwitchCamera : ICommand {

		[SerializeField] AnimationCurve _curve = null;
		[SerializeField] float _duration = 5;
		[SerializeField] Transform _a = null;
		[SerializeField] Transform _b = null;
		bool _isAtA = true;

		public override void Execute() {
			StopAllCoroutines();

			StartCoroutine(IEAnimCamera(_curve, _duration, (_isAtA ? _b : _a).localPosition, (_isAtA ? _b : _a).localRotation));
			_isAtA = !_isAtA;
		}

		IEnumerator IEAnimCamera(AnimationCurve animCurve, float animTime, Vector3 targetPosition, Quaternion targetRotation) {
			var startTime = Time.time;
			var startCamPos = Camera.main.transform;

			while(startTime + animTime > Time.time) {
				float currentValue = animCurve.Evaluate((Time.time - startTime) / animTime);
				Camera.main.transform.localPosition = Vector3.Lerp(startCamPos.localPosition, targetPosition, currentValue);
				Camera.main.transform.localRotation = Quaternion.Lerp(startCamPos.localRotation, targetRotation, currentValue);
				yield return null;
			}
			Camera.main.transform.localPosition = targetPosition;
			Camera.main.transform.localRotation = targetRotation;
		}
	}
}
