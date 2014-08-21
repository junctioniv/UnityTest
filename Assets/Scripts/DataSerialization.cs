using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class DataSerialization : MonoBehaviour
{
    public void Save()
    {

	    //use if saving to file
	    SaveToFile(Application.persistentDataPath + "playerInfo.dat");

    }
    public void Load()
    {
        //use for loading from file
        LoadFromFile(Application.persistentDataPath + "playerInfo.dat");
    }

    public void SaveToFile(string path)
    {
	    BinaryFormatter bf = new BinaryFormatter();

	    //PlayerInfo.dat can be the name of what ever save file you are trying to save to
	    FileStream file = File.Create(path);

	    PlayerData data = new PlayerData();
	    /*
		    set playerdata to local values
	    */

	    bf.Serialize(file, data);
	    file.Close();
    }
    
    public void LoadFromFile(string path)
    {
	    if(File.Exists(path))
	    {
		    BinaryFormatter bf = new BinaryFormatter();
		    FileStream file = File.Open(path, FileMode.Open);
		    PlayerData data = (PlayerData)bf.Deserialize(file);
		    file.Close();
		    /*
			    set the local variables to the vaules stored in the data object.
		    */

	    }
    }
}

//This is an obj
[Serializable]
class PlayerData
{
	//Data to be stored
	public float health;
	///...
}
