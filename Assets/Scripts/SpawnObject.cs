using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.IO;

public class SpawnObject : MonoBehaviour
{
    public GameObject item;
    public Transform player;
    public InputActionReference spawnReference = null;
    public TextMeshProUGUI valueText;
    private int spawnedObjects = 0;
    private const int SpawnValue = 100;
    int avgFrameRate = 120;
    bool isSpawning = true;
    float timer = 0.0f;
    string data = "";
    bool isSaving = true;

    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);

        if (seconds > 5 && isSpawning)
        {
            Spawn();
        }
        if(!isSpawning && isSaving)
        {
            StreamWriter writer = new StreamWriter("C:/FH/6.Semester/Bachelorarbeit/test.txt");
            Debug.Log(data);
            writer.Write(data);
            writer.Close();
            isSaving = false;
        }
    }

    private void Spawn()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        avgFrameRate = (int)current;
        Debug.Log(avgFrameRate);
        if (isSpawning)
        {
            Instantiate(item, new Vector3(player.position.x, player.position.y, player.position.z + 2), Quaternion.identity);
            spawnedObjects++;
            valueText.text = "Objekte erstellt: " + spawnedObjects;
            data += spawnedObjects + ":" + avgFrameRate + ";";
            isSpawning = avgFrameRate >= 60;
        }
    }
}
