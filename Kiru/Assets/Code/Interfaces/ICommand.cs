using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public abstract class ICommand : MonoBehaviour {
		public abstract void Execute();
	}
}
