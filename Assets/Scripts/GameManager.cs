using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoxCollider2D clickZone;
    public SpriteRenderer clickZoneRenderer;
    private Score Score;
    private LevelUp LevelUp;

    private void Awake()
    {
        Score = GetComponent<Score>();
        LevelUp = GetComponent<LevelUp>();
    }

    private void Start()
    {
        Color color = clickZoneRenderer.color;
        color.a = 0f;
        clickZoneRenderer.color = color;

        StartCoroutine("PerSecondScoreGenerate");
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (rayHit.collider != null)
        {
            if (rayHit.collider == clickZone && Input.GetMouseButtonDown(0))
            {
                Score.score += Score.clickPower;
                UpdateUI();
            }
        }
    }

    IEnumerator PerSecondScoreGenerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Score.score += Score.perSecondScore;
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        Score.scoreTxt.text = Score.score.ToString();
        Score.upgradeClickPowerCostTxt.text = $"Cost : {Score.upgradeClickPowerCost}\n Lv. {Score.powerLevel}";
        Score.upgradeGeneratePowerCostTxt.text = $"Cost : {Score.upgradeGeneratePowerCost}\n Lv. {Score.perSecondScoreLevel}";
        LevelUp.upgradePokedexCostTxt.text = $"Cost : {LevelUp.upgradePokedexCost}\n Lv. {LevelUp.pokedexLevel}";
    }
}
