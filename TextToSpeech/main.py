import tkinter as tk
import time
import ttsmodule
import threading
from tkinter.constants import HORIZONTAL, LEFT, VERTICAL


#TODO A multiprocessing.Process can p.terminate()



root = tk.Tk()
root.title('TextToSpeech')
root.iconbitmap('C:/Windows/System32/notebook.ico')
root.geometry("800x450+700+50") # Set offset from top-left corner of screen as well as size
root.maxsize(1000,700)

root.wm_attributes("-topmost", True)
root.wm_attributes("-disabled", False)
#root.wm_attributes("-transparentcolor", "white")
root.wm_attributes("-alpha", 1) # opacity
Main = tk.Label(root,bg='gray55')
Main.place(x=0, y=0, width=1000, height=700 )

# Global variables
text1 = 'This is a sentence, which is not meant to mean anything.'
checkbox_Debounce = tk.IntVar()
checkbox2_Debounce = tk.IntVar()
debounce_pause = True


path_kgb = "The_Mitrokhin_Archive_and_the_Secret_History_of_the_KGB2.txt"
path_discovery = "Discovery_of_India.txt"
path_novel = "Crime_and_Punishment.txt"
data_discovery = 'discovery_data.txt'
# reading file // content()
f = open(path_discovery,'r',encoding='utf8') # 'Discovery_of_India.txt'
lines = f.readlines()
f.close()
with open(data_discovery, 'r') as f2: 
	last_index = f2.read()

index=0
Content = ""
count=0
def content(x=1): # default is moving forward, 0 moves backward
    global count
    global lines
    global index
    global Content
    Content = ''
    count = 0
    if not x: 
        if (index - 6) >= 0: # for the initial 6 sentences.
            index = index - 6
        else:
            index = 0
    while True:
        if count < 4:
            Content = Content + lines[index]
            if len(lines[index]) > 10:
                count += 1
            index += 1
        else:
            if len(Content) < 350:
                text_Label.config(font=('Courier',15))
            elif len(Content) < 500:
                text_Label.config(font=('Courier',12))
            else: 
                text_Label.config(font=('Courier',10))
            return Content
        time.sleep(0.05)


def start_thread(event, val): # multi-threading so tkinter wont freeze
    global thread1
    thread1 = threading.Thread(target=val, daemon=True)
    thread1.start()



def pause_Button(): # button_pause.config(text=' ▶ ', font=('Courier',15))
    global button_pause
    global checkbox2_Debounce
    rate = int(horizontal2.get())
    button_pause['state'] = tk.DISABLED
    button_right['state'] = tk.DISABLED
    button_left['state'] = tk.DISABLED
    entry_Button['state'] = tk.DISABLED
    Main['bg']='orange'
    button_pause.config(text='| |', font=('Courier',15))
    ttsmodule.speak(text1,horizontal.get(), rate)
    Main['bg']='gray55'
    button_pause['state'] = tk.NORMAL
    button_right['state'] = tk.NORMAL
    button_left['state'] = tk.NORMAL
    entry_Button['state'] = tk.NORMAL


def left_Button():
    global checkbox_Debounce
    global button_left
    global text_Label
    global text_Label2
    global text1
    rate = int(horizontal2.get())
    button_pause['state'] = tk.DISABLED
    button_right['state'] = tk.DISABLED
    button_left['state'] = tk.DISABLED
    entry_Button['state'] = tk.DISABLED
    text1 = content(0)
    text_Label.config(text=text1)
    text_Label2.config(text=str(index)+'/'+str(len(lines)))
    if checkbox_Debounce.get() == 1:
        Main['bg']='orange'
        ttsmodule.speak(text1,horizontal.get(), rate)
        Main['bg']='gray55'
    button_pause['state'] = tk.NORMAL
    button_right['state'] = tk.NORMAL
    button_left['state'] = tk.NORMAL
    entry_Button['state'] = tk.NORMAL


def right_Button():
    global checkbox_Debounce
    global checkbox2_Debounce
    global horizontal
    global text_Label
    global text_Label2
    global text1
    rate = int(horizontal2.get())
    button_pause['state'] = tk.DISABLED
    button_right['state'] = tk.DISABLED
    button_left['state'] = tk.DISABLED
    entry_Button['state'] = tk.DISABLED
    text1 = content(1)
    text_Label2.config(text=str(index)+'/'+str(len(lines)))
    text_Label.config(text=text1)
    if checkbox_Debounce.get() == 1:
        while True:
            Main['bg']='orange'
            ttsmodule.speak(text1,horizontal.get(), rate)
            if checkbox2_Debounce.get():
                break
            text1 = content(1)
            text_Label2.config(text=str(index)+'/'+str(len(lines)))
            text_Label.config(text=text1)
            time.sleep(0.5)
        Main['bg']='gray55'
    button_pause['state'] = tk.NORMAL
    button_right['state'] = tk.NORMAL
    button_left['state'] = tk.NORMAL
    entry_Button['state'] = tk.NORMAL



def entry_Button():
	global index
	global text_Label
	global text_Label2
	index = int(entry1.get())
	text_Label2.config(text=str(index)+'/'+str(len(lines)))
	text1 = content(1)
	text_Label.config(text=text1)
	content(1)


horizontal = tk.Scale(root, from_=10, to=0, orient=VERTICAL, tickinterval=1, length=375, bg='white', activebackground='cornsilk4')
horizontal.place(x=725, y=5)

horizontal2 = tk.Scale(root, from_=200, to=100, orient=VERTICAL, tickinterval=25, length=250, bg='white', activebackground='cornsilk4')
horizontal2.place(x=625, y=5)

text_Label = tk.Label(root, text=text1, fg='blue', bg='white', height=00, width=00, anchor=tk.NW, wraplength=500)
text_Label.config(font=("Courier", 10))
text_Label.grid(row=0,column=0,pady=10)

text_Label2 = tk.Label(root, text=str(index)+'/'+str(len(lines)), font=('Courier',12), bg='white', height=00, width=00, anchor=tk.NW)
text_Label2.place(x=530, y=40)

text_Label3 = tk.Label(root, text="Last read: "+str(last_index), font=('Courier',12), bg='white', height=00, width=00, anchor=tk.NW)
text_Label3.place(x=500, y=425)

button_left= tk.Button(root,bg='white', activebackground='cornsilk4', text='<<<',font=('Courier',15), command=lambda:start_thread(None, left_Button))
button_left.place(x=530, y=100)

button_pause= tk.Button(root,bg='white', activebackground='cornsilk4', text='| |',font=('Courier',15),command=lambda:start_thread(None, pause_Button))
button_pause.place(x=530, y=175)

button_right= tk.Button(root,bg='white', activebackground='cornsilk4', text='>>>',font=('Courier',15),command=lambda:start_thread(None, right_Button))
button_right.place(x=530, y=250)

entry1 = tk.Entry(root, width=8, font=('Courier', 12))
entry1.place(x=625,y=325)

entry_Button =  tk.Button(root,bg='white', activebackground='cornsilk4', text='Search',font=('Courier',12),command=entry_Button)
entry_Button.place(x=625,y=370)

checkbox = tk.Checkbutton(root, text="Check to speak", variable=checkbox_Debounce)
checkbox.place(x=500, y=325)


checkbox2 = tk.Checkbutton(root, text="Check to stop", fg="red", variable=checkbox2_Debounce)
checkbox2.place(x=500, y=375)






root.mainloop()
with open(data_discovery, 'w') as f3:
	f3.write(str(index))
print('done')

'''
print (root.winfo_geometry()) # 200x200+182+182

'''