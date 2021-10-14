using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;
using BehaviorDesigner.Runtime;

namespace TeamJester
{
    public class FindWaypoints : Action
    {
        public SharedVector2 target;

        public override void OnStart()
        {
            FindCloserWaypoints(JesterController.instance._spaceShip, JesterController.instance._data);
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
        public void FindCloserWaypoints(SpaceShipView spaceship, GameData data)
        {
            float closeWaypoints;
            SharedVector2 saveWaypoints = new SharedVector2();
            closeWaypoints = Vector2.Distance(spaceship.Position, new Vector2(1000, 1000));
            for (int i = 0; i < data.WayPoints.Count; i++)
            {
                if (Vector2.Distance(spaceship.Position, data.WayPoints[i].Position) < closeWaypoints && data.WayPoints[i].Owner != spaceship.Owner)
                {
                    closeWaypoints = Vector2.Distance(spaceship.Position, data.WayPoints[i].Position);
                    saveWaypoints = data.WayPoints[i].Position;
                }
            }
            JesterController.instance.tree.SetVariable("Target", saveWaypoints);
        }
    }
}
