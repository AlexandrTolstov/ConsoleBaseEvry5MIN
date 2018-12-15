using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;

namespace ConsoleBaseEvry5MIN
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static void getCurrency()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;

            try
            {
                List<Currency> сurrencies = new List<Currency>();
                XDocument xdoc = XDocument.Load(ConnectionString);

                foreach (XElement item in xdoc.Element("rss").Element("channel").Elements("item"))
                {
                    Currency cur = new Currency();
                    cur.title = item.Element("title").Value;
                    cur.PubDate = Convert.ToDateTime(item.Element("pubDate").Value);
                    cur.Description = Convert.ToDouble(item.Element("description").Value.Replace('.', ','));

                    сurrencies.Add(cur);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
