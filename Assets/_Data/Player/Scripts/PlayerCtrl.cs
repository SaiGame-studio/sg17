using UnityEngine;

public class PlayerCtrl : SaiBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadAnimator();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(0,0.7f,0);
        this.model.localScale = new Vector3(2,2,2);
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }
}
