using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private static ObjectPooling instant;
    public static ObjectPooling Instant => instant;

    Dictionary<GameObject, List<GameObject>> pools = new Dictionary<GameObject, List<GameObject>>();


    private void Awake()
    {
        if (instant == null)
            instant = this;
        else if (!instant.GetInstanceID().Equals(this.GetInstanceID()))
            Destroy(this);
    }

    public GameObject GetObject(GameObject sample)
    {
        if (!pools.ContainsKey(sample))
            pools.Add(sample, new List<GameObject>());

        foreach (GameObject g in pools[sample])
        {
            if (g.activeSelf)
                continue;
            return g;
        }
        GameObject g2 = Instantiate(sample, this.transform.position, Quaternion.identity);
        pools[sample].Add(g2);
        return g2;
    }
}
