using Sculptor.KfLibDNet;
// using System;
// using System.Collections.Generic;
using System.Diagnostics;
// using System.Globalization;
// using System.IO;
// using System.Linq;
using System.Net;
// using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
// using System.Reflection.Metadata;
using System.Globalization;
using ExcelForm;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;

namespace Export
{

    class Export
    {
        private static Server server;
        private static Database database;

        public static KeyedFile racun;
        public static KeyedFile mat;
        public static KeyedFile mjul;
        public static KeyedFile podst;

        private static double sumIsporucenaToplinskaEnergija;
        private static double sumUkupanIznosRacuna;
        private static double sumUkupanIznosRacunaNakonUmanjenja;
        private static double sumIznosRazlike;

        private static readonly string[] HEADERS = {
                "OBRAČUNSKO MJERNO MJESTO",
                "RAČUN BROJ",
                "INTERNI BROJ RAČUNA",
                "KRAJNJI KUPAC",
                "OIB",
                "NAMJENA(GRIJANJE,PTV,itd.)",
                "ADRESA OBRAČUNSKOG MJERNOG MJESTA",
                "GRAD OMM",
                "NAZIV TOPLINSKOG SUSTAVA(C-centrali,Z-zatvoreni)",
                "REFUNDACIJA OD",
                "REFUNDACIJA DO",
                "TARIFNI MODEL",
                "ISPORUČENA TOPLINSKA ENERGIJA",
                "IZNOS RAZLIKE SUKLADNO ODLUCI VLADE RH(EUR(KN/KWH))",
                "UKUPAN IZNOS RAČUNA KRAJNJEG KUPCA PRIJE UMANJENJA",
                "UKUPAN IZNOS RAČUNA KRAJNJEG KUPCA NAKON UMANJENJA",
                "IZNOS RAZLIKE SUKLADNO ODLUCI VLADE RH",
                "NAPOMENA",
                "LINK NA VEZANI DOKUMENT(RAČUN KRAJ.KUPCA U PRILOGU)"
        };
        public static void start(string[] args, Label progressLabel)
        {
            Process[] pname = Process.GetProcessesByName("kfserver");

            if (pname.Length == 0)
            {
                // Console.WriteLine("starting kfserver...");

                Process kfserverProcess;

                if (args.Length == 1)
                {
                    kfserverProcess = Process.Start(args[0]);
                }
                else
                {
                    kfserverProcess = Process.Start("C:\\Sculptor\\bin\\kfserver.exe");
                }

                if (kfserverProcess.HasExited)
                {
                    // Console.WriteLine("Error starting kfserver!");
                    return;
                }
                else
                {
                    // Console.WriteLine("kfserver started");
                }

            }
            else
            {
                // Console.WriteLine("kfserver is already running");
            }

            server = new Server(Dns.GetHostEntry(IPAddress.Loopback).HostName, 10);

            string projectPath;

            if (args.Length == 2)
            {
                projectPath = args[1];
            }
            else
            {
                projectPath = "D:\\Tehnon2023\\tehnon23";
            }

            database = new Database(server,
                                    "baza",
                                    Database.Type.SCULPTOR,
                                    Database.Flag.IGNORE_CATALOG,
                                    projectPath,
                                    5,
                                    "log.txt");

            /*
            racun = database.openTable("racun14", KeyedFile.Mode.READ);
            mat = database.openTable("mat", KeyedFile.Mode.READ);
            mjul = database.openTable("mjul", KeyedFile.Mode.READ);
            podst = database.openTable("podst", KeyedFile.Mode.READ);

            // rewind all tables
            racun.rewind();
            mat.rewind();
            mjul.rewind();
            */



            // Get all data in List<List<string>>
            List<List<object>> data = new List<List<object>>();

            RacunRepository repo = new RacunRepository(server, database);

            // Using reflection, get all fields of the class

            PropertyInfo[] properties = typeof(Racun).GetProperties();

            progressLabel.Text = "Prikupljanje podataka iz baze...";
            progressLabel.Refresh();

            int counter = 0;
            while (true)
            {
                
                List<object> line = new List<object>();
                try
                {
                    Racun rac = (Racun)repo.NextRecord();

                    

                    if (rac.iznos_razlike == 0) continue;
                    sumIsporucenaToplinskaEnergija += rac.isporucena_toplinska_energija;
                    sumUkupanIznosRacuna += rac.ukupanIznosRacuna;
                    sumUkupanIznosRacunaNakonUmanjenja += rac.ukupanIznosRacunaNakonUmanjenja;
                    sumIznosRazlike += rac.iznos_razlike;
                    line.Add(rac.obracunska_mjerna_mjesta);
                    line.Add(rac.interni_broj_racuna);
                    line.Add(rac.interni_broj_racuna);
                    line.Add(rac.krajnji_kupac);
                    line.Add(rac.OIB);
                    line.Add(rac.namjena);
                    line.Add(rac.adresa_obracunskog_mjernog_mjesta);
                    line.Add(rac.grad_omm);
                    line.Add(rac.naziv_toplinskog_sustava);
                    line.Add(rac.refundacija_od);
                    line.Add(rac.refundacija_do);
                    line.Add(rac.tarifni_model);
                    line.Add(Math.Round(rac.isporucena_toplinska_energija, 3));
                    line.Add(rac.iznos_razlike_jed);
                    line.Add(rac.ukupanIznosRacuna);
                    line.Add(rac.ukupanIznosRacunaNakonUmanjenja);
                    line.Add(rac.iznos_razlike);
                    line.Add(rac.napomena);

                    data.Add(line);
                        
                }
                catch (KfException ex)
                {
                    Debug.WriteLine(ex.Message);
                    break;
                }

           
            }

            string fileName = "izvjestaj.xlsx";

            progressLabel.Text = "Zapisivanje podataka u excel datoteku...";
            progressLabel.Refresh();

            CreateExcelFile(fileName);
            FillDatabase(fileName, data);

            progressLabel.Text = "Gotovo";
            progressLabel.Refresh();
        }

        public static void FillDatabase(string filePath, List<List<object>> data)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filePath, true))
            {
                // Get the worksheet part
                WorksheetPart worksheetPart = spreadsheetDocument.WorkbookPart.WorksheetParts.First();

                // Get the sheet data
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                EnumValue<CellValues> cellType = new EnumValue<CellValues>(CellValues.String);

                // Add the data rows
                int i = 2;
                foreach (List<object> rowData in data)
                {
                    Row row = new Row();
                    foreach (object value in rowData)
                    {
                        row.Append(CreateCell(value));
                    }
                    try
                    {
                        // get year
                        KeyedFile racun = database.openTable("racun14", KeyedFile.Mode.READ);
                        racun.next();
                        string[] date = racun.getField("rr_dp").getString().Split('.');
                        int year = int.Parse(date[date.Length - 1]);
                        // make a new cell
                        Cell cell = new Cell();
                        cell.CellReference = "S" + i.ToString();
                        string path = $"D:/Tehnon2023/pregled/racun{rowData[1]}_{year}.pdf";

                        if (File.Exists(path))
                        {
                            cell.CellFormula = new CellFormula($"HYPERLINK(\"{path}\",\"racun{rowData[1]}_{year}.pdf\")");
                        }
                        else
                        {
                            cell.CellValue = new CellValue("NE POSTOJI GENERIRANI RAČUN");
                            cell.DataType = cellType;
                        }
                        row.Append(cell);
                        sheetData.Append(row);
                        i++;

                    }
                    catch (System.Net.Sockets.SocketException ex)
                    {
                        MessageBox.Show("Greška kod spajanja na bazu.\n Molimo nemojte zatvarati proces.");
                        return;
                    }
                }

                addSums(sheetData, i);
                // Save the changes to the spreadsheet document
                worksheetPart.Worksheet.Save();
                spreadsheetDocument.WorkbookPart.Workbook.Save();
                // racun.rewind();
            }
        }

        private static void addSums(SheetData sheetData, int i)
        {
            Row row = new Row();
            EnumValue<CellValues> numberType = new EnumValue<CellValues>(CellValues.Number);

            // isporučena energija
            Cell sumEnergyCell = new Cell();
            sumEnergyCell.CellReference = $"M{i}";
            sumEnergyCell.CellValue = new CellValue(sumIsporucenaToplinskaEnergija);
            sumEnergyCell.DataType = numberType;

            // ukupan iznos računa
            Cell sumUkupanIznosRacunaCell = new Cell();
            sumUkupanIznosRacunaCell.CellReference = $"O{i}";
            sumUkupanIznosRacunaCell.CellValue = new CellValue(sumUkupanIznosRacuna);
            sumUkupanIznosRacunaCell.DataType = numberType;

            // ukupan iznos računa nakon umanjena
            Cell sumUkupanIznosRacunaNakonUmanjenjaCell = new Cell();
            sumUkupanIznosRacunaNakonUmanjenjaCell.CellReference = $"P{i}";
            sumUkupanIznosRacunaNakonUmanjenjaCell.CellValue = new CellValue(sumUkupanIznosRacunaNakonUmanjenja);
            sumUkupanIznosRacunaNakonUmanjenjaCell.DataType = numberType;

            // Iznos razlike
            Cell sumIznosRazlikeCell = new Cell();
            sumIznosRazlikeCell.CellReference = $"Q{i}";
            sumIznosRazlikeCell.CellValue = new CellValue(sumIznosRazlike);
            sumIznosRazlikeCell.DataType = numberType;


            row.Append(sumEnergyCell);
            row.Append(sumUkupanIznosRacunaCell);
            row.Append(sumUkupanIznosRacunaNakonUmanjenjaCell);
            row.Append(sumIznosRazlikeCell);
            sheetData.Append(row);
            
        }


        public static void CreateExcelFile(string filePath)
{
    bool success = false;
    while (!success)
    {
        try
        {
            // Create a new spreadsheet document
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                // Add a new workbook
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // Add a new worksheet to the workbook
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                // Add a new sheet to the workbook
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                // Add the headers to the first row
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                Row row = new Row();
                foreach (string value in HEADERS)
                {
                    row.Append(CreateCell(value));
                }
                sheetData.Append(row);

                // Save the changes to the spreadsheet document
                workbookPart.Workbook.Save();

                // Set success to true to break out of the while loop
                success = true;
            }
        }
        catch (System.IO.IOException ex)
        {
            // Show an error message
            MessageBox.Show("Ne mogu pristupiti datoteci. Ako se već koristi u nekom programu zatvorite ju");

            // Wait for a short period before trying again
            System.Threading.Thread.Sleep(1000);
        }
    }
}

        private static Cell CreateCell(object value)
        {
            Cell cell = new Cell();
            // cell.DataType = CellValues.String;
            if (value is string)
            {
                cell.DataType = CellValues.String;
                cell.CellValue = new CellValue((string)value);
            }
            else if (value is DateTime)
            {
                cell.DataType = CellValues.Date;
                cell.CellValue = new CellValue((DateTime)value);
            }
            else if (value is bool)
            {
                cell.DataType = CellValues.Boolean;
                cell.CellValue = new CellValue((bool)value);
            }

            else if (value is decimal || value is int || value is double)
            {
                cell.DataType = CellValues.Number;
                cell.CellValue = new CellValue((double)value);
            }

            return cell;
        }



        public static string getFirst()
        {
            KeyedFile racun = database.openTable("racun14", KeyedFile.Mode.READ);
            racun.rewind();
            racun.nextu();

            return racun.getField("rr_dp").getString();
        }


        // filtriraj po datumu racuna
        public static List<string> getByDate(string date)
        {
            racun.rewind();
            List<string> entries = new List<string>();

            while (true)
            {
                try
                {
                    racun.nextu();
                    string dd = racun.getField("rr_dp").getString();
                    if (date == dd)
                    {
                        entries.Add(dd);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    break;
                }
            }

            return entries;
        }
    }



}

