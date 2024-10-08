﻿using MHGQuestEditor.Quest;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;
using static QuestConverter.Constants;

if(args.Length > 0)
{
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    var enc = Encoding.GetEncoding("shift-jis");
    Console.OutputEncoding = enc;
    if (args[0].Contains(".mib"))
    {
        using(BinaryReader br = new(new FileStream(args[0], FileMode.Open, FileAccess.Read), enc))
        {
            QuestFile quest = new QuestFile();
            quest.loadData(br);

            WriteToJsonFile<QuestFile>(args[0].Replace(".mib",".json"), quest, false);

            Console.WriteLine(quest.questData.title);
        }
    } else if (args[0].Contains(".json"))
    {
        QuestFile quest = ReadFromJsonFile<QuestFile>(args[0]);

        Console.WriteLine(quest.questData.title);
        Console.WriteLine(quest.miniMapData[0].pos[0]);

        using(FileStream fs = new FileStream($"{args[0].Replace(".json", ".mib")}", FileMode.OpenOrCreate, FileAccess.Write)) {
            using(BinaryWriter bw = new BinaryWriter(fs, enc))
            {
                quest.write(bw);
            }
        }
    }
}

/// <summary>
/// Writes the given object instance to a Json file.
/// <para>Object type must have a parameterless constructor.</para>
/// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
/// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
/// </summary>
/// <typeparam name="T">The type of object being written to the file.</typeparam>
/// <param name="filePath">The file path to write the object instance to.</param>
/// <param name="objectToWrite">The object instance to write to the file.</param>
/// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
{
    TextWriter writer = null;
    try
    {
        var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
        writer = new StreamWriter(filePath, append);
        writer.Write(contentsToWriteToFile);
    }
    finally
    {
        if (writer != null)
            writer.Close();
    }
}

/// <summary>
/// Reads an object instance from an Json file.
/// <para>Object type must have a parameterless constructor.</para>
/// </summary>
/// <typeparam name="T">The type of object to read from the file.</typeparam>
/// <param name="filePath">The file path to read the object instance from.</param>
/// <returns>Returns a new instance of the object read from the Json file.</returns>
static T ReadFromJsonFile<T>(string filePath) where T : new()
{
    TextReader reader = null;
    try
    {
        reader = new StreamReader(filePath);
        var fileContents = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<T>(fileContents);
    }
    finally
    {
        if (reader != null)
            reader.Close();
    }
}