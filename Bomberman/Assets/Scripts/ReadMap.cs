using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ReadMap : MonoBehaviour
{
    [SerializeField] private GameObject pared;
    [SerializeField] private GameObject vacio;

    private int offset = 0;

    private void Start()
    {
        ReadFileMap();
    }

    public void ReadFileMap()
    {
        string filePath = @"Assets/Maps/Map.txt";

        List<string> lines = new List<string>();
        lines = File.ReadAllLines(filePath).ToList();

        foreach (string line in lines)
        {
            offset += 1;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'X')
                {
                    Instantiate(pared, new Vector3(i * 1.0f, offset + 0, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(vacio, new Vector3(i * 1.0f, offset + 0, 0), Quaternion.identity);
                }
            }
        }
    }
}
