using UnityEngine;
using UnityEngine.EventSystems;

public class CompassClick : MonoBehaviour, IPointerClickHandler {
    public float speed = 0.8f;
    
    private Animator animator;
    private float animTime;
    private bool anim_Play;
    
    void Start() {
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        if (anim_Play && animTime < 1)      
            animTime += speed * Time.deltaTime;
        else if (!anim_Play && animTime > 0)
            animTime -= speed * Time.deltaTime;

        animator.Play("CompassClick", 0, animTime);
    }

    public void OnPointerClick(PointerEventData eventData) {
        ToggleAnim();
    }

    public void ToggleAnim() {
        anim_Play = !anim_Play;
    }
}
