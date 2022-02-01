from datetime import date
from nsepy import get_history
from datetime import date
import pandas
import json
import sys


PATH = "D:/Apps/VisualStudio/source/repos/Stock_Market_1/Stock_Market_1/Data/Daily/"
SYMBOL = "HCLTECH"
SYMBOL = sys.argv[1]
print(SYMBOL)
start_date = date(2016,1,1)
end_date = date.today()
data = get_history(symbol=SYMBOL,
                   start=start_date,
                   end=end_date)



data2 = data[['Open', 'High', 'Low', 'Close', 'Volume']] 

data2.reset_index(inplace=True) # ['Date', 'Open', 'High', 'Low', 'Close', 'Volume'] columns
dates = list() # "2021-10-25T00:00:00"
vols = list()
opens = list()
highs = list()
lows = list()
closes = list()

for i in range(data2.shape[0]):

	opens.append(data2['Open'][i])
	highs.append(data2['High'][i])
	lows.append(data2['Low'][i])
	closes.append(data2['Close'][i])
	vols.append(data2['Volume'][i])

	temp = data2['Date'][i]
	temp = temp.strftime("%Y-%m-%dT%H:%M:%S")
	dates.append(temp)





with open(PATH+SYMBOL+'.json', 'w') as f:
	#dates2 = json.dumps(dates)
	#vols2 = json.dumps(vols)
	#opens2 = json.dumps(opens)
	#highs2 = json.dumps(highs)
	#lows2 = json.dumps(lows)
	#closes2 = json.dumps(closes)

	
	data3 = [dates,vols,opens,highs,lows,closes]
	f.write(str(data3))