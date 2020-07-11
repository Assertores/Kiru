using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Kiru {
	public class VolumeControler : MonoBehaviour {
		[SerializeField] AudioMixer _mixer = null;

		[SerializeField] Slider _master = null;
		[SerializeField] Slider _music = null;
		[SerializeField] Slider _sfx = null;

		private void Awake() {
			/* not shure why it dosn't work
			float tmp;

			if(_master) {
				_mixer.GetFloat("Master", out tmp);
				_master.value = Mathf.InverseLerp(-30, 20, tmp);
			}
			if(_music) {
				_mixer.GetFloat("Music", out tmp);
				_music.value = Mathf.InverseLerp(-30, 20, tmp);
			}
			if(_sfx) {
				_mixer.GetFloat("SFX", out tmp);
				_sfx.value = Mathf.InverseLerp(-30, 20, tmp);
			}*/
		}

		public void ChangeMasterVolume(float value) {
			_mixer.SetFloat("Master", Mathf.Lerp(-30, 20, value));
		}

		public void ChangeMusicVolume(float value) {
			_mixer.SetFloat("Music", Mathf.Lerp(-30, 20, value));
		}

		public void ChangeEffectsVolume(float value) {
			_mixer.SetFloat("SFX", Mathf.Lerp(-30, 20, value));
		}
	}
}
