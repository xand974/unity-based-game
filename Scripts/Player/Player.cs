using UnityEngine;

[RequireComponent(typeof(InputReaderSO))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReaderSO;
    [SerializeField] private float _speedForce;
    [SerializeField] private Rigidbody _rb;

    void Start()
    {
        this._inputReaderSO = default;
        this._speedForce = 10;
    }


    private void OnEnable()
    {
        _inputReaderSO.MoveEvent += Move;
        _inputReaderSO.OpenInventoryEvent += OpenInventory;
        _inputReaderSO.AttackEvent += Attack;
        _inputReaderSO.JumpEvent += Jump;

    }

    private void OnDisable()
    {
        _inputReaderSO.MoveEvent -= Move;
        _inputReaderSO.OpenInventoryEvent -= OpenInventory;
        _inputReaderSO.AttackEvent -= Attack;
        _inputReaderSO.JumpEvent -= Jump;
    }

    private void Move()
    {
        Debug.Log("Moving " + _speedForce);
    }

    private void OpenInventory()
    {
        Debug.Log("Opening Inventory");
    }

    private void Attack(float damage)
    {
        float totalDomage = damage + 50;
        Debug.Log("Attacking : " + totalDomage);
    }

    private void Jump(float jumpForce)
    {
        Debug.Log("Jumping");
    }

    private bool CheckGround()
    {
        return true;
    }
}
