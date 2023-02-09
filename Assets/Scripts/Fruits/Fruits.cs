using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Fruits : MonoBehaviour
{
    // Fruit variables
    [SerializeField] protected Color fruitColor;
    [SerializeField] protected TextMeshProUGUI infosUI;
    [SerializeField] private string m_fruitName;
    [SerializeField] protected string fruitName //ENCAPTULASTINODGDG
    { 
        get { return m_fruitName; }
        set { m_fruitName = value; }
    
    }
    


    protected Renderer fruitRenderer;
    [SerializeField] protected TextMeshPro fruitText;
    [SerializeField] protected string fruitTextIntroduction;

    /// <summary>
    /// It is in range of the object and can interact with it
    /// </summary>
    [SerializeField] protected bool isInteractable = false;
    

    protected void Start()
    {
        
        fruitRenderer = GetComponent<Renderer>();
        ChangeColor(fruitColor);

        
    }
   
    
    protected void ChangeColor(Color color) //POLYMORPHISM?
    {
        fruitRenderer.material.color = fruitColor;
    }

    public virtual void Eatable()
    {
        infosUI.text = $"{fruitName} was eaten";
        Destroy(gameObject);
    }

    public virtual void DisplayText() //POLYMORPHISM
    {
        fruitText.text = fruitTextIntroduction;
    }


    
    private void OnTriggerEnter(Collider other)
    {
        isInteractable = true;
        DisplayText();
    }

    private void OnTriggerExit(Collider other)
    {
        isInteractable = false;
    }


}
