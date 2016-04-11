using UnityEngine;
using System.Collections;
using Valve.VR;
/// <summary>
/// This script must be on a controller to function
/// 
/// The purpose of this is to send events using the SteamVR.Event system. 
/// When using this script game objects do not need a reference to the controllers, they only need 
/// to listen for the event. (SteamVR.Event.Listen("controllerEvent", OnControllerEvent)
/// 
/// The listening object will need to recast the (params ojbect[] args) to ControllerEventArgs
/// ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];
/// And the parameters can be accessed from there. 
/// 
/// Credit: This script structure as taken from "SteamVR_TrackedController" in the Steam Unity VR package
/// And was made working with the help from Lee Wasilenko at www.vrdevschool.com
///  
/// Extensions: This class can be extended to get the controller rotation and axis information. 
/// The hair trigger method can be added as well 
/// 
/// Notes: The SteamVR event system uses the following pattern to check for null. 
/// The EtrackingResults are stored in the Valve name space. 
/// If this script needs to check for events then what are they? 
/// 
/// static public bool initializing { get; private set; }
///
/// var initializing = result == ETrackingResult.Uninitialized;
/// if (initializing != SteamVR.initializing)
/// {
///	SteamVR_Utils.Event.Send("initializing", initializing);
/// }
/// </summary>
/// 




//All parameters here will be passed on the event trigger
public struct ControllerEventArgs {
    public uint controllerIndex;
    public uint flags;
    public float padX, padY;
}


public class ControllerWrapper : MonoBehaviour {


    public uint controllerIndex;
    public VRControllerState_t controllerState;
    public bool triggerPressed = false;
    public bool steamPressed = false;
    public bool menuPressed = false;
    public bool padPressed = false;
    public bool padTouched = false;
    public bool gripped = false;


   


// Use this for initialization
void Start() {

        //Get a reference to the tracked object class 
        if (this.GetComponent<SteamVR_TrackedObject>() == null) {
            gameObject.AddComponent<SteamVR_TrackedObject>();
        }

        //Get the index this controller is
        controllerIndex = (uint)this.GetComponent<SteamVR_TrackedObject>().index;
        if (this.GetComponent<SteamVR_RenderModel>() != null) {
            this.GetComponent<SteamVR_RenderModel>().index = (SteamVR_TrackedObject.EIndex)controllerIndex;
        }
    }


   

   
    // Update is called once per frame
    void Update() {

        var system = OpenVR.System;
        if (system != null && system.GetControllerState(controllerIndex, ref controllerState)) {

            ulong trigger = controllerState.ulButtonPressed & (1UL << ((int)EVRButtonId.k_EButton_SteamVR_Trigger));
            if (trigger > 0L && !triggerPressed) {
                triggerPressed = true;
                ControllerEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                //I beleive the null check is handled in the SteamVR_Utils before the event is sent
                //TODO see if this good enough null checking
                SteamVR_Utils.Event.Send("triggerClicked", e);

            } else if (trigger == 0L && triggerPressed) {
                triggerPressed = false;
                ControllerEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                SteamVR_Utils.Event.Send("triggerUnclicked", e);
               
            }

            ulong grip = controllerState.ulButtonPressed & (1UL << ((int)EVRButtonId.k_EButton_Grip));
            if (grip > 0L && !gripped) {
                gripped = true;
                ControllerEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                SteamVR_Utils.Event.Send("gripClicked", e);

            } else if (grip == 0L && gripped) {
                gripped = false;
                ControllerEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                SteamVR_Utils.Event.Send("gripUnclicked", e);
            }

            ulong pad = controllerState.ulButtonPressed & (1UL << ((int)EVRButtonId.k_EButton_SteamVR_Touchpad));
            if (pad > 0L && !padPressed) {
                padPressed = true;
                ControllerEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                SteamVR_Utils.Event.Send("padClicked", e);

            } else if (pad == 0L && padPressed) {
                padPressed = false;
                ControllerEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                SteamVR_Utils.Event.Send("padUnclicked", e);
               
            }

            ulong menu = controllerState.ulButtonPressed & (1UL << ((int)EVRButtonId.k_EButton_ApplicationMenu));
            if (menu > 0L && !menuPressed) {
                menuPressed = true;
                ControllerEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                SteamVR_Utils.Event.Send("menuClicked", e);

            } else if (menu == 0L && menuPressed) {
                menuPressed = false;
                ControllerEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                SteamVR_Utils.Event.Send("menuUnclicked", e);
            }

            pad = controllerState.ulButtonTouched & (1UL << ((int)EVRButtonId.k_EButton_SteamVR_Touchpad));
            if (pad > 0L && !padTouched) {
                padTouched = true;
                ControllerEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                SteamVR_Utils.Event.Send("padTouched", e);

            } else if (pad == 0L && padTouched) {
                padTouched = false;
                ControllerEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                SteamVR_Utils.Event.Send("padUntouched", e);
            }
        }
    }
}
