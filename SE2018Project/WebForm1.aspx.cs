using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace SE2018Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        //Create XML documents for Address1
        public static string CreateAddress1XML(string address)
        {
            address = Regex.Replace(address, @"\p{P}", "");
            XmlDocument doc = new XmlDocument();
            XmlElement address1 = doc.CreateElement("Address1");
            address1.InnerText = address;

            doc.AppendChild(address1);

            return doc.OuterXml;
        }

        //Create XML documents for Address2
        public static string CreateAddress2XML(string address)
        {
            address = Regex.Replace(address, @"\p{P}", "");
            XmlDocument doc = new XmlDocument();
            XmlElement address2 = doc.CreateElement("Address2");
            address2.InnerText = address;

            doc.AppendChild(address2);

            return doc.OuterXml;
        }

        //Create XML documents for City
        public static string CreateCityXML(string city)
        {
            city = Regex.Replace(city, @"\p{P}", "");
            XmlDocument doc = new XmlDocument();
            XmlElement xcity = doc.CreateElement("City");
            xcity.InnerText = city;

            doc.AppendChild(xcity);

            return doc.OuterXml;
        }

        //Create XML documents for State
        public static string CreateStateXML(string state)
        {
            state = Regex.Replace(state, @"\p{P}", "");
            XmlDocument doc = new XmlDocument();
            XmlElement xstate = doc.CreateElement("State");
            xstate.InnerText = state;
            doc.AppendChild(xstate);

            return doc.OuterXml;
        }

        //Create XML documents for Zip4
        public static string CreateZip4XML(string zip)
        {
            zip = Regex.Replace(zip, @"\p{P}", "");
            XmlDocument doc = new XmlDocument();
            XmlElement zip4 = doc.CreateElement("Zip4");
            zip4.InnerText = zip;

            doc.AppendChild(zip4);

            return doc.OuterXml;
        }

        //Create XML documents for Zip5
        public static string CreateZip5XML(string zip)
        {
            zip = Regex.Replace(zip, @"\p{P}", "");
            XmlDocument doc = new XmlDocument();
            XmlElement zip5 = doc.CreateElement("Zip5");
            zip5.InnerText = zip;
            doc.AppendChild(zip5);

            return doc.OuterXml;
        }

        //Validate button
        protected void Validate_Click(object sender, EventArgs e)
        {
                string uspsUrl = "http://production.shippingapis.com/ShippingAPITest.dll?API=";
                string userId = "Your userID";

                GetAddress(ApptNum.Text, Address.Text, City.Text, State.Text, ZipCode.Text, ZipCode4.Text, uspsUrl, userId);
        }

        //TextBoxes
        protected void ZipCode_TextChanged(object sender, EventArgs e) { }
        protected void Address_TextChanged(object sender, EventArgs e) { }
        protected void ApptNum_TextChanged(object sender, EventArgs e) { }
        protected void TextBox1_TextChanged(object sender, EventArgs e) { }
        protected void TextBox2_TextChanged(object sender, EventArgs e) { }  

        //Getting address function 
        public void GetAddress(string address1, string address2, string city, string state, string zip5, string zip4, string url, string id)
        {
            //API
            string api = "Verify";

            //Creates open url
            string urlOpen = url + api + "&XML=<AddressValidateRequest USERID=\"" + id + "\"><Address ID =\"0\">";
            //Closes the url
            string urlClose = "</Address></AddressValidateRequest>";

            //Creates string of XML documents
            string xml = CreateAddress1XML(address1) + CreateAddress2XML(address2) + CreateCityXML(city) + CreateStateXML(state) + CreateZip5XML(zip5) + CreateZip4XML(zip4);

            //full request URL
            string requestUrl = urlOpen + xml + urlClose;

            //creates new XML document 
            XmlDocument doc = new XmlDocument();
            //loads XML documents from specific URL
            doc.Load(requestUrl);

            //Error check (if there exists an error output description to the textbox)
            XmlNodeList error = doc.GetElementsByTagName("Error");
            if (error[0] != null)
            {
                XmlNodeList description = doc.GetElementsByTagName("Description");
                TextBox1.Text = description[0].InnerText;
            }
            else
            {
                //Returns an XmlNodeList containing a list of all descendant elements that match the specified Name
                XmlNodeList address1list = doc.GetElementsByTagName("Address1");
                XmlNodeList address2list = doc.GetElementsByTagName("Address2");
                XmlNodeList citylist = doc.GetElementsByTagName("City");
                XmlNodeList statelist = doc.GetElementsByTagName("State");
                XmlNodeList zip5list = doc.GetElementsByTagName("Zip5");
                XmlNodeList zip4list = doc.GetElementsByTagName("Zip4");

                //if there exists an appt/suite number replace address1 textbox w/ newly created list
                if (!String.IsNullOrWhiteSpace(address1))
                    ApptNum.Text = address1list[0].InnerText;
                Address.Text = address2list[0].InnerText;
                City.Text = citylist[0].InnerText;
                State.Text = statelist[0].InnerText;
                ZipCode.Text = zip5list[0].InnerText;
                ZipCode4.Text = zip4list[0].InnerText;
                
                //textbox output 
                if (!String.IsNullOrWhiteSpace(address1))
                    TextBox1.Text = address2list[0].InnerText + "\n" + address1list[0].InnerText + "\n" + citylist[0].InnerText + " " + statelist[0].InnerText + " " + zip5list[0].InnerText + "-" + zip4list[0].InnerText;
                else
                    TextBox1.Text = address2list[0].InnerText + "\n" + citylist[0].InnerText + " " + statelist[0].InnerText + " " + zip5list[0].InnerText + "-" + zip4list[0].InnerText;
            }
        }

        protected void ZipCode_TextChanged1(object sender, EventArgs e)
        {

        }
    }
}
