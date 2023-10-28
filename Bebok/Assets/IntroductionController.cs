using System.Collections;
using TMPro;
using UnityEngine;

public class IntroductionController : MonoBehaviour
{
    string introText = "\tAs the last of my kind, I've watched the world around me change in ways I could never have imagined. Long ago, my kin and I roamed the vast forests, hidden in the quiet corners of the world. We were the guardians of nature, the keepers of ancient secrets, and the mischief-makers who brought laughter to those who respected the wild.\r\n\r\n\tBut now, as I stand here alone, I see the consequences of globalization. The forests I once called home have given way to concrete jungles, the rivers I played by are choked with pollution, and the quiet corners where we danced in moonlight are filled with the noise of machines. The world has become a different place, one where the balance of nature has been disrupted, and the old ways have been forgotten.\r\n\r\n\tI've watched my fellow spirits fade away, unable to withstand the relentless tide of progress and change. The spirits of the forest, the water, and the air have grown weaker, and now, it is only I who remains, the last Bebok. It's a lonely existence, a burden I bear with a heavy heart.\r\n\r\n\tBut in the face of these challenges, I am reminded of the importance of continuing our traditions and passing them down to the next generation. I may be the last of my kind, but that doesn't mean our way of life has to disappear completely. I have a duty to the children, the future caretakers of this world, to teach them the stories, the dances, and the songs of our people.\r\n\r\n\tThe children hold the key to a future where the Bebok and the other spirits of the land can thrive once more. They are the hope, the connection to a world that has been lost, and the potential for a brighter, more harmonious future. By teaching them about the importance of the natural world, the balance of ecosystems, and the magic that still exists in the hidden corners of the Earth, I can ensure that our traditions and way of life are not forgotten.\r\n\r\n\tIt won't be easy. The world has changed, and the challenges we face are great. But I am determined to do my part, to instill in the hearts of the young the reverence for the Earth, the understanding of the interconnectedness of all life, and the joy that comes from celebrating the wonders of nature. For as the last Bebok, I may be the end of an era, but with the children, I can help sow the seeds of a new one, where our ancient ways are preserved and the spirit of the wild still thrives.\r\n\r\n\tMy friends, gather around, for I have a tale to tell. In days long past, when the moon danced with the stars and the forests were alive with the whispers of the wind, we Beboks would embark on the most wondrous adventures. We were the keepers of the hunt, the masters of merriment, and the pranksters of the night.\r\n";
    [SerializeField] TMP_Text introTextBox;
    [SerializeField] float writingSpeed=.05f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextBySteps());
    }

    IEnumerator TextBySteps()
    {
        foreach (char c in introText)
        {
            introTextBox.text += c;
            yield return new WaitForSeconds(writingSpeed);
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            writingSpeed = 0.01f;
        }
        else
        {
            writingSpeed = .05f;
        }
    }
}
