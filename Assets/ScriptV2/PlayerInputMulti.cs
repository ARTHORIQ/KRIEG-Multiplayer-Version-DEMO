using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.Netcode;
using Cinemachine;

public class PlayerInputMulti : NetworkBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    private CinemachineVirtualCamera vcam;
    public UnityEvent onShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();
    public MultiPlayerCameraFollow MultiPlayerCameraFollow;

    private void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (!IsOwner)
        return;

        GetBodyMovement();
        GetTurretMovement();
        GetShootingInput();

    }
    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

    }

    private void GetShootingInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onShoot?.Invoke();
        }
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePosition());
    }

    private void GetBodyMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveBody?.Invoke(movementVector.normalized);
    }
    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }
}
