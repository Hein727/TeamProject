using UnityEngine;

public class Explosion_S : MonoBehaviour
{
    private Animator explosion;
    private bool triggered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is create
    void Start()
    {
        explosion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggered)
        {
            explosion.SetTrigger("Dead");
            triggered = true;
        }
        
        AnimatorStateInfo stateInfo = explosion.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Dead") && stateInfo.normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
