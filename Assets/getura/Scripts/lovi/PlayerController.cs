using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;

    private Rigidbody2D rb;
    public NextPosManager pNextPosManager;
    private Vector3 nextPos;
    private Vector3 direction;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isMoving) MoveToNextPos();
    }
    public void PlayerClickMove(Vector3 worldPosition)
    {
        nextPos = worldPosition;
        pNextPosManager.ClickMoveQol(nextPos);
        isMoving = true;
    }

    void MoveToNextPos()
    {
        Vector3 direction = (nextPos - transform.position).normalized;
        float step = speed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + direction * step);

        if (Vector3.Distance(transform.position, nextPos) < 0.1f)
        {
            transform.position = nextPos; // 最終的に位置を正確に合わせる
            isMoving = false;
            pNextPosManager.ClickMoveEnd();
        }
    }

}
