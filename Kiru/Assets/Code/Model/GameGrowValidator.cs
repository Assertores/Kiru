using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
	public class GameGrowValidator : IGrothValidate {

		[SerializeField] Transform _sphere;
		[SerializeField] float _radius;
		[SerializeField] GameData _game;

		public override bool Validate(IBranch element, Transform slot) {
			if(Vector3.Distance(slot.position, _sphere.position) > _radius) {
				_game.isAlive = false;
				return false;
			}
			return true;
		}
	}
}
