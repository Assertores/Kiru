using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public interface IGrothValidate {

		bool Validate(IBranch element, Transform slot);
	}
}
