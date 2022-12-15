INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber")
VALUES ('1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', 'Leskovac', 'Serbia', 'Old Gate', '1');

INSERT INTO "Buildings" ("Id", "Name") VALUES
('4c08ff1f-0227-4a3c-93db-dcd865a1069b', 'Zgrada B');
INSERT INTO "Floors" ("Id", "Name", "Number", "BuildingId") VALUES 
('9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'Sprat 1', '1', '4c08ff1f-0227-4a3c-93db-dcd865a1069b');
INSERT INTO "Rooms" ("Id", "Description","Name", "Number", "Discriminator", "FloorId", "Workhours") VALUES
('9ae3255d-261f-472f-a961-7f2e7d05d95c', 'OpisSobe', 'Name 01', '2431', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),
('8dd731ee-197f-40a8-a5e1-845662b0c0cd', 'OpisSobe', 'Name 02', '8598', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),
('d4857133-ef89-4e5e-865f-b49c83ecec23', 'OpisSobe', 'Name 03', '9000', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),

('424c4309-1154-4d52-9282-342601cef85c', 'OpisSobe', 'Name 04', '9040', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),
('6b046e88-546c-4071-9431-24511e1e2d28', 'OpisSobe', 'Name 05', '9041', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),
('a2c565f7-d61e-4302-a417-1ed48919bb8f', 'OpisSobe', 'Name 06', '9042', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),
('3bf58a45-d903-4148-8b7b-3fb0018bda83', 'OpisSobe', 'Name 07', '9043', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),
('cb4f5baf-0383-463c-b914-d4dc384012f3', 'OpisSobe', 'Name 08', '9044', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),

('d2c2c548-5590-436b-9463-3ba7b82ed690', 'OpisSobe', 'Name 09', '9045', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),
('fefd8331-bbbc-47ba-928d-abb0dedf3701', 'OpisSobe', 'Name 10', '9046', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),
('67b1877a-c89d-4bb3-ba17-5d44a6faab83', 'OpisSobe', 'Name 11', '9047', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),

('7f0b673f-4d4f-4b52-a66e-be888c3627f3', 'OpisSobe', 'Name 12', '9048', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),
('133962ea-c543-497b-81a6-6a2efb54212a', 'OpisSobe', 'Name 13', '9049', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),

('2b9b4701-831d-4510-aa44-d4a940acff73', 'OpisSobe', 'Name 14', '9050', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),

('f563b764-f837-4b70-ab6b-5c7be7f706b8', 'ConsiliumRoom', 'Name 15', '9051', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati'),
('e8c0f4e2-fa51-4691-a7ba-dbabb36e69b0', 'OpisSobe', 'Name 16', '9052', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'radni sati');



INSERT INTO "Doctors" ("Id", "LicenceNum", "Speciality", "WorkingTimeStart", "WorkingTimeEnd", "RoomId", "Name", "Surname", "Birthdate", "Gender", "AddressId", "Jmbg", "EmailAddress", "PhoneNumber") VALUES 
('5c036fba-1118-4f4b-b153-90d75e60625e', 'Licenca', 'Cardiology', '8:00', '20:00', '9ae3255d-261f-472f-a961-7f2e7d05d95c', 'Heinrick', 'Swigg', '1973-09-28 15:51:51', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'hswigg0@accuweather.com', '726-634-4678'),
('7875c605-4989-465c-8cbc-2f93f2b1612e', 'Licenca', 'Cardiology', '7:00', '19:00', '8dd731ee-197f-40a8-a5e1-845662b0c0cd', 'Haleigh', 'Dysert', '1976-08-30 22:56:33', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'hdysert1@blinklist.com', '351-318-9872'),
('d0e5743d-8718-432c-bc2c-53a5ea9bb3df', 'Licenca', 'Cardiology', '8:30', '18:30', 'd4857133-ef89-4e5e-865f-b49c83ecec23', 'Demeter', 'Stratton', '1992-04-01 14:23:23', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'dstratton2@addtoany.com', '442-178-7787'),

('57144fb5-20d6-4662-ae96-378aabfe93d3', 'Licenca', 'General practicioner', '9:15', '17:27', '424c4309-1154-4d52-9282-342601cef85c', 'Ilyssa', 'Lemon', '1999-10-04 11:09:26', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'ilemon5@ihg.com', '233-160-6561'),
('631732d1-2be0-481f-b104-604efb32014d', 'Licenca', 'General practicioner', '7:09', '18:33', '6b046e88-546c-4071-9431-24511e1e2d28', 'Reeva', 'MacGarrity', '1988-10-25 12:02:15', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'rmacgarrity6@drupal.org', '305-612-6943'),
('85bfee13-907e-410b-ad3a-9d4e0b7b87b7', 'Licenca', 'General practicioner', '8:52', '17:05', 'a2c565f7-d61e-4302-a417-1ed48919bb8f', 'Biddie', 'Brockton', '1988-03-30 21:18:41', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'bbrockton7@buzzfeed.com', '782-119-1823'),
('487d0767-1f8b-4a09-a593-4f076bdb9881', 'Licenca', 'General practicioner', '9:29', '19:18', '3bf58a45-d903-4148-8b7b-3fb0018bda83', 'Livvie', 'Ganniclifft', '1995-01-31 04:43:56', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'lganniclifft8@europa.eu', '803-712-3001'),
('c9f8ccb1-1b40-4d73-8a44-22d16144abdf', 'Licenca', 'General practicioner', '8:50', '20:26', 'cb4f5baf-0383-463c-b914-d4dc384012f3', 'Wakefield', 'Dybald', '1978-03-24 07:29:10', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'wdybald9@tamu.edu', '441-654-6351'),

('e96434fd-954c-45d9-8e1a-e3e151768c29', 'Licenca', 'Neurology', '10:12', '17:31', 'd2c2c548-5590-436b-9463-3ba7b82ed690', 'Miranda', 'Secker', '1977-04-17 19:10:25', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'mseckera@posterous.com', '303-594-2555'),
('02975cd9-be40-4f26-9d9a-d86a32e39d99', 'Licenca', 'Neurology', '8:03', '20:32', 'fefd8331-bbbc-47ba-928d-abb0dedf3701', 'Eartha', 'Petyakov', '1980-12-14 14:36:35', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'epetyakovb@yellowpages.com', '382-824-9664'),
('d5113ad6-b893-47cd-ae99-2d6236fd8f93', 'Licenca', 'Neurology', '9:05', '17:43', '67b1877a-c89d-4bb3-ba17-5d44a6faab83', 'Tyrone', 'Redwing', '1979-01-02 19:59:38', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'tredwingc@indiegogo.com', '300-547-5456'),

('023af84e-196e-4989-83b6-168ea2471a9f', 'Licenca', 'Pediatrist', '7:05', '17:03', '7f0b673f-4d4f-4b52-a66e-be888c3627f3', 'Petunia', 'Hruska', '1986-12-10 10:44:30', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'phruskaf@yellowbook.com', '788-517-0494'),
('bf172d00-ea82-4363-b17a-e54b6a804fbf', 'Licenca', 'Pediatrist', '7:05', '17:04', '133962ea-c543-497b-81a6-6a2efb54212a', 'Evangelia', 'Shulem', '1998-04-10 10:38:02', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'eshulemg@freewebs.com', '234-871-1344'),

('5ffed53e-8c78-432f-a603-8bce2f86c5e2', 'Licenca', 'Oftamologist', '8:04', '20:22', '2b9b4701-831d-4510-aa44-d4a940acff73', 'Vonni', 'Oris', '1970-12-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594');

INSERT INTO "Users"("Username", "Password", "IsAccountActive", "IsBlocked", "Role", "PersonId", suspicious_activities)VALUES
('doktor', '{"PasswordValue": "doktor"}', true, false, 1, '5c036fba-1118-4f4b-b153-90d75e60625e', null);


INSERT INTO "Patients" ("Id", "ChosenDoctorId", "Name", "Surname", "Birthdate", "Gender", "AddressId", "Jmbg", "EmailAddress", "PhoneNumber") VALUES
('e6fbebce-dd68-45e4-9e38-c66b98cc8197', '5c036fba-1118-4f4b-b153-90d75e60625e', 'Mandi', 'Leupold', '2014-08-09 16:50:05', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'mleupold13@cnet.com', '884-638-8935');


INSERT INTO "Appointments"("Id", "DoctorId", "RoomId", "PatientId", "Discriminator", "EndTime", "EquipmentToMoveId", "IsDone", "StartTime", "Type") VALUES
('9ae3255d-261f-472f-a961-7f2e7d05d22c', '5c036fba-1118-4f4b-b153-90d75e60625e', '9ae3255d-261f-472f-a961-7f2e7d05d95c', 'e6fbebce-dd68-45e4-9e38-c66b98cc8197', 'MedicalAppointment', '2022-12-12 8:30:00', null, false, '2022-12-12 8:00:00', null);
