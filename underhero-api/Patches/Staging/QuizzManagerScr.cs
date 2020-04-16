using System;
using MonoMod;
using UnityEngine.SceneManagement;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::QuizzManagerScr")]
    public class QuizzManagerScr2 : QuizzManagerScr
    {
        private void Awake()
        {
            string QuizLevel = "";
            switch (SceneManager.GetActiveScene().name)
            {
                case "Puzzle Quizzes Scene 1":
                    QuizLevel = "Puzzle1";
                    break;
                case "Puzzle Quizzes Scene 2":
                    QuizLevel = "Puzzle2";
                    break;
                case "Puzzle Quizzes Scene 3":
                    QuizLevel = "Puzzle3";
                    break;
                case "Puzzle Quizzes Scene 4":
                    QuizLevel = "Puzzle4";
                    break;
            }
            TextStorage.SetDialogsFromKey(IntroDialog, QuizLevel + "Intro");
            TextStorage.SetDialogsFromKey(NoCoinsDialog, "NoCoinsDialog");
            TextStorage.SetDialogsFromKey(EndDialog, QuizLevel + "End");
            TextStorage.SetDialogsFromKey(WonCoinsDialog, "WonCoinsDialog");
            for (var index = 1; index <= Questions.Count; index++)
            {
                var question = Questions[index - 1];
                string[] questionLines = TextStorage.Instance.GetString(QuizLevel + "Question" + index + "Text")
                    .Split(new[] {"<br>"}, StringSplitOptions.None);
                question.Title = questionLines[0];
                question.QuestionLine1 = questionLines[1];
                question.QuestionLine2 = questionLines[2];
                question.AnswerA.AnswerString = TextStorage.Instance.GetString(QuizLevel + "Question" + index + "A1");
                question.AnswerB.AnswerString = TextStorage.Instance.GetString(QuizLevel + "Question" + index + "A2");
                question.AnswerC.AnswerString = TextStorage.Instance.GetString(QuizLevel + "Question" + index + "A3");
                question.AnswerD.AnswerString = TextStorage.Instance.GetString(QuizLevel + "Question" + index + "A4");
                TextStorage.SetDialogsFromKey(question.IntroDialog, QuizLevel + "Question" + index + "Intro");
                TextStorage.SetDialogsFromKey(question.AnswerDialogA, QuizLevel + "Question" + index + "D1");
                TextStorage.SetDialogsFromKey(question.AnswerDialogB, QuizLevel + "Question" + index + "D2");
                TextStorage.SetDialogsFromKey(question.AnswerDialogC, QuizLevel + "Question" + index + "D3");
                TextStorage.SetDialogsFromKey(question.AnswerDialogD, QuizLevel + "Question" + index + "D4");
            }
        }
    }
}