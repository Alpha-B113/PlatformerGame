using System.Collections;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public GameObject waterDropPrefab;
    private float dropIntervalMin = 0.6f;
    private float dropIntervalMax = 1.2f;

    private void Start()
    {
        StartCoroutine(SpawnDrops());
    }

    IEnumerator SpawnDrops()
    {
        while (true)
        {
            var drop = Instantiate(waterDropPrefab, transform.position, Quaternion.identity);
            var rb = drop.GetComponent<Rigidbody2D>();
            var sr = drop.GetComponent<SpriteRenderer>();
            rb.gravityScale = 1.5f;
            sr.enabled = true;
            var randomInterval = Random.Range(dropIntervalMin, dropIntervalMax);
            yield return new WaitForSeconds(randomInterval);
        }
    }
}
