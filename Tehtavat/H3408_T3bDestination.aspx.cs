using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

public partial class Tehtavat_H3408_T3bDestination : System.Web.UI.Page
{
    DataSet koodit;
    //huonosti nimetty tiedostonimi
    string filePath = ConfigurationManager.AppSettings["koodaajat"];
    koodaajat kaikkiKoodaajat;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["kayttaja"] == null)
            Server.Transfer("H3408_T3bDestination.aspx");

        if (!IsPostBack)
        {
            gatAllData();
            nimi.Text = (string)Session["kayttaja"];
            paiva.Text = DateTime.Now.Date.ToShortDateString();
        }

    }

    private void gatAllData()
    {
        koodit = new DataSet();
        try
        {
            koodit.ReadXml(filePath);
            koodiTaulu.DataSource = koodit.Tables[0].DefaultView;
            koodiTaulu.DataBind();
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Tiedosto puuttuu tai sijainti virheellinen');", true);
        }
    }


    protected void lisaa_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            luomerkinta(nimi.Text, paiva.Text, aika.Text);
            gatAllData();
        }
    }

    public void luomerkinta(string a, string b, string c)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(koodaajat));

        using (Stream inputStream = File.OpenRead(filePath))
            kaikkiKoodaajat = (koodaajat)xmlSerializer.Deserialize(inputStream);

        tieto uusiUljas = new tieto
        {
            nimi = a,
            paiva = b,
            aika = c,
        };
        kaikkiKoodaajat.lTiedot.Add(uusiUljas);

        using (Stream outputStream = File.OpenWrite(filePath))
            xmlSerializer.Serialize(outputStream, kaikkiKoodaajat);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Näytä vain omat
        DataSet tempDataSet = new DataSet();
        try
        {
            tempDataSet.ReadXml(filePath);
            DataView orjadada = new DataView();
            orjadada = tempDataSet.Tables[0].DefaultView;
            string temp = String.Format("nimi='{0}'", (string)Session["kayttaja"]);
            orjadada.RowFilter = temp;
            koodiTaulu.DataSource = orjadada;
            koodiTaulu.DataBind();

            int tempTunnit = 0;

            //Hullua copypastea
            XmlDocument xml = new XmlDocument();
            xml.Load(ConfigurationManager.AppSettings["koodaajat"]);

            XmlNodeList nodeList = xml.SelectNodes("/koodaajat/koodaaja");
            foreach (XmlNode node in nodeList)
            { 
                if(node["nimi"].Equals(Session["kayttaja"]))
                    tempTunnit += int.Parse(node["aika"].InnerText);
            }
            tunnit.Text = tempTunnit.ToString();

        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Tiedosto puuttuu tai sijainti virheellinen');", true);
        }
    }
}
[XmlRoot("koodaajat")]
    public class koodaajat
    {
        [XmlElement(ElementName = "koodaaja")]
        public List<tieto> lTiedot { get; set; }
    }
    public class tieto
    {
        [XmlElement]
        public string nimi { get; set; }

        [XmlElement]
        public string paiva { get; set; }

        [XmlElement]
        public string aika { get; set; }
}