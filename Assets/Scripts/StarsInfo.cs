using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsInfo : MonoBehaviour
{
	public Sprite goldStar;
	public Sprite blackStar;
	public Image[] starImages;

	void Start()
    {
		int stars = PlayerPrefs.GetInt(GetComponentInChildren<Text>().text);

		foreach (var image in starImages)
			image.sprite = blackStar;

		if (stars >= 1)
			for (int i = 0; i < stars; i++)			
				starImages[i].sprite = goldStar;
			
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
