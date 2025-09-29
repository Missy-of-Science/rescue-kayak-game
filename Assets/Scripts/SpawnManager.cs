using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float zpos = 35f;
    private float xpos = 15f;
    private float spawn_x;
    private float spawn_z;

    private int swimmer_c;
    private int wave_c;
    public GameObject swimmer_prefab;
    public GameObject rock_prefab;
    public GameObject wave_prefab;
    public GameObject damsel_prefab;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        for (int i = 0; i < 5; i++)
        {
            SpawnSwimmer();
            SpawnRock();
            SpawnWave();
        }
        SpawnDamsel();
    }

    // Update is called once per frame
    void Update()
    {
        swimmer_c = FindObjectsOfType<ObstacleSwimmer>().Length;
        wave_c = FindObjectsOfType<ObstacleWave>().Length;

        if (swimmer_c < 3)
        {
            SpawnSwimmer();
        }
        if (wave_c < 3)
        {
            SpawnWave();
        }
    }

    void SpawnDamsel()
    {
        spawn_x = Random.Range(-xpos + 3, xpos - 3);
        Vector3 random_pos = new Vector3(spawn_x, 0.1f, 40);
        Instantiate(damsel_prefab, random_pos, transform.rotation);
    }

    void SpawnSwimmer()
    {
        Instantiate(
            swimmer_prefab,
            GenerateSpawnPosition(true, 0.1f),
            swimmer_prefab.transform.rotation
        );
    }

    void SpawnRock()
    {
        Instantiate(rock_prefab, GenerateSpawnPosition(false, 1f), rock_prefab.transform.rotation);
    }

    void SpawnWave()
    {
        Instantiate(
            wave_prefab,
            GenerateSpawnPosition(false, 0.3f),
            wave_prefab.transform.rotation
        );
    }

    private Vector3 GenerateSpawnPosition(bool bound, float ypos)
    {
        if (bound)
        {
            int idx = Random.Range(0, 2);
            float[] border = { -xpos, xpos };
            spawn_x = border[idx];
        }
        else
        {
            spawn_x = Random.Range(-xpos, xpos);
        }

        spawn_z = Random.Range(player.transform.position.z, zpos);

        Vector3 random_pos = new Vector3(spawn_x, ypos, spawn_z);

        return random_pos;
    }
}
