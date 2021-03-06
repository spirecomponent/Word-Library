﻿using System;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;

namespace Editing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create word document
            Document document = new Document();

            //load a document
            document.LoadFromFile(@"..\..\..\..\..\..\Data\Editing.doc");

            //Get a paragraph
            Paragraph paragraph = document.Sections[0].AddParagraph();

            //Append Text
            paragraph.AppendText("Editing sample");

            //Save doc file.
            document.SaveToFile("Sample.doc", FileFormat.Doc);

            //Launching the MS Word file.
            WordDocViewer("Sample.doc");
        }

        private void WordDocViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}