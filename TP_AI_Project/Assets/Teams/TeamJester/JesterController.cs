using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;

namespace TeamJester {

	public class JesterController : BaseSpaceShipController
	{
		bool next;
		int i=0;
		Vector2 moveDirection;
		Vector2 waypointToGo;
		public override void Initialize(SpaceShipView spaceship, GameData data)
		{
		}

		public override InputData UpdateInput(SpaceShipView spaceship, GameData data)
        {
			waypointToGo = FindCloserWaypoints(spaceship, data);
			moveDirection = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) - waypointToGo;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector2.up);
            SpaceShipView otherSpaceship = data.GetSpaceShipForOwner(1 - spaceship.Owner);
			float thrust = 1.0f;
			float targetOrient = Quaternion.AngleAxis(angle, Vector2.up).z;
			bool needShoot = AimingHelpers.CanHit(spaceship, otherSpaceship.Position, otherSpaceship.Velocity, 0.15f);
			return new InputData(thrust, targetOrient, needShoot, false, false);
		}

		public Vector2 FindCloserWaypoints(SpaceShipView spaceship, GameData data)
        {
			float closeWaypoints;
			Vector2 saveWaypoints = new Vector2();
			closeWaypoints = Vector2.Distance(gameObject.transform.position, data.WayPoints[0].Position);
			foreach(WayPointView point in data.WayPoints){
                if (Vector2.Distance(gameObject.transform.position, point.Position) < closeWaypoints && point.Owner !=spaceship.Owner)
                {
					closeWaypoints = Vector2.Distance(gameObject.transform.position, point.Position);
					saveWaypoints = point.Position;
				}
            }
			Debug.Log(saveWaypoints);
			return saveWaypoints;
        }
	}

}
