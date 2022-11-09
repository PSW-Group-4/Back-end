import os

destFile = open('dbResetScript.sql', 'w', encoding='Latin-1')

#Clears all tables
for fileName in os.listdir("DbScripts"):
    print('delete from "' + fileName[:len(fileName)-4] +'";', file=destFile)

#Merges scripts
#Bitno je da dodas prvo skripte od kojih zavise strani kljucevi
with open('DbScripts/Addresses.sql', 'r', encoding='Latin-1') as f:
    print(f.read().strip().replace('\n', '\r\n'), file=destFile)
    
with open('DbScripts/Allergies.sql', 'r', encoding="Latin-1") as f:
    print(f.read().strip().replace('\n', '\r\n'), file=destFile)

with open('DbScripts/Buildings.sql', 'r', encoding="Latin-1") as f:
    print(f.read().strip().replace('\n', '\r\n'), file=destFile)

with open('DbScripts/Floors.sql', 'r', encoding="Latin-1") as f:
    print(f.read().strip().replace('\n', '\r\n'), file=destFile)

with open('DbScripts/Rooms.sql', 'r', encoding="Latin-1") as f:
    print(f.read().strip().replace('\n', '\r\n'), file=destFile)

with open('DbScripts/Doctors.sql', 'r', encoding="Latin-1") as f:
    print(f.read().strip().replace('\n', '\r\n'), file=destFile)

with open('DbScripts/Patients.sql', 'r', encoding="Latin-1") as f:
    print(f.read().strip().replace('\n', '\r\n'), file=destFile)

with open('DbScripts/PatientAllergies.sql', 'r', encoding="Latin-1") as f:
    print(f.read().strip().replace('\n', '\r\n'), file=destFile)

with open('DbScripts/Users.sql', 'r', encoding="Latin-1") as f:
    print(f.read().strip().replace('\n', '\r\n'), file=destFile)