using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Add list of achievements to screen
/// </summary>
public class AchievenmentListIngame : MonoBehaviour
{
    public GameObject scrollContent;
    public GameObject lockedContent;
    public GameObject unlockedContent;
    [HideInInspector] public GameObject prefab;
    public GameObject Menu;
    public Dropdown Filter;
    [HideInInspector] public Text CountText;
    [HideInInspector] public Text CompleteText;
    [HideInInspector] public Scrollbar Scrollbar;

    private bool MenuOpen = false;
    [Tooltip("Key used to open UI menu. Set to \"None\" to prevent menu from opening with any key press")]
    public KeyCode OpenMenuKey; //Key to open in-game menu
    public bool showAchieved;
    public bool showBoth;

    /// <summary>
    /// Adds all achievements to the UI based on a filter
    /// </summary>
    /// <param name="Filter">Filter to use (All, Achieved or Unachieved)</param>
    /// 

    private void Start()
    {
/*        if (showAchieved)
        {
            Filter.value = 1;
            Debug.Log(Filter.options[Filter.value].text);
        }
        else
        {
            Filter.value = 2;
        }*/

        //ChangeFilter();
    }
    private void AddAchievements(string Filter)
    {  
        foreach (Transform child in scrollContent.transform)
        {
            Destroy(child.gameObject);
        }
        AchievementManager AM = AchievementManager.instance;
        int AchievedCount = AM.GetAchievedCount();

        CountText.text = "" + AchievedCount + " / " + AM.States.Count;
        CompleteText.text = "Complete (" + AM.GetAchievedPercentage() + "%)";

        for (int i = 0; i < AM.AchievementList.Count; i ++)
        {
            if((Filter.Equals("All")) || (Filter.Equals("Achieved") && AM.States[i].Achieved) || (Filter.Equals("Unachieved") && !AM.States[i].Achieved))
            {
                AddAchievementToUI(AM.AchievementList[i], AM.States[i]);
            }
        }
        Scrollbar.value = 1;
    }

    public void AddAchievementToUI(AchievementInfromation Achievement, AchievementState state)
    {
        UIAchievement UIAchievement = Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity).GetComponent<UIAchievement>();
        UIAchievement.Set(Achievement, state);
        

        if (showBoth)
        {
            if (state.Achieved)
            {
                UIAchievement.transform.SetParent(unlockedContent.transform);
            }
            else
            {
                UIAchievement.transform.SetParent(lockedContent.transform);
            }
                
            
        }
        else
        {
            UIAchievement.transform.SetParent(scrollContent.transform);
        }
    }
    /// <summary>
    /// Filter out a set of locked or unlocked achievements
    /// </summary>
    public void ChangeFilter ()
    {
        AddAchievements(Filter.options[Filter.value].text);
    }

    private void SetAchievements(string state, bool clearList)
    {
        if (clearList)
        {
            foreach (Transform child in unlockedContent.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in lockedContent.transform)
            {
                Destroy(child.gameObject);
            }
        }

        AchievementManager AM = AchievementManager.instance;
        int AchievedCount = AM.GetAchievedCount();

        CountText.text = "" + AchievedCount + " / " + AM.States.Count;
        CompleteText.text = "Complete (" + AM.GetAchievedPercentage() + "%)";

        for (int i = 0; i < AM.AchievementList.Count; i++)
        {
            if ((state.Equals("Achieved") && AM.States[i].Achieved) || (state.Equals("Unachieved") && !AM.States[i].Achieved))
            {
                AddAchievementToUI(AM.AchievementList[i], AM.States[i]);
            }
        }
        Scrollbar.value = 1;
    }

    /// <summary>
    /// Closes the UI window.
    /// </summary>
    public void CloseWindow()
    {
        MenuOpen = false;
        Menu.SetActive(MenuOpen);
    }
    /// <summary>
    /// Opens the UI window.
    /// </summary>
    public void OpenWindow()
    {
        MenuOpen = true;
        Menu.SetActive(MenuOpen);
        //AddAchievements("All");
        SetAchievements("Unachieved", true);
        SetAchievements("Achieved", false);
    }
    /// <summary>
    /// Toggles the state of the UI window open or closed
    /// </summary>
    public void ToggleWindow()
    {
        if (MenuOpen){
            CloseWindow();
        }
        else{
            OpenWindow();
        }
    }
 
    private void Update()
    {
        if(Input.GetKeyDown(OpenMenuKey))
        {
            ToggleWindow();
        }
    }
}