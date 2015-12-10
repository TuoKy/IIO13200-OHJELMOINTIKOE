using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Tehtavat_H3408_T2ASP : System.Web.UI.Page
{
    DataSet orjaDataSet;
    string filePath = ConfigurationManager.AppSettings["Orjat"];
    int maara = 0, palkkaKulut = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                getAllData();
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Tiedosto puuttuu tai sijainti virheellinen');", true);
            }
        }
            
    }

    private void getAllData()
    {               
        orjaDataSet = new DataSet();
        try
        {
            orjaDataSet.ReadXml(filePath);
            OrjaTaulu.DataSource = orjaDataSet.Tables[0].DefaultView;
            OrjaTaulu.DataBind();
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Tiedosto puuttuu tai sijainti virheellinen');", true);
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        orjaDataSet = new DataSet();
        try
        {
            orjaDataSet.ReadXml(filePath);
            DataView orjadada = new DataView();
            orjadada = orjaDataSet.Tables[0].DefaultView;
            orjadada.RowFilter = "tyosuhde='vakituinen'";
            OrjaTaulu.DataSource = orjadada;
            OrjaTaulu.DataBind();
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Tiedosto puuttuu tai sijainti virheellinen');", true);
        }       
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //näytä määräaikaiset
        orjaDataSet = new DataSet();
        try
        {
            orjaDataSet.ReadXml(filePath);
            DataView orjadada = new DataView();
            orjadada = orjaDataSet.Tables[0].DefaultView;
            orjadada.RowFilter = "tyosuhde='määräaikainen'";
            OrjaTaulu.DataSource = orjadada;
            OrjaTaulu.DataBind();
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Tiedosto puuttuu tai sijainti virheellinen');", true);
        }
        
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        //näytä muut
        orjaDataSet = new DataSet();
        orjaDataSet.ReadXml(filePath);
        DataView orjadada = new DataView();
        orjadada = orjaDataSet.Tables[0].DefaultView;
        orjadada.RowFilter = "tyosuhde='vierailija'";
        OrjaTaulu.DataSource = orjadada;
        OrjaTaulu.DataBind();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        //näytä kaikki
        getAllData();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //laske kaikkien määrä
        XmlDocument xml = new XmlDocument();
        xml.Load(ConfigurationManager.AppSettings["Orjat"]);

        XmlNodeList nodeList = xml.SelectNodes("/tyontekijat/tyontekija");
        foreach (XmlNode node in nodeList)
        {
            maara++;
        }      
        valitut.Text = maara.ToString();
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        //vakituisten määrä

        XmlDocument xml = new XmlDocument();
        xml.Load(ConfigurationManager.AppSettings["Orjat"]);

        XmlNodeList nodeList = xml.SelectNodes("/tyontekijat/tyontekija");
        foreach (XmlNode node in nodeList)
        {
            if (node["tyosuhde"].InnerText == "vakituinen")
                maara++;
        }
        valitut.Text = maara.ToString();
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        //määräaiakisten määrä
        XmlDocument xml = new XmlDocument();
        xml.Load(ConfigurationManager.AppSettings["Orjat"]);

        XmlNodeList nodeList = xml.SelectNodes("/tyontekijat/tyontekija");
        foreach (XmlNode node in nodeList)
        {
            if (node["tyosuhde"].InnerText == "määräaikainen")
                maara++;
        }
        valitut.Text = maara.ToString();

    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        //Muiden määrä
        XmlDocument xml = new XmlDocument();
        xml.Load(ConfigurationManager.AppSettings["Orjat"]);

        XmlNodeList nodeList = xml.SelectNodes("/tyontekijat/tyontekija");
        foreach (XmlNode node in nodeList)
        {
            if (node["tyosuhde"].InnerText != "määräaikainen" && node["tyosuhde"].InnerText != "vakituinen")
                maara++;
        }
        valitut.Text = maara.ToString();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //kaikkien palakt
        XmlDocument xml = new XmlDocument();
        xml.Load(ConfigurationManager.AppSettings["Orjat"]);

        XmlNodeList nodeList = xml.SelectNodes("/tyontekijat/tyontekija");
        foreach (XmlNode node in nodeList)
        {
            palkkaKulut += int.Parse(node["palkka"].InnerText);
        }
        valitutPalkat.Text = palkkaKulut.ToString();
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        //vakituisten palakat
        XmlDocument xml = new XmlDocument();
        xml.Load(ConfigurationManager.AppSettings["Orjat"]);

        XmlNodeList nodeList = xml.SelectNodes("/tyontekijat/tyontekija");
        foreach (XmlNode node in nodeList)
        {
            if (node["tyosuhde"].InnerText == "vakituinen")
                palkkaKulut += int.Parse(node["palkka"].InnerText);
        }
        valitutPalkat.Text = palkkaKulut.ToString();
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        //määräaikaisten palakt
        XmlDocument xml = new XmlDocument();
        xml.Load(ConfigurationManager.AppSettings["Orjat"]);

        XmlNodeList nodeList = xml.SelectNodes("/tyontekijat/tyontekija");
        foreach (XmlNode node in nodeList)
        {
            if (node["tyosuhde"].InnerText == "määräaikainen")
                palkkaKulut += int.Parse(node["palkka"].InnerText);
        }
        valitutPalkat.Text = palkkaKulut.ToString();
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        //muitten palakt
        XmlDocument xml = new XmlDocument();
        xml.Load(ConfigurationManager.AppSettings["Orjat"]);

        XmlNodeList nodeList = xml.SelectNodes("/tyontekijat/tyontekija");
        foreach (XmlNode node in nodeList)
        {
            if (node["tyosuhde"].InnerText != "määräaikainen" && node["tyosuhde"].InnerText != "vakituinen")
                palkkaKulut += int.Parse(node["palkka"].InnerText);
        }
        valitutPalkat.Text = palkkaKulut.ToString();

    }
}