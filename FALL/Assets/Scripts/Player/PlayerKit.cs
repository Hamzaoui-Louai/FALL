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
    const float DefaultCollisionCircleRadius = 0.763f;
    const float DefaultCollisionCircleYOffset = 0.762f;
    const float InvincibleCollisionCircleRadius = 0.905f;
    const float InvincibleCollisionCircleYOffset = 0.904f;
    const float ShooterCollisionCircleRadius = 1f;
    const float ShooterCollisionCircleYOffset = 0.999f;

    KitType currentKit = KitType.No_kit;
    float timer;

    CircleCollider2D circleCollider;

    public KitType GetKit() => currentKit;

    public void ApplyKit(KitType kit, float duration)
    {
        currentKit = kit;
        timer = duration * 60f;
        UpdateCollisionCircle(kit);
    }

    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        float duration = 5f;
        switch (collision.gameObject.tag)
        {
            case "Fragile": ApplyKit(KitType.Fragile, duration); break;
            case "Ice": ApplyKit(KitType.Ice, duration); break;
            case "Invincible": ApplyKit(KitType.Invincible, duration); break;
            case "Shooter": ApplyKit(KitType.Shooter, duration); break;
            case "Slime": ApplyKit(KitType.Slime, duration); break;
            case "Slowfalling": ApplyKit(KitType.Slowfalling, duration); break;
            case "Speed": ApplyKit(KitType.Speed, duration); break;
            case "Time": ApplyKit(KitType.Time, duration); break;
        }
    }

    void FixedUpdate()
    {
        if (GetKit() == KitType.No_kit) return;
        timer--;
        if (timer <= 0f)
        {
            ApplyKit(KitType.No_kit, 0f);
        }
    }

    void UpdateCollisionCircle(KitType kit)
    {
        float radius = DefaultCollisionCircleRadius;
        float yOffset = DefaultCollisionCircleYOffset;

        switch (kit)
        {
            case KitType.Invincible:
                radius = InvincibleCollisionCircleRadius;
                yOffset = InvincibleCollisionCircleYOffset;
                break;
            case KitType.Shooter:
                radius = ShooterCollisionCircleRadius;
                yOffset = ShooterCollisionCircleYOffset;
                break;
        }

        circleCollider.radius = radius;
        circleCollider.offset = new Vector2(circleCollider.offset.x, yOffset);
    }
}
