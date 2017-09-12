/*
    Copyright (C) 2010  Jason Laczko

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.IO;
using System.Collections.Generic;

public class dbPlaybackLog : dbLog
{
    private StreamReader logfile;
    private List<string[]> actions;
    public long start_time = 0;
    private long playback_time = 0;
    private string[] next_action;
    private int index = 0;
    
    public override long PlaybackTime()
    {
		return Int64.Parse(next_action[0]) - start_time;
	}

	public dbPlaybackLog(string filename)
    {
        setLogDirectory(filename);
        logfile = new StreamReader ( workingFile );

        actions = new List<string[]>();
	    string[] actiondefs;

        string line = logfile.ReadLine();
        while (line != null)
        {
        	actiondefs = line.Split(new char[] {'\t'});
        	actions.Add(actiondefs);
			line = logfile.ReadLine();
        }
		start_time = Int64.Parse(actions[0][0]);
	}

	public override string[] NextAction()
    {
		next_action = actions[index];
		index++;
		if (index >= actions.Count) {
			return null;
		} else {
			return next_action;
		}
	}
	
	public override void log(string msg, int level)
    {
		//ignore logs		
	}
}
