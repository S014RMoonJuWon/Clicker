using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI upgradeClickPowerCostTxt;
    public TextMeshProUGUI upgradeGeneratePowerCostTxt;

    public float score { get; set; } = 0;
    public float clickPower { get; private set; } = 1;  // 클릭 당 생산량
    public float upgradeClickPowerCost { get; private set; } = 30; // 클릭 당 생산량 강화 비용
    public float upgradeGeneratePowerCost { get; private set; } = 30;   // 초당 생산량 강화 비용
    private float upgradePower = 2;    // 클릭 당 생산량 강화량
    public float perSecondScore { get; private set; } = 1;  // 초당 생산량

    public int powerLevel { get; private set; } = 1;             // 클릭 당 생산량 레벨
    public int perSecondScoreLevel { get; private set; } = 1;    // 초당 생산량 레벨



    public void OnClickPowerUpClick()   // 클릭 파워 업 버튼
    {
        if( score >= upgradeClickPowerCost )
        {
            clickPower += upgradePower;

            upgradePower += Mathf.Ceil(upgradePower * 1.1f);

            score -= upgradeClickPowerCost;

            upgradeClickPowerCost += Mathf.Ceil(upgradeClickPowerCost * 1.7f);

           powerLevel++;
        }
    }

    public void OnGeneratePowerUpClick()    // 초당 생산량 파워 업 버튼
    {
        if (score >= upgradeGeneratePowerCost)
        {
            perSecondScore += Mathf.Ceil(perSecondScore * 1.1f);

            score -= upgradeGeneratePowerCost;

            upgradeGeneratePowerCost += Mathf.Ceil(upgradeGeneratePowerCost * 1.7f);

            perSecondScoreLevel++;
        }
    }
}
