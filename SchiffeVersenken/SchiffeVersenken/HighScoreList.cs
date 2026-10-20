using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SchiffeVersenken
{
    internal class HighScoreList
    {

        private List<HighScoreItem> highScores;

        private static string filePath = "highscore.xml";

        public HighScoreList()
        {
            highScores = new List<HighScoreItem>();

            LoadHighScoresFromFile();

            highScores.Add(new HighScoreItem(100, "Test1"));
            highScores.Add(new HighScoreItem(200, "Test2"));
            highScores.Add(new HighScoreItem(300, "Test3"));
            highScores.Add(new HighScoreItem(400, "Test4"));
            highScores.Add(new HighScoreItem(500, "Test5"));
            highScores.Add(new HighScoreItem(600, "Test6"));
        }

        public void Show()
        {
            Form f = new Form();
            f.Text = "High Score List";
            f.Size = new Size(300, 200);

            ListView listView = new ListView();
            listView.View = View.Details;
            listView.Columns.Add("Rank");
            listView.Columns.Add("Name");
            listView.Columns.Add("Score");
            listView.Sorting = SortOrder.Ascending;
            listView.Dock = DockStyle.Fill;


            int i = 1;
            foreach (HighScoreItem item in highScores)
            {
                listView.Items.Add(new ListViewItem(new string[] { i++.ToString(), item.Name, item.Score.ToString(), }));
            }

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            f.Controls.Add(listView);

            f.Show();
        }

        public void AddNewItem(int score)
        {
            if (highScores.Count >= 5)
            {

                if (score < highScores[4].Score)
                {
                    string userInput = Microsoft.VisualBasic.Interaction.InputBox("You won!\n\nEnter your name to be on the High Score List!", "High Score List", "Name");

                    HighScoreItem newItem = new HighScoreItem(score, userInput);

                    highScores.RemoveAt(4);
                    highScores.Add(newItem);

                }

            }
            else
            {
                string userInput = Microsoft.VisualBasic.Interaction.InputBox("You won!\n\nEnter your name to be on the High Score List!", "High Score List", "Name");
                HighScoreItem newItem = new HighScoreItem(score, userInput);

                highScores.Add(newItem);

            }

            highScores.Sort((x, y) => x.Score.CompareTo(y.Score));

            SaveHighScoresToFile();
            
        }

        public void SaveHighScoresToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HighScoreItem>));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, highScores);
            }
        }

        public void LoadHighScoresFromFile()
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<HighScoreItem>));
                using (TextReader reader = new StreamReader(filePath))
                {
                    highScores = (List<HighScoreItem>)serializer.Deserialize(reader);
                }
            }
        }

    }

    public class HighScoreItem
    {
        public int Score { get; set; }
        public string Name { get; set; }

        public HighScoreItem()
        {
            
        }

        public HighScoreItem(int score, string name)
        {
            Score = score;
            Name = name;
        }
    }
}


