import os

destFile = open('dbResetScript.sql', 'w')

# Pay attention to order
tables = ["Addresses", "Allergies", "Buildings", "Floors", "Rooms",
 "Doctors", "Patients", "PatientAllergies", "Feedbacks", "Users",
  "Appointments", "BuildingMaps", "FloorMaps", "RoomMaps"]


# Clear all tables
for table in reversed(tables):
    print('delete from "' + table + '";', file=destFile)

#Merges scripts
for table in tables:
    with open('DbScripts/' + table + '.sql', 'r', encoding='utf-8-sig') as f:
        print(f.read(), file=destFile)
