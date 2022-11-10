import os

destFile = open('dbResetScript.sql', 'w')

#Clears all tables
for fileName in os.listdir("DbScripts"):
    print('delete from "' + fileName[:len(fileName)-4] +'";', file=destFile)

#Merges scripts
#Bitno je da dodas prvo skripte od kojih zavise strani kljucevi
with open('DbScripts/Addresses.sql', 'r') as f:
    print(f.read(), file=destFile)

with open('DbScripts/Patients.sql', 'r') as f:
    print(f.read(), file=destFile)

with open('DbScripts/Feedbacks.sql', 'r') as f:
    print(f.read(), file=destFile)