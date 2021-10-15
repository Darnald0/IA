using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace TeamJester
{
    [TaskCategory("Jester")]
    [TaskDescription("Set Target to Enemy")]
    public class SetEnmyTarget : Action
    {
        public JesterController controller;
        public override void OnAwake()
        {
            base.OnAwake();
            controller = GetComponent<JesterController>();
        }

        public override void OnStart()
        {
            controller.tree.SetVariableValue("Target", controller._otherSpaceShip.Position);
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
    }
}
