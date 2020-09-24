using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public RectTransform Menu;
	public RectTransform LevelEnd;
	private bool isOnPause = false;
	private string currLevel = "CurrentLevel"; // ключ PlayerPrefs для сохранения номера загруженной сцены

    public void LoadSelected()
	{
		if (!GetComponentInChildren<Text>())
		{
			Debug.Log("[LevelLoader] - на объекте с этим скриптом нет компонента Text\nСкрипт отключен.");
			this.enabled = false;
		}

		int levelNumber = int.Parse(GetComponentInChildren<Text>().text);
		UpdatePlayerPrefs(levelNumber);
		SceneManager.LoadScene(levelNumber);
		Time.timeScale = 1;
	}

	public void LoadNext()
	{
		int nextLevelNumber = PlayerPrefs.GetInt(currLevel) + 1;
		//if (SceneManager.sceneCount < nextLevelNumber) return;  // если сцены кончились, то кнопка "вперед" не будет работать
		UpdatePlayerPrefs(nextLevelNumber);
		 
		if (nextLevelNumber < 4)
		{
			SceneManager.LoadScene(nextLevelNumber);
		}
		else
		{
			SceneManager.LoadScene(0);
		}
		Time.timeScale = 1;
	}
	public void Reload()
	{
		int levelNumber = PlayerPrefs.GetInt(currLevel);
		SceneManager.LoadScene(levelNumber);
		Time.timeScale = 1;
	}
	public void LoadMainMenu()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	}

	private void UpdatePlayerPrefs(int levelNumber)
	{
		if (PlayerPrefs.HasKey(currLevel))
		{
			PlayerPrefs.DeleteKey(currLevel);
			PlayerPrefs.SetInt(currLevel, levelNumber);
		}
		else
			PlayerPrefs.SetInt(currLevel, levelNumber);
	}
	public void ShowMenu()
	{
		if (!Menu)
		{
			Debug.Log("[LevelLoader] - к скрипту не присоединен префаб Menu\nСкрипт отключен.");
			this.enabled = false;
		}		

		if (isOnPause)
		{
			Time.timeScale = 1;
			Menu.gameObject.SetActive(false);
		}
		else
		{
			Time.timeScale = 0;
			Menu.gameObject.SetActive(true);
		}
		isOnPause = !isOnPause;
	}

	public void ShowLevelEnd()
	{
		if (!LevelEnd)
		{
			Debug.Log("[LevelLoader] - к скрипту не присоединен префаб LevelEnd\nСкрипт отключен.");
			this.enabled = false;
		}
		LevelEnd.gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("Stars").GetComponent<Stars>().SaveData();
	}
}
