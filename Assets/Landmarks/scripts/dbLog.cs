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
using System.Text.RegularExpressions;

public class dbLog
{

    protected long microseconds = 1;
    protected string workingFile = "";
    private StreamWriter logfile;

	public dbLog(string filename)
    {
        setLogDirectory(filename);
		logfile = new StreamWriter (workingFile);
	}

    //basically jsut creates a folder if it doesn't exist yet
    protected void setLogDirectory(string filename)
    {
        workingFile = filename;
        //creates a folder for the patient, if it doesnt exist
        var folderName = RegexHelpers.GetFolderFromFilepath(workingFile);
        Directory.CreateDirectory(folderName);
    }
	
	public dbLog()
    {
		//openNew(filename);
	}
	
	public virtual void close()
	{
		logfile.Close();	
	}
	
	public virtual string[] NextAction()
    {
		return null;
	}
	public virtual long PlaybackTime()
    {
		return 0;
	}
	
	public virtual void log(string msg, int level)
    {
	    long tick = DateTime.Now.Ticks;
        long milliseconds = tick / TimeSpan.TicksPerMillisecond;
        microseconds = tick / 10;
		logfile.WriteLine( milliseconds + "\t0\t" + msg );
	}
}
