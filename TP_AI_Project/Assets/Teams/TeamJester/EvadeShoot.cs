using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace TeamJester
{
    public class EvadeShoot : Action
    {
        public int nb_Raycast;
        public int max_angle;
        public RaycastHit2D[] raycastHit2DsRight = new RaycastHit2D[10];
        public RaycastHit2D[] raycastHit2DsLeft = new RaycastHit2D[10];
        public float RaycastLenght = 2;

        [SerializeField] private LayerMask layerMask;
        // Update is called once per frame
        public JesterController controller;
        public override void OnAwake()
        {
            base.OnAwake();
            controller = GetComponent<JesterController>();
        }

        public override void OnStart()
        {
            RayLook();
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }

        void RayLook()
        {

            if (controller == null || controller._spaceShip == null) return;

            for (int i = 0; i < nb_Raycast; i++)
            {
                Debug.Log("j'esite");
                float velocityX = controller._spaceShip.Velocity.x * -1;
                float velocityY = controller._spaceShip.Velocity.y * -1;
                Vector2 dir = new Vector2(velocityX, velocityY);
                Quaternion Rot = Quaternion.Euler(0, 0, max_angle * i / (nb_Raycast - 1));
                dir = Rot * dir;
                Debug.DrawRay(controller._spaceShip.PositionWorld, dir * RaycastLenght, Color.white);

                raycastHit2DsRight[i] = Physics2D.Raycast(controller._spaceShip.PositionWorld, dir, RaycastLenght, layerMask);

            }


            for (int i = 0; i < nb_Raycast; i++)
            {
                float velocityX = controller._spaceShip.Velocity.x * -1;
                float velocityY = controller._spaceShip.Velocity.y * -1;
                Vector2 dir = new Vector2(velocityX, velocityY);
                Quaternion Rot = Quaternion.Euler(0, 0, -(max_angle * i / (nb_Raycast - 1)));
                dir = Rot * dir;
                Debug.DrawRay(controller._spaceShip.PositionWorld, dir * RaycastLenght, Color.white);

                raycastHit2DsLeft[i] = Physics2D.Raycast(controller._spaceShip.PositionWorld, dir, RaycastLenght, layerMask);

            }

            for (int i = 0; i < nb_Raycast; i++)
            {
                if (raycastHit2DsRight[i].collider != null && i != 0)
                {
                    float velocityX = controller._spaceShip.Velocity.x * -1;
                    float velocityY = controller._spaceShip.Velocity.y * -1;
                    Vector2 dir = new Vector2(velocityX, velocityY);
                    Quaternion Rot = Quaternion.Euler(0, 0, max_angle * i / (nb_Raycast - 1));
                    dir = Rot * dir;
                    Debug.DrawRay(controller._spaceShip.PositionWorld, dir, Color.yellow);
                    if (raycastHit2DsRight[i].collider == null)
                    {
                        Debug.Log("drop mine ");
                        //drop mine
                    }

                }

                if (raycastHit2DsLeft[i].collider != null && i != 0)
                {
                    float velocityX = controller._spaceShip.Velocity.x * -1;
                    float velocityY = controller._spaceShip.Velocity.y * -1;
                    Vector2 dir = new Vector2(velocityX, velocityY);
                    Quaternion Rot = Quaternion.Euler(0, 0, -(max_angle * i / (nb_Raycast - 1)));
                    dir = Rot * dir;
                    Debug.DrawRay(controller._spaceShip.PositionWorld, dir, Color.yellow);
                    Debug.Log("detecte l'asteroid a gauche");
                    // se deplace a droite 
                    if (raycastHit2DsLeft[i].collider == null)
                    {
                        Debug.Log("drop mine ");
                    }
                }

                if (raycastHit2DsRight[0].collider != null && raycastHit2DsLeft[0].collider != null)
                {
                    Debug.Log("drop mine ");  
                }

            }

        }
    }
}
