using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace TeamJester
{
    public class GoTo : Action
    {
        public SharedFloat distanceStop;

        public override void OnStart()
        {
            GoToTarget(JesterController.instance._spaceShip, JesterController.instance._data);
        }

        public override TaskStatus OnUpdate()
        {
            if (distanceStop.Value < Vector2.Distance(JesterController.instance._spaceShip.Position, new Vector2(0, 0)))
                return TaskStatus.Success;
            else
            {
                return TaskStatus.Running;
            }
        }
        public void GoToTarget(SpaceShipView spaceship, GameData data)
        {
            float deltaAngle = Vector2.SignedAngle(spaceship.Velocity, (Vector2)JesterController.instance.tree.GetVariable("Target").GetValue() - spaceship.Position);
            deltaAngle *= 1.2f;
            deltaAngle = Mathf.Clamp(deltaAngle, -170, 170);
            float velocityOrientation = Vector2.SignedAngle(Vector2.right, spaceship.Velocity);
            float finalOrientation = velocityOrientation + deltaAngle;

            JesterController.instance.nextInputData.targetOrientation = finalOrientation;
            JesterController.instance.nextInputData.thrust = 1.0f;
        }
    }
}
