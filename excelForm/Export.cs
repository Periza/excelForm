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

        public static DateTime DatumRacuna { set; get; }


        public static string DatumOd { set; get; }
        public static string DatumDo { set; get; }

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
                "UKUPAN IZNOST RAČUNA KRAJNJEG KUPCA NAKON UMANJENJA",
                "IZNOS RAZLIKE SUKLADNO ODLUCI VLADE RH",
                "NAPOMENA",
                "LINK NA VEZANI DOKUMENT(RAČUN KRAJ.KUPCA U PRILOGU)"
        };
        public static void start(string[] args)
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

            // Open all needed tables in read mode
            racun = database.openTable("racun14", KeyedFile.Mode.READ);
            mat = database.openTable("mat", KeyedFile.Mode.READ);
            mjul = database.openTable("mjul", KeyedFile.Mode.READ);
            podst = database.openTable("podst", KeyedFile.Mode.READ);

            // rewind all tables
            racun.rewind();
            mat.rewind();
            mjul.rewind();



            // Get all data in List<List<string>>
            List<List<object>> data = new List<List<object>>();

            while (true)
            {
                List<object> line = new List<object>(); // one line in the excel file
                string obracunsko_mjerno_mjesto_grijanje;
                string obracunsko_mjerno_mjesto_voda;
                string obracunska_mjerna_mjesta;
                string rr_rn;
                string interni_broj_racuna;
                string krajnji_kupac;
                string OIB;
                string namjena;
                string adresa_obracunskog_mjernog_mjesta;
                string grad_omm;
                string naziv_toplinskog_sustava;
                string refundacija_od;
                string refundacija_do;
                string isporucena_toplinska_energija;
                string tarifni_model;
                string iznos_razlike_jed;
                double iznos_razlike;
                double ukupanIznosRacuna;
                double ukupanIznosRacunaNakonUmanjenja;
                string napomena;
                string valuta;

                string toplinski_sustav;

                // test
                string date_format = "dd.MM.yyyy";
                try
                {
                    racun.nextu();
                    List<object> row = new List<object>();

                    string rr_siz = racun.getField("rr_siz").getString();
                    string rr_sif = racun.getField("rr_sif").getString();
                    string rr_sst = racun.getField("rr_sst").getString();

                    string rr_pod = racun.getField("rr_pod").getString();

                    mat.getField("m_siz").setString(rr_siz);
                    mat.getField("m_sif").setString(rr_sif);
                    mat.getField("m_sst").setString(rr_sst);
                    try
                    {
                        mat.findu();

                        string m_mj = mat.getField("m_mj").getString();
                        string m_ul = mat.getField("m_ul").getString();

                        mjul.getField("mu_mj").setString(m_mj);
                        mjul.getField("mu_ul").setString(m_ul);

                        try
                        {
                            mjul.findu();
                            /*
                            MJUL.mu_mjn/ + "", FILE_RACUN14.rr_rn, FILE_RACUN14.rr_rn, MAT.m_ime/ + "","GRIJANJE"/ + "",MJUL.mu_uln/ + " " + MAT.m_kbr/ + ",
                             " + MJUL.mu_mjn/ + "",MAT.m_ommg/ + "", "NAZIV TOPLINSKOG SUSTAVA",FILE_RACUN14.rr_datp, FILE_RACUN14.rr_datn, MAT.m_tm/ + "", 
                             "ISPORUCENA_TOPLINSKA_ENERGIJA", convertCommasToDots(tmp.razlika)/ + " " + tostr(tmp.valuta)/ + "", convertCommasToDots(FILE_RACUN14.rr_sveukk)/ + "", 
                             convertCommasToDots(FILE_RACUN14.rr_sveukkk)/ + "", convertCommasToDots(tmp.razlika)/ + "", "NAPOMENA"
                             */
                            podst.getField("po_br").setString(rr_pod);
                            podst.findu();
                            // get sustav
                            toplinski_sustav = podst.getField("po_sustav").getString();
                            char firstChar = toplinski_sustav.Substring(0, 1)[0];
                            Debug.WriteLine(toplinski_sustav);

                            obracunsko_mjerno_mjesto_grijanje = racun.getField("rr_mjestog").getString();
                            obracunsko_mjerno_mjesto_voda = racun.getField("rr_mjestov").getString();
                            obracunska_mjerna_mjesta = obracunsko_mjerno_mjesto_grijanje;
                            if (obracunsko_mjerno_mjesto_voda != "0")
                            {
                                obracunska_mjerna_mjesta += $" - {obracunsko_mjerno_mjesto_voda}";
                            }
                            Debug.WriteLine(obracunsko_mjerno_mjesto_grijanje);
                            Debug.WriteLine(obracunsko_mjerno_mjesto_voda);
                            rr_rn = racun.getField("rr_rn").getString();
                            interni_broj_racuna = racun.getField("rr_rn").getString();
                            krajnji_kupac = mat.getField("m_ime").getString();
                            OIB = mat.getField("m_oib").getString();
                            Console.WriteLine(OIB);
                            namjena = obracunsko_mjerno_mjesto_voda != "0" ? "GRIJANJE - PTV" : "GRIJANJE";
                            adresa_obracunskog_mjernog_mjesta = $"{mjul.getField("mu_uln").getString()} {mat.getField("m_kbr").getString()}";
                            grad_omm = "VUKOVAR";

                            naziv_toplinskog_sustava = toplinski_sustav.Substring(0, 1)[0] == 'C' ? "Centralni" : "Zatvoreni";
                            try
                            {
                                refundacija_od = racun.getField("rr_dp").getString();
                                DateTime datum = Helpers.convertToDateTime(refundacija_od);
                                datum = datum.AddDays(datum.Day * (-1) + 1);
                                refundacija_od = (datum).ToString("dd.MM.yyyy");
                            }
                            catch (System.ArgumentOutOfRangeException ex)
                            {
                                refundacija_od = String.Empty;
                            }

                            try
                            {
                                refundacija_do = racun.getField("rr_dp").getString();

                            }
                            catch (System.ArgumentOutOfRangeException ex)
                            {
                                Debug.WriteLine(ex.Message);
                                refundacija_do = String.Empty;
                            }

                            tarifni_model = mat.getField("m_tm").getString();

                            isporucena_toplinska_energija = (racun.getField("rr_energ").getDouble() + racun.getField("rr_ptv").getDouble() + racun.getField("rr_ener").getDouble()).ToString("F3");


                            // isporucena_toplinska_energija = "ISPORUCENA TOPLINSKA ENERGIJA";

                            /* Set currency depending on the year of issue of the bill*/
                            valuta = "EUR";
                            // Get date of the bill
                            string[] date = racun.getField("rr_dp").getString().Split('.');
                            int year = int.Parse(date[date.Length - 1]);

                            if (year < 2023)
                            {
                                valuta = "HRK";
                            }
                            iznos_razlike_jed = Math.Abs(racun.getField("rr_cij_subv").getDouble()).ToString();

                            ukupanIznosRacuna = racun.getField("rr_sveukk").getDouble();
                            ukupanIznosRacunaNakonUmanjenja = racun.getField("rr_sveukkk").getDouble();
                            iznos_razlike = Math.Abs(racun.getField("rr_subv").getDouble());
                            if (iznos_razlike == 0) continue;
                            napomena = "";

                            // Console.WriteLine($"{obracunsko_mjerno_mjesto}, {rr_rn}, {interni_broj_racuna}, {krajnji_kupac}, {namjena}, {adresa_obracunskog_mjernog_mjesta}, {grad_omm}");
                            line.Add(obracunska_mjerna_mjesta);
                            line.Add(rr_rn);
                            line.Add(interni_broj_racuna);
                            line.Add(krajnji_kupac);
                            line.Add(OIB);
                            Console.WriteLine(krajnji_kupac);
                            line.Add(namjena);
                            line.Add(adresa_obracunskog_mjernog_mjesta);
                            line.Add(grad_omm);
                            line.Add(naziv_toplinskog_sustava);
                            line.Add(refundacija_od);
                            line.Add(refundacija_do);
                            line.Add(tarifni_model);
                            line.Add(isporucena_toplinska_energija);
                            line.Add($"{iznos_razlike_jed} {valuta}/kWh");
                            line.Add(ukupanIznosRacuna);
                            line.Add(ukupanIznosRacunaNakonUmanjenja);
                            line.Add(iznos_razlike);
                            line.Add(napomena);
                        }
                        catch (KfException ex)
                        {
                            // Console.WriteLine("mjul exception: " + ex.Message);
                        }
                    }
                    catch (KfException ex)
                    {
                        // Console.WriteLine("mat exception: " + ex.Message);
                        // Console.WriteLine($"{rr_siz}, {rr_sst}, {rr_sif}");
                    }

                }

                catch (KfException ex)
                {
                    // Console.WriteLine("racun exception: " + ex.Message);
                    break;
                }
                catch(System.Net.Sockets.SocketException ex)
                {
                    MessageBox.Show("Greška kod spajanja na bazu.\n Molimo nemojte zatvarati proces.");
                    return;
                }
                // append line to the data
                data.Add(line);
            }

            string fileName = "izvjestaj.xlsx";
            CreateExcelFile(fileName);
            FillDatabase(fileName, data);

        }

        public static void FillDatabase(string filePath, List<List<object>> data)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filePath, true))
            {
                // Get the worksheet part
                WorksheetPart worksheetPart = spreadsheetDocument.WorkbookPart.WorksheetParts.First();

                // Get the sheet data
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

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
                        cell.CellFormula = new CellFormula($"HYPERLINK(\"../pregled/racun{rowData[1]}_{year}.pdf\",\"racun{rowData[1]}_{year}.pdf\")");
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



                // Save the changes to the spreadsheet document
                worksheetPart.Worksheet.Save();
                spreadsheetDocument.WorkbookPart.Workbook.Save();
            }
        }


        public static void CreateExcelFile(string filePath)
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

