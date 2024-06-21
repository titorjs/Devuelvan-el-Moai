using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public AnimationClip runAnimation;
    public AnimationClip standAnimation;
    public GameObject player;
    public float detectionRadius = 5.0f;
    public float moveSpeed = 2.0f;

    private Animation anim;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Constants.playerTag);

        anim = GetComponent<Animation>();
        if (anim != null && standAnimation != null)
        {
            anim.clip = standAnimation;
            anim.wrapMode = WrapMode.Loop;
            anim.Play();
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= detectionRadius)
            {
                if (!isChasing)
                {
                    isChasing = true;
                    if (anim != null && runAnimation != null)
                    {
                        anim.clip = runAnimation;
                        anim.wrapMode = WrapMode.Loop;
                        anim.Play();
                    }
                }
                ChasePlayer();
            }
            else
            {
                if (isChasing)
                {
                    isChasing = false;
                    if (anim != null && standAnimation != null)
                    {
                        anim.clip = standAnimation;
                        anim.wrapMode = WrapMode.Loop;
                        anim.Play();
                    }
                }
            }
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(player.transform);
    }
}
