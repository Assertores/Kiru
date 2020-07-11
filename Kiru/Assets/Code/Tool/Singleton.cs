using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsserTOOLres {
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

		#region ===== ===== DATA ===== =====

		private static T s_instanceBackingField = default;

		#endregion
		#region ===== ===== API ===== =====

		public static T s_instance {
			get => SaveGetInstance();
		}

		public static bool Exists() {
			return s_instanceBackingField != default;
		}

		#endregion
		#region ===== ===== VIRTUAL ===== =====

		protected virtual void OnMyAwake() { }

		#endregion
		#region ===== ===== CORE ===== =====

		private void Awake() {
			if(s_instanceBackingField != null) {
#if UNITY_EDITOR
				Debug.Log("multible instances of type " + typeof(T));
#endif
				Destroy(this);
				return;
			}
			s_instanceBackingField = this as T;

			OnMyAwake();
		}

		static T SaveGetInstance() {
			if(s_instanceBackingField == default) {
#if UNITY_EDITOR
				Debug.Log("no object of type " + typeof(T) + " was found.");
#endif
				s_instanceBackingField = new GameObject("SINGELTON_" + typeof(T)).AddComponent<T>();
			}
			return s_instanceBackingField;
		}

		#endregion
	}
}
