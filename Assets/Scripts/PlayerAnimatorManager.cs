using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private RuntimeAnimatorController playerController;
    [SerializeField] private RuntimeAnimatorController playerWithGasSprayController;
    private static Animator animator;

    private void Awake()
    {
        animator = player.GetComponent<Animator>();
    }

    private void Start()
    {
        animator.runtimeAnimatorController = playerController;
    }

    public void TryChangeController()
    {
        if (IsNowCorrectController())
            return;

        if (animator.runtimeAnimatorController == playerController)
            animator.runtimeAnimatorController = playerWithGasSprayController;
        else
            animator.runtimeAnimatorController = playerController;
    }

    private bool IsNowCorrectController()
    {
        return animator.runtimeAnimatorController == playerController
                    && GasSpray.GasSprayCount == 0
                    || animator.runtimeAnimatorController == playerWithGasSprayController
                    && GasSpray.GasSprayCount > 0;
    }
}
