using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string LEVEL_KEY = "level_unlocked_";
	const string PLAYER_NAME_KEY = "player_name";
	const string LEVEL_SCORE_KEY = "level_score_";
	const string LEVEL_SCORE_MAX_KEY = "level_score_max_";
	
	public static void SetMasterVolume (float volume){
		if (volume >=0f && volume <=1f){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range");
		}
	}
	
	public static float GetMasterVolume (){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level){
		if (level <= SceneManager.sceneCountInBuildSettings -1){
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(),1);
		} else {
			Debug.LogError("Trying to unlock level not in build order");
		}
	}

	public static void LockLevel (int level){
		if (level <= SceneManager.sceneCountInBuildSettings -1){
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(),0);
		} else {
			Debug.LogError("Trying to unlock level not in build order");
		}
	}
	
	public static bool IsLevelUnocked (int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue ==1);

		if (level <= SceneManager.sceneCountInBuildSettings -1){
			return isLevelUnlocked;
		} else {
			Debug.LogError("Trying to query level not in build order");
			return false;
		}	
	}

	public static void SetPLayerName (string name){
		PlayerPrefs.SetString (PLAYER_NAME_KEY, name);
	}
	
	public static string GetPlayerName (){
		return PlayerPrefs.GetString (PLAYER_NAME_KEY);
	}


	public static void SetLevelScore (int level,int score){
		if (score >=0 && score <=300){
			PlayerPrefs.SetInt (LEVEL_SCORE_KEY + level.ToString(), score);
		} else {
			Debug.LogError("Score out of range");
		}
	}

	public static int GetLevelScore (int gamelevel){
		return PlayerPrefs.GetInt (LEVEL_SCORE_KEY + gamelevel.ToString());
	}

	public static void SetLevelScoreMax (int gamelevel,int score){
		PlayerPrefs.SetInt (LEVEL_SCORE_MAX_KEY + gamelevel.ToString(), score);
	}

	public static int GetLevelScoreMax (int gamelevel){
		return PlayerPrefs.GetInt (LEVEL_SCORE_MAX_KEY + gamelevel.ToString());
	}

}
