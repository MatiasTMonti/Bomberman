using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System;

public class ReadMap : MonoBehaviour
{
    [SerializeField] private GameObject pared;
    [SerializeField] private GameObject caminable;
    [SerializeField] private GameObject destruible;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemi;

    [SerializeField] private TextAsset mapAsset;
    string path;

    private Camera cam;

    private int offset = 0;

    private void Start()
    {
        path = Application.persistentDataPath + "/Assets/Maps";
        cam = Camera.main;
        CreateFileMap();
        ReadFileMap();

    }

    public void CreateFileMap()
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/Map.txt", mapAsset.ToString());
    }

    public void ReadFileMap()
    {
        string filePath = path + "/Map.txt";

        List<string> lines = new List<string>();
        lines = File.ReadAllLines(filePath).ToList();

        lines.Reverse();

        foreach (string line in lines)
        {
            cam.transform.position = new Vector3(lines.Count() / 2, line.Length / 2, lines.Count() < line.Length? -lines.Count() : -line.Length);

            offset += 1;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'X')
                {
                    Instantiate(pared, new Vector3(i * 1.0f, offset + 0, 0), Quaternion.identity);
                }
                else if (line[i] == 'C')
                {
                    Instantiate(caminable, new Vector3(i * 1.0f, offset + 0, 0), Quaternion.identity);
                }
                else if (line[i] == 'S')
                {
                    Instantiate(player, new Vector3(i * 1.0f, offset + 0.1f, 0), Quaternion.identity);
                    Instantiate(caminable, new Vector3(i * 1.0f, offset + 0, 0), Quaternion.identity);
                }
                else if (line[i] == 'E')
                {
                    Instantiate(enemi, new Vector3(i * 1.0f, offset + 0.1f, 0), Quaternion.identity);
                    Instantiate(caminable, new Vector3(i * 1.0f, offset + 0, 0), Quaternion.identity);
                }
                else if(line[i] == 'D')
                {
                    Instantiate(destruible, new Vector3(i * 1.0f, offset + 0, 0), Quaternion.identity);
                    Instantiate(caminable, new Vector3(i * 1.0f, offset + 0, 0), Quaternion.identity);
                }
            }
        }
    }
}
