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