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
		public SpaceShipView _otherSpaceShip;
		public InputData nextInputData;
		public BehaviorTree tree;
		int countWaypointsOwn;
		int countWaypointsEnmyOwn;
        bool get1Waypoint;

        public override void Initialize(SpaceShipView spaceship, GameData data)
		{
			_spaceShip = spaceship;
			tree = GetComponent<BehaviorTree>();

		}

		public override InputData UpdateInput(SpaceShipView spaceship, GameData data)
        {
			_data = data;
            _otherSpaceShip = data.GetSpaceShipForOwner(1 - spaceship.Owner);



            tree.SetVariable("DistanceToEnmy", (SharedFloat)Vector2.Distance(spaceship.Position, _otherSpaceShip.Position));
            tree.SetVariable("GameTime", (SharedInt)data.timeLeft);
			tree.SetVariable(("Energy"), (SharedFloat)spaceship.Energy);
			tree.SetVariable("ShockWaveDistance", (SharedFloat)Vector2.Distance(spaceship.Position, new Vector2((float)(_otherSpaceShip.Position.x - 2.2), (float)(_otherSpaceShip.Position.y - 2.2))));
            countWaypointsOwn = 0;
            for (int i = 0; i < data.WayPoints.Count; i++)
            {
                if (data.WayPoints[i].Owner == spaceship.Owner)
                {
                    countWaypointsOwn++;
                }
            }
            for (int i = 0; i < data.WayPoints.Count; i++)
            {
                if (data.WayPoints[i].Owner == _otherSpaceShip.Owner)
                {
                    countWaypointsEnmyOwn++;
                }
            }

            tree.SetVariableValue("EnmyWaypointsOwn", countWaypointsEnmyOwn);
            tree.SetVariableValue("WaypointsOwnEmpty", data.WayPoints.Count - (countWaypointsEnmyOwn + countWaypointsOwn));
            tree.SetVariableValue("EnmyEnergy", _otherSpaceShip.Energy);

            if (get1Waypoint)
            {
                tree.SetVariableValue("GetWaypoint", false);
                get1Waypoint = false;
            }
            if (countWaypointsOwn > (int)tree.GetVariable("WaypointsOwn").GetValue())
            {
                tree.SetVariableValue("GetWaypoint", true);
                get1Waypoint = true;
            }

            tree.SetVariableValue("WaypointsOwn", countWaypointsOwn);

            if (spaceship.Velocity.x == spaceship.SpeedMax || spaceship.Velocity.y == spaceship.SpeedMax)
            {
                tree.SetVariableValue("isSpeedMax", true);
            }
            else
            {
                tree.SetVariableValue("isSpeedMax", false);
            }
            tree.SetVariableValue("DistanceToTarget", Vector2.Distance(spaceship.Position, (Vector2)tree.GetVariable("Target").GetValue()));

            if (spaceship.Position.x < -3)
            {
                tree.SetVariableValue("PositionOnScreen", -1);
            }
            else if (spaceship.Position.x < 1 && spaceship.Position.x > -1)
            {
                tree.SetVariableValue("PositionOnScreen", 0);
            }
            else if(spaceship.Position.x > 3)
            {
                tree.SetVariableValue("PositionOnScreen", 1);
            }

            Vector2 dir = spaceship.Velocity.normalized;
            tree.SetVariableValue("Direction", dir);

            nextInputData.dropMine = (bool)tree.GetVariable("BombDrop").GetValue();
            nextInputData.fireShockwave = (bool)tree.GetVariable("ShockWave").GetValue();
            nextInputData.shoot = (bool)tree.GetVariable("Shoot").GetValue();

            //InputData inputData = nextInputData;
            //inputData.dropMine = (bool)tree.GetVariable("BombDrop").GetValue();
            //inputData.fireShockwave = false;
            //inputData.shoot = false;
            return nextInputData;
		}
	}
}
