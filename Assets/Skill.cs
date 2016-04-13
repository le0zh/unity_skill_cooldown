using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill : MonoBehaviour
{
    // 技能的图标
    public Image icon;

    // 技能的冷却时间
    public float coolDown;

    // 技能名称，用于区分使用了哪个技能的
    public string skillName;

    // 保存当前技能的冷却时间
    private float currentCoolDown;

    // 技能的按钮
    private Button skillButton;

    public void UseSkill(string skillName)
    {
        if (currentCoolDown >= coolDown)
        {
            // 使用技能，这里只是简单的打印了。
            Debug.LogFormat("使用 【{0}】", skillName);

            // 重置冷却时间
            currentCoolDown = 0;
        }
    }

    void Start()
    {
        // 获得技能按钮，然后绑定点击事件
        this.skillButton = this.GetComponent<Button>();
        skillButton.onClick.AddListener(() => this.UseSkill(skillName));

        // 一开始冷却时满的，可以立即使用技能
        // 如果不想让玩家一开始能立即使用技能，这里设置成别的小于技能冷却的值
        currentCoolDown = coolDown;
    }

    void Update()
    {
        if (currentCoolDown < coolDown)
        {
            // 更新冷却
            currentCoolDown += Time.deltaTime;

            // 显示冷却动画
            this.icon.fillAmount = currentCoolDown / coolDown;
        }
    }
}
