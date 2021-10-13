using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using DoNotModify;
using TeamJester;
using UnityEngine;

namespace TeamJester
{
    public class JesterShoot : Action
    {
        public JesterController controller;
        GameData gd;
        SpaceShipView ss;
        
        public override void OnAwake()
        {
            gd = controller.gameData;
            ss = controller.spaceShip;
        }
        public override TaskStatus OnUpdate()
        {   
            if(controller.spaceShip.Energy >= controller.spaceShip.ShootEnergyCost)
            {
                //InputData inputData = controller.UpdateInput(controller.spaceShip, GameManager.Instance.GetGameData());
                controller.spaceShip.Shoot();

                //InputData i = new InputData(1.0f, targetOrient, true, false, false);
                if (controller.UpdateInput(ss, gd).shoot)
                {

                }
                return TaskStatus.Success;
            }
            return TaskStatus.Running;
        }

    }

}
