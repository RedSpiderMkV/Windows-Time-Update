
import urllib2
import json

from datetime import datetime, timedelta

class timeSync:
    syncUrl = r'http://www.portvisibility.co.uk/visibility/tools/showTime.php'
    
    def __init__(self):
        response = urllib2.urlopen(self.syncUrl)
        timeJson = response.read()
        
        self.time = json.loads(timeJson)['time']
        self.date = json.loads(timeJson)['date']
        
    def printTimeStr(self):
        print(self.dateTime)
        
    def getTimeWithTimezoneOffset(self, timezoneOffset):
        t = datetime.strptime(self.time, '%H:%M:%S %Z')
        d = datetime.strptime(self.date, '%Y-%m-%d')
        t = t + timedelta(hours=timezoneOffset)
        validatedTime = '%d-%02d-%02d %02d:%02d:%02d' % (d.year, d.month, d.day, t.hour, t.minute, t.second)
        
        return validatedTime
        