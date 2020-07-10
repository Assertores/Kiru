using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public interface IBranch {
		Transform GetTransform();

		IBranch[] GetChildren();

		IBranch GetParent();

		IBranchValidate GetGrothValidator();

		IBranchValidate GetCutValidator();

		void Grow(IBranchFactory factory);

		bool Cut();
	}
}
