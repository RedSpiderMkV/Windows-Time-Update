
import os
import time
import socket
from windowsTimeSync import timeSync

REMOTE_SERVER = "www.google.com"

def is_connected():
  try:
    # see if we can resolve the host name -- tells us if there is
    # a DNS listening
    host = socket.gethostbyname(REMOTE_SERVER)
    # connect to the host -- tells us if the host is reachable
    s = socket.create_connection((host, 80), 2)
    return True
  except:
     return False

def main():
    attempt = 0
    while not is_connected():
        # after 10 tries, give up
        if attempt >= 10:
            return;

        time.sleep(10)
        attempt += 1

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
