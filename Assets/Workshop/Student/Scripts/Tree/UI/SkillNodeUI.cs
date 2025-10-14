using UnityEngine;
using UnityEngine.UI;
using TMPro; // ������Ѻ TextMeshPro ��Ҥس��ͧ���Сͺ���
public class SkillNodeUI : MonoBehaviour
{
    // ��ҧ�ԧ�֧ Component UI
    [Header("UI References")]
    public Button button;
    public Image background;
    public TextMeshProUGUI skillNameText; // ���� public Text skillNameText; �������� TMP

    // ��ҧ�ԧ�֧������ Skill
    [HideInInspector] public Skill skillData;

    // ʶҹ��� (��˹�������ҹ��� Inspector)
    [Header("Colors")]
    public Color colorLearned = Color.yellow;
    public Color colorAvailable = Color.green;
    public Color colorLocked = Color.gray;

    public void Initialize(Skill skill)
    {
        this.skillData = skill;
        skillNameText.text = skill.name; // ���� skill.Name; �������Ѻ Skill class

        button.onClick.AddListener(OnNodeClicked);
        UpdateUI();
    }

    public void UpdateUI()
    {
        // ��ͧ�� property isLearned 㹤��� Skill �����к�ʶҹлŴ��ͤ
        // �����: skillData.IsLearned �� true ����Ͷ١ Unlock

        if (skillData.isUnlocked) // ��� Skill �١���¹������� (Learned)
        {
            background.color = colorLearned;
            button.interactable = false; // ��ԡ�ա�����
        }
        else if (skillData.isAvailable) // ��� Skill �Ŵ��ͤ������¹����� (Available)
        {
            background.color = colorAvailable;
            button.interactable = true; // ��ԡ�������¹���
        }
        else // ��� Skill �ѧ�١��ͤ (Locked)
        {
            background.color = colorLocked;
            button.interactable = false; // ��ԡ�����
        }
    }

    private void OnNodeClicked()
    {
        if (skillData.isAvailable && !skillData.isUnlocked)
        {
            // ���¡���ʹ Unlock() 㹤��� Skill
            skillData.Unlock();

            // ����� UI �ء����ѻവʶҹ� (�����)
            SkillTreeUI.Instance.RefreshAllUI();
        }
    }
}
