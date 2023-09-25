using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {

    }

    public void Save(GameData data)
    {
        // Use Path.Combine to account for different OS's having different path separators
        string fullPath = fullPath.Combine(dataDirPath, dataFileName);

        try{
            // Create the directory the file will be written to if it doesn't already exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serialize the C# game data object into Json
            string dataToStore = JsonUtility.ToJson(data, true);

            // Write the serialized data to the file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)){
                using (StreamWriter writer = new StreamWriter(stream){
                    writer.Write(dataToStore);
                })
            }
        }

        catch (Exception e){
            Debug.LogError("Error occured when trying to save data to file: " + fullPathPath + "\n" + e);
        }
    }
}
