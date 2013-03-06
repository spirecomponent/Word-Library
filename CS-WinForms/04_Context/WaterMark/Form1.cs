using System;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;

namespace InsertingWatermark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Open a blank word document as template
            Document document = new Document(@"..\..\..\..\..\..\Data\Blank.doc");

            InsertWatermark(document.Sections[0]);

            //Save doc file.
            document.SaveToFile("Sample.doc",FileFormat.Doc);

            //Launching the MS Word file.
            WordDocViewer("Sample.doc");


        }

        private void InsertWatermark(Section section)
        {
            Paragraph paragraph
                = section.Paragraphs.Count > 0 ? section.Paragraphs[0] : section.AddParagraph();
            paragraph.AppendText("The sample demonstrates how to insert a watermark into a document.");
            paragraph.ApplyStyle(BuiltinStyle.Heading2);


            TextWatermark txtWatermark = new TextWatermark();
            txtWatermark.Text = "Watermark Demo";
            txtWatermark.FontSize = 90;
            txtWatermark.Layout = WatermarkLayout.Diagonal;
            section.Document.Watermark = txtWatermark;
         
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
