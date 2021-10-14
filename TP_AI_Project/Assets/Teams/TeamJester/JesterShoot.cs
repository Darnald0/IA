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

        public override TaskStatus OnUpdate()
        {
            if(JesterController.instance._spaceShip.Energy >= JesterController.instance._spaceShip.ShootEnergyCost)
            {

                JesterController.instance.nextInputData.shoot = true;
                //InputData inputData = controller.UpdateInput(JesterController.instance._spaceShip, GameManager.Instance.GetGameData());
                //JesterController.instance._spaceShip.Shoot();

                //InputData i = new InputData(1.0f, targetOrient, true, false, false);
                //if (controller.UpdateInput(ss, gd).shoot)
                //{

                //}
                return TaskStatus.Success;
            }
            return TaskStatus.Running;
        }

    }

}
