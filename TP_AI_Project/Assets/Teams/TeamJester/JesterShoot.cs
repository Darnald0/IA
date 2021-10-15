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
            Debug.DrawRay(new Vector3(controller._spaceShip.PositionWorld.x + dir.x*0.6f, controller._spaceShip.PositionWorld.y + dir.y*0.6f, 0), dir * 5, Color.red); ;
            mask = LayerMask.GetMask("Player");
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(controller._spaceShip.PositionWorld.x + dir.x*0.6f, controller._spaceShip.PositionWorld.y + dir.y*0.6f, 0), dir, 5, mask);
            if (hit.collider != null && new Vector2(hit.collider.transform.parent.position.x, hit.collider.transform.parent.position.y) != controller._spaceShip.Position)
            {
                Debug.Log(hit.collider.gameObject.transform.parent.name);

               controller.nextInputData.shoot = true;
               return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }

    }

}
