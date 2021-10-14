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
        public JesterController controller;

        public override void OnAwake()
        {
            base.OnAwake();
            controller = GetComponent<JesterController>();
        }

        public override void OnStart()
        {
            FindCloserWaypoints(controller._spaceShip, controller._data);
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
        public void FindCloserWaypoints(SpaceShipView spaceship, GameData data)
        {
            float closeWaypoints;
            SharedVector2 saveWaypoints = new SharedVector2();
            if (controller.nextInputData.thrust != 0 && controller.tree.GetVariable("Target")!= null)
            {
                closeWaypoints = Vector2.Distance(spaceship.Position, new Vector2(1000, 1000));
                for (int i = 0; i < data.WayPoints.Count; i++)
                {
                    if (Vector2.Distance(spaceship.Position, data.WayPoints[i].Position) < closeWaypoints && data.WayPoints[i].Owner != spaceship.Owner)
                    {
                        closeWaypoints = Vector2.Distance(spaceship.Position, data.WayPoints[i].Position);
                        saveWaypoints = data.WayPoints[i].Position;
                    }
                }
                controller.tree.SetVariable("Target", saveWaypoints);
                controller.tree.SetVariable("NextTarget", saveWaypoints);
            }
            else if (controller.nextInputData.thrust == 0 && controller.tree.GetVariable("Target") != null)
            {
                closeWaypoints = Vector2.Distance((Vector2)controller.tree.GetVariable("Target").GetValue(), new Vector2(1000, 1000));
                for (int i = 0; i < data.WayPoints.Count; i++)
                {
                    if (Vector2.Distance((Vector2)controller.tree.GetVariable("Target").GetValue(), data.WayPoints[i].Position) < closeWaypoints && data.WayPoints[i].Owner != spaceship.Owner && data.WayPoints[i].Position != (Vector2)controller.tree.GetVariable("Target").GetValue())
                    {
                        closeWaypoints = Vector2.Distance((Vector2)controller.tree.GetVariable("Target").GetValue(), data.WayPoints[i].Position);
                        saveWaypoints = data.WayPoints[i].Position;
                    }
                }
                controller.tree.SetVariable("NextTarget", saveWaypoints);
            }
        }
    }
}
