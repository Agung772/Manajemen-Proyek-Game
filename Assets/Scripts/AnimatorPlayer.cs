using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimatorPlayer : MonoBehaviour
{
    public Animator animatorPlayer;

    public RuntimeAnimatorController animatorPlayer1;
    public RuntimeAnimatorController animatorPlayer2;
    public RuntimeAnimatorController animatorPlayer3;

    public void SetAnimator(int value)
    {
        if (value == 1)
        {
            animatorPlayer.runtimeAnimatorController = animatorPlayer1;
        }
        else if (value == 2)
        {
            animatorPlayer.runtimeAnimatorController = animatorPlayer2;
        }
        else if (value == 3)
        {
            animatorPlayer.runtimeAnimatorController = animatorPlayer3;
        }
    }
}
