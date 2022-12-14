using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    //BASE CLASS FOR PLAYER PROJECTILES

    [SerializeField] int damage = 1;

    [SerializeField] float knockbackForce = 1f;
    [SerializeField] float knockbackDuration = 2f;

    [SerializeField] float speed = 8f;

    [SerializeField] float lifetimeLength = 1f;
    float lifetimeTimer;

    Rigidbody2D rb;

    public GameEventAudioClip onPlayClip;
    public AudioClip hitClip;

    private void OnEnable()
    {
        lifetimeTimer = lifetimeLength;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lifetimeTimer -= Time.deltaTime;

        if (lifetimeTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Setup(Vector2 direction, Vector3 orientation)
    {
        rb.velocity = direction.normalized * speed;
        transform.rotation = Quaternion.Euler(orientation);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        if (!collision.isTrigger)
        {
            if (collision.GetComponentInParent<EnemyHealthManager>() != null)
            {
                collision.GetComponentInParent<EnemyHealthManager>().TakeDamage(damage);

                // knockback & temporary invulnerability
                Vector2 direction = collision.transform.position - transform.position;
                direction.Normalize();

                collision.gameObject.GetComponent<KnockbackEnemy>().GetKnockedBack
                    (knockbackForce * direction, knockbackDuration);

                onPlayClip.Raise(hitClip);
            }

            gameObject.SetActive(false);
        }
    }
}