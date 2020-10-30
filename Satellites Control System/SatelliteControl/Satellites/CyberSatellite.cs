using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteControl.Satellites
{
    public class CyberSatellite : Satellite
    {
        #region Ctor

        public CyberSatellite(SatelliteUnit satelliteControl)
            : base(satelliteControl)
        {
            mCommands.Add("SearchInText", 2);
        }

        #endregion

        #region Methods

        private int SearchInText(string filePath, string word)
        {
            string text = "I go to army every day"; // File.ReadAllText(filePath);

            int counter = 0;
            int indexOf = -1;

            while ((indexOf = text.IndexOf(word, indexOf + 1)) != -1)
            {
                counter++;
            }

            return counter;
        }

        #endregion

        #region Strategy

        internal override object ExecuteCommand(string commandName, object[] args)
        {
            if (!mCommands.ContainsKey(commandName) || mCommands[commandName] != args.Length)
            {
                mIsLocked = true;
                mLockedTimer.Start();
            }

            switch (commandName)
            {
                case "Search":
                    {
                        return SearchInText((string)args[0], (string)args[1]);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        #endregion
    }
}
