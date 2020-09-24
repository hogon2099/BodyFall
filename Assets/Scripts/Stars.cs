using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
	private string currLevel = "CurrentLevel";
	public int allowedForThreeStars = 1;
	public int allowedForTwoStars = 2;
	public int allowedForOneStar = 3;

	public int shotedShots = 0;
	public int stars = 3;

	public Sprite goldStar;
	public Sprite blackStar;
	public SpriteRenderer[] starSprites;
	public Image[] starImages;

    void Start()
    {
	}

	// Update is called once per frame
	void Update()
	{
		if (shotedShots == allowedForThreeStars) stars = 3;
		if (shotedShots == allowedForTwoStars) stars = 2;
		if (shotedShots == allowedForOneStar) stars = 1;
		if (shotedShots > allowedForOneStar) stars = 0;

		foreach (var sprite in starSprites)
			sprite.sprite = blackStar;

		foreach (var image in starImages)
			image.sprite = blackStar;

		if (stars >= 1)
			for (int i = 0; i < stars; i++)
			{
				starSprites[i].sprite = goldStar;
				starImages[i].sprite = goldStar;
			}		
	}
	public void SaveData()
	{
		string level = PlayerPrefs.GetInt(currLevel).ToString();
		if (PlayerPrefs.HasKey(level))
		{
			if(PlayerPrefs.GetInt(level) < stars)
				PlayerPrefs.SetInt(level, stars);
		}
		else
		{
			PlayerPrefs.SetInt(level, stars);
		}

	}
}
