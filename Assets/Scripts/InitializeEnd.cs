using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitializeEnd : MonoBehaviour
{
    private TaskValues value;

    private GameObject playerMain;
    private GameObject light;

    [SerializeField]
    private Text text;

    [SerializeField]
    private Material mat1;

    [SerializeField]
    private string scene;
    [SerializeField]
    private GameObject camera;

    private string ending;


    // Start is called before the first frame update
    void Start()
    {
        playerMain = GameObject.Find("Player");
        playerMain.SetActive(false);
        camera.SetActive(true);

        value = playerMain.GetComponent<TaskValues>();

        ///////////////////////////////////////////
        ///// Endings
        //////////////////////////////////////////
        if (value.GetData())
        {
            if ((value.GetFoodValue() == 2) && (value.GetSuppliesValue() == 2))
            {
                text.text = @"You arrived at the ship just in time, the crew and inhabitants of the colony were already starting to"+
                            " wonder whether you made it. Luckily you did not only made it in time but managed to bag enough" +
                            " food supplies for everyone present on the ship to survive the journey to Earth. When the virus" +
                            " brought upon by the aliens broke out you were able to provide the formula for the antidote to cure" +
                            " the crew and prevent contaminating Earth with the virus. Shortly before arriving a comet hit and" +
                            " damaged the ship which would have been fatal if again you hadn’t been able to secure enough" +
                            " supplies and materials to fix the damage on the ship. You and every inhabitant of the Mars colony" +
                            " arrive safely on Earth. ";

            }
            else if ((value.GetFoodValue() == 2) && (value.GetSuppliesValue() == 1))
            {
                text.text = @"You arrive at the ship where the crew and inhabitants of your mars colony have already been" +
                            " waiting for you. You safely leave Mars and steer into the direction of Earth. With the food supplies" +
                            " you bagged and the formula you retrieved you are able to feed everyone on the ship comfortably" +
                            " and also cure everyone from the virus once it broke out. But when the comet hit and damaged your" +
                            " ship you face damages that were only with a lot of effort repairable because you did not bring as" +
                            " many supplies and material as you could have, had you taken some more time on Mars." +
                            " Nevertheless you are able to repair the ship and safely arrive on Earth.";
            }
            else if ((value.GetFoodValue() == 2) && (value.GetSuppliesValue() == 0))
            {
                text.text = @"You arrive at the ship where the crew and inhabitants of your Mars colony have already been" +
                            " waiting for you. You safely leave the planet and steer into the direction of Earth. With the food" +
                            " supplies you bagged and the formula you retrieved you are able to feed everyone on the ship" +
                            " comfortably and also cure everyone from the virus once it broke out. But when a comet hit and" +
                            " damaged your ship you face damages on the ship that were not repairable with the tools and" +
                            " equipment you brought. You realize that you should have spent more time to retrieve more tools and" +
                            " material. The ship soon breaks down because of fuel leakage. You float around the galaxy until your" +
                            " food supplies end. You never reach Earth.";
            }
            else if ((value.GetFoodValue() == 1) && (value.GetSuppliesValue() == 2))
            {
                text.text = @"You arrive at the ship where the crew and inhabitants are already waiting for you to leave mars as" +
                            " quickly as possible. It seems like you are ready to start the month long journey back to earth when" +
                            " you realize that the food supplies might be just enough to arrive at earth if you ration the food from" +
                            " the beginning on. As it turns out your assumption was correct and neither the virus that broke out" +
                            " nor the comet that hit the ship were able to drag you and the ship down but the food supplies" +
                            " became more and more tight. You are able to arrive on Earth famished but alive without a single" +
                            " member lost due to starvation. ";
            }
            else if((value.GetFoodValue() == 1) && (value.GetSuppliesValue() == 1))
            {
                text.text = @"You arrive at the ship where the crew and inhabitants of your Mars colony have already been" +
                            " waiting for you. You safely leave the planet and steer into the direction of Earth. With the food" +
                            " supplies you bagged and the formula you retrieved you know you will be able to cure everyone if" +
                            " the virus breaks out but you already worry about the amount of food you brought and whether it" +
                            " will be enough for everyone to reach Earth. You therefore rationed the food from the beginning on" +
                            " and everything seemed fine for a moment. But when the comet hit and damaged your ship you" +
                            " faced damages on the ship that were barely repairable with the tools and equipment you brought." +
                            " You realized that you should have spent more time to retrieve more tools and material. But you are" +
                            " nevertheless with a lot of effort able to repair the ship. You are able to arrive on Earth famished but" +
                            " alive.";
            }
            else if ((value.GetFoodValue() == 1) && (value.GetSuppliesValue() == 0))
            {
                text.text = @"You arrive at the ship where the crew and inhabitants of your mars colony have already been" +
                            " waiting for you. You safely leave Mars and steer into the direction of Earth. With the food supplies" +
                            " you bagged and the formula you retrieved you know you will be able to cure everyone if the virus" +
                            " breaks out but already worry about the amount of food you brought and whether it will be enough" +
                            " for everyone to reach earth. You therefore rationed the food from the beginning on and everything" +
                            " seemed fine for a moment. But when a comet hit and damaged your ship you faced damages on the" +
                            " ship that were not repairable with the tools and equipment you brought. You realized that you" +
                            " should have spent more time to retrieve more tools and material. The ship soon breaks down" +
                            " because of fuel leakage. You float around the galaxy until your food supplies end. You never reach" +
                            " Earth.";
            }
            else if ((value.GetFoodValue() == 0) && (value.GetSuppliesValue() == 2))
            {
                text.text = @"You arrived safely at the ship with the formula to cure the virus in case it breaks out and the" +
                            " supplies to repair any damages at the ship at hand. But once you leave Mars you realize that the" +
                            " food you brought will never be enough for everyone on the ship to reach Earth alive. By the time" +
                            " this realization hits it is already too late to turn back and you understand that you will have to face" +
                            " the consequences. Even though you try to ration the food supplies as much as possible soon the first" +
                            " members of the ship die of starvation and not long after the rest follows. You never reach Earth.";
            }
            else if ((value.GetFoodValue() == 0) && (value.GetSuppliesValue() == 1))
            {
                text.text = @"You arrived safely at the ship with the formula to cure the virus in case it breaks out and at least" +
                            " some supplies to repair damages at the ship. But once you leave Mars you realize that the food you" +
                            " brought will never be enough for everyone on the ship to reach Earth alive. By the time this" +
                            " realization hits you it is already too late to turn back and you understand that you will have to face" +
                            " the consequences. Even though you try to ration the food supplies as much as possible soon the first" +
                            " members of the ship die of starvation and not long after the rest follows. You never reach Earth.";
            }
            else if ((value.GetFoodValue() == 0) && (value.GetSuppliesValue() == 0F))
            {
                text.text = @"You arrive at the ship where the crew and inhabitants of your Mars colony have already been" +
                            " waiting for you. You proudly present the formula for the antidote for the virus that was brought" +
                            " upon you. But the happiness is not very long lived as you realize that the food supplies you brought" +
                            " will never be enough for everyone to survive the month long journey and arrive safely on Earth. By" +
                            " the time this realization hits it is already too late to turn back and you understand that you will have" +
                            " to face the consequences. Even though you try to ration the food supplies as much as possible, soon" +
                            " the first members of the ship die of starvation and not long after the rest follows. You never reach" +
                            " Earth.";
            }
        }
        else
        {
            if ((value.GetFoodValue() == 2) && (value.GetSuppliesValue() == 2))
            {
                text.text = @"You arrived at the ship in time but did not manage to secure the formula to cure the virus brought"+
                            " upon your colony.For now everybody hopes that the symptoms and consequences won’t be too"+
                            " harsh.The first part of your journey runs smoothly, you have enough food supplies to feed everyone"+
                            " present on the ship and also when a comet hits the ship you are able to provide the necessary"+
                            " equipment to fix the damage.But then more and more crew members begin to feel unwell and soon"+
                            " it is obvious that the virus is spreading.For some time it seems like this will be the end of the"+
                            " journey but due to the healthy and luxuriant food supply you brought, people are able to handle the"+
                            " virus and recover from the virus without the antidote. You reach Earth safely without a single"+
                            " person lost to the virus.";
            }
            else if ((value.GetFoodValue() == 2) && (value.GetSuppliesValue() == 1))
            {
                text.text = @"You arrived at the ship just in time, the crew and inhabitants of the colony were already starting to"+
                            " wonder whether you made it. Luckily you did not only made it in time but managed to bag enough"+
                            " food supplies for everyone present on the ship to survive the journey to earth. Everything seems"+
                            " fine for a moment until a comet hits your ship and damages the ship nearly beyond repair. But you"+
                            " manage to use the material in such a way that it is enough to fix the damage. You are hoping that for"+
                            " the rest of the journey the ship is not going to need more repairing as you used up everything you"+
                            " brought. Soon people around you begin to feel ill and it becomes obvious really quick that the virus"+
                            " did indeed break out. More and more passengers on the ship catch the virus but luckily due to the"+
                            " generous food supplies you brought people were healthy and some manage to recover from the"+
                            " disease. You reach Earth with a few less passengers than you started the journey with.";
            }
            else if ((value.GetFoodValue() == 2) && (value.GetSuppliesValue() == 0))
            {
                text.text = @"You arrive at the ship where the crew and inhabitants of your Mars colony have already been"+
                            " waiting for you. You safely leave the planet and steer into the direction of Earth. With the food"+
                            " supplies you bagged you are able to feed everyone on the ship comfortably. But when a comet hit"+
                            " and damaged your ship you face damages that were not repairable with the tools and equipment you"+
                            " brought. You realize that you should have more time to retrieve tools and material. The ship soon"+
                            " breaks down because of fuel leakage. You float around the galaxy until your food supplies end. You"+
                            " never reach Earth.";
            }
            else if ((value.GetFoodValue() == 1) && (value.GetSuppliesValue() == 2))
            {
                text.text = @"You arrive at the ship where everyone is waiting for you already to leave Mars. Even though you"+
                            " managed to secure a lot of equipment and different tools that might come in handy if the ship needs"+
                            " maintenance during the journey, you realize that the food supplies you brought probably need to be"+
                            " rationed. As it turns out you were right and rationing the food was necessary but what you hadn’t"+
                            " anticipated was that the virus brought upon you by the aliens might still break out on the ship and"+
                            " you hadn’t managed to retrieve the formula from the laboratory to cure the virus if it breaks out."+
                            " Soon the first passengers become ill and more follow. You are at a loss at what to do and accept"+
                            " your fate. Your ship never reaches Earth. ";
            }
            else if ((value.GetFoodValue() == 1) && (value.GetSuppliesValue() == 1))
            {
                text.text = @"You arrive at the ship where the crew and inhabitants of your Mars colony have already been"+
                            " waiting for you. You safely leave the planet and steer into the direction of Earth. But soon you begin"+
                            " to worry about the amount of food you brought and whether it will be enough for everyone to reach"+
                            " earth. You therefore rationed the food from the beginning on and everything seemed fine for a"+
                            " moment. But when the comet hit and damaged your ship you faced damages on the ship that were"+
                            " barely repairable with the tools and equipment you brought. You realized that you should have spent"+
                            " more time to retrieve tools and material. But you are nevertheless with a lot of effort able to repair"+
                            " the ship. It seems like there is no time to relax as soon more and more people begin to catch the"+
                            " virus that was brought upon you by the aliens on Mars. As you had not managed to retrieve the"+
                            " formula for the antidote to the virus you had hoped the virus would not break out. It turns out"+
                            " nobody is able to recover without the antidote and you realize you should have spent more time in"+
                            " the laboratory to get the formula. You never reach Earth. ";
            }
            else if ((value.GetFoodValue() == 1) && (value.GetSuppliesValue() == 0))
            {
                text.text = @"You arrive at the ship where the crew and inhabitants of your mars colony have already been"+
                            " waiting for you. You safely leave Mars and steer into the direction of Earth. But soon you begin to"+
                            " worry about the amount of food you brought and whether it will be enough for everyone to reach"+
                            " earth. You therefore rationed the food from the beginning on and everything seemed fine for a"+
                            " moment. But when the comet hit and damaged your ship you faced damages on the ship that were"+
                            " not repairable with the tools and equipment you brought. You realized that you should have spent at"+
                            " least some more time to retrieve more tools and material. The ship soon breaks down because of"+
                            " fuel leakage. You float around the galaxy until your food supplies end. You never reach Earth. ";
            }
            else if ((value.GetFoodValue() == 0) && (value.GetSuppliesValue() == 2))
            {
                text.text = @"You arrive at the ship where everyone is waiting for you already to leave Mars. Even though you"+
                            " managed to secure a lot of equipment and different tools that might come in handy if the ship needs"+
                            " maintenance during the journey, you realize that the food supplies you brought will never be enough"+
                            " for everyone to survive the journey to Earth. As it turns out you were right and soon people begin to"+
                            " feel the hunger. What you also hadn’t anticipated was that the virus brought upon you by the aliens"+
                            " might still break out on the ship and you hadn’t managed to retrieve the formula from the laboratory"+
                            " to cure the virus in case it breaks out. People around you not only start to catch the virus but start to"+
                            " suffer the consequences of the little food you brought. You are at a loss at what to do and accept"+
                            " your fate. Your ship never reaches Earth.";
            }
            else if ((value.GetFoodValue() == 0) && (value.GetSuppliesValue() == 1))
            {
                text.text = @"You arrive at the ship where everyone is waiting for you already to leave Mars. Quickly you realize"+
                            " that the food supplies you brought will never be enough for everyone to survive the journey to"+
                            " Earth. As it turns out you were right and soon people begin to feel the hunger. What you also hadn’t"+
                            " anticipated was that the virus brought upon you by the aliens might still break out on the ship and"+
                            " you hadn’t managed to retrieve the formula to cure the virus from the laboratory if it breaks out."+
                            " People around you not only start to catch the virus but start to suffer the consequences of little food"+
                            " you brought. You are at a loss at what to do and accept your fate. Your ship never reaches Earth.";
            }
            else if ((value.GetFoodValue() == 0) && (value.GetSuppliesValue() == 0))
            {
                text.text = @"Even though you arrive at the ship where everyone was waiting for you soon not only you but" +
                            " everybody realizes that you are doomed to die and to never reach Earth. All the inhabitants on the" +
                            " ship were counting on you but you did not manage to bring enough food, the formula to cure the" +
                            " virus in case it breaks out or enough equipment to keep the ship intact during the journey. As" +
                            " predicted soon you are faced with all the mentioned problems. People die of starvation, people die" +
                            " because they caught the virus and the ship is damaged beyond repair. You never reach Earth.";
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            RenderSettings.skybox = mat1;
            playerMain.SetActive(true);
            SceneManager.LoadScene(scene);


        }
    }
}
