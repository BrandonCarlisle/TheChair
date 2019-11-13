//using UnityEngine;
//using System.Collections;
//using Valve.VR;
//using Valve;
//using System.Collections.Generic;
//using Valve.VR.InteractionSystem;
//using System.Collections.ObjectModel;
//public class Dpad : MonoBehaviour
//{

//    SteamVR_TrackedObject trackedObj;

//    SteamVR_Action action;
  

//    public bool up = false;
//    public bool down = false;

//    void Update()
//    {
//        trackedObj = GetComponent<SteamVR_TrackedObject>();
//        action.
//        device = SteamVR_Controller.Input((int)trackedObj.index);

//        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
//        {
//            if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y > 0.5f)
//            {
//                up = true;
//                Debug.Log("Dpad Up");
//            }
//            else if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y < -0.5)
//            {
//                down = true;
//                Debug.Log("Dpad Down");
//            }


//        }

//    }
//}
