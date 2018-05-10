using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class CompassClick : MonoBehaviour, IPointerClickHandler {
    public float speed = 0.8f;
    public GameObject scenario;
    
    private Vector3 startPosition = new Vector3(0, -800.0f, 0);
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
        scenario.transform.position += startPosition;
        scenario.GetComponent<Animator>().SetBool("Show", anim_Play);
    }
}
