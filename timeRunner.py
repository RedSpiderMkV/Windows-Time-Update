
import os
import time
from windowsTimeSync import timeSync

def main():
    time.sleep(10)
    
    timeSyncer = timeSync()
    timeVal = timeSyncer.getTimeWithTimezoneOffset(1)
    dateTime = timeVal.split(' ')
    
    dateParts = dateTime[0].split('-')
    formattedDate = dateParts[2] + '-' + dateParts[1] + '-' + dateParts[0]
    
    dateCommand = 'date ' + formattedDate
    timeCommand = 'time ' + dateTime[1]
    
    os.system(dateCommand)
    os.system(timeCommand)

if __name__ == '__main__':
    main()