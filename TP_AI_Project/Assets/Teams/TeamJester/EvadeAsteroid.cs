using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace TeamJester
{
    public class EvadeAsteroid : Action
    {
        public int nb_Raycast;
        public int max_angle;
        public RaycastHit2D[] raycastHit2DsRight = new RaycastHit2D[100];
        public RaycastHit2D[] raycastHit2DsLeft = new RaycastHit2D[100];
        public float RaycastLenght = 2;

        [SerializeField] private LayerMask layerMask;
        // Update is called once per frame
        public JesterController controller;
        public override void OnAwake()
        {
            base.OnAwake();
            controller = GetComponent<JesterController>();
        }
        void Start()
        {
            
            
        }
        void Update()
        {
            if (JesterController.instance == null || JesterController.instance._spaceShip == null) return;
            for (int i = 0; i < nb_Raycast; i++)
            {
                Vector2 dir = JesterController.instance._spaceShip.Velocity.normalized;
                Quaternion Rot = Quaternion.Euler(0, 0, max_angle * i / (nb_Raycast - 1));
                dir = Rot * dir;
                Debug.DrawRay(JesterController.instance._spaceShip.PositionWorld, dir*RaycastLenght , Color.white);

                raycastHit2DsRight[i] = Physics2D.Raycast(JesterController.instance._spaceShip.PositionWorld, dir, RaycastLenght, layerMask);

            }

            for (int i = 0; i < nb_Raycast; i++)
            {
                Vector2 dir = JesterController.instance._spaceShip.Velocity.normalized;
                Quaternion Rot = Quaternion.Euler(0, 0, -(max_angle * i / (nb_Raycast - 1)));
                dir = Rot * dir;
                Debug.DrawRay(JesterController.instance._spaceShip.PositionWorld, dir * RaycastLenght, Color.white);

                raycastHit2DsLeft[i] = Physics2D.Raycast(JesterController.instance._spaceShip.PositionWorld, dir, RaycastLenght, layerMask);

            }

            for (int i = 0; i < nb_Raycast; i++)
            {
                if (raycastHit2DsRight[i].collider != null && i != 0)
                {
                    Vector2 dir = JesterController.instance._spaceShip.Velocity.normalized;
                    Quaternion Rot = Quaternion.Euler(0, 0, max_angle * i / (nb_Raycast - 1));
                    dir = Rot * dir;
                    Debug.DrawRay(JesterController.instance._spaceShip.PositionWorld, dir, Color.yellow);
                    Debug.Log("detecte l'asteroid a droite");
                    // se deplace a gauche
                    if (raycastHit2DsRight[0].collider == null && raycastHit2DsLeft[0].collider == null)
                    {
                        controller.tree
                    }

                }

                if (raycastHit2DsLeft[i].collider != null && i != 0)
                {
                    Vector2 dir = JesterController.instance._spaceShip.Velocity.normalized;
                    Quaternion Rot = Quaternion.Euler(0, 0, -(max_angle * i / (nb_Raycast - 1)));
                    dir = Rot * dir;
                    Debug.DrawRay(JesterController.instance._spaceShip.PositionWorld, dir, Color.yellow);
                    Debug.Log("detecte l'asteroid a gauche");
                    // se deplace a droite 
                }

                if (raycastHit2DsRight[0].collider != null && raycastHit2DsLeft[0].collider != null)
                {
                    Vector2 dir = JesterController.instance._spaceShip.Velocity.normalized;
                    Quaternion Rot = Quaternion.Euler(0, 0, (max_angle * 0 / (nb_Raycast - 1)));
                    dir = Rot * dir;
                    Debug.DrawRay(JesterController.instance._spaceShip.PositionWorld, dir, Color.yellow);
                    Debug.Log("detecte l'asteroid au midle");
                    // 
                }
                
            }
            
        }
    }
}

