using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace TeamJester
{
    public class ManageThrust : Action
    {
        public JesterController controller;
        float _thrust;
        public override void OnAwake()
        {
            base.OnAwake();
            controller = GetComponent<JesterController>();
        }

        public override void OnStart()
        {
            Thrust(controller._spaceShip,controller._data);
        }

        public override TaskStatus OnUpdate()
        {
                return TaskStatus.Success;
        }
        public void Thrust(SpaceShipView spaceship, GameData data)
        {
            if (Vector2.Distance(spaceship.Position, (Vector2)controller.tree.GetVariable("Target").GetValue()) < 1.6f && 
                (Vector2.SignedAngle(spaceship.Velocity, (Vector2)controller.tree.GetVariable("Target").GetValue() - spaceship.Position)*1.2f<40 && Vector2.SignedAngle(spaceship.Velocity, (Vector2)controller.tree.GetVariable("Target").GetValue() - spaceship.Position)*1.2f>-40) &&
                ((spaceship.Velocity.x > 0.9f || spaceship.Velocity.x <-0.9f) || (spaceship.Velocity.y > 0.9f || spaceship.Velocity.y <-0.9f)))
            {
                _thrust = 0;
            }
            else
            {
                _thrust = 1;
            }
            controller.nextInputData.thrust = _thrust;
        }
    }
}
