delete from "Rooms";
delete from "Doctors";
delete from "Patients";
delete from "";
delete from "Addresses";
delete from "Appointments";
delete from "Floor";
delete from "Buildings";
delete from "Feedbacks";
INSERT INTO public."Addresses" ("Id","City","Country","Street","StreetNumber") VALUES
	 ('de3ebdd7-d0da-4646-9bd1-e04df2c562ad','Novi Sad','Serbia','Markova','1'),
	 ('be3135bf-47fb-454a-9e64-6af7a0fc838c','Novi Sad','Serbia','Radnicka','5'),
	 ('081a6c25-719c-4424-a032-6255ff98c28c','Sremska Kamenica','Serbia','Gavrila Principa','204');

INSERT INTO public."Patients" ("Id","Lbo","Blocked","Name","Surname","Birthdate","Gender","AddressId","Jmbg","Email","PhoneNumber") VALUES
	 ('0c75e30a-1b93-4eb1-b601-5a1422e86636','41234123414',false,'Marko','Markovic','2000-01-03 00:00:00',0,'de3ebdd7-d0da-4646-9bd1-e04df2c562ad','837198219312','marko@gmail.com','06412332111'),
	 ('5a365cb2-d52a-4dc4-96a5-d37af79da08c','123412341234',false,'Stefan','Stefanovic','1995-05-03 00:00:00',0,'be3135bf-47fb-454a-9e64-6af7a0fc838c','49371947194192','stefan@gmail.com','06315124125'),
	 ('5bdd96ec-9b9f-4c77-b74d-4425b8c65032','48923589092',false,'Milica','Mirandic','1988-08-11 17:02:05.107',1,'081a6c25-719c-4424-a032-6255ff98c28c','1108881028410','milica@gmail.com','06487610921');

INSERT INTO public."Feedbacks" ("Id","Text","IsAnonimous","IsDesiredPublic","Status","PatientId","Date") VALUES
	 ('da243b20-2d31-458f-ab28-66f2d6653149','Very good',true,true,2,'0c75e30a-1b93-4eb1-b601-5a1422e86636','2022-10-29 19:06:26.026728'),
	 ('d27eff98-5e81-420d-83a3-6175be4939b7','Could be better',false,false,1,'0c75e30a-1b93-4eb1-b601-5a1422e86636','2022-10-29 19:08:33.852363'),
	 ('3e75f50a-6cf1-4818-8f82-445c89c4e430','Excellent',false,true,0,'0c75e30a-1b93-4eb1-b601-5a1422e86636','2022-10-29 19:07:45.829214'),
	 ('aec658b3-bcd5-43db-8668-8361363923ef','Doctor Strahinja chopped my finger and laughed',true,false,0,'0c75e30a-1b93-4eb1-b601-5a1422e86636','2022-10-29 19:07:12.273741');

