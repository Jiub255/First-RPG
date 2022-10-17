using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyMovementTrigger : MonoBehaviour
{
    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public Rigidbody2D rb;

    [HideInInspector]
    public float moveSpeed;

    public bool canMove = true;

    bool playerNear = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = GetComponent<Enemy>().moveSpeed;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (playerNear)
            {
                PlayerNearAction();
            }

            else //if (!playerNear)
            {
                PlayerFarAction();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            target = collision.transform;
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNear = false;
        }
    }

    // make this virtual too. some enemies might stay still and shoot when player near
    public virtual void PlayerNearAction()
    {

    }

    // make this virtual so different child classes can do different movement when player not in range
    public virtual void PlayerFarAction()
    {

    }
}