
import urllib2
import json

from datetime import datetime, timedelta

class timeSync:
    syncUrl = r'http://www.portvisibility.co.uk/visibility/tools/showTime.php'
    
    def __init__(self):
        response = urllib2.urlopen(self.syncUrl)
        timeJson = response.read()
        
        self.dateTime = json.loads(timeJson)['time']
        
    def printTimeStr(self):
        print(self.dateTime)
        
    def getTimeWithTimezoneOffset(self, timezoneOffset):
        t = datetime.strptime(self.dateTime, '%d-%m-%Y %H:%M:%S %Z')
        t = t + timedelta(hours=timezoneOffset)
        validatedTime = '%d-%02d-%02d %02d:%02d:%02d' % (t.year, t.month, t.day, t.hour, t.minute, t.second)
        
        return validatedTime
        
