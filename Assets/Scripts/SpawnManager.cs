using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameManager
{
    private float zpos = 75f;
    private float xpos = 25f;
    private float spawn_x;
    private float spawn_z;

    private int swimmer_c;

    // private int wave_c;

    public GameObject swimmer_prefab;
    public GameObject[] rock_prefab;
    public GameObject wave_prefab;
    public GameObject damsel_prefab;
    private GameObject player;

    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        player = GameObject.Find("Player");

        for (int i = 0; i < 6 * difficulty; i++)
        {
            SpawnRock();
        }
        SpawnDamsel();

        StartCoroutine(SpawnSwimmer());
        titleScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    IEnumerator SpawnSwimmer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            swimmer_c = FindObjectsByType<ObstacleSwimmer>(FindObjectsSortMode.None).Length;
            if (swimmer_c < 5)
            {
                Instantiate(
                    swimmer_prefab,
                    GenerateSpawnPosition(true),
                    swimmer_prefab.transform.rotation
                );
            }
        }
    }

    void SpawnDamsel()
    {
        spawn_x = Random.Range(-xpos + 3, xpos - 3);
        Vector3 random_pos = new Vector3(spawn_x, 0.1f, 40);
        Instantiate(damsel_prefab, random_pos, transform.rotation);
    }

    void SpawnRock()
    {
        int idxr = Random.Range(0, 4);
        Instantiate(
            rock_prefab[idxr],
            GenerateSpawnPosition(false),
            rock_prefab[idxr].transform.rotation
        );
    }

    void SpawnWave()
    {
        Instantiate(wave_prefab, GenerateSpawnPosition(false), wave_prefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition(bool bound)
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

        Vector3 random_pos = new Vector3(spawn_x, 0f, spawn_z);

        return random_pos;
    }
}
