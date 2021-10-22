using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopupController : MonoBehaviour
{
    [SerializeField] private TextMeshPro damageText;
    [SerializeField] private Animator animator;


    public void SetDamageText(int damage)
    {
        AnimationClip[] animations = animator.runtimeAnimatorController.animationClips;
        int animationRandomIndex = Random.Range(0, animations.Length);
        animator.Play(animations[animationRandomIndex].name);

        damageText.text = damage.ToString();
    }
}



