﻿using System;
using System.Windows.Forms;
using ClassLibrary2;


namespace Проект_к_школе
{
    public partial class QuestionSetupForm : Form
    {
        public QuestionSetupForm()
        {
            InitializeComponent();
        }
        internal Question LocalQuestion;    
        bool IsChange;
        int CurrentIndex = 0;

        private void AddQuestion_Click(object sender, EventArgs e)
        {
            Question q = new Question();
            FormWriter form = (FormWriter)Application.OpenForms[0];

            q.Question_s = QuestionSetup.Text != "" ? QuestionSetup.Text : "  ";
            q.Answers[0] = AnswerSetup1.Text;
            q.Answers[1] = AnswerSetup2.Text;
            q.Answers[2] = AnswerSetup3.Text;
            q.Answers[3] = AnswerSetup4.Text;
            q.arg = AnswerSetup5.Text;
            if (!IsChange)
            {
                form.Lesson_mass[form.ChoosenLesson].QuestionList.Add(q);
                form.AddToQuestionChoose(q);
            }
            else
            {
                form.Lesson_mass[form.ChoosenLesson].QuestionList[form.ChoosenQuestion] = q;
            }
            form.Enabled = true;
            form.UpdateQuestions();
            this.Dispose();
        }

        private void QuestionSetupForm_Load(object sender, EventArgs e)
        {
            FormWriter f = (FormWriter)Application.OpenForms[0];
            if ((string)f.Lesson_mass[f.ChoosenLesson].args[3] == "1")
            {
                Answer5Label.Visible = true;
                AnswerSetup5.Visible = true;
            }
            try
            {
                QuestionSetup.Text = LocalQuestion.Question_s;
                AnswerSetup1.Text = LocalQuestion.Answers[0];
                AnswerSetup2.Text = LocalQuestion.Answers[1];
                AnswerSetup3.Text = LocalQuestion.Answers[2];
                AnswerSetup4.Text = LocalQuestion.Answers[3];
                AnswerSetup5.Text = LocalQuestion.arg;
                AddQuestion.Text = "Изменить";
                IsChange = true;
            }
            catch
            {

            }
        }

        private void QuestionSetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Enabled = true;
            FileTools.Log("Question create is done");
        }

        private void QuestionSetupForm_KeyDown(object sender, KeyEventArgs e)
        {
            CurrentIndex = CurrentIndex == 5 ? 0 : CurrentIndex + 1;
            if(e.KeyCode == Keys.Enter)
            {
                switch(CurrentIndex)
                {
                    case 0:
                        QuestionSetup.Focus();
                        break;
                    case 1:
                        AnswerSetup1.Focus();
                        break;
                    case 2:
                        AnswerSetup2.Focus();
                        break;
                    case 3:
                        AnswerSetup3.Focus();
                        break;
                    case 4:
                        AnswerSetup4.Focus();
                        if (!AnswerSetup5.Visible) CurrentIndex = -1;
                        break;
                    case 5:
                        AnswerSetup5.Focus();
                        break;
                }
            }
        }
    }
}
