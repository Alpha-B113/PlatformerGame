using UnityEngine;

public class GasSprayShooter : MonoBehaviour
{
    public Player Player;
    public PlayerAnimatorManager playerAnimatorManager;
    public GameObject gas;
    private float shootForce = 5f;
    private SpriteRenderer gasSr;
    private Animator gasAnimator;
    private Rigidbody2D gasRb;
    private float disappearTime = 1f;
    private bool isShooting;
    private Vector2 shootDirection;

    private void Start()
    {
        Invoke(nameof(HideGas), disappearTime);
    }

    private void Awake()
    {
        gasSr = gas.GetComponent<SpriteRenderer>();
        gasAnimator = gas.GetComponent<Animator>();
        gasRb = gas.GetComponent<Rigidbody2D>();
        HideGas();
    }

    private void Update()
    {
        if (!isShooting && GasSpray.GasSprayCount > 0 && Input.GetKeyDown(KeyCode.F))
        {
            isShooting = true;
            GasSpray.GasSprayCount--;
            playerAnimatorManager.TryChangeController();
            ShootGas();
        }

        if (Player.LooksRight)
        {
            shootDirection = Vector2.right;
            transform.localPosition = new Vector2(0.3717505f, -0.1632589f);
        }

        if (Player.LooksLeft)
        {
            shootDirection = Vector2.left;
            transform.localPosition = new Vector2(-0.36f, -0.1632589f);
        }
    }

    private void ShootGas()
    {
        gasRb.simulated = true;
        gasSr.enabled = true;
        gasAnimator.SetTrigger("isSpraying");
        gasRb.linearVelocity = shootDirection * shootForce;
        Invoke(nameof(HideGas), disappearTime);
    }

    private void HideGas()
    {
        gas.transform.position = transform.position;
        gasRb.linearVelocity = Vector2.zero;
        gasRb.simulated = false;
        gasSr.enabled = false;
        isShooting = false;
    }
}
