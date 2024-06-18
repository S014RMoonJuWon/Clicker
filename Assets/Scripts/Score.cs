using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI upgradeClickPowerCostTxt;
    public TextMeshProUGUI upgradeGeneratePowerCostTxt;

    public float score { get; set; } = 0;
    public float clickPower { get; private set; } = 1;  // Ŭ�� �� ���귮
    public float upgradeClickPowerCost { get; private set; } = 30; // Ŭ�� �� ���귮 ��ȭ ���
    public float upgradeGeneratePowerCost { get; private set; } = 30;   // �ʴ� ���귮 ��ȭ ���
    private float upgradePower = 2;    // Ŭ�� �� ���귮 ��ȭ��
    public float perSecondScore { get; private set; } = 1;  // �ʴ� ���귮

    public int powerLevel { get; private set; } = 1;             // Ŭ�� �� ���귮 ����
    public int perSecondScoreLevel { get; private set; } = 1;    // �ʴ� ���귮 ����



    public void OnClickPowerUpClick()   // Ŭ�� �Ŀ� �� ��ư
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

    public void OnGeneratePowerUpClick()    // �ʴ� ���귮 �Ŀ� �� ��ư
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
