using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioPlanner
{
    internal class ScenarioPlannerService
    {
        internal string[] _roles { get; set; } = null!;
        internal string[] _scenarios { get; set; } = null!;
        internal string[] _timeframes { get; set; } = null!;

        internal string[] prepString(string text)
        {
            string[] noPreppedArray = text.Split(',');
            string[] preppedArray = new string[noPreppedArray.Length];

            for (int i = 0; i < preppedArray.Length; i++)
            {
                string cleaned = noPreppedArray[i].Trim();
                preppedArray[i] = cleaned;
            }
            return preppedArray;
        }




        public void addRoles(string roles)
        {
            _roles = prepString(roles);
        }

        public string[] getRoles()
        {
            return _roles;
        }


        public void addScenarios(string scenarios)
        {

            _scenarios = prepString(scenarios);
        }

        public string[] getSenarios()
        {
            return _scenarios;
        }

        public void addTimeFrames(string timeFrame)
        {

            _timeframes = prepString(timeFrame);
        }

        public string[] getTimeFrames()
        {
            return _timeframes;
        }


        public string getTable()
        {
            int maxLength = 0;
            List<Dictionary<string, string>> rows = new List<Dictionary<string,string>>();

            foreach(string role in _roles)
            {
                foreach(string scenario in _scenarios)
                {
                    foreach(string timeframe in _timeframes)
                    {
                        string link = $"[[{role.Replace(' ', '_')}-{scenario.Replace(' ', '_')}-{timeframe.Replace(' ', '_')}]]";
                        if (link.Length > maxLength)
                        {
                            maxLength = link.Length;
                        }


                       Dictionary<string,string> row =  new Dictionary<string, string>();
                        row.Add("link", link);
                        row.Add("role", role);
                        row.Add("scenario", scenario);
                        row.Add("timeframe", timeframe);
                        rows.Add(row);
                    }
                }
            }

            string header = $"|{BuildSpace(maxLength,"link")}|{BuildSpace(maxLength, "role")}|{BuildSpace(maxLength, "scenario")}|{BuildSpace(maxLength, "timeframe")}|\r\n";
            string spacer = $"|{new String('-', BuildSpace(maxLength, "link").Length)}|{new String('-', BuildSpace(maxLength, "link").Length)}|{new String('-', BuildSpace(maxLength, "link").Length)}|{new String('-', BuildSpace(maxLength, "link").Length)}|\r\n";

            string body = header + spacer;
            foreach(Dictionary<string,string>row in rows)
            {
                body = body + $"|{BuildSpace(maxLength, row["link"])}|{BuildSpace(maxLength, row["role"])}|{BuildSpace(maxLength, row["scenario"])}|{BuildSpace(maxLength, row["timeframe"])}|\r\n";
            }

            return body;

        }

        public string BuildSpace (int maxLength,string text)
        {
            if (text.Length == maxLength)
            {
                return text;
            }
            int spaces = maxLength - text.Length+1;
            bool isEven = spaces % 2 > 0;
            if (isEven == true)
            {
                int spacesAround =spaces / 2;
                return new String(' ', spacesAround) + text + new String(' ', spacesAround);
            }
        
                int frontSpaces = (spaces - 1) / 2;
                int backSpaces = frontSpaces + 1;
                return new String(' ', frontSpaces) + text + new String(' ', backSpaces);
            


          
        }

    }
}
