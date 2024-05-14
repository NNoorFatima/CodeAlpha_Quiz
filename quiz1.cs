using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CodeALpha_Quiz
{
    public partial class quiz1 : Form
    {
        private List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox>();
        private Dictionary<int, string> correctAnswers = new Dictionary<int, string>();

        public quiz1()
        {
            InitializeComponent();
        }

        private void quiz_Load(object sender, EventArgs e)
        {
            LoadQuestions();
        }
        private void LoadQuestions()
        {
            string connectionString = Registration.source;

            // SQL query to fetch questions and their answers
            string query = "SELECT Q.question_id, Q.question_text, A.ans_text FROM questions Q INNER JOIN answer A ON Q.ansid = A.ansid where Q.question_id<=3";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                int yPosition = 10; // Starting y position for TextBoxes

                while (reader.Read())
                {
                    int questionId = reader.GetInt32(0);
                    string questionText = reader.GetString(1);
                    string correctAnswer = reader.GetString(2);

                    // Create a new Label for each question
                    Label label = new Label
                    {
                        Text = questionText,
                        Location = new System.Drawing.Point(10, yPosition),
                        Width = this.Width - 40
                    };
                    this.Controls.Add(label);

                    // Create a new TextBox for each answer
                    System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox
                    {
                        Location = new System.Drawing.Point(10, yPosition + 25),
                        Width = this.Width - 40
                    };
                    this.Controls.Add(textBox);
                    textBoxes.Add(textBox);

                    // Store the correct answer in the dictionary
                    correctAnswers.Add(questionId, correctAnswer);

                    // Increment the y position for the next Label and TextBox
                    yPosition += 60;
                }
            }
        }

        private void CheckAnswers()
        {
            int counter = 0;
            string connectionString = Registration.source;

            // Clear previous result
            foreach (var textBox in textBoxes)
            {
                textBox.BackColor = System.Drawing.Color.White;
            }

            for (int i = 0; i < textBoxes.Count; i++)
            {
                System.Windows.Forms.TextBox textBox = textBoxes[i];
                string userAnswer = textBox.Text.Trim();

                // Since we do not have the question IDs in textBoxes list, we assume they are in order
                int questionId = correctAnswers.Keys.ElementAt(i);
                string correctAnswer = correctAnswers[questionId];

                if (userAnswer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    textBox.BackColor = System.Drawing.Color.LightGreen;
                    counter++;
                }
                else
                {
                    textBox.BackColor = System.Drawing.Color.LightCoral;
                }
            }
            MessageBox.Show($"Your score is {counter}");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAnswers();
        }
    }
}
