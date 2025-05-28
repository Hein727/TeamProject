using Unity.VisualScripting;
using UnityEngine;

public class Stats_S : MonoBehaviour
{
    private float health = 0.0f;
    [SerializeField] public int Rank = 1;
    [SerializeField] public float Speed = 5f;
    [SerializeField] public float Damage = 5f;
    [SerializeField] public GameObject explosionPrefab;

    private void Start()
    {
        health = 20 * Rank;   
    }
    
    private void Update()
    {
        if(health <= 0)
        {
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Stats_S other = collision.gameObject.GetComponent<Stats_S>();
        if (other != null)
        {
            health -= other.Damage;
        }
        else { return ; }
    }
}
