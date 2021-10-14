using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;

namespace TeamJester {


	public class JesterController : BaseSpaceShipController
	{
		public static JesterController instance;
		public GameData _data;
		public SpaceShipView _spaceShip;
		public InputData nextInputData;

		public override void Initialize(SpaceShipView spaceship, GameData data)
		{
			instance = this;
			_spaceShip = spaceship;
		}

		public override InputData UpdateInput(SpaceShipView spaceship, GameData data)
        {
			_data = data;

            SpaceShipView otherSpaceship = data.GetSpaceShipForOwner(1 - spaceship.Owner);
			//float thrust = 1.0f;
			//         float targetOrient = spaceship.Orientation;
			//         bool needShoot = AimingHelpers.CanHit(spaceship, otherSpaceship.Position, otherSpaceship.Velocity, 0.15f);

			InputData input = nextInputData;
			nextInputData.dropMine = false;
			nextInputData.fireShockwave = false;
			nextInputData.shoot = false;

			return input;
		}
	}
}
