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
        public JesterController controller;
        public override void OnAwake()
        {
            base.OnAwake();
            controller = GetComponent<JesterController>();
        }

        public override void OnStart()
        {
            GoToTarget(controller._spaceShip, controller._data);
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
        public void GoToTarget(SpaceShipView spaceship, GameData data)
        {
            float deltaAngle = Vector2.SignedAngle(spaceship.Velocity, (Vector2)controller.tree.GetVariable("NextTarget").GetValue() - spaceship.Position);
            deltaAngle *= 1.5f;
            deltaAngle = Mathf.Clamp(deltaAngle, -170, 170);
            float velocityOrientation = Vector2.SignedAngle(Vector2.right, spaceship.Velocity);
            float finalOrientation = velocityOrientation + deltaAngle;

            controller.nextInputData.targetOrientation = finalOrientation;
        }
    }
}
