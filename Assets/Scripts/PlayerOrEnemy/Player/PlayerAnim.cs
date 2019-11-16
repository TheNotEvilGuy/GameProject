using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script must be attached to a player
 */

public class PlayerAnim : MonoBehaviour
{
    [SerializeField]
    public Animator anim;

    void Update()
    {
        if (anim)
        {
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
                anim.SetBool("idle", true);
            else
                anim.SetBool("idle", false);

            anim.SetFloat("horChange", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
            anim.SetFloat("verChange", Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
            transform.eulerAngles = new Vector3(0, 180f, 0);
        else if (Input.GetAxisRaw("Horizontal") > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);

    }
}
