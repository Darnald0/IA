using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;

namespace TeamJester
{
    public class FindWaypoints : Action
    {
        public override void OnStart()
        {
            FindCloserWaypoints(JesterController.instance._spaceShip, JesterController.instance._data);
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }

        Vector2 moveDirection;
        Vector2 waypointToGo;
        public void FindCloserWaypoints(SpaceShipView spaceship, GameData data)
        {
            float closeWaypoints;
            Vector2 saveWaypoints = new Vector2();
            closeWaypoints = Vector2.Distance(gameObject.transform.position, data.WayPoints[0].Position);
            for (int i = 0; i < data.WayPoints.Count; i++)
            {
                if (Vector2.Distance(spaceship.Position, data.WayPoints[i].Position) < closeWaypoints && data.WayPoints[i].Owner != spaceship.Owner)
                {
                    closeWaypoints = Vector2.Distance(spaceship.Position, data.WayPoints[i].Position);
                    saveWaypoints = data.WayPoints[i].Position;
                }
            }

            waypointToGo = saveWaypoints;
            moveDirection =  waypointToGo - spaceship.Position;
            float thrust = 1.0f;

            if (Vector2.Distance(spaceship.Position, saveWaypoints)<= 0.5f)
            {
                thrust = 0.2f;
            }

            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            float targetOrient = angle - 180;
            //return saveWaypoints;
            //return new InputData(thrust, targetOrient, false, false, false);

            Vector2 dir = new Vector2(Mathf.Cos(spaceship.Orientation * Mathf.Deg2Rad), Mathf.Sin(spaceship.Orientation * Mathf.Deg2Rad));
            Vector2 targetDir = moveDirection;
            float deltaAngle = Vector2.SignedAngle(dir, targetDir);
            deltaAngle *= 2;
            JesterController.instance.nextInputData.targetOrientation = spaceship.Orientation + deltaAngle;
            JesterController.instance.nextInputData.thrust = 1.0f;
        }
    }
}
