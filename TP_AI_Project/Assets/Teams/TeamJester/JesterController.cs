using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;
using BehaviorDesigner.Runtime;

namespace TeamJester {


	public class JesterController : BaseSpaceShipController
	{
		public GameData _data;
		public SpaceShipView _spaceShip;
		public InputData nextInputData;
		public BehaviorTree tree;
		int countWaypointsOwn;
		public override void Initialize(SpaceShipView spaceship, GameData data)
		{
			_spaceShip = spaceship;
			tree = GetComponent<BehaviorTree>();
		}

		public override InputData UpdateInput(SpaceShipView spaceship, GameData data)
        {
			_data = data;
            SpaceShipView otherSpaceship = data.GetSpaceShipForOwner(1 - spaceship.Owner);
			//         float targetOrient = spaceship.Orientation;
			//         bool needShoot = AimingHelpers.CanHit(spaceship, otherSpaceship.Position, otherSpaceship.Velocity, 0.15f);

			InputData input = nextInputData;
			nextInputData.dropMine = false;
			nextInputData.fireShockwave = false;
			nextInputData.shoot = false;

            tree.SetVariable("DistanceToEnmy", (SharedFloat)Vector2.Distance(spaceship.Position, otherSpaceship.Position));
            tree.SetVariable("GameTime", (SharedInt)data.timeLeft);
            countWaypointsOwn = 0;
            for (int i = 0; i < data.WayPoints.Count; i++)
            {
                if (data.WayPoints[i].Owner == spaceship.Owner)
                {
                    countWaypointsOwn++;
                }
            }
            tree.SetVariableValue("WaypointsOwn", countWaypointsOwn);
            //bool needShoot = AimingHelpers.CanHit(spaceship, otherSpaceship.Position, otherSpaceship.Velocity, 0.15f);

            return nextInputData;
		}
	}
}
