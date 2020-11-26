using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class DictionaryController : Controller
    {
        [Route("get_value_method")]
        public string GetValueMethod()
        {
            string test = "";
            Dictionary<string, string> capitalCities = new Dictionary<string, string>();
            capitalCities.Add("England","London");
            capitalCities.Add("Germany", "Berlin");
            capitalCities.Add("Norway", "Oslo");
            capitalCities.Add("USA", "Washington DC");
            capitalCities.TryGetValue("Norway", out test);
            RevDeBugAPI.Snapshot.RecordSnapshot("get_value_method");
            return test;
        }
        [Route("get_value_assign")]
        public string GetValueAssign()
        {
            string test = "";
            Dictionary<string, string> capitalCities = new Dictionary<string, string>();
            capitalCities.Add("England", "London");
            capitalCities.Add("Germany", "Berlin");
            capitalCities.Add("Norway", "Oslo");
            capitalCities.Add("USA", "Washington DC");
            test += capitalCities["England"];
            RevDeBugAPI.Snapshot.RecordSnapshot("get_value_assign");
            return test;
        }
        [Route("update_value")]
        public string UpdateValue()
        {
            string test = "";
            Dictionary<string, string> cities = new Dictionary<string, string>();
            cities.Add("England", "London");
            cities.Add("Germany", "Berlin");
            cities["England"]="Liverpool, Bristol";
            test += cities["England"];
            RevDeBugAPI.Snapshot.RecordSnapshot("update_value");
            return test;
        }
        [Route("clear_values")]
        public string ClearValues()
        {
            string test = "";
            Dictionary<string, string> cities = new Dictionary<string, string>();
            cities.Add("England", "London");
            cities.Add("Germany", "Berlin");
            cities["England"] = "Liverpool, Bristol";
            cities.Clear();
            try
            {
                test += cities["England"];
            }
            catch(Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("clear_values");
            return test;
        }
        [Route("remove_value")]
        public string RemoveValue()
        {
            string test = "";
            Dictionary<string, string> cities = new Dictionary<string, string>();
            cities.Add("England", "London");
            cities.Add("Germany", "Berlin");
            cities.Add("Norway", "Oslo");
            cities.Add("Poland", "Warsaw");
            cities["England"] = "Liverpool, Bristol";
            cities.Remove("England");
            try
            {
                for (int i=0;i<cities.Count;i++) 
                { 
                    test += string.Format("Key: {0}, Value: {1} \n", cities.ElementAt(i).Key, cities.ElementAt(i).Value);
                }
            }
            catch (Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("remove_value");
            return test;
        }
        [Route("get_from_value")]
        public string GetFromValue()
        {
            string test = "";
            Dictionary<string, string> cities = new Dictionary<string, string>();
            cities.Add("England", "London");
            cities.Add("Germany", "Berlin");
            cities.Add("Norway", "Oslo");
            cities.Add("Poland", "Warsaw");
            try
            {
                if(cities.ContainsKey("Germany"))
               test+= cities["Germany"];
            }
            catch (Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("get_from_value");
            return test;
        }
        [Route("different_types")]
        public string DifferentTypes()
        {
            string test = "";
            Dictionary<string, int> person = new Dictionary<string, int>();
            person.Add("Steven", 32);
            person.Add("Joe", 30);
            person.Add("Tom", 16);
            person.Add("Brad", 24);
            try
            {
                test +="Name: " +person.ElementAt(0).Key + "\nAge: " + person.ElementAt(0).Value;
            }
            catch (Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("different_types");
            return test;
        }
    }
}
