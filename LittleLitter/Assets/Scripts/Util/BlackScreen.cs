using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CoffeeBara.Util {
    [RequireComponent(typeof(Image))]
    public class BlackScreen : MonoBehaviour {
        private const float DEFAULT_FADE_TIME = 0.5f;
        private const float DEFAULT_PAD_TIME = 0;
        
        private Image _image;

        public IEnumerator FadeIn(float fadeTime = DEFAULT_FADE_TIME, float padTime = DEFAULT_PAD_TIME) {
            yield return new WaitForSeconds(padTime);
            yield return Fade(Color.black, Color.clear, fadeTime);
        }

        public IEnumerator FadeOut(float fadeTime = DEFAULT_FADE_TIME, float padTime = DEFAULT_PAD_TIME) {
            yield return Fade(Color.clear, Color.black, fadeTime);
            yield return new WaitForSeconds(padTime);
        }
        
        private void Awake() {
            _image = GetComponent<Image>();
        }

        private IEnumerator Fade(Color from, Color to, float fadeTime) {
            float t = 0;

            while (t < fadeTime) {
                _image.color = Color.Lerp(from, to, t / fadeTime);
                
                t += Time.deltaTime;
                yield return null;
            }

            _image.color = to;
        }
    }
}
