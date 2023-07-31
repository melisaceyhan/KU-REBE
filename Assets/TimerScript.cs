using UnityEngine;

public class DailyFunctionScheduler : MonoBehaviour
{

    public OpenCVForUnityExample.TensorflowInceptionWebCamTextureExample tensorflowInceptionWebCamTextureExample;
    // The target time for the function to be executed daily
    private int targetHour = 15;    // 8 o'clock in the morning
    private int targetMinute = 0;  // 0 minutes (you can adjust this if needed)
    private int targetSecond = 0;  // 0 seconds (you can adjust this if needed)

    private bool hasScheduled = false;

    private void Start()
    {
        ScheduleDailyFunction();
    }

    private void ScheduleDailyFunction()
    {
        if (!hasScheduled)
        {
            // Get the current time
            System.DateTime now = System.DateTime.Now;

            // Calculate the time difference to the target time
            System.TimeSpan timeToTarget = new System.TimeSpan(targetHour, targetMinute, targetSecond).Subtract(now.TimeOfDay);

            // If the target time has already passed for today, schedule it for the next day
            if (timeToTarget.TotalSeconds < 0)
            {
                timeToTarget = timeToTarget.Add(new System.TimeSpan(24, 0, 0));
            }

            // Convert the time difference to seconds
            float initialDelay = (float)timeToTarget.TotalSeconds;

            // Schedule the function to repeat daily at the target time
            ScheduleLocalNotification("Your daily challanges are renewed!", initialDelay, 86400);

            hasScheduled = true;
        }
    }

    private void ScheduleLocalNotification(string message, float delay, float repeatInterval)
    {
        // Check if the platform supports local notifications
#if UNITY_IOS || UNITY_ANDROID
        UnityEngine.iOS.LocalNotification notification = new UnityEngine.iOS.LocalNotification();
        notification.alertBody = message;
        notification.fireDate = System.DateTime.Now.AddSeconds(delay);
        notification.repeatInterval = UnityEngine.iOS.CalendarUnit.Day;
        UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notification);

        #if UNITY_ANDROID
        // For Android, use CPNP's local notification function
        CPNP.LocalNotification.SendNotification(0, (int)delay, message, UnityEngine.Color.white, repeatInterval);
        #endif
#endif
    }

    // Your custom function that you want to execute daily at the specified time
    private void ExecuteDailyTask()
    {

        tensorflowInceptionWebCamTextureExample.RandomObjectSelection();
        tensorflowInceptionWebCamTextureExample.ResetButtonStates();
        // Add your custom logic here
        // This function will be called daily at the specified time
        // Put your game-specific code here
        Debug.Log("Your custom task executed!");

        // Call your own functions, update game state, give rewards, etc.
        // For example:
        // UpdatePlayerResources();
        // CheckDailyQuests();
        // GrantDailyRewards();
        // ...
    }
}
