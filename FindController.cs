using UnityEngine;
using System.Collections;

/// <summary>
///
/// This class works wiht the "ControllerWrapper" class and is used to receive events from it. 
/// To use this class place it on any game object that should receive events from a controller (i.e. - button press) 
/// Modify as nessacary. 
/// 
/// This class is far from effecient and may have errors. So you have optimizations or find errors please let me know 
/// or better yet provide the solutions. 
/// 
/// </summary>

public class FindController : MonoBehaviour {

    //Left controller index reference 
    uint lt = 0;
    uint rt = 0;

    public uint controllerIndex;
    public bool triggerPressed = false;
    public bool steamPressed = false;
    public bool menuPressed = false;
    public bool padPressed = false;
    public bool padTouched = false;
    public bool gripped = false;


    // private SteamVR_Controller.Device rtController { get { return SteamVR_Controller.Input((int)rt); } }
    private SteamVR_Controller.Device rtController;


    public void OnEnable() {
        SteamVR_Utils.Event.Listen("device_connected", OnDeviceConnected);

        SteamVR_Utils.Event.Listen("triggerClicked", OnTriggerClicked);
        SteamVR_Utils.Event.Listen("triggerUnclicked", OnTriggerUnclicked);
        SteamVR_Utils.Event.Listen("gripClicked", OnGripClicked);
        SteamVR_Utils.Event.Listen("gripUnclicked", OnGripUnclicked);
        SteamVR_Utils.Event.Listen("padClicked", OnPadClicked);
        SteamVR_Utils.Event.Listen("padUnclicked", OnPadUnclicked);
        SteamVR_Utils.Event.Listen("menuClicked", OnMenulicked);
        SteamVR_Utils.Event.Listen("menuUnclicked", OnMenuUnclicked);
        SteamVR_Utils.Event.Listen("padTouched", OnPadTouched);
        SteamVR_Utils.Event.Listen("padUntouched", OnPadUntouched);



    }
    public void OnDisable() {
        SteamVR_Utils.Event.Remove("device_connected", OnDeviceConnected);

        SteamVR_Utils.Event.Remove("triggerClicked", OnTriggerClicked);
        SteamVR_Utils.Event.Remove("triggerUnclicked", OnTriggerUnclicked);
        SteamVR_Utils.Event.Remove("gripClicked", OnGripClicked);
        SteamVR_Utils.Event.Remove("gripUnclicked", OnGripUnclicked);
        SteamVR_Utils.Event.Remove("padClicked", OnPadClicked);
        SteamVR_Utils.Event.Remove("padUnclicked", OnPadUnclicked);
        SteamVR_Utils.Event.Remove("menuClicked", OnMenulicked);
        SteamVR_Utils.Event.Remove("menuUnclicked", OnMenuUnclicked);
        SteamVR_Utils.Event.Remove("padTouched", OnPadTouched);
        SteamVR_Utils.Event.Remove("padUntouched", OnPadUntouched);
    }


    private void OnTriggerClicked(params object[] args) {
       
        ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];

        Debug.Log("OnTriggerClicked");
        Debug.Log("Controller Index is " + eventStruct.controllerIndex);
        Debug.Log("The flags are " + eventStruct.flags);
        Debug.Log("Touchpad X is " + eventStruct.padX);
        Debug.Log("Touchpad Y is  " + eventStruct.padY);

        DebugTest(eventStruct.controllerIndex);

    }

    private void OnTriggerUnclicked(params object[] args) {
      
        ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];

        Debug.Log("OnTriggerUnclicked");
        Debug.Log("Controller Index is " + eventStruct.controllerIndex);
        Debug.Log("The flags are " + eventStruct.flags);
        Debug.Log("Touchpad X is " + eventStruct.padX);
        Debug.Log("Touchpad Y is  " + eventStruct.padY);
    }


    private void OnGripClicked(params object[] args) {
       
        ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];

        Debug.Log("OnGripClicked");
        Debug.Log("Controller Index is " + eventStruct.controllerIndex);
        Debug.Log("The flags are " + eventStruct.flags);
        Debug.Log("Touchpad X is " + eventStruct.padX);
        Debug.Log("Touchpad Y is  " + eventStruct.padY);
    }

    private void OnGripUnclicked(params object[] args) {

        ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];

        Debug.Log("OnGripUnclicked");
        Debug.Log("Controller Index is " + eventStruct.controllerIndex);
        Debug.Log("The flags are " + eventStruct.flags);
        Debug.Log("Touchpad X is " + eventStruct.padX);
        Debug.Log("Touchpad Y is  " + eventStruct.padY);
    }

    private void OnPadClicked(params object[] args) {

        ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];

        Debug.Log("OnPadClicked");
        Debug.Log("Controller Index is " + eventStruct.controllerIndex);
        Debug.Log("The flags are " + eventStruct.flags);
        Debug.Log("Touchpad X is " + eventStruct.padX);
        Debug.Log("Touchpad Y is  " + eventStruct.padY);
    }

    private void OnPadUnclicked(params object[] args) {

        ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];

        Debug.Log("OnPadUnclicked");
        Debug.Log("Controller Index is " + eventStruct.controllerIndex);
        Debug.Log("The flags are " + eventStruct.flags);
        Debug.Log("Touchpad X is " + eventStruct.padX);
        Debug.Log("Touchpad Y is  " + eventStruct.padY);
    }

    private void OnMenulicked(params object[] args) {

        ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];

        Debug.Log("OnMenulicked");
        Debug.Log("Controller Index is " + eventStruct.controllerIndex);
        Debug.Log("The flags are " + eventStruct.flags);
        Debug.Log("Touchpad X is " + eventStruct.padX);
        Debug.Log("Touchpad Y is  " + eventStruct.padY);
    }

    private void OnMenuUnclicked(params object[] args) {

        ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];

        Debug.Log("OnMenuUnclicked");
        Debug.Log("Controller Index is " + eventStruct.controllerIndex);
        Debug.Log("The flags are " + eventStruct.flags);
        Debug.Log("Touchpad X is " + eventStruct.padX);
        Debug.Log("Touchpad Y is  " + eventStruct.padY);
    }

    private void OnPadTouched(params object[] args) {

        ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];

        Debug.Log("OnPadTouched");
        Debug.Log("Controller Index is " + eventStruct.controllerIndex);
        Debug.Log("The flags are " + eventStruct.flags);
        Debug.Log("Touchpad X is " + eventStruct.padX);
        Debug.Log("Touchpad Y is  " + eventStruct.padY);
    }

    private void OnPadUntouched(params object[] args) {

        ControllerEventArgs eventStruct = (ControllerEventArgs)args[0];

        Debug.Log("OnPadUntouched");
        Debug.Log("Controller Index is " + eventStruct.controllerIndex);
        Debug.Log("The flags are " + eventStruct.flags);
        Debug.Log("Touchpad X is " + eventStruct.padX);
        Debug.Log("Touchpad Y is  " + eventStruct.padY);
    }

    //This gets the index for the contollers. 
    //TODO get index based on "right/left most" to get accurate results
    private void OnDeviceConnected(params object[] args) {

        if ((int) args[0] != 0) {
        var i = (int)args[0]; 
        bool connected = (bool)args[1]; 
        var vr = SteamVR.instance;
        if (connected) {
            if (vr.hmd.GetTrackedDeviceClass((uint)i) == Valve.VR.ETrackedDeviceClass.Controller) {
                if (rt == 0) {
                    rt = (uint)i;
                    Debug.Log("Right Controller index is " + rt);
                }else if (lt == 0) {
                    lt = (uint)i;
                    Debug.Log("Left controller index is " + lt);
                }
            }
          }
        }
    }



   void DebugTest(uint controllerIndex) {
        //Simple usage 
            if (controllerIndex == rt) {
                Debug.Log("Right Trigger pulled"); 
            } else {
            Debug.Log("Left Trigger pulled");
        }
        
    }
}
