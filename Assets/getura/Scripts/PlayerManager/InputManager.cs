using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerController playerController;
    public CameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) toPlayerClickMove();

        if (Input.mousePosition.x < 0) toMoveCamera(Vector3.left);
        if (Input.mousePosition.x > Screen.width) toMoveCamera(Vector3.right);
        if (Input.mousePosition.y < 0) toMoveCamera(Vector3.down);
        if (Input.mousePosition.y > Screen.height) toMoveCamera(Vector3.up);
    }

    void toPlayerClickMove()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0; // Zç¿ïWÇÕ2DÇÃèÍçáå≈íËílÇ…Ç∑ÇÈ

        playerController.PlayerClickMove(worldPosition);
    }

    void toMoveCamera(Vector3 direction)
    {
        cameraController.MoveCamera(direction);
    }



}
