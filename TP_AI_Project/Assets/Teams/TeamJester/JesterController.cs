using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;
using BehaviorDesigner.Runtime;

namespace TeamJester {

	public class JesterController : BaseSpaceShipController
	{
		public static JesterController instance;
		public GameData _data;
		public SpaceShipView _spaceShip;
		public InputData nextInputData;
		public BehaviorTree tree;

		public override void Initialize(SpaceShipView spaceship, GameData data)
		{
			instance = this;
			_spaceShip = spaceship;
			tree = GetComponent<BehaviorTree>();
		}

		public override InputData UpdateInput(SpaceShipView spaceship, GameData data)
        {
			_data = data;
            SpaceShipView otherSpaceship = data.GetSpaceShipForOwner(1 - spaceship.Owner);
			//bool needShoot = AimingHelpers.CanHit(spaceship, otherSpaceship.Position, otherSpaceship.Velocity, 0.15f);

			return nextInputData;
		}
	}
}
