using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Kiru {
	public class VolumeControler : MonoBehaviour {
		[SerializeField] AudioMixer p_mixer;

        public void ChangeMasterVolume(float value) {
            p_mixer.SetFloat("Master", Mathf.Lerp(-30, 20, value));
        }

        public void ChangeMusicVolume(float value) {
            p_mixer.SetFloat("Music", Mathf.Lerp(-30, 20, value));
        }

        public void ChangeEffectsVolume(float value) {
            p_mixer.SetFloat("SFX", Mathf.Lerp(-30, 20, value));
        }
    }
}
