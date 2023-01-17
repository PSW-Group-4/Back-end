delete from "Reports";
delete from "Appointments";
delete from "EquipmentToMoves";
delete from "RenovationSessionEvents";
delete from "RenovationSessionAggregateRoots";
delete from "AdmissionHistories";
delete from "Admissions";
delete from "MapItem";
delete from "RoomsEquipment";
delete from "Equipments";
delete from "Beds";
delete from "Users";
delete from "Feedbacks";
delete from "PatientAllergies";
delete from "Patients";
delete from "Doctors";
delete from "Rooms";
delete from "Floors";
delete from "Buildings";
delete from "Allergies";
delete from "Addresses";
delete from "AgeGroups";
delete from "Treatments";
delete from "BloodConsumptionRecords";
delete from "Medicines";
delete from "Symptoms";

insert into	public."AgeGroups" ("Id","GropuName","MinAge","MaxAge")values 
	('1e9ab3fc-3b7c-4ef4-a67c-5026db4e3188','Child',0,16),
	('113faa92-ea79-4bd7-9b9a-6413098f39ec','Young adults',17,30),
	('e789e5f8-1780-4bee-aaaa-1059b22c7b6b','Middle-aged adults',31,50),
	('f17018ae-b598-4063-9229-757ee3763f7c','Old Adults',51,999);
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', 'Leskovac', 'Serbia', 'Old Gate', '1');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('c188c722-cfa9-47c4-8d84-bb56b9302870', 'Blobo', 'Serbia', 'Eastwood', '0');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('15fef027-3c08-4dd6-b8b9-5f416186c169', 'Celica', 'Serbia', 'Hudson', '48');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('4ad66020-57b4-498f-8061-d7e5779dfa51', 'Krynice', 'Serbia', 'Superior', '52');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('1431c6d9-7007-40ac-bd33-1ad4ece4f7a2', 'Slavgorod', 'Serbia', 'Donald', '64367');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('50ba78fd-ad55-45ba-b5b6-5e824dc69b16', 'Stan-Bekhtemir', 'Serbia', 'Green', '17504');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('15434d70-e028-4fd4-8c7f-a6c3da059c80', 'Zwolle', 'Serbia', 'Autumn Leaf', '70');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('48c55ee1-d8e5-46ba-94df-797c78d52c36', 'Chitose', 'Serbia', 'Anhalt', '01');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('a2da1a49-3d40-4ff3-a888-c16ae2efe823', 'Al Qurayn', 'Serbia', 'Cordelia', '3793');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('37a52cdb-eed2-4425-8c8f-a8190f46a2bf', 'Piquete', 'Serbia', 'Lyons', '771');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('73a404c1-6790-4ee2-8504-0fcc686a6f10', 'Arevshat', 'Serbia', 'Doe Crossing', '0729');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('da28b029-6f07-46eb-b0dc-1e700df37f15', 'Taremskoye', 'Serbia', 'Menomonie', '71');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('dd4ca828-b495-4b35-a4f7-a115e7104c92', 'Cidadap', 'Serbia', 'Bayside', '33');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('f8382ee5-c8f4-4267-92d2-41dc850e2492', 'San Quintin', 'Serbia', 'Anniversary', '56');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('b2d2d6d2-7715-44e7-894b-e59926a110c2', 'Gandekan', 'Serbia', 'Cherokee', '7');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('9b73d896-e323-41e6-ad56-c31363d601cc', 'Krivyanskaya', 'Serbia', 'Brickson Park', '2');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('5ad3f27c-8a37-49d1-b298-a90284823dfd', 'Xekar', 'Serbia', 'Mccormick', '86');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('b102478f-fbd5-4d62-8889-8b0086d1f241', 'Zargarān', 'Serbia', 'Moland', '4');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('a5b6dc07-222c-4073-ab98-3d9cf939e162', 'Babo-Pangulo', 'Serbia', 'Algoma', '41');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('ab3bdc17-de85-4d61-8246-cdac9a0db304', 'Sufang', 'Serbia', 'Hovde', '3');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('18b397f4-76ec-4dec-b292-dd43f429a166', 'Ngulahan', 'Serbia', 'Dorton', '43299');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('6895c936-d304-4c80-be25-98bf58146b5a', 'Bulongji', 'Serbia', 'Old Shore', '5');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('9b75b261-e305-4f6f-9990-97cb2d06d774', 'Kibonsod', 'Serbia', 'Comanche', '8');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('74c3ce7d-47e1-4b13-9504-426f8ed186f3', 'Mananjary', 'Serbia', 'David', '37');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('6312c282-57e5-4601-a3f2-e5a1549d46f8', 'Mazkeret Batya', 'Serbia', 'North', '078');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('506f4b6f-75ce-4119-bba3-2d95a241d1bd', 'Bacuyangan', 'Serbia', 'Loeprich', '72');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('dcd56603-454e-4003-8d06-76c04d59a6bf', 'Hamilton', 'Serbia', 'Nova', '7682');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('61f1082a-302a-4beb-90c2-b9ca2ef8a2d7', 'Oslo', 'Serbia', 'Independence', '00');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('660ce5e1-6c54-4101-9ae1-7e04c8c36a98', 'Uttar Char Fasson', 'Serbia', 'Eagan', '331');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('25de93cd-9aa4-4a2f-84f4-fa990ba71abf', 'Cizhu', 'Serbia', 'Northfield', '56');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('27b629b8-d521-43de-aa67-49baae8a57e4', 'Jelisavac', 'Serbia', 'Bowman', '426');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('b22e87a3-1d38-41e7-8e2c-076850fd7caa', 'Gubkinskiy', 'Serbia', 'Rusk', '765');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('7ecb4c0f-af79-419c-a8d4-736999a47288', 'Hengbanqiao', 'Serbia', 'Saint Paul', '06');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('051b3ba2-fdff-48ad-9da8-ffdcae56031d', 'Dongchengyuan', 'Serbia', 'Dottie', '03083');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('8401e712-0f23-497f-8eeb-1de0322bf40b', 'Cibeusi', 'Serbia', 'Rutledge', '07');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('b2c8c18d-3cc9-4341-9008-9a260715fb2b', 'Sumberbakti', 'Serbia', 'Forest Run', '01382');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('ab3d6f02-5504-48fa-b5cf-a5d86766f95d', 'Luoqi', 'Serbia', 'Prairie Rose', '55515');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('ad5e8230-5fa2-4de3-b0c7-05259660dc7d', 'Mancos', 'Serbia', 'Bartelt', '835');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('85d3d6f4-24b4-4ef2-8189-a424c8c16e88', 'Haz-Zebbug', 'Serbia', 'Reindahl', '62184');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('fed60c51-cdc5-4125-aa57-d0d0dc2ae0d8', 'Saguing', 'Serbia', 'Butterfield', '28082');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('60c971d9-a97a-40e9-b11a-dc10559b8bc2', 'La Roxas', 'Serbia', 'Dovetail', '7353');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('104e30aa-1b5f-4ae9-a1e2-4a06a1ce4ad9', 'Gujrāt', 'Serbia', 'Menomonie', '8');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('6d92bbec-2317-4bfe-8642-0047778afa35', 'Wanjiazhuang', 'Serbia', 'Sommers', '973');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('57cd510e-dd96-4776-bf85-eef52e00811d', 'San Cristóbal', 'Serbia', 'Daystar', '2905');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('35b1e385-eac8-4e21-884f-61d6dbb71c24', 'Ural', 'Serbia', 'Cambridge', '94');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('33aaafa8-784b-4ade-9488-de310dd4ee49', 'Sernur', 'Serbia', 'Killdeer', '2');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('e84bfb2f-f264-4146-9c30-6cdf780c08ba', 'Malummaduri', 'Serbia', 'Hazelcrest', '04');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('2b95ffec-86dd-4931-a9e8-cc571c5af3f0', 'Tõrva', 'Serbia', 'Corry', '6');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('fc982639-c2bd-42f3-a9b2-b763d4871cbe', 'Wenhe', 'Serbia', 'Clyde Gallagher', '2239');
INSERT INTO "Addresses" ("Id", "City", "Country", "Street", "StreetNumber") VALUES ('18d73b88-60f2-4f77-a25e-622c8d6de090', 'Santiago De Compostela', 'Serbia', 'Carberry', '25');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('a6739c08-1939-4a6e-8ca9-e58b087bc9a5', 'Peanuts');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('04eee618-5b2c-481b-8e52-4e32f7ab6ce8', 'Soy');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('d281b879-f344-461a-ada7-a8ef826f1155', 'Crustaceans');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('e4cb7241-82ff-44fd-880d-60fb1b42079b', 'Pellaea bridgesii Hook.');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('6868ae25-ab9b-4549-931f-8b39c0117026', 'Trillium pusillum Michx.');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('01f0d06f-e4e4-4a35-94d1-8e34547a548d', 'Nicolletia edwardsii A. Gray');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('b9b6aca0-887c-4499-a0f2-71c9300447dd', 'Pomaria Cav.');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('456f9b57-e49b-4b62-8404-ac789ad84faa', 'Solanum xanti A. Gray var. obispoense (Eastw.) Wiggins');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('d19f3c22-eb67-4c21-9868-d196294b3dd5', 'Arabis fendleri (S. Watson) Greene');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('5535fcea-0711-4c48-9642-89b79ce57d31', 'Rubus plicatifolius Blanch.');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('266bcf0a-3bd2-4f6b-a1a8-604a992b9d6b', 'Phacelia scopulina (A. Nelson) J.T. Howell var. scopulina');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('5fddd29f-4781-4031-884b-cd9f951f51d4', 'Claytonia parviflora Douglas ex Hook. ssp. utahensis (Rydb.) John M. Mill. & K.L. Chambers');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('6ab34a29-916f-4fee-9f53-ae5e199039d8', 'Sisyrinchium farwellii E.P. Bicknell');
INSERT INTO "Allergies" ("Id", "Name") VALUES ('00e47bc5-874f-4550-a3ec-fed94591250d', 'Erigeron pumilus Nutt. ssp. intermedius Cronquist var. intermedius (Cronquist) Cronquist');

insert into Public."Buildings" ("Id", "Name") values 
    ('4c08ff1f-0227-4a3c-93db-dcd865a1069b', 'Old Building'),
    ('6f8f6c66-a869-4715-8229-95df705418a6', 'New Building');
insert into Public."Floors" ("Id", "Name", "Number", "BuildingId") values 
('9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'Ground floor', '0', '4c08ff1f-0227-4a3c-93db-dcd865a1069b'),
('0f3a9eb2-5223-4775-b60f-3d13baadb254', 'First floor', '1', '4c08ff1f-0227-4a3c-93db-dcd865a1069b'),
('c8d321c2-7bab-4f4d-a133-98eb4de4bb30', 'Second floor', '2', '4c08ff1f-0227-4a3c-93db-dcd865a1069b'),
('f775fba5-843e-4701-96e9-664530b18b3a', 'Third floor', '3', '4c08ff1f-0227-4a3c-93db-dcd865a1069b'),
('1b7f1f98-8737-4c53-87e3-3399705be80d', 'Ground floor', '0', '6f8f6c66-a869-4715-8229-95df705418a6'),
('1b89ab52-d8ed-4a95-a436-4ecbe5404179', 'First floor', '1', '6f8f6c66-a869-4715-8229-95df705418a6'),
('f65545be-c944-453d-9d41-d6463553279a', 'Second floor', '2', '6f8f6c66-a869-4715-8229-95df705418a6');

INSERT INTO "Rooms" ("Id", "Description","Name", "Number", "Discriminator", "FloorId", "Workhours") values
('06497611-4659-4ab3-a644-1a70710655d7', 'ConsiliumRoom'      , 'Old R001', '001', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', '00-24'),
('9ae3255d-261f-472f-a961-7f2e7d05d95c', 'This is doctor room', 'Old R002', '002', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', '00-24'),
('8dd731ee-197f-40a8-a5e1-845662b0c0cd', 'This is doctor room', 'Old R003', '003', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', '00-24'),
('d4857133-ef89-4e5e-865f-b49c83ecec23', 'This is doctor room', 'Old R004', '004', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', '00-24'),
('424c4309-1154-4d52-9282-342601cef85c', 'This is doctor room', 'Old R005', '005', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', '00-24'),
('6b046e88-546c-4071-9431-24511e1e2d28', 'This is doctor room', 'Old R006', '006', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', '00-24'),
('a2c565f7-d61e-4302-a417-1ed48919bb8f', 'This is doctor room', 'Old R101', '101', 'DoctorRoom', '0f3a9eb2-5223-4775-b60f-3d13baadb254', '00-24'),
('3bf58a45-d903-4148-8b7b-3fb0018bda83', 'This is doctor room', 'Old R102', '102', 'DoctorRoom', '0f3a9eb2-5223-4775-b60f-3d13baadb254', '00-24'),
('cb4f5baf-0383-463c-b914-d4dc384012f3', 'This is doctor room', 'Old R103', '103', 'DoctorRoom', '0f3a9eb2-5223-4775-b60f-3d13baadb254', '00-24'),
('d2c2c548-5590-436b-9463-3ba7b82ed690', 'This is doctor room', 'Old R104', '104', 'DoctorRoom', '0f3a9eb2-5223-4775-b60f-3d13baadb254', '00-24'),
('fefd8331-bbbc-47ba-928d-abb0dedf3701', 'This is doctor room', 'Old R105', '105', 'DoctorRoom', '0f3a9eb2-5223-4775-b60f-3d13baadb254', '00-24'),
('67b1877a-c89d-4bb3-ba17-5d44a6faab83', 'This is doctor room', 'Old R106', '106', 'DoctorRoom', '0f3a9eb2-5223-4775-b60f-3d13baadb254', '00-24'),
('7f0b673f-4d4f-4b52-a66e-be888c3627f3', 'This is doctor room', 'Old R201', '201', 'DoctorRoom', 'c8d321c2-7bab-4f4d-a133-98eb4de4bb30', '00-24'),
('133962ea-c543-497b-81a6-6a2efb54212a', 'This is doctor room', 'Old R202', '202', 'DoctorRoom', 'c8d321c2-7bab-4f4d-a133-98eb4de4bb30', '00-24'),
('2b9b4701-831d-4510-aa44-d4a940acff73', 'This is doctor room', 'Old R203', '203', 'DoctorRoom', 'c8d321c2-7bab-4f4d-a133-98eb4de4bb30', '00-24'),
('f563b764-f837-4b70-ab6b-5c7be7f706b8', 'This is doctor room', 'Old R204', '204', 'DoctorRoom', 'c8d321c2-7bab-4f4d-a133-98eb4de4bb30', '00-24'),
('e8c0f4e2-fa51-4691-a7ba-dbabb36e69b0', 'This is doctor room', 'Old R205', '205', 'DoctorRoom', 'c8d321c2-7bab-4f4d-a133-98eb4de4bb30', '00-24'),
('b64ea4ac-e015-4a31-8cb1-dd514b889fad', 'This is doctor room', 'Old R206', '206', 'DoctorRoom', 'c8d321c2-7bab-4f4d-a133-98eb4de4bb30', '00-24'),
('620472d5-85b1-4f2d-aafc-3c9d9a59904f', 'This is doctor room', 'Old R301', '301', 'DoctorRoom', 'f775fba5-843e-4701-96e9-664530b18b3a', '00-24'),
('17612be9-8a0e-4fca-b937-134e053a916e', 'This is doctor room', 'Old R302', '302', 'DoctorRoom', 'f775fba5-843e-4701-96e9-664530b18b3a', '00-24'),
('0a675efc-9118-47e7-8701-392b2fce8f24', 'This is doctor room', 'Old R303', '303', 'DoctorRoom', 'f775fba5-843e-4701-96e9-664530b18b3a', '00-24'),
('37bad4cf-c231-4be2-b6cb-e4cdf75217e9', 'This is doctor room', 'Old R304', '304', 'DoctorRoom', 'f775fba5-843e-4701-96e9-664530b18b3a', '00-24'),
('ec0ff92c-9d64-4456-93a1-ca3d04be76b1', 'This is doctor room', 'Old R305', '305', 'DoctorRoom', 'f775fba5-843e-4701-96e9-664530b18b3a', '00-24'),
('3c8bb35e-cc74-46db-8c3e-fe757b0643e7', 'This is doctor room', 'Old R306', '306', 'DoctorRoom', 'f775fba5-843e-4701-96e9-664530b18b3a', '00-24'),
('79dfc8d1-2990-417d-8398-3227087b9d8f', 'This is doctor room', 'New R001', '001', 'DoctorRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24'),
('fda46699-49a4-49c8-83a0-9efb86db9079', 'This is doctor room', 'New R002', '002', 'DoctorRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24'),
('a460539e-cf02-4691-a09e-f132ed9939ec', 'This is doctor room', 'New R003', '003', 'DoctorRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24'),
('dc73d590-da16-4035-a25a-db400cdc9c53', 'This is doctor room', 'New R004', '004', 'DoctorRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24'),
('546d4ea1-937f-4029-8005-6b188cb33090', 'This is doctor room', 'New R005', '005', 'DoctorRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24'),
('bfd7238a-1157-47fd-97d4-ed61a3acc03b', 'This is doctor room', 'New R006', '006', 'DoctorRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24'),
('7187bad6-1336-4835-a072-de7dbd44ed47', 'This is doctor room', 'New R101', '101', 'DoctorRoom', '1b89ab52-d8ed-4a95-a436-4ecbe5404179', '00-24'),
('9460b027-03fb-4b07-89c7-25b5c22099a6', 'This is doctor room', 'New R102', '102', 'DoctorRoom', '1b89ab52-d8ed-4a95-a436-4ecbe5404179', '00-24'),
('92c8ef07-03b3-47ac-a159-56cfa490d111', 'This is doctor room', 'New R103', '103', 'DoctorRoom', '1b89ab52-d8ed-4a95-a436-4ecbe5404179', '00-24'),
('ca404f3e-a95d-44f5-9fab-42719dbcdd21', 'This is doctor room', 'New R104', '104', 'DoctorRoom', '1b89ab52-d8ed-4a95-a436-4ecbe5404179', '00-24'),
('3b310efb-a542-4838-ab2b-05faac495895', 'This is doctor room', 'New R105', '105', 'DoctorRoom', '1b89ab52-d8ed-4a95-a436-4ecbe5404179', '00-24'),
('dde5590b-1bea-489e-a503-302a9b9fc0ca', 'This is doctor room', 'New R106', '106', 'DoctorRoom', '1b89ab52-d8ed-4a95-a436-4ecbe5404179', '00-24'),
('25d39e5f-26f4-4254-a6f8-82d5e1abb6f0', 'This is doctor room', 'New R107', '107', 'DoctorRoom', '1b89ab52-d8ed-4a95-a436-4ecbe5404179', '00-24'),
('54c6de76-bc71-4615-8c73-4ebf9546444f', 'This is doctor room', 'New R201', '201', 'DoctorRoom', 'f65545be-c944-453d-9d41-d6463553279a', '00-24'),
('c9f57048-e05c-4cc7-926c-bdb48ef6a3dc', 'This is doctor room', 'New R202', '202', 'DoctorRoom', 'f65545be-c944-453d-9d41-d6463553279a', '00-24'),
('d6ef1785-b796-44b9-87b9-941f3684189d', 'This is doctor room', 'New R203', '203', 'DoctorRoom', 'f65545be-c944-453d-9d41-d6463553279a', '00-24'),
('f36eea9c-721a-40be-8cb0-12ac348c66bc', 'This is doctor room', 'New R204', '204', 'DoctorRoom', 'f65545be-c944-453d-9d41-d6463553279a', '00-24'),
('d709d442-1dd4-4560-8072-c8cfcab5454f', 'This is doctor room', 'New R205', '205', 'DoctorRoom', 'f65545be-c944-453d-9d41-d6463553279a', '00-24'),
('537f4833-bd4b-45be-92a0-d82f29e7c352', 'This is doctor room', 'New R206', '206', 'DoctorRoom', 'f65545be-c944-453d-9d41-d6463553279a', '00-24'),
('66b63e58-17a2-4a4a-9fa4-b5a26afd0fc6', 'This is doctor room', 'New R207', '207', 'DoctorRoom', 'f65545be-c944-453d-9d41-d6463553279a', '00-24'),
('be5d6557-f0fa-42fb-bff0-823923d6dfd9', 'This is doctor room', 'New R208', '208', 'DoctorRoom', 'f65545be-c944-453d-9d41-d6463553279a', '00-24');

INSERT INTO "Doctors" ("Id", "LicenceNum", "Speciality", "WorkingTimeStart", "WorkingTimeEnd", "RoomId", "Name", "Surname", "Birthdate", "Gender", "AddressId", "Jmbg", "EmailAddress", "PhoneNumber") VALUES 

('631732d1-2be0-481f-b104-604efb32014d', '0001', 'General practicioner', '7:00', '18:30', '9ae3255d-261f-472f-a961-7f2e7d05d95c', 'Reeva', 'MacGarrity', '1988-10-25 12:02:15', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'rmacgarrity6@drupal.org', '305-612-6943'),
('85bfee13-907e-410b-ad3a-9d4e0b7b87b7', '0002', 'General practicioner', '8:00', '17:00', '8dd731ee-197f-40a8-a5e1-845662b0c0cd', 'Biddie', 'Brockton', '1988-03-30 21:18:41', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'bbrockton7@buzzfeed.com', '782-119-1823'),
('487d0767-1f8b-4a09-a593-4f076bdb9881', '0003', 'General practicioner', '9:00', '19:30', 'd4857133-ef89-4e5e-865f-b49c83ecec23', 'Livvie', 'Ganniclifft', '1995-01-31 04:43:56', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'lganniclifft8@europa.eu', '803-712-3001'),
('c9f8ccb1-1b40-4d73-8a44-22d16144abdf', '0004', 'General practicioner', '8:30', '18:30', '424c4309-1154-4d52-9282-342601cef85c', 'Miranda', 'Dybald', '1928-03-24 07:29:10', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'wdybald9@tamu.edu', '441-654-6351'),
('a462c5f4-f1ec-47ce-958a-33e16b8f477b', '0005', 'General practicioner', '8:30', '20:30', '6b046e88-546c-4071-9431-24511e1e2d28', 'Sekoslav', 'Anal', '1948-03-24 07:29:10', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'wdybald9@tamu.edu', '441-654-6351'),
('09b5d1bc-2bef-4fcb-a199-6dbf8db560ae', '0006', 'General practicioner', '8:30', '19:30', 'a2c565f7-d61e-4302-a417-1ed48919bb8f', 'Haralampije', 'Skirt', '1958-05-24 07:29:10', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'wdybald9@tamu.edu', '441-654-6351'),
('022f69a6-1ed6-40f8-86f6-34efe85c94b8', '0007', 'General practicioner', '9:30', '21:30', '3bf58a45-d903-4148-8b7b-3fb0018bda83', 'Dokusur', 'Kolinc', '1978-05-24 07:29:10', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'wdybald9@tamu.edu', '441-654-6351'),
('cef2d8cd-49d7-4fef-8b24-d7e1dca50182', '0008', 'General practicioner', '9:30', '20:30', 'cb4f5baf-0383-463c-b914-d4dc384012f3', 'Punjab', 'Hanka', '1934-08-24 07:29:10', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'wdybald9@tamu.edu', '441-654-6351'),
('5a813d63-2e5a-4e91-961f-9b74d79f8de5', '0009', 'General practicioner', '8:30', '21:30', 'd2c2c548-5590-436b-9463-3ba7b82ed690', 'Darker', 'Esad', '1938-02-24 07:29:10', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'wdybald9@tamu.edu', '441-654-6351'),
('cd8be910-f742-4319-8db5-8fefaeccfc0f', '0010', 'General practicioner', '9:30', '20:30', 'fefd8331-bbbc-47ba-928d-abb0dedf3701', 'Brejkersfild', 'Hazihafizgebovic', '1943-06-24 07:29:10', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'wdybald9@tamu.edu', '441-654-6351'),
('26b169fa-e49d-4f5f-8d62-42bbd6333f85', '0011', 'General practicioner', '8:30', '21:30', '67b1877a-c89d-4bb3-ba17-5d44a6faab83', 'Kanter', 'Jasammusliman', '1975-09-24 07:29:10', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'wdybald9@tamu.edu', '441-654-6351'),
('737aa48b-c098-4309-8532-d16fb92ca314', '0012', 'General practicioner', '8:30', '20:30', '7f0b673f-4d4f-4b52-a66e-be888c3627f3', 'Solkor', 'Kiss', '1989-10-24 07:29:10', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'wdybald9@tamu.edu', '441-654-6351'),

('13936c4b-03ef-4b43-8c37-b928a5ee9d38', '0013', 'Cardiology', '8:00', '20:00', '133962ea-c543-497b-81a6-6a2efb54212a', 'Kankun', 'Swigg', '1973-09-28 15:51:51', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'hswigg0@accuweather.com', '726-634-4678'),
('a7132160-5c3e-4fb6-9f28-a82ada7cffd2', '0014', 'Cardiology', '7:00', '19:00', '2b9b4701-831d-4510-aa44-d4a940acff73', 'Mosa', 'Dysert', '1976-08-30 22:56:33', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'hdysert1@blinklist.com', '351-318-9872'),
('acd03892-cb1f-4264-981b-a6ba30cb424d', '0015', 'Cardiology', '8:30', '18:30', 'f563b764-f837-4b70-ab6b-5c7be7f706b8', 'Delker', 'Kpert', '1992-04-01 14:23:23', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'dstratton2@addtoany.com', '442-178-7787'),
('4c3724ac-eb55-4040-9978-d3604d85d219', '0016', 'Cardiology', '9:30', '18:30', 'e8c0f4e2-fa51-4691-a7ba-dbabb36e69b0', 'Njigar', 'Cviv', '1949-08-01 14:23:23', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'dstratton2@addtoany.com', '442-178-7787'),
('68bfe7c4-c5f9-4f0c-9326-b9f513f129fc', '0017', 'Cardiology', '4:30', '14:30', 'b64ea4ac-e015-4a31-8cb1-dd514b889fad', 'Pelen', 'Stratton', '1987-02-01 14:23:23', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'dstratton2@addtoany.com', '442-178-7787'),

('20770be2-7a1f-4656-8d9c-4c615ab27b5c', '0018', 'Neurology', '6:00', '17:30', '620472d5-85b1-4f2d-aafc-3c9d9a59904f', 'Karc', 'Secker', '1977-04-17 19:10:25', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'mseckera@posterous.com', '303-594-2555'),
('30b45dbb-1fca-4aa2-9df3-a646dfb6f532', '0019', 'Neurology', '8:00', '20:30', '17612be9-8a0e-4fca-b937-134e053a916e', 'Tolkin', 'Petyakov', '1980-12-14 14:36:35', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'epetyakovb@yellowpages.com', '382-824-9664'),
('9f35094e-339a-4e57-85f4-9cb8e48108b9', '0020', 'Neurology', '9:00', '13:30', '0a675efc-9118-47e7-8701-392b2fce8f24', 'Kengur', 'Psvalt', '1988-08-02 19:59:38', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'tredwingc@indiegogo.com', '300-547-5456'),
('c74a1a2f-6553-488a-a28e-d77f6d34072a', '0021', 'Neurology', '7:00', '17:30', '37bad4cf-c231-4be2-b6cb-e4cdf75217e9', 'Jan', 'Kirta', '1991-01-02 19:59:38', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'tredwingc@indiegogo.com', '300-547-5456'),

('9288e615-e4a5-458f-a98b-29486482261c', '0022', 'Pediatrist', '7:00', '17:00', 'ec0ff92c-9d64-4456-93a1-ca3d04be76b1', 'Kolup', 'Hruska', '1985-12-10 10:44:30', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'phruskaf@yellowbook.com', '788-517-0494'),
('46214694-a5cd-4472-be02-0912a8b807f7', '0023', 'Pediatrist', '8:00', '14:00', '3c8bb35e-cc74-46db-8c3e-fe757b0643e7', 'Skirtik', 'Shulem', '1996-11-10 10:38:02', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'eshulemg@freewebs.com', '234-871-1344'),
('6c78a5ed-2f4d-4d88-89b8-9bf658e65366', '0024', 'Pediatrist', '4:00', '15:00', '79dfc8d1-2990-417d-8398-3227087b9d8f', 'Kartikangjikar', 'Perez', '1992-05-10 10:38:02', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'eshulemg@freewebs.com', '234-871-1344'),
('3cc3c6a7-0849-4c6e-90b9-ea18641b3af7', '0025', 'Pediatrist', '8:00', '16:00', 'fda46699-49a4-49c8-83a0-9efb86db9079', 'Colkonur', 'Alana', '1991-03-10 10:38:02', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'eshulemg@freewebs.com', '234-871-1344'),
('cbcfa34f-f356-40af-8ca0-132278db5f41', '0026', 'Pediatrist', '9:00', '17:00', 'a460539e-cf02-4691-a09e-f132ed9939ec', 'Evangelia', 'Shalom', '1988-09-10 10:38:02', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'eshulemg@freewebs.com', '234-871-1344'),
('6f6dfb1b-3148-41d1-af23-364c3ac4b54d', '0027', 'Pediatrist', '7:00', '18:00', 'dc73d590-da16-4035-a25a-db400cdc9c53', 'Pstig', 'KajtiPeri', '1978-07-10 10:38:02', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'eshulemg@freewebs.com', '234-871-1344'),

('da100e21-33c1-46b8-bcd1-4eabf50ed4d6', '0028', 'Oftamologist', '8:00', '20:30', '546d4ea1-937f-4029-8005-6b188cb33090', 'Perty', 'Orangutan', '1976-12-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('da40fbc6-f341-4126-9e04-4e891cd75ec0', '0029', 'Oftamologist', '7:00', '17:30', 'bfd7238a-1157-47fd-97d4-ed61a3acc03b', 'JoniGori', 'Vucki', '1956-11-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('e0fd4969-8257-4b26-9263-2b47419456d4', '0030', 'Oftamologist', '9:00', '16:30', '7187bad6-1336-4835-a072-de7dbd44ed47', 'Fens', 'Kurti', '1997-01-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),

('35d68f4c-da7b-4745-9f51-cd89044bb9b5', '0031', 'Surgeon', '8:00', '20:30', '9460b027-03fb-4b07-89c7-25b5c22099a6', 'Quzar', 'Mostikular', '1957-11-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('e2856109-acdc-4af8-9512-66d1b65b4760', '0032', 'Surgeon', '9:00', '14:30', '92c8ef07-03b3-47ac-a159-56cfa490d111', 'Pompom', 'Cvarck', '1954-10-03 08:14:18', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('f19b7905-9bb7-4d07-abf6-7b9d4e782714', '0033', 'Surgeon', '3:00', '20:30', 'ca404f3e-a95d-44f5-9fab-42719dbcdd21', 'Qi', 'Kentikurt', '1994-12-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('1b08b11c-11bb-4d82-a695-4657f7c86b8c', '0034', 'Surgeon', '4:00', '15:30', '3b310efb-a542-4838-ab2b-05faac495895', 'Umbape', 'Samar', '1954-08-03 08:14:18', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('75d6b568-b9cc-4521-8de0-cb93d653c862', '0035', 'Surgeon', '8:00', '13:30', 'dde5590b-1bea-489e-a503-302a9b9fc0ca', 'Turkmno', 'Pirm', '1987-05-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),

('c43843a8-19c7-447a-ab11-21d0da2fc77c', '0036', 'Immunology', '7:00', '13:30', '25d39e5f-26f4-4254-a6f8-82d5e1abb6f0', 'Peqsx', 'Dens', '1969-12-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('b2ecb208-e064-4af8-8273-fa650fbf7839', '0037', 'Immunology', '9:00', '16:30', '54c6de76-bc71-4615-8c73-4ebf9546444f', 'Roek', 'Hakarlimp', '1983-05-03 08:14:18', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('ade29412-d7bf-4f82-8ead-e1f5a50f9c28', '0038', 'Immunology', '8:00', '14:30', 'c9f57048-e05c-4cc7-926c-bdb48ef6a3dc', 'Melikverije', 'Satis', '1984-10-03 08:14:18', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),

('231c2ada-80ce-4fdd-a0fc-f905b53a5213', '0039', 'Dermatology', '15:00', '22:30', 'd6ef1785-b796-44b9-87b9-941f3684189d', 'Kwertsitmia', 'Sorz', '1985-11-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('34d324fc-1b20-4855-af4a-9203a192830b', '0040', 'Dermatology', '16:00', '21:30', 'f36eea9c-721a-40be-8cb0-12ac348c66bc', 'Lokvnji', 'Kalpi', '1959-06-03 08:14:18', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('fce5f91d-8460-4b5f-93c1-2f2a7baa6c2a', '0041', 'Dermatology', '18:00', '22:30', 'd709d442-1dd4-4560-8072-c8cfcab5454f', 'Serik', 'Rose', '1993-05-03 08:14:18', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),
('8c3c8455-574b-44c2-a5b5-2554bd5e669f', '0042', 'Dermatology', '17:00', '19:00', '537f4833-bd4b-45be-92a0-d82f29e7c352', 'Azgabul', 'Lemon', '1936-11-04 11:09:26', 1, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'ilemon5@ihg.com', '233-160-6561'),
('d1f4a910-f61f-4c0b-9ddd-0e16e6f11c8b', '0043', 'Dermatology', '8:00', '20:30', '66b63e58-17a2-4a4a-9fa4-b5a26afd0fc6', 'Perimetrako', 'Biter', '1984-05-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594'),

('bdffc1c1-4765-4184-802e-d70388f2f429', '0044', 'Urology', '8:00', '20:30', 'be5d6557-f0fa-42fb-bff0-823923d6dfd9', 'Kvacr', 'Nadanz', '1979-07-03 08:14:18', 0, '1b9e69e2-283a-4e1b-999e-4f9997bbcfe5', '{"JmbgValue": "1807000730038"}', 'vorisj@twitpic.com', '862-694-4594');

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

INSERT INTO "PatientAllergies" ("AllergiesId", "PatientsId") VALUES ('a6739c08-1939-4a6e-8ca9-e58b087bc9a5','79978326-f136-4cec-813b-6b12c962752b');
INSERT INTO "PatientAllergies" ("AllergiesId", "PatientsId") VALUES ('04eee618-5b2c-481b-8e52-4e32f7ab6ce8','79978326-f136-4cec-813b-6b12c962752b');
INSERT INTO "PatientAllergies" ("AllergiesId", "PatientsId") VALUES ('d281b879-f344-461a-ada7-a8ef826f1155','79978326-f136-4cec-813b-6b12c962752b');

INSERT INTO public."Feedbacks" ("Id","Text","IsAnonimous","IsDesiredPublic","Status","PatientId","Date") VALUES
	 ('17535a9b-d2d7-4369-8612-0223c8e9b398','Good maintenance of rooms. Nice gesture by nursing staff. Overall had a very good experience and feel at home. Good job. Cheers..! ',false,true,0,'3e9e456a-7948-4e82-b33c-583737856111','2021-02-07 19:48:51.44'),
	 ('04311e21-af8d-45ed-957e-823b3b1db240','Attention given by the doctors and staff is good. I am impressed and feel safe to refer any patient, who requires treatment, to this hospital.',false,true,0,'43d8ef21-2f8e-47a3-97fa-bb9253ea7d04','2021-01-15 20:51:07.041'),
	 ('06f2538b-8480-42ad-b7f4-804d7f6cc731','Nursing Staff is excellent and dedicated. Housekeeping is very good. Doctors are professional and gave confidence to the patients. Please keep up the good work.',false,true,0,'3fe961db-5146-43b4-b7b4-e1c63a299ce1','2021-06-10 14:15:50.878'),
	 ('4eb45012-7216-4184-99fe-2a4e59ef6428','very advanced hospital with the technology and also doctors….they take care of patients verygood…the entire staff reciveing and treating of the patients is very excellent… ',true,true,0,'1e173ef3-3daa-482b-aa59-fc536c218fe3','2022-11-27 07:52:33.035'),
	 ('3e4c0ade-116f-436a-b5d0-8ccaeba568b7','Extremely well maintained hospital with a terrific team of doctors, who leave no stone unturned for a patient and stand by you on the journey to recovery. ',true,true,0,'243aa452-2d25-4fbf-9d66-f01917f009ff','2022-12-01 18:36:50.856'),
	 ('b976e01f-4e5e-40c4-8bb0-6cb99088af1e','Nothing to specify in particular. Everything is in good manner. 100% marks when it comes to cleanliness. Never seen such a well maintained hospital. ',true,true,0,'ddbe195e-2337-4347-86f2-d702cd206543','2023-01-10 17:53:09.838'),
	 ('0d7a2ed3-dbf2-4be4-9fbb-bf06c60ac5c2','After you get past the fancy white spaceship interior, you realize the service is super overpriced. Haleigh Dysert charges way more than anyone else.',true,true,0,'24826bea-0ebb-492c-96db-3d7e5f214028','2023-01-13 21:04:50.451'),
	 ('ce18681d-98bc-48e4-9b0e-e81bd924b9f1','Dr Haleigh Dysert is constantly disrespectful of my time. I had a noon appointment and walked out at 12:45 without getting seen.',false,true,0,'e2415681-422e-4870-84e1-9b3b2a108643','2023-01-16 10:49:14.557');

INSERT INTO "Users" ("Username", "Password", "IsAccountActive", "IsBlocked", "Role", "PersonId") VALUES
('manager0', '{"PasswordValue":"manager0"}', true, false, 2, null),
('manager1', '{"PasswordValue":"manager1"}', true, false, 2, null),

('doktor0', '{"PasswordValue": "doktor0"}', true, false, 1, '631732d1-2be0-481f-b104-604efb32014d'),
('doktor1', '{"PasswordValue": "doktor1"}', true, false, 1, '85bfee13-907e-410b-ad3a-9d4e0b7b87b7'),
('doktor2', '{"PasswordValue": "doktor2"}', true, false, 1, '487d0767-1f8b-4a09-a593-4f076bdb9881'),
('doktor3', '{"PasswordValue": "doktor3"}', true, false, 1, '13936c4b-03ef-4b43-8c37-b928a5ee9d38'),
('doktor4', '{"PasswordValue": "doktor4"}', true, false, 1, '20770be2-7a1f-4656-8d9c-4c615ab27b5c'),
('doktor5', '{"PasswordValue": "doktor5"}', true, false, 1, 'bdffc1c1-4765-4184-802e-d70388f2f429');

insert into public."Equipments" ("Id", "Name") values ('c8da3993-1a84-46c0-97bd-187991b54b4a','Bed');
insert into public."Equipments" ("Id", "Name") values ('497f7913-2139-4091-9a4c-0091d3b76216','Infusion stand');
insert into public."Equipments" ("Id", "Name") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0','Computer');
insert into public."Equipments" ("Id", "Name") values ('2d6e94c6-775a-499f-861f-c432439bc7ff','Chair');
insert into public."Equipments" ("Id", "Name") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8','EKG monitor');
insert into public."Equipments" ("Id", "Name") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74','Table');
insert into public."Equipments" ("Id", "Name") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442','Cabinet');



insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',3, '133962ea-c543-497b-81a6-6a2efb54212a');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',2, '25d39e5f-26f4-4254-a6f8-82d5e1abb6f0');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',2, '37bad4cf-c231-4be2-b6cb-e4cdf75217e9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',5, '3bf58a45-d903-4148-8b7b-3fb0018bda83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',3, '424c4309-1154-4d52-9282-342601cef85c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',3, '546d4ea1-937f-4029-8005-6b188cb33090');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',1, '620472d5-85b1-4f2d-aafc-3c9d9a59904f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',2, '67b1877a-c89d-4bb3-ba17-5d44a6faab83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',1, '7187bad6-1336-4835-a072-de7dbd44ed47');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',1, '7f0b673f-4d4f-4b52-a66e-be888c3627f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',2, '92c8ef07-03b3-47ac-a159-56cfa490d111');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',2, '9ae3255d-261f-472f-a961-7f2e7d05d95c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',3, 'a460539e-cf02-4691-a09e-f132ed9939ec');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',4, 'be5d6557-f0fa-42fb-bff0-823923d6dfd9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',3, 'c9f57048-e05c-4cc7-926c-bdb48ef6a3dc');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',1, 'cb4f5baf-0383-463c-b914-d4dc384012f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',1, 'd4857133-ef89-4e5e-865f-b49c83ecec23');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',4, 'd709d442-1dd4-4560-8072-c8cfcab5454f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',1, 'dde5590b-1bea-489e-a503-302a9b9fc0ca');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',2, 'ec0ff92c-9d64-4456-93a1-ca3d04be76b1');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',1, 'f563b764-f837-4b70-ab6b-5c7be7f706b8');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',6, 'fefd8331-bbbc-47ba-928d-abb0dedf3701');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',4, '133962ea-c543-497b-81a6-6a2efb54212a');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',3, '25d39e5f-26f4-4254-a6f8-82d5e1abb6f0');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',2, '37bad4cf-c231-4be2-b6cb-e4cdf75217e9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',4, '3bf58a45-d903-4148-8b7b-3fb0018bda83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',7, '424c4309-1154-4d52-9282-342601cef85c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',1, '546d4ea1-937f-4029-8005-6b188cb33090');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',1, '620472d5-85b1-4f2d-aafc-3c9d9a59904f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',1, '67b1877a-c89d-4bb3-ba17-5d44a6faab83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',4, '7187bad6-1336-4835-a072-de7dbd44ed47');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',1, '7f0b673f-4d4f-4b52-a66e-be888c3627f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',4, '92c8ef07-03b3-47ac-a159-56cfa490d111');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',1, '9ae3255d-261f-472f-a961-7f2e7d05d95c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',2, 'a460539e-cf02-4691-a09e-f132ed9939ec');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',3, 'be5d6557-f0fa-42fb-bff0-823923d6dfd9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',2, 'c9f57048-e05c-4cc7-926c-bdb48ef6a3dc');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',1, 'cb4f5baf-0383-463c-b914-d4dc384012f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',2, 'd4857133-ef89-4e5e-865f-b49c83ecec23');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',2, 'd709d442-1dd4-4560-8072-c8cfcab5454f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',3, 'dde5590b-1bea-489e-a503-302a9b9fc0ca');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',3, 'f563b764-f837-4b70-ab6b-5c7be7f706b8');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',1, 'fefd8331-bbbc-47ba-928d-abb0dedf3701');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',5, '133962ea-c543-497b-81a6-6a2efb54212a');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',1, '25d39e5f-26f4-4254-a6f8-82d5e1abb6f0');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',1, '37bad4cf-c231-4be2-b6cb-e4cdf75217e9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',2, '3bf58a45-d903-4148-8b7b-3fb0018bda83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',1, '424c4309-1154-4d52-9282-342601cef85c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',6, '546d4ea1-937f-4029-8005-6b188cb33090');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',5, '620472d5-85b1-4f2d-aafc-3c9d9a59904f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',3, '67b1877a-c89d-4bb3-ba17-5d44a6faab83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',6, '7187bad6-1336-4835-a072-de7dbd44ed47');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',1, '7f0b673f-4d4f-4b52-a66e-be888c3627f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',1, '92c8ef07-03b3-47ac-a159-56cfa490d111');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',2, '9ae3255d-261f-472f-a961-7f2e7d05d95c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',6, 'a460539e-cf02-4691-a09e-f132ed9939ec');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',4, 'be5d6557-f0fa-42fb-bff0-823923d6dfd9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',1, 'c9f57048-e05c-4cc7-926c-bdb48ef6a3dc');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',3, 'cb4f5baf-0383-463c-b914-d4dc384012f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',1, 'd4857133-ef89-4e5e-865f-b49c83ecec23');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',6, 'd709d442-1dd4-4560-8072-c8cfcab5454f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',1, 'dde5590b-1bea-489e-a503-302a9b9fc0ca');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',2, 'ec0ff92c-9d64-4456-93a1-ca3d04be76b1');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',3, 'f563b764-f837-4b70-ab6b-5c7be7f706b8');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',3, 'fefd8331-bbbc-47ba-928d-abb0dedf3701');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',1, '133962ea-c543-497b-81a6-6a2efb54212a');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',1, '25d39e5f-26f4-4254-a6f8-82d5e1abb6f0');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',6, '37bad4cf-c231-4be2-b6cb-e4cdf75217e9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',4, '3bf58a45-d903-4148-8b7b-3fb0018bda83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',1, '424c4309-1154-4d52-9282-342601cef85c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',2, '546d4ea1-937f-4029-8005-6b188cb33090');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',2, '620472d5-85b1-4f2d-aafc-3c9d9a59904f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',3, '67b1877a-c89d-4bb3-ba17-5d44a6faab83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',2, '7187bad6-1336-4835-a072-de7dbd44ed47');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',3, '7f0b673f-4d4f-4b52-a66e-be888c3627f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',4, '92c8ef07-03b3-47ac-a159-56cfa490d111');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',3, '9ae3255d-261f-472f-a961-7f2e7d05d95c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',4, 'a460539e-cf02-4691-a09e-f132ed9939ec');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',4, 'be5d6557-f0fa-42fb-bff0-823923d6dfd9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',2, 'c9f57048-e05c-4cc7-926c-bdb48ef6a3dc');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',3, 'cb4f5baf-0383-463c-b914-d4dc384012f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',2, 'd4857133-ef89-4e5e-865f-b49c83ecec23');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',2, 'd709d442-1dd4-4560-8072-c8cfcab5454f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',1, 'dde5590b-1bea-489e-a503-302a9b9fc0ca');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',1, 'ec0ff92c-9d64-4456-93a1-ca3d04be76b1');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',5, 'f563b764-f837-4b70-ab6b-5c7be7f706b8');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',5, 'fefd8331-bbbc-47ba-928d-abb0dedf3701');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',4, '133962ea-c543-497b-81a6-6a2efb54212a');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',2, '25d39e5f-26f4-4254-a6f8-82d5e1abb6f0');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',2, '37bad4cf-c231-4be2-b6cb-e4cdf75217e9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',1, '3bf58a45-d903-4148-8b7b-3fb0018bda83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',2, '424c4309-1154-4d52-9282-342601cef85c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',2, '546d4ea1-937f-4029-8005-6b188cb33090');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',1, '620472d5-85b1-4f2d-aafc-3c9d9a59904f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',7, '67b1877a-c89d-4bb3-ba17-5d44a6faab83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',7, '7187bad6-1336-4835-a072-de7dbd44ed47');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',5, '7f0b673f-4d4f-4b52-a66e-be888c3627f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',1, '92c8ef07-03b3-47ac-a159-56cfa490d111');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',1, '9ae3255d-261f-472f-a961-7f2e7d05d95c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',3, 'a460539e-cf02-4691-a09e-f132ed9939ec');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',3, 'be5d6557-f0fa-42fb-bff0-823923d6dfd9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',2, 'c9f57048-e05c-4cc7-926c-bdb48ef6a3dc');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',7, 'cb4f5baf-0383-463c-b914-d4dc384012f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',1, 'd4857133-ef89-4e5e-865f-b49c83ecec23');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',5, 'd709d442-1dd4-4560-8072-c8cfcab5454f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',1, 'dde5590b-1bea-489e-a503-302a9b9fc0ca');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',2, 'ec0ff92c-9d64-4456-93a1-ca3d04be76b1');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',6, 'f563b764-f837-4b70-ab6b-5c7be7f706b8');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',4, 'fefd8331-bbbc-47ba-928d-abb0dedf3701');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',6, '133962ea-c543-497b-81a6-6a2efb54212a');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',4, '25d39e5f-26f4-4254-a6f8-82d5e1abb6f0');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',3, '37bad4cf-c231-4be2-b6cb-e4cdf75217e9');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',1, '3bf58a45-d903-4148-8b7b-3fb0018bda83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',1, '424c4309-1154-4d52-9282-342601cef85c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',2, '546d4ea1-937f-4029-8005-6b188cb33090');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',3, '620472d5-85b1-4f2d-aafc-3c9d9a59904f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',2, '67b1877a-c89d-4bb3-ba17-5d44a6faab83');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',7, '7187bad6-1336-4835-a072-de7dbd44ed47');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',7, '7f0b673f-4d4f-4b52-a66e-be888c3627f3');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',3, '92c8ef07-03b3-47ac-a159-56cfa490d111');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',3, '9ae3255d-261f-472f-a961-7f2e7d05d95c');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',4, 'bfd7238a-1157-47fd-97d4-ed61a3acc03b');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',3, 'ca404f3e-a95d-44f5-9fab-42719dbcdd21');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',1, 'd2c2c548-5590-436b-9463-3ba7b82ed690');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',2, 'd6ef1785-b796-44b9-87b9-941f3684189d');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',4, 'dc73d590-da16-4035-a25a-db400cdc9c53');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',2, 'e8c0f4e2-fa51-4691-a7ba-dbabb36e69b0');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',4, 'f36eea9c-721a-40be-8cb0-12ac348c66bc');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',1, 'fda46699-49a4-49c8-83a0-9efb86db9079');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',2, '0a675efc-9118-47e7-8701-392b2fce8f24');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',1, '17612be9-8a0e-4fca-b937-134e053a916e');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',5, '2b9b4701-831d-4510-aa44-d4a940acff73');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',2, '3b310efb-a542-4838-ab2b-05faac495895');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',2, '3c8bb35e-cc74-46db-8c3e-fe757b0643e7');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',3, '537f4833-bd4b-45be-92a0-d82f29e7c352');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',4, '54c6de76-bc71-4615-8c73-4ebf9546444f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',2, '66b63e58-17a2-4a4a-9fa4-b5a26afd0fc6');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',2, '6b046e88-546c-4071-9431-24511e1e2d28');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',3, '79dfc8d1-2990-417d-8398-3227087b9d8f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',5, '8dd731ee-197f-40a8-a5e1-845662b0c0cd');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',2, '9460b027-03fb-4b07-89c7-25b5c22099a6');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',4, 'a2c565f7-d61e-4302-a417-1ed48919bb8f');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',2, 'b64ea4ac-e015-4a31-8cb1-dd514b889fad');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',6, 'bfd7238a-1157-47fd-97d4-ed61a3acc03b');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('c8da3993-1a84-46c0-97bd-187991b54b4a',4, 'ca404f3e-a95d-44f5-9fab-42719dbcdd21');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0',3, 'd2c2c548-5590-436b-9463-3ba7b82ed690');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('a00e71fd-7d8f-427e-afb7-ff1b45749fd8',2, 'd6ef1785-b796-44b9-87b9-941f3684189d');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('4de7e93f-95d9-4d49-8856-d3d6a8af8442',2, 'dc73d590-da16-4035-a25a-db400cdc9c53');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('497f7913-2139-4091-9a4c-0091d3b76216',6, 'e8c0f4e2-fa51-4691-a7ba-dbabb36e69b0');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('2d6e94c6-775a-499f-861f-c432439bc7ff',1, 'f36eea9c-721a-40be-8cb0-12ac348c66bc');
insert into public."RoomsEquipment" ("EquipmentId", "Amount", "RoomId") values ('fef16a98-f2e5-4d12-9346-ddd6b8840d74',5, 'fda46699-49a4-49c8-83a0-9efb86db9079');

INSERT INTO public."MapItem"(
	"Id", "BuildingId", "CoordinateX", "CoordinateY", "Height", "Width", "Discriminator")
	VALUES ('bf9fefb6-d1d8-47f9-b97f-50e099d63f90', '4c08ff1f-0227-4a3c-93db-dcd865a1069b', 10, 10, 200, 250, 'BuildingMap'),
		   ('52d812c9-ab26-46ba-a4f6-17f492c71510', '6f8f6c66-a869-4715-8229-95df705418a6', 300, 280, 150, 250, 'BuildingMap');
INSERT INTO public."MapItem"(
	"Id", "FloorId", "CoordinateX", "CoordinateY", "Height", "Width", "Discriminator")
	VALUES ('fc47af3d-5a41-402b-8863-9aae827e9008', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 10, 150, 45, 300, 'FloorMap'),
			('f7d556b2-8667-44bd-95ec-a5dc2d8d1353', '0f3a9eb2-5223-4775-b60f-3d13baadb254', 10, 100, 45, 300, 'FloorMap'),
			('4ce897d3-6392-48fc-b0a4-9671fd8b6343', 'c8d321c2-7bab-4f4d-a133-98eb4de4bb30', 10, 50, 45, 300, 'FloorMap'),
			('6605a870-8a45-4fc7-b281-039f91b48d3d', 'f775fba5-843e-4701-96e9-664530b18b3a', 10, 0, 48, 300, 'FloorMap'),
			('cb7de67a-3f3e-42ab-91da-335252bc533d', '1b7f1f98-8737-4c53-87e3-3399705be80d', 20, 100, 45, 300, 'FloorMap'),
			('220f2cf0-d0f9-47a8-bca5-86fb869e486f', '1b89ab52-d8ed-4a95-a436-4ecbe5404179', 20, 50, 45, 300, 'FloorMap'),
			('e3d38c92-01de-4d49-afb5-90de4dad2a42', 'f65545be-c944-453d-9d41-d6463553279a', 20, 0, 45, 300, 'FloorMap')
	
	;
INSERT INTO public."MapItem"("Id", "RoomId", "CoordinateX", "CoordinateY", "Height", "Width", "Discriminator") VALUES ('1dd897c6-56a0-4b9c-be76-c5cfd0ccfea0', '9ae3255d-261f-472f-a961-7f2e7d05d95c', 0, 0, 100, 80, 'RoomMap');
INSERT INTO public."MapItem"("Id", "RoomId", "CoordinateX", "CoordinateY", "Height", "Width", "Discriminator") VALUES ('4c8b0af2-9936-46a3-9eaf-002840685f64', '8dd731ee-197f-40a8-a5e1-845662b0c0cd', 0, 100, 80, 80, 'RoomMap');
INSERT INTO public."MapItem"("Id", "RoomId", "CoordinateX", "CoordinateY", "Height", "Width", "Discriminator") VALUES ('c2c47c06-4403-4f77-8c70-ed570e2a8812', 'd4857133-ef89-4e5e-865f-b49c83ecec23', 80, 0, 80, 80, 'RoomMap'),
			('0f753a34-bf93-4e9a-ac80-5922a2394ae0', '424c4309-1154-4d52-9282-342601cef85c', 160, 0, 80, 80, 'RoomMap'),
			('af16141a-8ebc-4c84-a22e-0990d0c50efe', '6b046e88-546c-4071-9431-24511e1e2d28', 240, 0, 80, 80, 'RoomMap'),
			('79851b1a-d097-488d-a60c-1d3f49aab33c', 'a2c565f7-d61e-4302-a417-1ed48919bb8f', 10, 10, 80, 80, 'RoomMap'),
			('5c3ba31a-0a57-466f-a59d-e4cdd26c8adc', '3bf58a45-d903-4148-8b7b-3fb0018bda83', 90, 10, 80, 80, 'RoomMap'),
			('12776675-36e3-40a6-a4fe-d6f490cd9e00', 'cb4f5baf-0383-463c-b914-d4dc384012f3', 170, 10, 80, 80, 'RoomMap'),
			('9be28ba5-f383-4d6f-b54e-92633bc31cfb', 'd2c2c548-5590-436b-9463-3ba7b82ed690', 10, 120, 80, 80, 'RoomMap'),
			('e54eb688-cbc3-43ac-a2eb-35d28d641f44', 'fefd8331-bbbc-47ba-928d-abb0dedf3701', 90, 120, 80, 80, 'RoomMap'),
			('51865243-4cf1-4a0b-86d5-f5712360377f', '67b1877a-c89d-4bb3-ba17-5d44a6faab83', 170, 120, 50, 90, 'RoomMap'),
			('2eb93231-970d-4c15-93a0-dd3cb6a10db4', '7f0b673f-4d4f-4b52-a66e-be888c3627f3', 10, 10, 50, 90, 'RoomMap'),
			('b383b831-4e1a-46d6-aff3-c663f8580a78', '133962ea-c543-497b-81a6-6a2efb54212a', 100, 10, 50, 90, 'RoomMap'),
			('f8b3b550-93ee-423d-801d-f7482617dd8a', '2b9b4701-831d-4510-aa44-d4a940acff73', 190, 10, 50, 90, 'RoomMap'),
			('ce0d82bf-75b3-4148-96ab-c7c4c90090f2', 'f563b764-f837-4b70-ab6b-5c7be7f706b8', 10, 110, 80, 80, 'RoomMap'),
			('82e4bf09-01e1-4164-afa8-52fac8c2f3d8', 'e8c0f4e2-fa51-4691-a7ba-dbabb36e69b0', 90, 110, 80, 80, 'RoomMap'),
			('6d1c0f1a-a8bc-407c-8ed2-eeca6e065178', 'b64ea4ac-e015-4a31-8cb1-dd514b889fad', 170, 110, 80, 80, 'RoomMap'),
			('ead480a8-a7c6-4317-9e6d-2aa78250c1a6', '620472d5-85b1-4f2d-aafc-3c9d9a59904f', 10, 10, 80, 80, 'RoomMap'),
			('91f6cef2-7735-4a0d-86f4-cebf64eb12a2', '17612be9-8a0e-4fca-b937-134e053a916e', 10, 90, 80, 80, 'RoomMap'),
			('0a9a8a1e-4509-4696-94d5-e1d971a5a157', '0a675efc-9118-47e7-8701-392b2fce8f24', 10, 170, 80, 80, 'RoomMap'),
			('57071813-2346-48a2-b5cd-df2b79d6fe2a', '37bad4cf-c231-4be2-b6cb-e4cdf75217e9', 120, 10, 80, 80, 'RoomMap'),
			('f2d0261a-f74f-4d40-8def-3657ecb1adb7', 'ec0ff92c-9d64-4456-93a1-ca3d04be76b1', 120, 90, 80, 80, 'RoomMap'),
			('9b314b91-c97b-4b0b-a0f7-c03ff339f46e', '3c8bb35e-cc74-46db-8c3e-fe757b0643e7', 120, 170, 80, 80, 'RoomMap'),
			('9863e32d-9a9b-41e5-8d37-2f579521ab14', '79dfc8d1-2990-417d-8398-3227087b9d8f', 10, 10, 80, 90, 'RoomMap'),
			('4ee3dbac-2850-41b4-8b60-79eb8b1cef59', 'fda46699-49a4-49c8-83a0-9efb86db9079', 100, 10, 80, 100, 'RoomMap'),
			('da23f3bd-af84-4205-a3cc-2e5c3139ee08', 'a460539e-cf02-4691-a09e-f132ed9939ec', 200, 10, 80, 100, 'RoomMap'),
			('ea50801a-2a4e-4873-8566-163fb655c7ec', 'dc73d590-da16-4035-a25a-db400cdc9c53', 10, 90, 80, 80, 'RoomMap'),
			('eb62ca3d-98fa-46b7-ad82-c4742e301ef6', '546d4ea1-937f-4029-8005-6b188cb33090', 100, 170, 80, 80, 'RoomMap'),
			('da4d54e2-114a-46df-8a08-30bc17fa4608', 'bfd7238a-1157-47fd-97d4-ed61a3acc03b', 180, 170, 80, 80, 'RoomMap'),
			('3917b474-4c7b-4f6a-b875-ee2aded1a2e9', '7187bad6-1336-4835-a072-de7dbd44ed47', 10, 10, 80, 90, 'RoomMap'),
			('e6c0794d-15c2-4fcc-8d4b-615599179d12', '9460b027-03fb-4b07-89c7-25b5c22099a6', 100, 10, 80, 100, 'RoomMap'),
			('c68f7e99-3585-4c9a-9974-340874a850f9', '92c8ef07-03b3-47ac-a159-56cfa490d111', 200, 10, 80, 100, 'RoomMap'),
			('4609e026-1213-4f9d-95b1-b5f2692adfb8', 'ca404f3e-a95d-44f5-9fab-42719dbcdd21', 10, 90, 80, 80, 'RoomMap'),
			('8a650187-6121-42af-8113-fb274824c6f1', '3b310efb-a542-4838-ab2b-05faac495895', 90, 180, 80, 80, 'RoomMap'),
			('21cbedf3-fbf0-4bd2-baa3-bddd12511393', 'dde5590b-1bea-489e-a503-302a9b9fc0ca', 170, 180, 80, 80, 'RoomMap'),
			('538f6a4b-f58b-4f61-a5e2-30e71c80c5c3', '25d39e5f-26f4-4254-a6f8-82d5e1abb6f0', 250, 180, 80, 80, 'RoomMap'),
			('4b7631f6-73e9-40f3-9471-b835f9edf938', '54c6de76-bc71-4615-8c73-4ebf9546444f', 10, 20, 80, 80, 'RoomMap'),
			('e0d6dc3c-d7ac-493e-b373-42ac20071685', 'c9f57048-e05c-4cc7-926c-bdb48ef6a3dc', 90, 20, 80, 80, 'RoomMap'),
			('938befe5-68d5-40c5-8e64-6d11b3808f20', 'd6ef1785-b796-44b9-87b9-941f3684189d', 170, 20, 80, 80, 'RoomMap'),
			('ff0cdc47-e961-4da7-8f77-ea4a6cdf7164', 'f36eea9c-721a-40be-8cb0-12ac348c66bc', 250, 20, 80, 80, 'RoomMap'),
			('1203d09e-578a-47e8-95a8-58cadacb567b', 'd709d442-1dd4-4560-8072-c8cfcab5454f', 10, 120, 80, 80, 'RoomMap'),
			('309c86e4-3459-4756-8c32-da9bef5ca395', '537f4833-bd4b-45be-92a0-d82f29e7c352', 90, 120, 80, 80, 'RoomMap'),
			('56d875b8-c7f0-4c4e-acdf-99bdc4a979e8', '66b63e58-17a2-4a4a-9fa4-b5a26afd0fc6', 170, 120, 80, 80, 'RoomMap'),
			('a7120f41-2893-4041-88cb-55beb585583a', 'be5d6557-f0fa-42fb-bff0-823923d6dfd9', 250, 120, 80, 80, 'RoomMap')
			;
INSERT INTO public."Admissions" ("Id","PatientId","ReasonText","RoomId","arrivalDate") VALUES
	 ('1412c639-c5e1-47a1-b29b-1fe925536612','24826bea-0ebb-492c-96db-3d7e5f214028','Povisen secer pa mora da se oporavi','54c6de76-bc71-4615-8c73-4ebf9546444f','2022-11-11 11:11:00'),
	 ('15f4c4e0-08b2-44ef-9e1b-0f14164d59d2','24826bea-0ebb-492c-96db-3d7e5f214028','Srcani zastoj u prednjoj komori','d4857133-ef89-4e5e-865f-b49c83ecec23','2022-09-09 10:10:00');

INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('10151c79-4419-4d5e-8009-ed70ab887601',0,'[{"Id":"c2f3642d-a99d-4053-ba6b-f4397061d5ed","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"f348f2dc-8b61-49f6-b3c3-7bcec4db60de","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room","Description":"123","Type":1,"Number":123}]','2023-01-12 23:00:00','2023-01-13 23:00:00',0);
INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('266edcd7-ee86-4fa2-a17e-d14822a7a1dc',0,'[]',NULL,NULL,0);
INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('37e5221a-6c29-4f0b-9a2d-1230ae443ec9',0,'[]',NULL,NULL,0);
INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('59034bf1-ec91-40dd-9280-2f54b0ec1ac9',0,'[]',NULL,NULL,0);
INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('7f47a353-1b30-41a6-ae31-9ea2c63b502b',1,'[{"Id":"fda46699-49a4-49c8-83a0-9efb86db9079","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"00000000-0000-0000-0000-000000000000","Name":"123","Description":"123","Type":1,"Number":123},{"Id":"00000000-0000-0000-0000-000000000000","Name":"123","Description":"123","Type":1,"Number":123}]','2023-01-19 23:30:00','2023-01-21 00:31:00',0);
INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('87ecc6e9-47e3-4719-abc2-8ee90a482e76',1,'[]',NULL,NULL,0);
INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('b352cd9c-a1ea-4dda-a88d-8714a71ad607',1,'[{"Id":"d2c2c548-5590-436b-9463-3ba7b82ed690","Name":null,"Description":null,"Type":0,"Number":0}]','2023-01-20 00:00:00','2023-02-01 01:01:00',0);
INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('d2619d7c-9779-4c7e-9ef9-6e0486dc7e81',0,'[{"Id":"9ae3255d-261f-472f-a961-7f2e7d05d95c","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"8dd731ee-197f-40a8-a5e1-845662b0c0cd","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"00000000-0000-0000-0000-000000000000","Name":"123","Description":"123","Type":1,"Number":123}]','2023-01-17 23:30:00','2023-01-19 00:31:00',0);
INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('de6a6b04-aed0-44f7-8f68-3be107b79ff9',0,'[{"Id":"fda46699-49a4-49c8-83a0-9efb86db9079","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"a460539e-cf02-4691-a09e-f132ed9939ec","Name":null,"Description":null,"Type":0,"Number":0}]',NULL,NULL,0);
INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('e5cec894-c48c-48f7-8abb-ed14403b9af8',1,'[{"Id":"01ae9144-0414-4839-93a7-f11a70c8f9bb","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room1","Description":"123","Type":1,"Number":123},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room2","Description":"123","Type":1,"Number":123}]','2023-01-12 23:00:00','2023-01-13 23:00:00',0);
INSERT INTO Public."RenovationSessionAggregateRoots"("Id","TypeOfRenovation","RoomRenovationPlans","Start","End","Version") VALUES ('f6231984-1baa-42c3-9d12-3863cc7099d2',0,'[{"Id":"a2c565f7-d61e-4302-a417-1ed48919bb8f","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"3bf58a45-d903-4148-8b7b-3fb0018bda83","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room1","Description":"123","Type":1,"Number":123}]','2023-01-19 00:00:00','2023-01-20 01:01:00',0);

INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('03ba76b9-86a2-4551-8f8a-bd3df3b73de1','ReturnedToTimeframeCreation',NULL,NULL,NULL,NULL,NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:36.233058');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('0885ff5b-a881-45d2-baae-69883f60b02d','ReturnedToTimeframeCreation',NULL,NULL,NULL,NULL,NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:34.244343');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('0feeac02-7da3-4d28-81b2-2ce4edde80d6','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,1,'b352cd9c-a1ea-4dda-a88d-8714a71ad607','2023-01-12 02:01:24.367879');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('115e2da9-1564-44dc-b465-b053d82acad8','OldRoomsChosen',NULL,'[{"Id":"a2c565f7-d61e-4302-a417-1ed48919bb8f","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"3bf58a45-d903-4148-8b7b-3fb0018bda83","Name":null,"Description":null,"Type":0,"Number":0}]',NULL,NULL,NULL,NULL,0,'f6231984-1baa-42c3-9d12-3863cc7099d2','2023-01-12 02:02:29.124622');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('1632939a-26f5-4ece-a435-8014c31be236','ReturnedToSpecificTimeSelection',NULL,NULL,NULL,NULL,NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:43.162486');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('1d11b47b-5d0a-4e75-8fc7-8ff78209ca0e','SpecificTimeChosen',NULL,NULL,'2023-01-17 23:30:00','2023-01-19 00:31:00',NULL,NULL,0,'d2619d7c-9779-4c7e-9ef9-6e0486dc7e81','2023-01-12 02:09:28.69223');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('1d480dab-068d-4dfd-9582-225d35b014ec','OldRoomsChosen',NULL,'[{"Id":"9ae3255d-261f-472f-a961-7f2e7d05d95c","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"8dd731ee-197f-40a8-a5e1-845662b0c0cd","Name":null,"Description":null,"Type":0,"Number":0}]',NULL,NULL,NULL,NULL,0,'10151c79-4419-4d5e-8009-ed70ab887601','2023-01-10 15:47:40.217898');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('1fb888c2-5394-4bfe-b989-974996ca344a','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,0,'de6a6b04-aed0-44f7-8f68-3be107b79ff9','2023-01-11 19:25:07.49994');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('219c6303-665f-4b47-990a-06da192b32ae','ReturnedToTypeSelection',NULL,NULL,NULL,NULL,NULL,NULL,0,'37e5221a-6c29-4f0b-9a2d-1230ae443ec9','2023-01-12 02:09:09.131493');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('24978c03-6583-4b38-9930-109e16c2ae2e','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,0,'d2619d7c-9779-4c7e-9ef9-6e0486dc7e81','2023-01-12 02:09:10.492879');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('2502e207-b6cd-485a-a2f0-450a2c03b90c','OldRoomsChosen',NULL,'[{"Id":"d2c2c548-5590-436b-9463-3ba7b82ed690","Name":null,"Description":null,"Type":0,"Number":0}]',NULL,NULL,NULL,NULL,0,'b352cd9c-a1ea-4dda-a88d-8714a71ad607','2023-01-12 02:01:32.31058');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('2b688291-2133-4e12-b1c1-78ca536edf29','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,0,'266edcd7-ee86-4fa2-a17e-d14822a7a1dc','2023-01-12 02:01:55.84631');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('2b943fa5-b257-4389-ae1c-34694c33afc1','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'f6231984-1baa-42c3-9d12-3863cc7099d2','2023-01-12 02:02:09.814784');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('2c95c93b-3ee8-4637-ae16-59e55fea2cb5','TimeframeCreated',NULL,NULL,NULL,NULL,'2023-01-19 23:00:00','2023-01-21 00:01:00',0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:37.236664');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('2f843ebe-a893-4176-b04f-2d989a17683c','SessionEnded',NULL,NULL,NULL,NULL,NULL,NULL,0,'10151c79-4419-4d5e-8009-ed70ab887601','2023-01-10 15:48:18.038165');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('354687a0-2f02-4dfb-9f88-c279657342cf','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'b352cd9c-a1ea-4dda-a88d-8714a71ad607','2023-01-12 02:01:24.155376');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('38e356ae-ac06-48b5-a4da-b3ef384b8f1e','NewRoomsCreated','[{"Id":"00000000-0000-0000-0000-000000000000","Name":"room1","Description":"123","Type":1,"Number":123},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room2","Description":"123","Type":1,"Number":123}]',NULL,NULL,NULL,NULL,NULL,0,'e5cec894-c48c-48f7-8abb-ed14403b9af8','2023-01-10 18:18:27.365789');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('3ae3cead-cdba-4ed8-b75a-0ad227e812c0','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,0,'59034bf1-ec91-40dd-9280-2f54b0ec1ac9','2023-01-12 18:12:19.785558');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('47593c71-0109-41a5-b683-2d4ee3f7dd65','ReturnedToSpecificTimeSelection',NULL,NULL,NULL,NULL,NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:40.836072');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('4c73fadd-5239-44aa-921f-0c95d8d8a3a3','SpecificTimeChosen',NULL,NULL,'2023-01-19 00:00:00','2023-01-20 01:01:00',NULL,NULL,0,'f6231984-1baa-42c3-9d12-3863cc7099d2','2023-01-12 02:02:37.936386');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('4c7d9c77-9557-4dba-9373-a63a23ceab15','SpecificTimeChosen',NULL,NULL,'2023-01-19 23:30:00','2023-01-21 00:31:00',NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:41.899039');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('584d6912-4dfc-45da-a8f6-1433802254b8','SpecificTimeChosen',NULL,NULL,'2023-01-20 00:00:00','2023-02-01 01:01:00',NULL,NULL,0,'b352cd9c-a1ea-4dda-a88d-8714a71ad607','2023-01-12 02:01:47.6182');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('5a5d4f64-8353-4d9d-9887-a2c61559d05f','SessionEnded',NULL,NULL,NULL,NULL,NULL,NULL,0,'f6231984-1baa-42c3-9d12-3863cc7099d2','2023-01-12 02:02:47.433832');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('5b46dd04-d71f-465f-a27d-e93a598d2d23','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'10151c79-4419-4d5e-8009-ed70ab887601','2023-01-10 15:47:31.909247');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('5cf5dc29-227a-4abd-bb74-e1db605ed894','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'266edcd7-ee86-4fa2-a17e-d14822a7a1dc','2023-01-12 02:01:55.78984');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('5d68a3fc-7f31-4e52-8554-28a28a10f5ca','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'d2619d7c-9779-4c7e-9ef9-6e0486dc7e81','2023-01-12 02:09:10.397117');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('5f14dcfb-b666-4244-8211-da23ff0f1255','TimeframeCreated',NULL,NULL,NULL,NULL,'2023-01-17 23:00:00','2023-01-19 00:01:00',0,'d2619d7c-9779-4c7e-9ef9-6e0486dc7e81','2023-01-12 02:09:26.598633');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('65a837fa-1677-4ff9-8207-0ca8aee1107b','NewRoomsCreated','[{"Id":"00000000-0000-0000-0000-000000000000","Name":"123","Description":"123","Type":1,"Number":123},{"Id":"00000000-0000-0000-0000-000000000000","Name":"123","Description":"123","Type":1,"Number":123}]',NULL,NULL,NULL,NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:51.132328');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('65d56b44-6a59-4ee4-ad28-8c6a9775e4de','SpecificTimeChosen',NULL,NULL,'2023-01-12 23:00:00','2023-01-13 23:00:00',NULL,NULL,0,'e5cec894-c48c-48f7-8abb-ed14403b9af8','2023-01-10 18:18:18.765552');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('663efcba-cc9e-4e1f-b03b-2dc5f692eddb','SessionEnded',NULL,NULL,NULL,NULL,NULL,NULL,0,'e5cec894-c48c-48f7-8abb-ed14403b9af8','2023-01-10 18:18:28.964265');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('6e436751-b688-4f17-913a-521cbc3c7202','SpecificTimeChosen',NULL,NULL,'2023-01-19 23:30:00','2023-01-21 00:31:00',NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:39.888947');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('72a560da-d98b-41ae-b072-f71a96c12250','NewRoomsCreated','[{"Id":"00000000-0000-0000-0000-000000000000","Name":"room","Description":"123","Type":1,"Number":123}]',NULL,NULL,NULL,NULL,NULL,0,'10151c79-4419-4d5e-8009-ed70ab887601','2023-01-10 15:48:16.793174');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('72cb7cd6-8bb3-4329-bc7f-78c3d9da4f64','OldRoomsChosen',NULL,'[{"Id":"fda46699-49a4-49c8-83a0-9efb86db9079","Name":null,"Description":null,"Type":0,"Number":0}]',NULL,NULL,NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:26.070847');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('7a455fcd-f57e-4b34-8b4f-2be052e1c3cd','ReturnedToNewRoomCreation',NULL,NULL,NULL,NULL,NULL,NULL,0,'d2619d7c-9779-4c7e-9ef9-6e0486dc7e81','2023-01-12 02:13:52.182416');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('7a76f39f-108a-4865-b398-348b01e7ed6b','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:21.840324');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('7bb74b81-bf3c-42ef-b469-772ea82ce0b6','SpecificTimeChosen',NULL,NULL,'2023-01-12 23:00:00','2023-01-13 23:00:00',NULL,NULL,0,'10151c79-4419-4d5e-8009-ed70ab887601','2023-01-10 15:48:11.171745');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('7c66f75f-a569-4b45-8676-089621b79d12','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'59034bf1-ec91-40dd-9280-2f54b0ec1ac9','2023-01-12 18:12:19.17024');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('82a9c315-b4ae-46ba-b48e-762d70b49cff','TimeframeCreated',NULL,NULL,NULL,NULL,'2023-01-18 23:00:00','2023-01-20 00:01:00',0,'f6231984-1baa-42c3-9d12-3863cc7099d2','2023-01-12 02:02:34.985792');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('836d697a-3df9-4f33-ad01-b2aa71982392','ReturnedToOldRoomsSelection',NULL,NULL,NULL,NULL,NULL,NULL,0,'59034bf1-ec91-40dd-9280-2f54b0ec1ac9','2023-01-12 18:12:33.036302');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('864b882b-7ff3-4258-90aa-af5eca044efa','OldRoomsChosen',NULL,'[{"Id":"c2f3642d-a99d-4053-ba6b-f4397061d5ed","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"f348f2dc-8b61-49f6-b3c3-7bcec4db60de","Name":null,"Description":null,"Type":0,"Number":0}]',NULL,NULL,NULL,NULL,0,'10151c79-4419-4d5e-8009-ed70ab887601','2023-01-10 15:47:48.288947');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('8962bfc9-428c-4923-a427-dec9dd6c767d','NewRoomsCreated','[{"Id":"00000000-0000-0000-0000-000000000000","Name":"123","Description":"123","Type":1,"Number":123}]',NULL,NULL,NULL,NULL,NULL,0,'d2619d7c-9779-4c7e-9ef9-6e0486dc7e81','2023-01-12 02:13:50.957029');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('90c9a394-b470-46bc-91eb-ccf2f86b6ace','OldRoomsChosen',NULL,'[{"Id":"fda46699-49a4-49c8-83a0-9efb86db9079","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"a460539e-cf02-4691-a09e-f132ed9939ec","Name":null,"Description":null,"Type":0,"Number":0}]',NULL,NULL,NULL,NULL,0,'de6a6b04-aed0-44f7-8f68-3be107b79ff9','2023-01-11 19:25:16.348347');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('92f24a46-65f2-45d5-850b-3b4a5890e34c','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,1,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:21.885333');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('98fdff53-0d90-46b6-8887-dfcf6120aae4','SpecificTimeChosen',NULL,NULL,'2023-01-19 23:30:00','2023-01-21 00:31:00',NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:45.879584');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('9aab3256-4c6c-471b-95d2-9767eee222cc','ReturnedToOldRoomsSelection',NULL,NULL,NULL,NULL,NULL,NULL,0,'10151c79-4419-4d5e-8009-ed70ab887601','2023-01-10 15:47:41.962255');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('9e2ea8db-fa8a-4f42-a8d6-d2b37956a7ac','OldRoomsChosen',NULL,'[{"Id":"9ae3255d-261f-472f-a961-7f2e7d05d95c","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"8dd731ee-197f-40a8-a5e1-845662b0c0cd","Name":null,"Description":null,"Type":0,"Number":0}]',NULL,NULL,NULL,NULL,0,'d2619d7c-9779-4c7e-9ef9-6e0486dc7e81','2023-01-12 02:09:21.330158');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('a5793700-02e6-4a2e-82f7-0a06a7c01d34','TimeframeCreated',NULL,NULL,NULL,NULL,'2023-01-19 23:00:00','2023-01-21 00:01:00',0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:33.19428');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('adc1233c-b184-4c4e-ad4c-020d29021acd','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'87ecc6e9-47e3-4719-abc2-8ee90a482e76','2023-01-12 02:02:01.088083');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('b0f9adec-f6a2-42a5-b260-4a28dc78c4fa','TimeframeCreated',NULL,NULL,NULL,NULL,'2023-01-19 23:00:00','2023-02-01 00:01:00',0,'b352cd9c-a1ea-4dda-a88d-8714a71ad607','2023-01-12 02:01:43.684917');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('b774ea3f-3900-4944-8ee8-01d778b5bb9b','ReturnedToSpecificTimeSelection',NULL,NULL,NULL,NULL,NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:44.903621');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('ba2b4290-f5a2-4d10-a031-dedcb4708d89','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,0,'37e5221a-6c29-4f0b-9a2d-1230ae443ec9','2023-01-12 02:09:07.63895');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('baa0af32-403e-4029-a793-a17dc3869fa8','OldRoomsChosen',NULL,'[{"Id":"a2c565f7-d61e-4302-a417-1ed48919bb8f","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"3bf58a45-d903-4148-8b7b-3fb0018bda83","Name":null,"Description":null,"Type":0,"Number":0}]',NULL,NULL,NULL,NULL,0,'59034bf1-ec91-40dd-9280-2f54b0ec1ac9','2023-01-12 18:12:28.673962');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('bac3ba9f-75df-4303-852b-8c58d0d8e6fd','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'de6a6b04-aed0-44f7-8f68-3be107b79ff9','2023-01-11 19:25:07.211762');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('bc5a9357-f175-4343-9f00-3503fedc407d','TimeframeCreated',NULL,NULL,NULL,NULL,'2023-01-12 23:00:00','2023-01-13 23:00:00',0,'10151c79-4419-4d5e-8009-ed70ab887601','2023-01-10 15:48:00.572763');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('bcd81633-376b-4313-b15e-32a39d1d5a2f','TimeframeCreated',NULL,NULL,NULL,NULL,'2023-01-12 23:00:00','2023-01-13 23:00:00',0,'e5cec894-c48c-48f7-8abb-ed14403b9af8','2023-01-10 18:18:15.265417');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('c28632f9-63d8-4c11-89a5-0db9fecc5147','OldRoomsChosen',NULL,'[{"Id":"01ae9144-0414-4839-93a7-f11a70c8f9bb","Name":null,"Description":null,"Type":0,"Number":0}]',NULL,NULL,NULL,NULL,0,'e5cec894-c48c-48f7-8abb-ed14403b9af8','2023-01-10 18:18:07.433081');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('c3f95e73-516c-49da-90e4-d326ddf43ca8','NewRoomsCreated','[{"Id":"00000000-0000-0000-0000-000000000000","Name":"room1","Description":"123","Type":1,"Number":123}]',NULL,NULL,NULL,NULL,NULL,0,'f6231984-1baa-42c3-9d12-3863cc7099d2','2023-01-12 02:02:46.213274');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('c7f97e4c-d52c-486f-b9f4-edc7e0a56e3d','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'e5cec894-c48c-48f7-8abb-ed14403b9af8','2023-01-10 18:17:57.928391');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('ccb0e54c-b1e1-4418-9a48-07e8098b7469','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,0,'f6231984-1baa-42c3-9d12-3863cc7099d2','2023-01-12 02:02:09.864476');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('cef365b1-6a7f-4a04-86ea-8404e7aafb14','TimeframeCreated',NULL,NULL,NULL,NULL,'2023-01-19 23:00:00','2023-01-21 00:01:00',0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:35.308335');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('d7a9f09f-de75-45cd-a7c3-11e841794741','SpecificTimeChosen',NULL,NULL,'2023-01-19 23:30:00','2023-01-21 00:31:00',NULL,NULL,0,'7f47a353-1b30-41a6-ae31-9ea2c63b502b','2023-01-12 02:03:44.050104');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('df0a3b41-78a7-42b4-968f-81521c750273','ReturnedToTypeSelection',NULL,NULL,NULL,NULL,NULL,NULL,0,'59034bf1-ec91-40dd-9280-2f54b0ec1ac9','2023-01-12 18:12:36.563034');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('e5867b1d-84d1-4a7e-b51e-14353de3b2c3','ReturnedToNewRoomCreation',NULL,NULL,NULL,NULL,NULL,NULL,0,'d2619d7c-9779-4c7e-9ef9-6e0486dc7e81','2023-01-12 02:13:47.096798');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('ecea9307-40d9-4dc2-8aa2-cebfec2910e9','ReturnedToTypeSelection',NULL,NULL,NULL,NULL,NULL,NULL,0,'266edcd7-ee86-4fa2-a17e-d14822a7a1dc','2023-01-12 02:01:56.778381');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('f0b982d8-aa6a-4107-8802-7fce0988de73','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,1,'e5cec894-c48c-48f7-8abb-ed14403b9af8','2023-01-10 18:17:58.197576');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('f23acf93-e480-47a9-9791-161468bc606d','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,0,'10151c79-4419-4d5e-8009-ed70ab887601','2023-01-10 15:47:32.099296');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('f5e13b44-bddf-4b7e-983c-6ae317b41838','NewRoomsCreated','[{"Id":"00000000-0000-0000-0000-000000000000","Name":"123","Description":"123","Type":1,"Number":123}]',NULL,NULL,NULL,NULL,NULL,0,'d2619d7c-9779-4c7e-9ef9-6e0486dc7e81','2023-01-12 02:13:59.651564');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('fd6a6905-6b5a-48a6-a610-76ee1d3d9399','TypeChosen',NULL,NULL,NULL,NULL,NULL,NULL,1,'87ecc6e9-47e3-4719-abc2-8ee90a482e76','2023-01-12 02:02:01.134828');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('fd7d2033-ebf7-4918-b8f6-759bd1a4091e','NewRoomsCreated','[{"Id":"00000000-0000-0000-0000-000000000000","Name":"123","Description":"123","Type":1,"Number":123}]',NULL,NULL,NULL,NULL,NULL,0,'d2619d7c-9779-4c7e-9ef9-6e0486dc7e81','2023-01-12 02:09:33.744746');
INSERT INTO Public."RenovationSessionEvents"("Id","Discriminator","NewRoomsCreated_RoomRenovationPlans","RoomRenovationPlans","Start","End","TimeframeCreated_Start","TimeframeCreated_End","TypeOfRenovationChosen","AggregateId","OccurrenceTime") VALUES ('ff9bfd42-e98d-48f9-9843-db5a2303a059','SessionStarted',NULL,NULL,NULL,NULL,NULL,NULL,0,'37e5221a-6c29-4f0b-9a2d-1230ae443ec9','2023-01-12 02:09:07.376063');

INSERT INTO Public."EquipmentToMoves"("Id","EquipmentId","Amount") VALUES ('0c683ed3-ea47-46c2-88ae-a257c7b9fc34','497f7913-2139-4091-9a4c-0091d3b76216',3);
INSERT INTO Public."EquipmentToMoves"("Id","EquipmentId","Amount") VALUES ('1f0821a6-adad-4c5f-aad0-6543863c50b1','a00e71fd-7d8f-427e-afb7-ff1b45749fd8',2);
INSERT INTO Public."EquipmentToMoves"("Id","EquipmentId","Amount") VALUES ('26d8ded0-f7bd-4da7-be46-7f41bd85cc16','2d6e94c6-775a-499f-861f-c432439bc7ff',2);
INSERT INTO Public."EquipmentToMoves"("Id","EquipmentId","Amount") VALUES ('6bacf315-f405-4b59-ba72-20fd06f68800','497f7913-2139-4091-9a4c-0091d3b76216',2);
INSERT INTO Public."EquipmentToMoves"("Id","EquipmentId","Amount") VALUES ('9427486b-7639-4cbe-ae2e-fb4d3635ecf0','497f7913-2139-4091-9a4c-0091d3b76216',2);
INSERT INTO Public."EquipmentToMoves"("Id","EquipmentId","Amount") VALUES ('96f4effe-49a2-4751-a8dc-605a9001eb7f','2d6e94c6-775a-499f-861f-c432439bc7ff',2);
INSERT INTO Public."EquipmentToMoves"("Id","EquipmentId","Amount") VALUES ('a4a3bfd3-feb5-4250-bcc5-83343726a286','497f7913-2139-4091-9a4c-0091d3b76216',3);
INSERT INTO Public."EquipmentToMoves"("Id","EquipmentId","Amount") VALUES ('daadaac8-e543-4074-9652-7e84e54e4694','a00e71fd-7d8f-427e-afb7-ff1b45749fd8',2);
INSERT INTO Public."EquipmentToMoves"("Id","EquipmentId","Amount") VALUES ('e36a880d-8f02-43a3-ae6f-d57113f6b65e','2d6e94c6-775a-499f-861f-c432439bc7ff',3);
INSERT INTO Public."EquipmentToMoves"("Id","EquipmentId","Amount") VALUES ('e5e07046-a3f9-4005-9b31-0d045897eced','2d6e94c6-775a-499f-861f-c432439bc7ff',3);

-- Vise ne puca, pa sam privremeno otkomentarisao, Relocation appointments

INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('500be7f7-2105-458f-96e5-a06074a2257c','2023-01-25 13:15:00','2023-01-25 13:30:00','dde5590b-1bea-489e-a503-302a9b9fc0ca','MoveEquipmentAppointment','False',NULL,NULL,NULL,NULL,'1f0821a6-adad-4c5f-aad0-6543863c50b1',0,NULL,NULL);
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('51c5a18e-9e68-4251-abfd-eb8805a109a7','2023-01-25 09:00:00','2023-01-25 09:15:00','6b046e88-546c-4071-9431-24511e1e2d28','MoveEquipmentAppointment','False',NULL,NULL,NULL,NULL,'0c683ed3-ea47-46c2-88ae-a257c7b9fc34',1,NULL,NULL);
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('59dd3fa9-738a-4ffa-841f-fc0af3bf6137','2023-01-30 15:00:00','2023-01-30 15:15:00','66b63e58-17a2-4a4a-9fa4-b5a26afd0fc6','MoveEquipmentAppointment','False',NULL,NULL,NULL,NULL,'26d8ded0-f7bd-4da7-be46-7f41bd85cc16',1,NULL,NULL);
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('7f4b4399-e37d-4735-a746-52772c866506','2023-01-25 09:00:00','2023-01-25 09:15:00','9ae3255d-261f-472f-a961-7f2e7d05d95c','MoveEquipmentAppointment','False',NULL,NULL,NULL,NULL,'a4a3bfd3-feb5-4250-bcc5-83343726a286',0,NULL,NULL);
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('85ae0b9d-ca58-42d8-b8a2-c2d315a644ed','2023-01-19 10:00:00','2023-01-19 10:15:00','a2c565f7-d61e-4302-a417-1ed48919bb8f','MoveEquipmentAppointment','False',NULL,NULL,NULL,NULL,'e5e07046-a3f9-4005-9b31-0d045897eced',1,NULL,NULL);
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('aa1076c4-ae1d-4cd3-80db-a085eb3245fe','2023-01-30 15:00:00','2023-01-30 15:15:00','54c6de76-bc71-4615-8c73-4ebf9546444f','MoveEquipmentAppointment','False',NULL,NULL,NULL,NULL,'96f4effe-49a2-4751-a8dc-605a9001eb7f',0,NULL,NULL);
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('ad9cdfea-1e3b-4c44-8edc-694f506c2461','2023-01-29 18:30:00','2023-01-29 18:45:00','be5d6557-f0fa-42fb-bff0-823923d6dfd9','MoveEquipmentAppointment','False',NULL,NULL,NULL,NULL,'9427486b-7639-4cbe-ae2e-fb4d3635ecf0',0,NULL,NULL);
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('d2bb655e-4410-4bbe-8c10-74875b3072bc','2023-01-19 10:00:00','2023-01-19 10:15:00','bfd7238a-1157-47fd-97d4-ed61a3acc03b','MoveEquipmentAppointment','False',NULL,NULL,NULL,NULL,'e36a880d-8f02-43a3-ae6f-d57113f6b65e',0,NULL,NULL);
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('da8459a5-88e6-4529-84f4-085ce275e496','2023-01-25 13:15:00','2023-01-25 13:30:00','8dd731ee-197f-40a8-a5e1-845662b0c0cd','MoveEquipmentAppointment','False',NULL,NULL,NULL,NULL,'daadaac8-e543-4074-9652-7e84e54e4694',1,NULL,NULL);
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('f45ef1d5-15b7-4a9a-937a-e628b40a46bb','2023-01-29 18:30:00','2023-01-29 18:45:00','66b63e58-17a2-4a4a-9fa4-b5a26afd0fc6','MoveEquipmentAppointment','False',NULL,NULL,NULL,NULL,'6bacf315-f405-4b59-ba72-20fd06f68800',1,NULL,NULL);

-- Renovation appointments
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('4a236c8f-7a69-4c3c-8cff-b2b031403cb9','2023-01-19 00:00:00','2023-01-20 01:01:00','a2c565f7-d61e-4302-a417-1ed48919bb8f','RenovationAppointment','False',NULL,NULL,NULL,NULL,NULL,NULL,0,'[{"Id":"a2c565f7-d61e-4302-a417-1ed48919bb8f","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"3bf58a45-d903-4148-8b7b-3fb0018bda83","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room1","Description":"123","Type":1,"Number":123}]');
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('4fac6399-1d97-4c22-97dc-aa5d58063f5a','2023-01-12 23:00:00','2023-01-13 23:00:00',NULL,'RenovationAppointment','True',NULL,NULL,NULL,NULL,NULL,NULL,1,'[{"Id":"01ae9144-0414-4839-93a7-f11a70c8f9bb","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room1","Description":"123","Type":1,"Number":123},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room2","Description":"123","Type":1,"Number":123}]');
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('91fba77c-8466-4bca-893a-4e5fdc73daca','2023-01-12 23:00:00','2023-01-09 23:00:00',NULL,'RenovationAppointment','True',NULL,NULL,NULL,NULL,NULL,NULL,0,'[{"Id":"c2f3642d-a99d-4053-ba6b-f4397061d5ed","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"f348f2dc-8b61-49f6-b3c3-7bcec4db60de","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room","Description":"123","Type":1,"Number":123}]');
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('c2ba8b24-07c6-4383-b628-c2d9cde80868','2023-01-19 00:00:00','2023-01-20 01:01:00','3bf58a45-d903-4148-8b7b-3fb0018bda83','RenovationAppointment','False',NULL,NULL,NULL,NULL,NULL,NULL,0,'[{"Id":"a2c565f7-d61e-4302-a417-1ed48919bb8f","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"3bf58a45-d903-4148-8b7b-3fb0018bda83","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room1","Description":"123","Type":1,"Number":123}]');
INSERT INTO Public."Appointments"("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES ('cfa0fa5b-2d36-4766-9b90-f04675528837','2023-01-12 23:00:00','2023-01-09 23:00:00',NULL,'RenovationAppointment','True',NULL,NULL,NULL,NULL,NULL,NULL,0,'[{"Id":"c2f3642d-a99d-4053-ba6b-f4397061d5ed","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"f348f2dc-8b61-49f6-b3c3-7bcec4db60de","Name":null,"Description":null,"Type":0,"Number":0},{"Id":"00000000-0000-0000-0000-000000000000","Name":"room","Description":"123","Type":1,"Number":123}]');


-- Medical appointments
INSERT INTO public."Appointments" ("Id","StartTime","EndTime","RoomId","Discriminator","IsDone","DoctorId","PatientId","IsCanceled","Reason","EquipmentToMoveId","Type","RenovationAppointment_Type","RoomRenovationPlans") VALUES
	 ('9db40539-a39d-4831-b01b-4187ddd40987','2023-02-02 11:00:00','2023-02-02 11:30:00','fda46699-49a4-49c8-83a0-9efb86db9079','MedicalAppointment',false,'3cc3c6a7-0849-4c6e-90b9-ea18641b3af7','79978326-f136-4cec-813b-6b12c962752b',false,NULL,NULL,NULL,NULL,NULL),
	 ('9ac93783-c6f9-4866-9ca4-697feb2851ee','2023-02-15 18:00:00','2023-02-15 18:30:00','537f4833-bd4b-45be-92a0-d82f29e7c352','MedicalAppointment',false,'8c3c8455-574b-44c2-a5b5-2554bd5e669f','79978326-f136-4cec-813b-6b12c962752b',false,NULL,NULL,NULL,NULL,NULL),
	 ('9e95aaf0-8d5e-41d9-895d-5353c81887b1','2023-04-12 10:30:00','2023-04-12 11:00:00','0a675efc-9118-47e7-8701-392b2fce8f24','MedicalAppointment',false,'9f35094e-339a-4e57-85f4-9cb8e48108b9','79978326-f136-4cec-813b-6b12c962752b',false,NULL,NULL,NULL,NULL,NULL),
	 ('f1f98760-26e8-46db-aca7-070edb293a45','2023-03-31 10:30:00','2023-03-31 11:00:00','3c8bb35e-cc74-46db-8c3e-fe757b0643e7','MedicalAppointment',false,'46214694-a5cd-4472-be02-0912a8b807f7','79978326-f136-4cec-813b-6b12c962752b',true,NULL,NULL,NULL,NULL,NULL),
	 ('63ddcb6d-faa6-4089-ae4c-9a4eafa1fb29','2023-01-27 08:00:00','2023-01-27 08:30:00','bfd7238a-1157-47fd-97d4-ed61a3acc03b','MedicalAppointment',false,'da40fbc6-f341-4126-9e04-4e891cd75ec0','79978326-f136-4cec-813b-6b12c962752b',true,NULL,NULL,NULL,NULL,NULL),
	 ('6b3cb57c-357c-4f4c-b4b3-830fdee78615','2023-02-06 07:00:00','2023-02-06 07:30:00','ca404f3e-a95d-44f5-9fab-42719dbcdd21','MedicalAppointment',false,'f19b7905-9bb7-4d07-abf6-7b9d4e782714','79978326-f136-4cec-813b-6b12c962752b',true,NULL,NULL,NULL,NULL,NULL),
	 ('eb71b54b-7eef-4e23-b2c2-4db336244893','2023-01-05 10:30:00','2023-01-05 11:00:00','9ae3255d-261f-472f-a961-7f2e7d05d95c','MedicalAppointment',false,'631732d1-2be0-481f-b104-604efb32014d','79978326-f136-4cec-813b-6b12c962752b',false,NULL,NULL,NULL,NULL,NULL),
	 ('afc6da3c-91bc-400c-8853-45abe2d169d5','2023-01-11 13:30:00','2023-01-11 14:00:00','133962ea-c543-497b-81a6-6a2efb54212a','MedicalAppointment',false,'13936c4b-03ef-4b43-8c37-b928a5ee9d38','79978326-f136-4cec-813b-6b12c962752b',false,NULL,NULL,NULL,NULL,NULL),
	 ('f349d7d2-3baf-423c-8937-d3c30c11fae3','2022-01-16 16:00:00','2022-01-16 16:30:00','620472d5-85b1-4f2d-aafc-3c9d9a59904f','MedicalAppointment',true,'631732d1-2be0-481f-b104-604efb32014d','22fc8a6a-609a-4177-be8b-cecb48640c88',false,NULL,NULL,NULL,NULL,NULL),
	 ('f349d7d2-3baf-423c-8937-d3c30c0efae3','2023-01-16 16:00:00','2023-01-16 16:30:00','620472d5-85b1-4f2d-aafc-3c9d9a59904f','MedicalAppointment',false,'20770be2-7a1f-4656-8d9c-4c615ab27b5c','79978326-f136-4cec-813b-6b12c962752b',false,NULL,NULL,NULL,NULL,NULL);


INSERT INTO public."Symptoms" ("Id","Name") VALUES
	('02776ef1-45e9-4bf1-b6ce-58e2be21b865','Temperature'),
	('e03dfbcc-c934-4e3b-a4a6-a0255d7898aa','Sore throat'),
	('bf63dbb1-cce0-4b30-807b-2ba7e51d70b4','Headache'),
	('f5575217-44a8-45ad-9a39-ef78f22ece79','Toothache'),
	('b7ca7cde-58fc-4971-9e39-0f6ceaafbd5e','Stomachache'),
	('3df0969c-c43c-4315-a1ea-2a2960212eb4','Ill'),
	('d497d3db-93d0-421a-8ece-ea8631772cba','Broken bone'),
	('3d1ffa79-6ef9-4460-aafe-c51a8e56728b','Fever');

INSERT INTO public."Medicines" ("Id","Name") VALUES
	('d5796196-18b7-4e65-94d8-0094733ddb10','Aspirin'),
	('909d551d-88ad-4496-bfe1-361c85fc2166','Brufen'),
	('227a40a4-609f-4b80-b89c-b0760591794a','Aspirin'),
	('839c1918-7e27-42a0-87da-f0185beb2b7a','Brufen'),
	('be83b11e-0cb2-4338-8029-e7580d5d1a1b','Panadol'),
	('a0d369ff-61b5-4d64-b934-5138737c2500','Linex'),
	('524b99a6-3d14-44ab-a9e4-29c1fa6d29c0','Corex'),
	('9028f723-b735-453e-9ea7-92ae228a28cf','Bleturs');

INSERT INTO public."Reports" ("Id","MedicalAppointmentId","Text","DateTime","Prescriptions","Symptoms") VALUES
	 ('f95e12b5-7352-40f7-82f0-05b02d593743','eb71b54b-7eef-4e23-b2c2-4db336244893','Exam Findings: Blood pressure: 140/85 mmHg, Heart rate: 78 bpm, Weight: 190 lbs, Height: 6''0"

Assessment: The patient''s vital signs are elevated, indicating a potential risk for hypertension and heart disease. 

Recommendations: The patient is advised to make lifestyle changes, including diet and exercise, and follow a healthy lifestyle.','2023-01-17 00:00:00','[{"Medicines": [{"Id": "d5796196-18b7-4e65-94d8-0094733ddb10", "Name": "Aspirin"}]}]','[{"Id": "bf63dbb1-cce0-4b30-807b-2ba7e51d70b4", "Name": "Headache"}]'),
	 ('d6c3fa87-bd58-4727-bc78-ca360e3ea5e5','afc6da3c-91bc-400c-8853-45abe2d169d5','Exam Findings: Blood pressure: 140/85 mmHg, Heart rate: 78 bpm, Weight: 190 lbs, Height: 6''0", Electrocardiogram (ECG) showed signs of left ventricular hypertrophy.

Assessment: The patient''s vital signs are elevated and ECG results indicate potential cardiac issues.

Recommendations: The patient is advised to undergo further cardiac testing, such as an echocardiogram or stress test, to determine the extent of the cardiac involvement. ','2023-01-17 00:00:00','[{"Medicines": [{"Id": "524b99a6-3d14-44ab-a9e4-29c1fa6d29c0", "Name": "Corex"}]}]','[{"Id": "bf63dbb1-cce0-4b30-807b-2ba7e51d70b4", "Name": "Headache"}]'),
	 ('e128e154-f6d1-4eed-b708-ded2ce63666e','f349d7d2-3baf-423c-8937-d3c30c0efae3','Exam Findings: Blood pressure: 140/85 mmHg, Heart rate: 78 bpm, Weight: 190 lbs, Height: 6''0", Neurological examination revealed no abnormalities, patient reported experiencing seizures.

Assessment: The patient appears to have epilepsy, the cause of which needs to be determined through further testing. 

Recommendations: The patient is advised to undergo an EEG (electroencephalogram) to confirm the diagnosis and to determine the type of epilepsy.
','2023-01-17 00:00:00','[{"Medicines": [{"Id": "9028f723-b735-453e-9ea7-92ae228a28cf", "Name": "Bleturs"}]}]','[{"Id": "b7ca7cde-58fc-4971-9e39-0f6ceaafbd5e", "Name": "Stomachache"}]');

insert into public."Beds" ("Id", "equipmentId", "IsFree") values ('c8da3993-1a84-46c0-97bd-187991b59999', 'c8da3993-1a84-46c0-97bd-187991b54b4a', true);
insert into public."Beds" ("Id", "equipmentId", "IsFree") values ('c8da3993-1a84-46c0-97bd-187991b59998', 'c8da3993-1a84-46c0-97bd-187991b54b4a', true);
insert into public."Beds" ("Id", "equipmentId", "IsFree") values ('c8da3993-1a84-46c0-97bd-187991b59997', 'c8da3993-1a84-46c0-97bd-187991b54b4a', true);
insert into public."Beds" ("Id", "equipmentId", "IsFree") values ('c8da3993-1a84-46c0-97bd-187991b59996', 'c8da3993-1a84-46c0-97bd-187991b54b4a', true);
insert into public."Beds" ("Id", "equipmentId", "IsFree") values ('c8da3993-1a84-46c0-97bd-187991b59995', 'c8da3993-1a84-46c0-97bd-187991b54b4a', true);
insert into public."Beds" ("Id", "equipmentId", "IsFree") values ('c8da3993-1a84-46c0-97bd-187991b59994', 'c8da3993-1a84-46c0-97bd-187991b54b4a', true);
insert into public."Beds" ("Id", "equipmentId", "IsFree") values ('c8da3993-1a84-46c0-97bd-187991b59993', 'c8da3993-1a84-46c0-97bd-187991b54b4a', true);
insert into public."Beds" ("Id", "equipmentId", "IsFree") values ('c8da3993-1a84-46c0-97bd-187991b59992', 'c8da3993-1a84-46c0-97bd-187991b54b4a', true);

INSERT INTO "Rooms" ("Id", "Description","Name", "Number", "Discriminator", "FloorId", "Workhours", "BedIds") values
('497f7913-2139-4091-9a4c-0091d3b76101', 'This is a patient room'      , 'NEW R009', '009', 'PatientRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24', '{c8da3993-1a84-46c0-97bd-187991b59999}'),
('497f7913-2139-4091-9a4c-0091d3b76102', 'This is a patient room'      , 'NEW R010', '010', 'PatientRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24', '{c8da3993-1a84-46c0-97bd-187991b59998}'),
('497f7913-2139-4091-9a4c-0091d3b76103', 'This is a patient room'      , 'NEW R011', '011', 'PatientRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24', '{c8da3993-1a84-46c0-97bd-187991b59997, c8da3993-1a84-46c0-97bd-187991b59996}'),
('497f7913-2139-4091-9a4c-0091d3b76104', 'This is a patient room'      , 'NEW R012', '012', 'PatientRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24', '{c8da3993-1a84-46c0-97bd-187991b59995, c8da3993-1a84-46c0-97bd-187991b59994}'),
('497f7913-2139-4091-9a4c-0091d3b76105', 'This is a patient room'      , 'NEW R013', '013', 'PatientRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24', '{c8da3993-1a84-46c0-97bd-187991b59993}'),
('497f7913-2139-4091-9a4c-0091d3b76106', 'This is a patient room'      , 'NEW R014', '014', 'PatientRoom', '1b7f1f98-8737-4c53-87e3-3399705be80d', '00-24', '{c8da3993-1a84-46c0-97bd-187991b59992}');