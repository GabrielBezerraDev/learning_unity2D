using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{

    public Image image;
    public Button btn;
    public InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(createObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L)) image.gameObject.SetActive(true);
    }

    private void createObject()
    {
        Debug.Log(inputField.text);
        Sprite teste = Resources.Load<Sprite>($"Sprite/{inputField.text}");
        GameObject newObject = Resources.Load<GameObject>($"Prefabs/BaseCharacter");
        Instantiate(newObject, Vector3.zero, Quaternion.identity);
        newObject.GetComponent<BaseCharacter>().setSprite(teste);
        image.gameObject.SetActive(false);
    }

    //private void createObject()
    //{
    //    // Carrega o sprite do Resources usando o texto do inputField
    //    Sprite teste = Resources.Load<Sprite>($"Sprite/{inputField.text}");

    //    // Carrega o prefab do Resources
    //    GameObject newObject = Resources.Load<GameObject>($"Prefabs/BaseCharacter");

    //    // Instancia o prefab na posição zero com rotação padrão
    //    GameObject instantiatedObject = Instantiate(newObject, Vector3.zero, Quaternion.identity);

    //    // Esconde a imagem associada
    //    image.gameObject.SetActive(false);

    //    // Obtém o componente BaseCharacter do GameObject instanciado
    //    BaseCharacter baseCharacterComponent = instantiatedObject.GetComponent<BaseCharacter>();

    //    // Verifica se o componente BaseCharacter foi encontrado e chama a função setSprite
    //    if (baseCharacterComponent != null)
    //    {
    //        baseCharacterComponent.setSprite(teste);
    //    }
    //    else
    //    {
    //        Debug.LogError("O componente BaseCharacter não foi encontrado no prefab instanciado.");
    //    }
    //}

}
