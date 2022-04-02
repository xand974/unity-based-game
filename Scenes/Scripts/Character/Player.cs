using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] private InputReader _inputReader = default;

    private void OnEnable()
    {
        _inputReader.moveEvent += Move;
        _inputReader.jumpEvent += Jump;
    }

    private void OnDisable()
    {
        _inputReader.moveEvent -= Move;
        _inputReader.jumpEvent -= Jump;
    }

    void Update()
    {
        
    }

    void Move(Vector3 movement)
    {
        Debug.Log(movement.y + 2);
    }

    void Jump(Vector3 movement)
    {
        Debug.Log(movement.z + 1);
    }
}
