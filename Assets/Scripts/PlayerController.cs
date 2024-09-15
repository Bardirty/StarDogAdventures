using UnityEngine;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private ThrowController canePrefab;
    public int health = 3;
    public bool isWeaponed = false;
    public Transform spawnPoint;
    public int cutSceneFrozen = 1;
    private Rigidbody2D rb;
    private Animator anim;

    // Update is called once per frame
    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime * cutSceneFrozen;

        sprite.flipX = movement < 0 ? true : false;
        if (Input.GetAxis("Horizontal") != 0.0f)
            anim.SetBool("IsRunning", true);
        else anim.SetBool("IsRunning", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05f)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        if (Input.GetButtonDown("Fire1") && isWeaponed && transform.childCount <= 3)
        {
            ThrowController cane = Instantiate(canePrefab, transform.position, Quaternion.identity, transform);
            Vector2 throwDirection = !sprite.flipX ? Vector2.right : Vector2.left;
            cane.Throw(throwDirection);
            Destroy(cane.gameObject, 5.0f);
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            health--;
        }
    }
}
