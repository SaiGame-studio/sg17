using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMoving : PlayerAbstract
{
    [SerializeField] protected bool isFlyingDown = true;
    [SerializeField] protected float flyDownSpeed = 20f;
    [SerializeField] protected float moveSpeed = 7f;
    [SerializeField] protected float stopDistance = 2f;
    [SerializeField] protected bool isMoving = false;

    protected virtual void Update()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        if (this.isFlyingDown)
        {
            this.FlyingDown();
            return;
        }

        this.GoToMousePosition();
    }

    protected virtual void GoToMousePosition()
    {
        Vector2 mouseWorldPosition = InputManager.Instance.MouseWorldPosition;
        Vector3 playerPosition = transform.parent.position;

        float previousX = playerPosition.x;

        if (Mathf.Abs(playerPosition.x - mouseWorldPosition.x) > stopDistance)
        {
            playerPosition.x = Mathf.MoveTowards(playerPosition.x, mouseWorldPosition.x, moveSpeed * Time.deltaTime);
            transform.parent.position = playerPosition;
        }

        isMoving = !Mathf.Approximately(previousX, playerPosition.x);
    }

    protected virtual void FlyingDown()
    {
        transform.parent.position += Vector3.down * flyDownSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.FlyingDownToGround(collision);
    }

    protected virtual void FlyingDownToGround(Collision collision)
    {
        if (!this.isFlyingDown) return;

        GroundCtrl groundCtrl = collision.gameObject.GetComponent<GroundCtrl>();
        if (groundCtrl == null) return;

        this.flyDownSpeed = 0f;
        this.ctrl.Animator.SetBool("IsFlyingDown", false);
        Invoke(nameof(this.DelayStopFlyingDown), 1f);
    }

    protected virtual void DelayStopFlyingDown()
    {
        this.isFlyingDown = false;
    }
}
