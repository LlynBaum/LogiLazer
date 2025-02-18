using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : DeathTask
    {
        private static readonly int Die = Animator.StringToHash("die");
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        protected override IEnumerator StartDeathTask()
        {
            animator.SetTrigger(Die);
            yield return new WaitForSeconds(3.54f);
            onFinished.Invoke();
        }
    }
}