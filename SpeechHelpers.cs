using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace SpeechAPI
{
    public static class SpeechSynthRecognition
    {
        static SpeechSynthesizer synth;
        static PromptBuilder promptBuilder;
        static SpeechRecognitionEngine recognition;

        static SpeechSynthRecognition()
        {
            synth = new SpeechSynthesizer();
            promptBuilder = new PromptBuilder();
            recognition = new SpeechRecognitionEngine();
        }
        //extension method
        public static void Aloud(this object s)
        {
            promptBuilder.ClearContent();
            promptBuilder.AppendText(s.ToString());
            synth.Speak(promptBuilder);
        }
        
        public static string Listen()
        {
            RecognitionResult result;
            Grammar dictationGrammar = new DictationGrammar();
            recognition.LoadGrammar(dictationGrammar);
            recognition.SetInputToDefaultAudioDevice();
            result = recognition.Recognize();
            return result.Text;
        }
    }
}