/*
    Copyright (C) 2010  Jason Laczko

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using UnityEngine;

public enum ConfigRunMode
{
	NEW,
	RESUME,
	PLAYBACK,
	DEBUG
}
 /// Config is a singleton.
 /// To avoid having to manually link an instance to every class that needs it, it has a static property called
 /// instance, so other objects that need to access it can just call:
 /// Config.instance.DoSomeThing();
 ///
 
//TODO - redo into generic singleton
public class Config : Singleton<Config>
{
	public float version;
	public int width = 1024;
	public int height = 768;
	
	public float volume = 1.0F;
	public bool nofullscreen = false;
	public bool showFPS = false;

	public string filename = "config.txt";

	public string home = "default";
	public string appPath = "default";
	public string expPath = "default";
	public string subjectPath = "default";
	public string subject = "default";
	public string session = "default";
	public string level = "default";
	public ConfigRunMode 	runMode = ConfigRunMode.DEBUG;
	[HideInInspector] public bool 	bootstrapped = false;
    
    // Ensure that the instance is destroyed when the game is stopped in the editor.
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 0);
        PlayerPrefs.SetInt("Screenmanager Resolution Width", 968);
        PlayerPrefs.SetInt("Screenmanager Resolution Height", 768);
    }
	
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    //Deprecated but might be important in older scripts
    public static Config instance
    {
        get { return Instance; }
    }
}

