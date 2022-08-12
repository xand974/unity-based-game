using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Game/Input Reader SO")]
public class InputReaderSO : ScriptableObject, Inputs.IGameplayActions
{

    public event UnityAction MoveEvent = delegate { };
    public event UnityAction<float> AttackEvent = delegate { };
    public event UnityAction<float> JumpEvent = delegate { };
    public event UnityAction OpenInventoryEvent = delegate { };

    private Inputs _inputs;

    private void OnEnable()
    {
        if (_inputs == null)
        {
            _inputs = new Inputs();
            _inputs.Gameplay.SetCallbacks(this);
        }

        EnableGameplayInput();
    }

    void DisableAllInputs()
    {
        _inputs.Gameplay.Disable();
    }

    private void OnDisable()
    {
        DisableAllInputs();
    }

    public void EnableGameplayInput()
    {
        //disable le reste
        _inputs.Gameplay.Enable();
    }


    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!this._inputs.Gameplay.Attack.triggered) return;
        AttackEvent.Invoke(context.ReadValue<float>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!this._inputs.Gameplay.Jump.triggered) return;
        JumpEvent.Invoke(context.ReadValue<float>());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!this._inputs.Gameplay.Move.triggered) return;
        MoveEvent.Invoke();
    }

    public void OnOpenInventory(InputAction.CallbackContext context)
    {
        if (!this._inputs.Gameplay.OpenInventory.triggered) return;
        OpenInventoryEvent.Invoke();
    }
}
