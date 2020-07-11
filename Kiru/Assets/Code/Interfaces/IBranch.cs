using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public interface IBranch {

		void Init();

		Transform GetTransform();

		Transform[] GetSlots();

		IBranch[] GetChildren();

		IBranch GetParent();

		IGrothValidate GetGrothValidator();

		ICutValidate GetCutValidator();

		// may neet do work in bredfirstsearch
		bool Grow(IBranchFactory factory);

		bool Cut();
	}
}
