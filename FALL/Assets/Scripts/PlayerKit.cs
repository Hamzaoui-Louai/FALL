using UnityEngine;

public enum KitType
{
    No_kit,
    Fragile,
    Ice,
    Invincible,
    Shooter,
    Slime,
    Slowfalling,
    Speed,
    Time
}

public class PlayerKit : MonoBehaviour
{
    KitType currentKit = KitType.No_kit;
    float timer;

    public KitType GetKit() => currentKit;

    public void ApplyKit(KitType kit, float duration)
    {
        currentKit = kit;
        timer = duration;
    }

    void FixedUpdate()
    {
        if (currentKit == KitType.No_kit) return;
        timer -= Time.fixedDeltaTime;
        if (timer <= 0f)
        {
            timer = 0f;
            currentKit = KitType.No_kit;
        }
    }
}
