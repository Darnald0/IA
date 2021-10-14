using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace TeamJester
{
    public class ThrustStop : Action
    {
        public JesterController controller;
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
            controller.tree.SetVariableValue("Thrust", 0.0f);
            controller.nextInputData.thrust = (float)controller.tree.GetVariable("Thrust").GetValue();
        }
    }
}
