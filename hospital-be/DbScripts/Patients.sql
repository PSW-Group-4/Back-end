-- Patient addresses
insert into "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") values
('55db8539-2825-4dbe-adf5-5112ce70b976', 'Carbonear', 'Canada', 'Stone Corner', '5'),
('b5a5d01e-3d7c-4877-a88f-83b7aa1a0e1c', 'Douala', 'Cameroon', 'Mayfield', '06472'),
('c84316a3-b07c-42dc-a5a3-d478d12a89e4', 'Eaubonne', 'France', 'Coolidge', '504'),
('b17d8b5e-4874-49c7-b87b-6a5a3a0b8049', 'Itzer', 'Morocco', 'Sherman', '83224'),
('ec0fe89a-a428-4369-a3de-17fe0aefe960', 'Tunggaoen Timur', 'Indonesia', 'Dottie', '68'),
('3f4d3f64-064a-46cf-8fa9-afd8ebbe26d5', 'Bel Air Rivière Sèche', 'Mauritius', 'Anhalt', '92523'),
('65c57e41-443d-46b7-aeb7-47a9eda130fe', 'Ban Kruat', 'Thailand', 'Pine View', '6955'),
('6eee472f-ecb4-4a1a-9f0e-03994e608806', 'Powidz', 'Poland', 'Porter', '8'),
('f3c1e5d9-de9c-45b6-9a01-1c229a2b6c7e', 'La Poma', 'Argentina', 'Scott', '30534'),
('d77214fe-6f55-428b-afb8-f3e697e771d1', 'Suso', 'Philippines', 'Porter', '8984'),
('ac5a4816-4796-44e9-8ffb-09475dbe67fa', 'Río Grande', 'Dominican Republic', 'Cascade', '5455'),
('f0b17c41-acaa-493d-912c-500669a1c466', 'Manaquiri', 'Brazil', 'Lakeland', '1'),
('3749cc8a-a884-440e-b91d-eaf3c3b98a23', 'Yanji', 'China', 'Steensland', '5710'),
('64fc95c7-f3fc-4e95-8ab2-2df4488bfe80', 'Sujji', 'Mongolia', 'Darwin', '156'),
('76bfb7c4-26ce-4f12-bf4a-7f5a8984300e', 'Zrenjanin', 'Serbia', 'Izvorska', '27');


-- Patients

insert into "Patients" ("Id", "BloodGroup", "RhFactor", "ChosenDoctorId", "Name", "Surname",
  "Birthdate", "Gender", "AddressId", "Jmbg", "EmailAddress", "PhoneNumber") values
 ('3e9e456a-7948-4e82-b33c-583737856111', 0, 0, '631732d1-2be0-481f-b104-604efb32014d', 'Shaylah', 'Revett',
  '1953-11-15 11:09:55', 1, 'b5a5d01e-3d7c-4877-a88f-83b7aa1a0e1c',  '{"JmbgValue": "1807000730038"}', 'srevett0@dailymail.co.uk', '661-129-1559'),
 ('43d8ef21-2f8e-47a3-97fa-bb9253ea7d04', 1, 1, '85bfee13-907e-410b-ad3a-9d4e0b7b87b7', 'Cthrine', 'Breinl',
  '1951-05-06 14:33:56', 1, 'c84316a3-b07c-42dc-a5a3-d478d12a89e4',   '{"JmbgValue": "1807000730038"}', 'cbreinl1@pagesperso-orange.fr', '867-541-1547'),
 ('3fe961db-5146-43b4-b7b4-e1c63a299ce1', 2, 0, '487d0767-1f8b-4a09-a593-4f076bdb9881', 'Morley', 'Gamble',
  '1991-04-14 06:19:07', 0, 'b17d8b5e-4874-49c7-b87b-6a5a3a0b8049',    '{"JmbgValue": "1807000730038"}', 'mgamble2@nationalgeographic.com', '803-385-8179'),
 ('1e173ef3-3daa-482b-aa59-fc536c218fe3', 3, 1, 'c9f8ccb1-1b40-4d73-8a44-22d16144abdf', 'Allin', 'Menault',
  '1984-12-15 19:36:22', 0,'ec0fe89a-a428-4369-a3de-17fe0aefe960',     '{"JmbgValue": "1807000730038"}', 'amenault3@house.gov', '762-605-0246'),
 ('243aa452-2d25-4fbf-9d66-f01917f009ff', 0, 0, '09b5d1bc-2bef-4fcb-a199-6dbf8db560ae', 'Giraldo', 'Steedman',
  '1969-07-15 18:44:36', 0, '3f4d3f64-064a-46cf-8fa9-afd8ebbe26d5', '{"JmbgValue": "1807000730038"}', 'gsteedman4@eventbrite.com', '614-648-4177'),
 ('ddbe195e-2337-4347-86f2-d702cd206543', 1, 1,  '09b5d1bc-2bef-4fcb-a199-6dbf8db560ae', 'Odelle', 'Hebblewhite',
  '1961-08-25 12:44:54', 1, '65c57e41-443d-46b7-aeb7-47a9eda130fe', '{"JmbgValue": "1807000730038"}', 'ohebblewhite5@bluehost.com', '258-754-3693'),
 ('24826bea-0ebb-492c-96db-3d7e5f214028', 2, 0,   '09b5d1bc-2bef-4fcb-a199-6dbf8db560ae', 'Allison', 'Glennie',
  '1983-02-06 16:56:44', 1, '6eee472f-ecb4-4a1a-9f0e-03994e608806', '{"JmbgValue": "1807000730038"}', 'aglennie6@economist.com', '698-220-4910'),
 ('e2415681-422e-4870-84e1-9b3b2a108643', 3, 1,    '09b5d1bc-2bef-4fcb-a199-6dbf8db560ae', 'Fernandina', 'Buttel',
  '1996-03-01 06:55:41', 1, 'f3c1e5d9-de9c-45b6-9a01-1c229a2b6c7e', '{"JmbgValue": "1807000730038"}', 'fbuttel7@about.me', '418-287-9630'),
 ('1f02df96-acca-42cf-98c0-73a9c0d53221', 0, 0,     '09b5d1bc-2bef-4fcb-a199-6dbf8db560ae', 'Aryn', 'Shopcott',
  '1954-02-21 19:30:09', 1, 'd77214fe-6f55-428b-afb8-f3e697e771d1', '{"JmbgValue": "1807000730038"}', 'ashopcott8@indiatimes.com', '400-455-2780'),
 ('2a4c0071-f08d-4c78-a183-f101325a0a66', 1, 1, 'cd8be910-f742-4319-8db5-8fefaeccfc0f', 'Durand', 'Evers',
  '1997-01-06 08:47:01', 0, 'ac5a4816-4796-44e9-8ffb-09475dbe67fa', '{"JmbgValue": "1807000730038"}', 'devers9@nhs.uk', '891-150-9637'),
 ('0675271e-4254-417b-91a6-03621975b37c', 2, 0,  'cd8be910-f742-4319-8db5-8fefaeccfc0f', 'Elwyn', 'Jaram',
  '1954-08-05 12:43:52', 1, 'f0b17c41-acaa-493d-912c-500669a1c466', '{"JmbgValue": "1807000730038"}', 'ejarama@bloglovin.com', '688-925-3642'),
 ('22fc8a6a-609a-4177-be8b-cecb48640c88', 3, 1,   'cd8be910-f742-4319-8db5-8fefaeccfc0f', 'Ezra', 'Venny',
  '2004-02-23 05:24:42', 1, '3749cc8a-a884-440e-b91d-eaf3c3b98a23', '{"JmbgValue": "1807000730038"}', 'evennyb@apple.com', '755-695-7989'),
 ('b57cee85-e10e-45f9-bd97-2bbd2ee6c93d', 0, 0,    'cd8be910-f742-4319-8db5-8fefaeccfc0f', 'Cristina', 'Mieville',
  '1998-07-12 19:31:42', 1, '3749cc8a-a884-440e-b91d-eaf3c3b98a23', '{"JmbgValue": "1807000730038"}', 'cmievillec@nsw.gov.au', '680-810-0737'),
 ('edf25aa4-a19a-4a03-ae71-ef1078eadc17', 1, 1,     'cd8be910-f742-4319-8db5-8fefaeccfc0f', 'Ogdon', 'Durrant',
  '1952-02-04 07:18:48', 0, '64fc95c7-f3fc-4e95-8ab2-2df4488bfe80', '{"JmbgValue": "1807000730038"}', 'odurrantd@sphinn.com', '367-523-3316'),
 ('79978326-f136-4cec-813b-6b12c962752b', 3, 0, 'c74a1a2f-6553-488a-a28e-d77f6d34072a', 'Jovan', 'Srdanov',
  '2000-11-01 02:14:45', 0, '76bfb7c4-26ce-4f12-bf4a-7f5a8984300e',  '{"JmbgValue": "0111000850019"}', 'jovansrdanov@gmail.com', '064-327-2628');

-- Users for patients

INSERT INTO "Users" ("Username", "Password", "IsAccountActive", "IsBlocked", "Role", "PersonId") VALUES
('shayla', '{"PasswordValue":"password"}', true, false, 0,'3e9e456a-7948-4e82-b33c-583737856111'),
('cthrine', '{"PasswordValue":"password"}', true, false, 0,'43d8ef21-2f8e-47a3-97fa-bb9253ea7d04'),
('morley', '{"PasswordValue":"password"}', true, false, 0,'3fe961db-5146-43b4-b7b4-e1c63a299ce1'),
('allin', '{"PasswordValue":"password"}', true, false, 0,'1e173ef3-3daa-482b-aa59-fc536c218fe3'),
('giraldo', '{"PasswordValue":"password"}', true, false, 0,'243aa452-2d25-4fbf-9d66-f01917f009ff'),
('odele', '{"PasswordValue":"password"}', true, false, 0,'ddbe195e-2337-4347-86f2-d702cd206543'),
('allison', '{"PasswordValue":"password"}', true, false, 0,'24826bea-0ebb-492c-96db-3d7e5f214028'),
('fernandina', '{"PasswordValue":"password"}', true, false, 0,'e2415681-422e-4870-84e1-9b3b2a108643'),
('aryn', '{"PasswordValue":"password"}', true, false, 0,'1f02df96-acca-42cf-98c0-73a9c0d53221'),
('durand', '{"PasswordValue":"password"}', true, false, 0,'2a4c0071-f08d-4c78-a183-f101325a0a66'),
('elwyn', '{"PasswordValue":"password"}', true, false, 0,'0675271e-4254-417b-91a6-03621975b37c'),
('ezra', '{"PasswordValue":"password"}', true, false, 0,'22fc8a6a-609a-4177-be8b-cecb48640c88'),
('cristina', '{"PasswordValue":"password"}', true, false, 0,'b57cee85-e10e-45f9-bd97-2bbd2ee6c93d'),
('ogdon', '{"PasswordValue":"password"}', true, false, 0,'edf25aa4-a19a-4a03-ae71-ef1078eadc17'),
('jovansrdanov', '{"PasswordValue":"password"}', true, false, 0,'79978326-f136-4cec-813b-6b12c962752b');
