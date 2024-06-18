using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelUp : MonoBehaviour
{
    public Image mainImage;

    public TextMeshProUGUI upgradePokedexCostTxt;

    public float upgradePokedexCost { get; private set; } = 90; // 도감 업그레이드 강화 비용
    public int pokedexLevel { get; private set; } = 1;  // 도감 레벨

    private List<Sprite> sprites;
    private List<Sprite> restSprites;

    private Score Score;
    private void Awake()
    {
        Score = GetComponent<Score>();
    }

    private void Start()
    {
        sprites = new List<Sprite>(Resources.LoadAll<Sprite>("Sprite/Dictionary"));
        restSprites = new List<Sprite>(sprites);
    }

    public void OnPokedexLevelUp()  // 도감 레벨업 버튼
    {
        if (Score.score >= upgradePokedexCost) 
        {
            Score.score -= upgradePokedexCost;
            upgradePokedexCost += Mathf.Ceil(upgradePokedexCost * 1.3f);
            pokedexLevel++;

            Sprite newSprite = GetRandomSprites();
            mainImage.sprite = newSprite;
            restSprites.Remove(newSprite);
        }
    }

    private Sprite GetRandomSprites()   // 랜덤 이미지 반환
    {
        int randomIndex = Random.Range(0, restSprites.Count);
        return restSprites[randomIndex];
    }
}
