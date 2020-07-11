using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class GameGrowValidator : IGrothValidate {

		[SerializeField] Transform _sphere = null;
		[SerializeField] float _radius = 3;
		[SerializeField] GameData _game = null;

		public override bool Validate(IBranch element, Transform slot) {
			if(Vector3.Distance(slot.position, _sphere.position) > _radius) {
				_game.isAlive = false;
				return false;
			}
			return true;
		}
	}
}
