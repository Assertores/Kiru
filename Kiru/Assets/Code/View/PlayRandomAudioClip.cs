using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class PlayRandomAudioClip : ICommand {

		[SerializeField] AudioSource _target;
		[SerializeField] AudioClip[] _clips;

		public override void Execute() {
			_target.PlayOneShot(_clips[Random.Range(0, _clips.Length)]);
		}
	}
}
