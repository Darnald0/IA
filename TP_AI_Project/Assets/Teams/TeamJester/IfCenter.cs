using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TeamJester
{
    [TaskCategory("Jester")]
    public class IfCenter : Conditional
    {
        public JesterController controller;
        private Vector2 shipPos;

        public override TaskStatus OnUpdate()
        {
            shipPos = controller._spaceShip.Position;
            if (shipPos.x <= 0.1f && shipPos.x >= -0.1f )
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }

}
