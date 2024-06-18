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

    public float upgradePokedexCost { get; private set; } = 90; // ���� ���׷��̵� ��ȭ ���
    public int pokedexLevel { get; private set; } = 1;  // ���� ����

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

    public void OnPokedexLevelUp()  // ���� ������ ��ư
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

    private Sprite GetRandomSprites()   // ���� �̹��� ��ȯ
    {
        int randomIndex = Random.Range(0, restSprites.Count);
        return restSprites[randomIndex];
    }
}
