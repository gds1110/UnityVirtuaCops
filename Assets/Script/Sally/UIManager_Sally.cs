using UnityEngine;
using UnityEngine.SceneManagement; // �� ������ ���� �ڵ�
using UnityEngine.UI; // UI ���� �ڵ�

// �ʿ��� UI�� ��� �����ϰ� ������ �� �ֵ��� ����ϴ� UI �Ŵ���
public class UIManager_Sally : MonoBehaviour
{
    // �̱��� ���ٿ� ������Ƽ
    public static UIManager_Sally instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager_Sally>();
            }

            return m_instance;
        }
    }

    private static UIManager_Sally m_instance; // �̱����� �Ҵ�� ����

    public Text ammoText; // ź�� ǥ�ÿ� �ؽ�Ʈ
    public Text scoreText; // ���� ǥ�ÿ� �ؽ�Ʈ
    public Text waveText; // �� ���̺� ǥ�ÿ� �ؽ�Ʈ
    public GameObject gameoverUI; // ���� ������ Ȱ��ȭ�� UI 

    // ź�� �ؽ�Ʈ ����
    public void UpdateAmmoText(int magAmmo, int remainAmmo)
    {
        ammoText.text = magAmmo + "/" + remainAmmo;
    }

    //// ���� �ؽ�Ʈ ����
    //public void UpdateScoreText(int newScore)
    //{
    //    scoreText.text = "Score : " + newScore;
    //}

    //// �� ���̺� �ؽ�Ʈ ����
    //public void UpdateWaveText(int waves, int count)
    //{
    //    waveText.text = "Wave : " + waves + "\nEnemy Left : " + count;
    //}

    //// ���� ���� UI Ȱ��ȭ
    //public void SetActiveGameoverUI(bool active)
    //{
    //    gameoverUI.SetActive(active);
    //}

    //// ���� �����
    //public void GameRestart()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}