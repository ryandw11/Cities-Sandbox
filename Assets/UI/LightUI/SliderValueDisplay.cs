using UnityEngine;
using UnityEngine.UI;

/**
 * <summary>
 *  Display the value of the slider in a Text component.
 * </summary>
 */
[RequireComponent(typeof(Text))]
public class SliderValueDisplay : MonoBehaviour
{
    /**
     * <summary>
     *  The slider the text should be updated for.
     * </summary>
     */
    public Slider slider;

    /**
     * <summary>
     *  The format of the text.
     *  <para>This is formated accoding to the <a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=net-5.0">string.Format()</a> method.</para>
     * </summary>
     */
    public string format = "{0}%";

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        slider.onValueChanged.AddListener(delegate { OnValueChange(); });
        // Initalize the text.
        OnValueChange();
    }

    /**
     * <summary>
     *  Change the value of the text when the slider changes it's value.
     * </summary>
     */
    void OnValueChange()
    {
        text.text = string.Format(format, slider.value);
    }
}
