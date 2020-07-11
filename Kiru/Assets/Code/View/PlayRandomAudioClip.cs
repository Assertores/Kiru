using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class PlayRandomAudioClip : ICommand {

		[SerializeField] AudioSource _target = null;
		[Tooltip("0 = growSFX\n1 = cutSFX\n2 = backgroundSFX\n3 = music")]
		[SerializeField] int clipenum = 0;

		public override void Execute() {
			var modeIndex = GameData.s_instance.andimode ? 1 : 0;
			AudioClip[] clips = null;
			switch(clipenum) {
			case 0:
				clips = GameData.s_instance.data.growSFX[modeIndex].clips;
				break;
			case 1:
				clips = GameData.s_instance.data.cutSFX[modeIndex].clips;
				break;
			case 2:
				clips = GameData.s_instance.data.backgroundSFX[modeIndex].clips;
				break;
			case 3:
				clips = GameData.s_instance.data.music[modeIndex].clips;
				break;
			}
			if(clips == null)
				return;
			if(clips.Length <= 0)
				return;

			_target.PlayOneShot(clips[Random.Range(0, clips.Length - 1)]);
		}
	}
}
