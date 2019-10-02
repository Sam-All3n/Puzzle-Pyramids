using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ReadWrite : MonoBehaviour
{
    string path = ""; 
    // Use this for initialization
    void Start()
    {
        path = Application.dataPath + @"/data/data.csv";
    }

    // Update is called once per frame
    void Update()
    {
        List<HighScore> res = ReadFiles();
        foreach (HighScore HS in res)
        {
           // print(HS.Name);
        }
    }

    public List<HighScore> ReadFiles()
    {
        List<HighScore> highs = new List<HighScore>();
        using (StreamReader reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                HighScore hs = new HighScore
                {
                    Name = data[0],
                    Pyr1Time = (data[1]),
                    Pyr2Time = (data[2]),
                    Pyr3Time = (data[3]),
                    TotalTime = (data[4])
                };
                highs.Add(hs);
            }
        }
        return highs;
    }


    public List<HighScore> OrderLVL1Time(List<HighScore> highs)
    {
        highs = highs.OrderBy(x => x.Pyr1Time).ToList();
        return highs;
    }

    public List<HighScore> OrderLVL2Time(List<HighScore> highs)
    {
        highs = highs.OrderBy(x => x.Pyr2Time).ToList();
        return highs;
    }

    public List<HighScore> OrderLVL3Time(List<HighScore> highs)
    {
        highs = highs.OrderBy(x => x.Pyr3Time).ToList();
        return highs;
    }

    public List<HighScore> OrderTotalTime(List<HighScore> highs)
    {
        highs = highs.OrderBy(x => x.TotalTime).ToList();
        return highs;
    }

    public void WriteFile(HighScore hs)
    {
        using(StreamWriter writer = new StreamWriter(path, true))
        {
            string line = hs.Name + "," + hs.Pyr1Time + "," + hs.Pyr2Time + "," + hs.Pyr3Time + "," + hs.TotalTime;
            writer.WriteLine(line);
        }
    }
}

public class HighScore
{
    public string Name { get; set; }
    public string Pyr1Time { get; set; }
    public string Pyr2Time { get; set; }
    public string Pyr3Time { get; set; }
    public string TotalTime { get; set; }

    public HighScore() { }
}
