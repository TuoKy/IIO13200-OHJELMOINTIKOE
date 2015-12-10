using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Tehtavat_H3408_T3bLogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void logIn_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(ConfigurationManager.AppSettings["tunnukset"]);

            XmlNodeList nodeList = xml.SelectNodes("/kayttajat/kayttaja");
            foreach (XmlNode node in nodeList)
            {
                if (node["nimi"].InnerText.Equals(nimi.Text) && node["passu"].InnerText.Equals(passu.Text))
                {
                    Session["kayttaja"] = nimi.Text;
                    Server.Transfer("H3408_T3bDestination.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Väärät tunniste tiedot');", true);
                }
            }
        }
    }
}