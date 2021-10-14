using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TeamJester
{
    [TaskCategory("Jester")]
    public class JesterBomb : Action
    {
        public JesterController controller;

        public override void OnStart()
        {
            controller = GetComponent<JesterController>();
        }
        public override TaskStatus OnUpdate()
        {
            if (controller._spaceShip.Energy >= controller._spaceShip.MineEnergyCost)
            {
                controller.nextInputData.dropMine = true;
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }

    }

}
