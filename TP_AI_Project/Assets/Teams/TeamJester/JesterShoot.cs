using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TeamJester
{
    [TaskCategory("Jester")]

    public class JesterShoot : Action
    {
        public JesterController controller;
        private LayerMask mask;
        public override void OnStart()
        {
            controller = GetComponent<JesterController>();
            LayerMask mask = 10;
        }

        public override TaskStatus OnUpdate()
        {
            Vector2 dir = controller._spaceShip.Velocity.normalized;
            Debug.DrawRay(controller._spaceShip.PositionWorld, dir * 5, Color.red);
            mask = LayerMask.GetMask("Player");

            RaycastHit2D hit = Physics2D.Raycast(controller._spaceShip.PositionWorld, dir, 5, mask);
            if (hit.collider != null)
            {
               controller.nextInputData.shoot = true;
               return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }

    }

}
