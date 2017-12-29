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
                namestaj = value;
                NamestajId = namestaj.Id;
                OnPropertyChanged("Namestaj");
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

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{DatumPocetka}, {Popust}, {DatumZavrsetka}";
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
                NamestajId = namestajId
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

                    akcijskaProdaja.Add(a);
                }

            }


            return akcijskaProdaja;
        }
        #endregion


        #region CRUD
        public static ObservableCollection<Namestaj> NaAkciji()
        {
            var namestaj = new ObservableCollection<Namestaj>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Namestaj WHERE Id NOT IN (SELECT NamestajId FROM NaAkciji) AND Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj");

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.Naziv = row["Naziv"].ToString();
                    n.Sifra = row["Sifra"].ToString();
                    n.JedinicnaCena = double.Parse(row["Cena"].ToString());
                    n.KolicinaUMagacinu = int.Parse(row["Kolicina"].ToString());
                    n.AkcijaId = int.Parse(row["AkcijaId"].ToString());
                    n.TipNamestajaId = int.Parse(row["TipNamestajaId"].ToString());
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namestaj.Add(n);
                }

            }


            return namestaj;
        }
        #endregion

        #region CRUD
        public static AkcijskaProdaja Create(AkcijskaProdaja a)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();


                cmd.CommandText = "INSERT INTO AkcijskaProdaja (DatumPocetka, Popust, DatumZavrsetka, NamestajId, Obrisan) VALUES (@DatumPocetka, @Popust, @DatumZavrsetka, @NamestajId, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("DatumPocetka", a.DatumPocetka);
                cmd.Parameters.AddWithValue("Popust", a.Popust);
                cmd.Parameters.AddWithValue("DatumZavrsetka", a.DatumZavrsetka);
                cmd.Parameters.AddWithValue("NamestajId", a.NamestajId);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                a.Id = int.Parse(cmd.ExecuteScalar().ToString());
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


                cmd.CommandText = "UPDATE AkcijskaProdaja SET DatumPocetka=@DatumPocetka, Popust=@Popust, DatumZavrsetka=@DatumZavrsetka, NamestajId=@NamestajId, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", a.Id);
                cmd.Parameters.AddWithValue("DatumPocetka", a.DatumPocetka);
                cmd.Parameters.AddWithValue("Popust", a.Popust);
                cmd.Parameters.AddWithValue("DatumZavrsetka", a.DatumZavrsetka);
                cmd.Parameters.AddWithValue("NamestajId", a.NamestajId);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                cmd.ExecuteNonQuery();
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
                }
            }
        }

        public static void Delete(AkcijskaProdaja a)
        {
            a.Obrisan = true;
            Update(a);
        }
        #endregion
    }
}
