using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace ToXML
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

            addTable(document.AddSection());

            //Save xml file.
            document.SaveToFile("Sample.xml",FileFormat.Xml);

            //Launching the xml file.
            XMLViewer("Sample.xml");
        }

        private void addTable(Section section)
        {
            String[] header = { "Name", "Capital", "Continent", "Area", "Population" };
            String[][] data =
                {
                    new String[]{"Argentina", "Buenos Aires", "South America", "2777815", "32300003"},
                    new String[]{"Bolivia", "La Paz", "South America", "1098575", "7300000"},
                    new String[]{"Brazil", "Brasilia", "South America", "8511196", "150400000"},
                    new String[]{"Canada", "Ottawa", "North America", "9976147", "26500000"},
                    new String[]{"Chile", "Santiago", "South America", "756943", "13200000"},
                    new String[]{"Colombia", "Bagota", "South America", "1138907", "33000000"},
                    new String[]{"Cuba", "Havana", "North America", "114524", "10600000"},
                    new String[]{"Ecuador", "Quito", "South America", "455502", "10600000"},
                    new String[]{"El Salvador", "San Salvador", "North America", "20865", "5300000"},
                    new String[]{"Guyana", "Georgetown", "South America", "214969", "800000"},
                    new String[]{"Jamaica", "Kingston", "North America", "11424", "2500000"},
                    new String[]{"Mexico", "Mexico City", "North America", "1967180", "88600000"},
                    new String[]{"Nicaragua", "Managua", "North America", "139000", "3900000"},
                    new String[]{"Paraguay", "Asuncion", "South America", "406576", "4660000"},
                    new String[]{"Peru", "Lima", "South America", "1285215", "21600000"},
                    new String[]{"United States of America", "Washington", "North America", "9363130", "249200000"},
                    new String[]{"Uruguay", "Montevideo", "South America", "176140", "3002000"},
                    new String[]{"Venezuela", "Caracas", "South America", "912047", "19700000"}
                };
            Spire.Doc.Table table = section.AddTable();
            table.ResetCells(data.Length + 1, header.Length);

            // ***************** First Row *************************
            TableRow row = table.Rows[0];
            row.IsHeader = true;
            row.Height = 20;    //unit: point, 1point = 0.3528 mm
            row.HeightType = TableRowHeightType.Exactly;
            row.RowFormat.BackColor = Color.Gray;
            for (int i = 0; i < header.Length; i++)
            {
                row.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                Paragraph p = row.Cells[i].AddParagraph();
                p.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                TextRange txtRange = p.AppendText(header[i]);
                txtRange.CharacterFormat.Bold = true;
            }

            for (int r = 0; r < data.Length; r++)
            {
                TableRow dataRow = table.Rows[r + 1];
                dataRow.Height = 20;
                dataRow.HeightType = TableRowHeightType.Exactly;
                dataRow.RowFormat.BackColor = Color.Empty;
                for (int c = 0; c < data[r].Length; c++)
                {
                    dataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    dataRow.Cells[c].AddParagraph().AppendText(data[r][c]);
                }
            }
        }

        private void XMLViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}
