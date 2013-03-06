using System;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;

namespace Bookmark
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

            Bookmark(document.Sections[0]);

            //Save doc file.
            document.SaveToFile("Sample.doc",FileFormat.Doc);

            //Launching the MS Word file.
            WordDocViewer("Sample.doc");


        }

        private void Bookmark(Section section)
        {
            Paragraph paragraph
                = section.Paragraphs.Count > 0 ? section.Paragraphs[0] : section.AddParagraph();
            paragraph.AppendText("The sample demonstrates how to using bookmark.");
            paragraph.ApplyStyle(BuiltinStyle.Heading2);

            section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.AppendText("Simple bookmark.");
            paragraph.ApplyStyle(BuiltinStyle.Heading4);
            
            // Writing simple bookmarks
            section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.AppendBookmarkStart("SimpleBookMark");
            paragraph.AppendText("This is a simple book mark.");
            paragraph.AppendBookmarkEnd("SimpleBookMark");

            section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.AppendText("Nested bookmark.");
            paragraph.ApplyStyle(BuiltinStyle.Heading4);

            // Writing nested bookmarks
            section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.AppendBookmarkStart("Root");
            paragraph.AppendText(" Root data ");
            paragraph.AppendBookmarkStart("NestedLevel1");
            paragraph.AppendText(" Nested Level1 ");
            paragraph.AppendBookmarkStart("NestedLevel2");
            paragraph.AppendText(" Nested Level2 ");
            paragraph.AppendBookmarkEnd("NestedLevel2");
            paragraph.AppendText(" Data Level1 ");
            paragraph.AppendBookmarkEnd("NestedLevel1");
            paragraph.AppendText(" Data Root ");
            paragraph.AppendBookmarkEnd("Root");

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
