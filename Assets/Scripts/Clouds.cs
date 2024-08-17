


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [Header("Set In Inspector")]
    [SerializeField] private Transform zone;
    public GameObject prefabCloud;
    public Vector2 sizeRange = new Vector2(0.3f, 0.6f);
    public int cloudsCount = 5;

    private float ZoneWidth { get { return zone.localScale.x; } }
    private float ZoneHeight { get { return zone.localScale.y; } }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(zone.transform.position, zone.transform.localScale);
    }

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < cloudsCount; i++)
        {
            var pos = Vector3.zero;
            pos.x = Random.Range(-ZoneWidth / 2, ZoneWidth / 2);
            pos.y = Random.Range(-ZoneHeight / 2 + zone.position.y, ZoneHeight / 2 + zone.position.y);

            var cloud = Instantiate(prefabCloud);
            cloud.transform.SetParent(transform, false);
            cloud.transform.position = pos;
            cloud.transform.localScale = Vector3.one * Random.Range(sizeRange.x, sizeRange.y);
        }
    }

}
