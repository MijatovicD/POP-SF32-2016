using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace POP_SF32_2016.Model
{
    public class AkcijskaProdaja : INotifyPropertyChanged, ICloneable
    {
        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private DateTime datumPocetka;

        public DateTime DatumPocetka
        {
            get
            {
                return datumPocetka;
            }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }

        private decimal popust;

        public decimal Popust
        {
            get
            {
                return popust;
            }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }

        private DateTime datumZavrsetka;

        public DateTime DatumZavrsetka
        {
            get
            {
                return datumZavrsetka;
            }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }
        }

        private int namestajId;

        public int NamestajId
        {
            get
            {
                return namestajId;
            }
            set
            {
                namestajId = value;
                OnPropertyChanged("NamestajId");
            }
        }

        private Namestaj namestaj;

        [XmlIgnore]
        public Namestaj Namestaj
        {
            get
            {
                if (namestaj == null)
                {
                    namestaj = Namestaj.GetById(NamestajId);
                }
                return namestaj;
            }
            set
            {
                try
                {
                    namestaj = value;
                    NamestajId = namestaj.Id;
                    OnPropertyChanged("Namestaj");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska");
                }
            }
        }

        private bool obrisan;

        public bool Obrisan
        {
            get
            {
                return obrisan;
            }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        private string naziv;

        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Naziv}, {Popust}";
        }

        public static AkcijskaProdaja GetById(int id)
        {
            foreach (var akcija in Projekat.Instance.AkcijskeProdaje)
            {
                if (akcija.Id == id)
                {
                    return akcija;
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return new AkcijskaProdaja()
            {
                Id = id,
                DatumPocetka = datumPocetka,
                Popust = popust,
                DatumZavrsetka = datumZavrsetka,
                NamestajId = namestajId,
                Naziv = naziv
            };
        }

        #region CRUD
        public static ObservableCollection<AkcijskaProdaja> GetAll()
        {
            var akcijskaProdaja = new ObservableCollection<AkcijskaProdaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM AkcijskaProdaja WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "AkcijskaProdaja");

                foreach (DataRow row in ds.Tables["AkcijskaProdaja"].Rows)
                {
                    var a = new AkcijskaProdaja();
                    a.Id = int.Parse(row["Id"].ToString());
                    a.DatumPocetka = DateTime.Parse(row["DatumPocetka"].ToString());
                    a.Popust = decimal.Parse(row["Popust"].ToString());
                    a.DatumZavrsetka = DateTime.Parse(row["DatumZavrsetka"].ToString());
                    a.NamestajId = int.Parse(row["NamestajId"].ToString());
                    a.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    a.Naziv = row["Naziv"].ToString();

                    akcijskaProdaja.Add(a);
                }

            }


            return akcijskaProdaja;
        }
        #endregion


        #region CRUD
        public static AkcijskaProdaja Create(AkcijskaProdaja a)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "INSERT INTO AkcijskaProdaja (DatumPocetka, Popust, DatumZavrsetka, Naziv, NamestajId, Obrisan) VALUES (@DatumPocetka, @Popust, @DatumZavrsetka, @Naziv, @NamestajId, @Obrisan);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("DatumPocetka", a.DatumPocetka);
                    cmd.Parameters.AddWithValue("Popust", a.Popust);
                    cmd.Parameters.AddWithValue("DatumZavrsetka", a.DatumZavrsetka);
                    cmd.Parameters.AddWithValue("Naziv", a.Naziv);
                    cmd.Parameters.AddWithValue("NamestajId", a.NamestajId);
                    cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                    a.Id = int.Parse(cmd.ExecuteScalar().ToString());

                    var listaAkcija = Projekat.Instance.Akcija;

                    foreach (var akcija in listaAkcija)
                    {
                        SqlCommand command = con.CreateCommand();


                        command.CommandText = "INSERT INTO NaAkciji (NamestajId, AkcijaId, Obrisan) VALUES (@NamestajId, @AkcijaId, @Obrisan);";
                        command.Parameters.AddWithValue("NamestajId", a.NamestajId);
                        command.Parameters.AddWithValue("AkcijaId", a.Id);
                        command.Parameters.AddWithValue("Obrisan", akcija.Obrisan);

                        command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspesno dodavanje", "Greska");
                }
           

            }

            Projekat.Instance.AkcijskeProdaje.Add(a);

            return a;
        }
        #endregion

        #region CRUD
        public static void Update(AkcijskaProdaja a)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "UPDATE AkcijskaProdaja SET DatumPocetka=@DatumPocetka, Popust=@Popust, DatumZavrsetka=@DatumZavrsetka, NamestajId=@NamestajId, Obrisan=@Obrisan, @Naziv=Naziv WHERE Id=@Id;";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Id", a.Id);
                    cmd.Parameters.AddWithValue("DatumPocetka", a.DatumPocetka);
                    cmd.Parameters.AddWithValue("Popust", a.Popust);
                    cmd.Parameters.AddWithValue("DatumZavrsetka", a.DatumZavrsetka);
                    cmd.Parameters.AddWithValue("NamestajId", a.NamestajId);
                    cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);
                    cmd.Parameters.AddWithValue("Naziv", a.Naziv);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspesno azuriranje", "Greska");
                }

            }

            foreach (var akcijskaProdaja in Projekat.Instance.AkcijskeProdaje)
            {
                if (a.Id == akcijskaProdaja.Id)
                {
                    akcijskaProdaja.DatumPocetka = a.DatumPocetka;
                    akcijskaProdaja.Popust = a.Popust;
                    akcijskaProdaja.DatumZavrsetka = a.DatumZavrsetka;
                    akcijskaProdaja.Namestaj = a.Namestaj;
                    akcijskaProdaja.NamestajId = a.NamestajId;
                    akcijskaProdaja.Obrisan = a.Obrisan;
                    akcijskaProdaja.Naziv = a.Naziv;
                }
            }
        }

        public static void Delete(AkcijskaProdaja a)
        {
            try
            {
                a.Obrisan = true;
                Update(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Neuspesno brisanje", "Greska");
            }
        }
        #endregion
    }
}
