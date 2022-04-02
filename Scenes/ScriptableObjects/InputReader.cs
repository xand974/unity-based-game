using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Game/Input Reader SO")]
public class InputReader : ScriptableObject , Inputs.IPlayerActions
{
    public event UnityAction<Vector3> moveEvent = delegate { };
    public event UnityAction<Vector3> jumpEvent = delegate { }; 


    private Inputs inputs;

    private void OnEnable()
    {
        if(inputs == null)
        {
            inputs = new Inputs();
            inputs.Player.SetCallbacks(this);
        }

        EnableGameplayInput();
    }

    private void OnDisable()
    {
        DisableAllInputs();
    }

    void DisableAllInputs()
    {
        inputs.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (moveEvent != null)
            moveEvent.Invoke(context.ReadValue<Vector3>());
    }

    public void EnableGameplayInput()
    {
        //disable le reste

        inputs.Player.Enable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (jumpEvent != null)
        {
            jumpEvent.Invoke(context.ReadValue<Vector3>());
        }
    }
}
