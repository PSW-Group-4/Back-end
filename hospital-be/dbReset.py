import os

destFile = open('dbResetScript.sql', 'w')

#Clears all tables - I ovo mora rucno...
print('delete from "RoomMaps";', file=destFile)

print('delete from "FloorMaps";', file=destFile)

print('delete from "BuildingMaps";', file=destFile)

print('delete from "Appointments";', file=destFile)

print('delete from "Users";', file=destFile)

print('delete from "Feedbacks";', file=destFile)

print('delete from "PatientAllergies";', file=destFile)

print('delete from "Patients";', file=destFile)

print('delete from "Doctors";', file=destFile)

print('delete from "Rooms";', file=destFile)

print('delete from "Floors";', file=destFile)

print('delete from "Buildings";', file=destFile)

print('delete from "Allergies";', file=destFile)

print('delete from "Addresses";', file=destFile)


#Merges scripts
#Bitno je da dodas prvo skripte od kojih zavise strani kljucevi
with open('DbScripts/Addresses.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/Allergies.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/Buildings.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/Floors.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/Rooms.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/Doctors.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)
with open('DbScripts/Patients.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/PatientAllergies.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/Feedbacks.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/Users.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/Appointments.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/BuildingMaps.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/FloorMaps.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)

with open('DbScripts/RoomMaps.sql', 'r', encoding='utf-8-sig') as f:
    print(f.read(), file=destFile)
