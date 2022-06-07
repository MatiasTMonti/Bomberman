using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ReadMap : MonoBehaviour
{
    [SerializeField] private GameObject pared;
    [SerializeField] private GameObject caminable;
    [SerializeField] private GameObject destruible;
    [SerializeField] private GameObject player;

    private Camera cam;

    private int offset = 0;

    private void Start()
    {
        cam = Camera.main;
        ReadFileMap();
    }

    public void ReadFileMap()
    {
        string filePath = @"Assets/Maps/Map.txt";

        List<string> lines = new List<string>();
        lines = File.ReadAllLines(filePath).ToList();

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
                else if(line[i] == 'D')
                {
                    Instantiate(destruible, new Vector3(i * 1.0f, offset + 0, 0), Quaternion.identity);
                    Instantiate(caminable, new Vector3(i * 1.0f, offset + 0, 0), Quaternion.identity);
                }
            }
        }
    }
}
