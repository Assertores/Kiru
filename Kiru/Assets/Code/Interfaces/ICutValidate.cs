using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public interface ICutValidate {
		bool Validate(IBranch element);
	}
}
