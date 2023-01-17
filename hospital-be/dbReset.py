import os

destFile = open('dbResetScript.sql', 'w', encoding="utf-8")

# Pay attention to order
tables = ["AgeGroups","Addresses", "Allergies", "Buildings", "Floors", "Rooms",
 "Doctors", "Patients", "PatientAllergies", "Feedbacks", "Users", "Equipments", "RoomsEquipment",
 "MapItem","Admissions","RenovationSessionAggregateRoots","RenovationSessionEvents", "EquipmentToMoves", "Appointments", "Symptoms", "Medicines", "Reports"]


# Clear all tables
for table in reversed(tables):
    print('delete from "' + table + '";', file=destFile)

#Merges scripts
for table in tables:
    with open('DbScripts/' + table + '.sql', 'r', encoding='utf-8-sig') as f:
        print(f.read(), file=destFile)
