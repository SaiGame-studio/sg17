using UnityEngine;

public abstract class PlayerAbstract : SaiBehaviour
{
    [SerializeField] protected PlayerCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
