using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Vml;
using Sculptor.KfLibDNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelForm
{
    public class RacunRepository : IRecordRepository
    {

        private static Server server;

        private static Database database;

        public KeyedFile racun;
        public KeyedFile mat;
        public KeyedFile mjul;
        public KeyedFile podst;

        

        public RacunRepository(Server server, Database database, string table, KeyedFile.Mode mode = KeyedFile.Mode.READ) 
        {
            // Process kfserverProcess = Process.Start("C:\\Sculptor\\bin\\kfserver.exe");
            // If the server is not provided, set it to default value
            if (server == null)
            {
                server = new Server(Dns.GetHostEntry(IPAddress.Loopback).HostName, 10);
            }

            

            racun = database.openTable(table, mode);
            mat = database.openTable("mat", mode);
            mjul = database.openTable("mjul", mode);
            podst = database.openTable("podst", mode);

            rewindAll();

        }

        public Record NextRecord()
        {
            Racun rac = new Racun();
            bool success = false;
            while (!success)
            {
                try
                {
                    racun.next();

                    setFields(rac);

                    success = true;
                }
                catch (KfException ex)
                {
                    throw ex;
                }
                catch(System.Net.Sockets.SocketException ex)
                {
                    throw ex;
                }
            }
            return rac;
        }

        public Record PreviousRecord()
        {
            Racun rac = new Racun();
            try
            {
                racun.prev();

                setFields(rac);
            } catch(KfException ex)
            {
                throw ex;
            }
            return rac;

        }



        private void setFields(Racun rac)
        {
            rac.rr_siz = racun.getField("rr_siz").getString();
            rac.rr_sif = racun.getField("rr_sif").getString();
            rac.rr_sst = racun.getField("rr_sst").getString();

            

            string rr_pod = racun.getField("rr_pod").getString();

            mat.getField("m_siz").setString(rac.rr_siz);
            mat.getField("m_sif").setString(rac.rr_sif);
            mat.getField("m_sst").setString(rac.rr_sst);

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
                    podst.getField("po_br").setString(rr_pod);
                    podst.findu();
                    rac.toplinski_sustav = podst.getField("po_sustav").getString();
                    char firstChar = rac.toplinski_sustav.Substring(0, 1)[0];


                    rac.toplinski_sustav = racun.getField("rr_mjestog").getString();
                    rac.obracunsko_mjerno_mjesto_voda = racun.getField("rr_mjestov").getString();
                    rac.obracunska_mjerna_mjesta = racun.getField("rr_mjestog").getString();
                    if (rac.obracunsko_mjerno_mjesto_voda != "0")
                    {
                        rac.obracunska_mjerna_mjesta += $" - {rac.obracunsko_mjerno_mjesto_voda}";
                    }
                    Debug.WriteLine(rac.obracunsko_mjerno_mjesto_grijanje);
                    Debug.WriteLine(rac.obracunsko_mjerno_mjesto_voda);
                    rac.rr_rn = racun.getField("rr_rn").getString();
                    rac.interni_broj_racuna = racun.getField("rr_rn").getString();
                    //rac.krajnji_kupac = mat.getField("m_ime").getString();
                    rac.krajnji_kupac = Encoding.GetEncoding(1250).GetString(mat.getField("m_ime").getBinary());
                    //MessageBox.Show(Encoding.GetEncoding(1250).GetString(mat.getField("m_ime").getBinary()));

                    rac.OIB = mat.getField("m_oib").getString();
                    rac.namjena = rac.obracunsko_mjerno_mjesto_voda != "0" ? "GRIJANJE - PTV" : "GRIJANJE";
                    rac.adresa_obracunskog_mjernog_mjesta = $"{Encoding.GetEncoding(1250).GetString(mjul.getField("mu_uln").getBinary())} {mat.getField("m_sub").getString()}";
                    
                    rac.grad_omm = "VUKOVAR";

                    rac.naziv_toplinskog_sustava = rac.toplinski_sustav.Substring(0, 1)[0] == 'C' ? "C" : "Z";
                    try
                    {
                        rac.refundacija_od = racun.getField("rr_dp").getString();
                        DateTime datum = Helpers.convertToDateTime(rac.refundacija_od);
                        datum = datum.AddDays(datum.Day * (-1) + 1);
                        rac.refundacija_od = (datum).ToString("dd.MM.yyyy");
                    }
                    catch (System.ArgumentOutOfRangeException ex)
                    {
                        rac.refundacija_od = String.Empty;
                    }

                    try
                    {
                        rac.refundacija_do = racun.getField("rr_dp").getString();

                    }
                    catch (System.ArgumentOutOfRangeException ex)
                    {
                        Debug.WriteLine(ex.Message);
                        rac.refundacija_do = String.Empty;
                    }

                    rac.tarifni_model = mat.getField("m_tm").getString();
                    if (rac.tarifni_model == "TM9" || rac.tarifni_model == "TM10")
                    {
                        rac.tarifni_model = "TM1";
                    }
                    else if (rac.tarifni_model == "TM5" || rac.tarifni_model == "TM6")
                    {
                        rac.tarifni_model = "TM2";
                    }

                    rac.isporucena_toplinska_energija = racun.getField("rr_energ").getDouble() + racun.getField("rr_ptv").getDouble() + racun.getField("rr_ener").getDouble();


                    // isporucena_toplinska_energija = "ISPORUCENA TOPLINSKA ENERGIJA";

                    /* Set currency depending on the year of issue of the bill*/
                    rac.valuta = "EUR";
                    // Get date of the bill
                    string[] date = racun.getField("rr_dp").getString().Split('.');
                    int year = int.Parse(date[date.Length - 1]);

                    if (year < 2023)
                    {
                        rac.valuta = "HRK";
                    }

                    rac.iznos_razlike_jed = racun.getField("rr_cij_subv") != null ? Math.Abs(racun.getField("rr_cij_subv").getDouble()).ToString() : "";

                    rac.ukupanIznosRacuna = racun.getField("rr_sveukk").getDouble();
                    rac.ukupanIznosRacunaNakonUmanjenja = racun.getField("rr_sveukkk").getDouble();
                    rac.iznos_razlike = Math.Abs(racun.getField("rr_subv").getDouble());
                    rac.napomena = "";
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void rewindAll()
        {
            racun.rewind();
            mat.rewind();
            mjul.rewind();
            podst.rewind();
        }

        Record IRecordRepository.GetRecordById()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Record> IRecordRepository.GetAllRecords()
        {
            throw new NotImplementedException();
        }
    }
}
