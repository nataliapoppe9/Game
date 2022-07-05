using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveGame
{
    //Ruta para guardar el archivo de guardado
    //dataPath accede a la carpeta del juego dependiendo del sistema en el q esté
    private static readonly string SaveFolder = Application.dataPath + "/Saves/";
    private const string saveExtension = "txt";

    public static void Init()
    {
        //comprobar si existe el directorio y sino lo creo
        if (!Directory.Exists(SaveFolder))
        {
            Directory.CreateDirectory(SaveFolder);
        }
    }


    //Guardar varias partidas o historico de guardado
    public static void Save(string saveString)
    {
        int saveNumber = 1;
        while (File.Exists(SaveFolder + "save_" + saveNumber + " " + saveExtension))
        {
            saveNumber++;
        }

        // Si quisieramos machacar el archivo no necesitamos saveNumber
        //guardamos saveString que ya contiene la info del JSON y los datos
        File.WriteAllText(SaveFolder + "save_" + saveNumber + " " + saveExtension, saveString);


    }

    public static string Load()
    {
        // "* " es todo lo que haya dentro
        DirectoryInfo directoryInfo = new DirectoryInfo(SaveFolder);

        FileInfo[] saveFiles = directoryInfo.GetFiles("* " + saveExtension);


        FileInfo mostRecentFile = null;
        foreach (FileInfo fileInfo in saveFiles)
        {
            if (mostRecentFile == null)
            {
                mostRecentFile = fileInfo;
            }
            else
            {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = fileInfo;
                }
            }
        }

        string saveString = File.ReadAllText(mostRecentFile.FullName);
        return saveString;
    }

}