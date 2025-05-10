using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text text;
    public float timeBetweenChar = .01f;
    public float timeBetweenLine = 1f;
    public Canvas canvas;
    public CanvasGroup canvasGroup;
    public List<string> messages = new List<string>();
    private List<string> messageQueue = new List<string>();
    private bool isRenderingMessages = false;

    public void QueueMessage(string message, float delay)
    {
        messageQueue.Add(message);

        if (!isRenderingMessages)
        {
            print("rendering message");
            isRenderingMessages = true;
            StartCoroutine(RenderMessages(delay));
        }
    }

    private IEnumerator RenderMessages(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvasGroup.alpha = 1;
        text.text = "";
        while (messageQueue.Count != 0)
        {
            for (int i = 0; i < messageQueue[0].Length; i++)
            {
                text.text += messageQueue[0][i];
                yield return new WaitForSeconds(timeBetweenChar);
            }

            yield return new WaitForSeconds(timeBetweenLine);
            text.text = "";

            messageQueue.RemoveAt(0);
        }

        isRenderingMessages = false;
        canvasGroup.alpha = 0;
    }
}
