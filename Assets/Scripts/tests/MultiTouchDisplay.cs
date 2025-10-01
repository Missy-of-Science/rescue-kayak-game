using TMPro;
using UnityEngine;

public class MultiTouchDisplay : MonoBehaviour
{
    public TextMeshProUGUI multiTouchInfoDisplay;
    private int maxTapCount = 0;
    private string multiTouchInfo;
    private Touch theTouch;

    // Update is called once per frame
    void Update()
    {
        multiTouchInfo = $"Max tap count: {maxTapCount}\n";

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                theTouch = Input.GetTouch(i);

                multiTouchInfo += string.Format(
                    "Touch {0} - Position {1} - Tap Count: {2} - Finger ID: {3}\nRadius: {4} ({5}%)\n",
                    i,
                    theTouch.position,
                    theTouch.tapCount,
                    theTouch.fingerId,
                    theTouch.radius,
                    (
                        (theTouch.radius / (theTouch.radius + theTouch.radiusVariance)) * 100f
                    ).ToString("F1")
                );

                if (theTouch.tapCount > maxTapCount)
                {
                    maxTapCount = theTouch.tapCount;
                }
            }
        }

        multiTouchInfoDisplay.text = multiTouchInfo;
    }
}
