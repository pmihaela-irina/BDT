--TESTARE CONSTRANGERI TABELA CAMERE--
--numarul de studenti dintr-o camera sa nu fie in intervalul [1-4]
INSERT into camere (nr_camera, nr_studenti, tarif, tip_camera, tip_baie, status, id_camin) 
VALUES('101',0,120,'Dubla','Comuna','Libera',(SELECT id_camin FROM camine WHERE nume_camin='T1'));

INSERT into camere (nr_camera, nr_studenti, tarif, tip_camera, tip_baie, status, id_camin) 
VALUES('101',5,120,'Dubla','Comuna','Libera',(SELECT id_camin FROM camine WHERE nume_camin='T1'));

--tariful aferent camerei sa nu fie unul dintre {0, 120, 130, 135, 150,200, 270}
INSERT into camere (nr_camera, nr_studenti, tarif, tip_camera, tip_baie, status, id_camin) 
VALUES('101',2,110,'Dubla','Comuna','Libera',(SELECT id_camin FROM camine WHERE nume_camin='T1'));

--camera exista deja in tabela
INSERT into camere (nr_camera, nr_studenti, tarif, tip_camera, tip_baie, status, id_camin) 
VALUES('101',3,120,'Tripla','Comuna','Libera',(SELECT id_camin FROM camine WHERE nume_camin='T1'));


--TESTARE CONSTRANGERI TABELA CAMINE--
--caminul exista deja in tabela
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere)
VALUES('T1',197,5,2,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Mihai Vencu'));

--TESTARE CONSTRANGERI TABELA CONDUCERE--
--numele prodecanului contine cifre
INSERT into conducere (nume_prodecan,nume_administrator,nume_presedinte) 
VALUES('Vasiliu Gabri8ela', 'Florea Mihai', 'Panaite Mihai');
--numele administratorului contine cifre
INSERT into conducere (nume_prodecan,nume_administrator,nume_presedinte) 
VALUES('Vasiliu Gabriela', 'Fl0rea Mihai', 'Panaite Mihai');
--nuemele presedintelui contine cifre
INSERT into conducere (nume_prodecan,nume_administrator,nume_presedinte) 
VALUES('Vasiliu Gabriela', 'Florea Mihai', 'Pana2te Mihai');
--numele presedintelui trebuie sa fie unic
INSERT into conducere (nume_prodecan,nume_administrator,nume_presedinte) 
VALUES('Vasiliu Gabriela', 'Florea Mihai', 'Marchidan Florin');

--TESTARE CONSTRANGERI TABELA DATE_STUDENTI--
--CNP sa fie unic (1|2|5|6)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])(0[1-9]|[1-4]\d|5[0-2]|99)\d{4}
INSERT into date_studenti 
VALUES(
	'2990322259634',
    'MX',
    '659894',
    'Iasi',
    (SELECT id_student FROM studenti where nume_student = 'Marinescu Florin')
    );
--numarul si seria CI sa fie unice (pot exista doua carti de identitate cu acelari numar insa seria trebuie sa difere)
--exemplu de functionalitate
INSERT into date_studenti 
VALUES(
	'6990322259634',
    'XT',
    '659894',
    'Botosani',
    (SELECT id_student FROM studenti where nume_student = 'Marinescu Florin')
    );
--va da eroare
INSERT into date_studenti 
VALUES(
	'6980514298797',
    'XT',
    '659894',
    'Botosani',
    (SELECT id_student FROM studenti where nume_student = 'Vasilescu Marina')
    );
    
--cnp-ul sa inceapa cu 1,2,5, sau 6
INSERT into date_studenti 
VALUES(
	'8980514338795',
    'VS',
    '659894',
    'Vaslui',
    (SELECT id_student FROM studenti where nume_student = 'Neculce David')
    );

--cnp-ul sa sa aiba in sintaxa sa o luna cuprinsa intre 01-12
INSERT into date_studenti 
VALUES(
	'6981514338795',
    'VS',
    '659894',
    'Vaslui',
    (SELECT id_student FROM studenti where nume_student = 'Neculce David')
    );
--cnp-ul sa aiba in sitaxa sa o zi cuprinsa intre 01-31
INSERT into date_studenti 
VALUES(
	'6980535338795',
    'VS',
    '659894',
    'Vaslui',
    (SELECT id_student FROM studenti where nume_student = 'Neculce David')
    );
--cnp-ul sa aiba in sitaxa codul pentru judet cuprinz intre 01-52
INSERT into date_studenti 
VALUES(
	'6980514728795',
    'VS',
    '659894',
    'Vaslui',
    (SELECT id_student FROM studenti where nume_student = 'Neculce David')
    );
    
--seria sa fie formata doar din 2 litere 
INSERT into date_studenti 
VALUES(
	'6980514338795',
    'V5',
    '659894',
    'Vaslui',
    (SELECT id_student FROM studenti where nume_student = 'Neculce David')
    );

INSERT into date_studenti 
VALUES(
	'6980514338795',
    'V',
    '659894',
    'Vaslui',
    (SELECT id_student FROM studenti where nume_student = 'Neculce David')
    );
    
--numarul sa fie format doar din 6 cifre
INSERT into date_studenti 
VALUES(
	'6980514338795',
    'VS',
    '6598949',
    'Vaslui',
    (SELECT id_student FROM studenti where nume_student = 'Neculce David')
    );
    
INSERT into date_studenti 
VALUES(
	'6980514338795',
    'V5',
    '6S9894',
    'Vaslui',
    (SELECT id_student FROM studenti where nume_student = 'Neculce David')
    );
    
--TESTARE CONSTRANGERI TABELA DOSARE--
--numarul de averismente sa fie in intervalul 0-3
INSERT into dosare (nr_avertismente, nr_referate, status, id_student)
VALUES(4,0,'Cazat',(SELECT id_student FROM studenti WHERE nume_student='Agudaru Ingrid'));
--numarul de referate sa fie in intervalul 0-3
INSERT into dosare (nr_avertismente, nr_referate, status, id_student)
VALUES(0,4,'Cazat',(SELECT id_student FROM studenti WHERE nume_student='Agudaru Ingrid'));
--statusul poate fi Cazat/Decazat
INSERT into dosare (nr_avertismente, nr_referate, status, id_student)
VALUES(0,0,'Necunoscut',(SELECT id_student FROM studenti WHERE nume_student='Agudaru Ingrid'));

--TESTARE CONSTRANGERI TABELA REGISTRE
--valorile pentru lunile anului trebuie sa fie 0/1
INSERT into registre (octombrie, noiembrie, decembrie, ianuarie, februarie, martie, aprilie, mai, iunie, iulie, id_student) 
VALUES(1,0,0,0,0,3,0,0,0,0,(SELECT id_student FROM studenti WHERE nume_student='Agudaru Ingrid'));

--TESTARE CONSTRANGERI TABELA STUDENTI--
--numele studentului sa fie format doar din litere
INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, data_decazare, id_camera) 
VALUES(
    'Marinescu Flor9n',
    'Facultatea de Design Industrial ?i Managementul Afacerilor',
	'II',
    '0775301729',
    'marinescuflor1n@gmail.com',
    'RO41RZBR0000060041414141',
    TO_DATE('20.12.2020', 'DD.MM.YYYY'),
    ADD_MONTHS(TO_DATE('20.12.2020','DD.MM.YYYY'),10), 
    (SELECT a.id_camera FROM camere a, camine b WHERE a.id_camin = b.id_camin AND a.nr_camera ='101' AND b.nume_camin='T1')  
    );
--facultatea sa faca parte doar din lista
INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, data_decazare, id_camera) 
VALUES(
    'Marinescu Florn',
    'AC',
	'II',
    '0775301729',
    'marinescuflor1n@gmail.com',
    'RO41RZBR0000060041414141',
    TO_DATE('20.12.2020', 'DD.MM.YYYY'),
    ADD_MONTHS(TO_DATE('20.12.2020','DD.MM.YYYY'),10), 
    (SELECT a.id_camera FROM camere a, camine b WHERE a.id_camin = b.id_camin AND a.nr_camera ='101' AND b.nume_camin='T1')  
    );
--anul de studeiu sa faca parte doar din lista
INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, data_decazare, id_camera) 
VALUES(
    'Marinescu Florin',
    'Facultatea de Design Industrial ?i Managementul Afacerilor',
	'Master III',
    '0775301729',
    'marinescuflor1n@gmail.com',
    'RO41RZBR0000060041414141',
    TO_DATE('20.12.2020', 'DD.MM.YYYY'),
    ADD_MONTHS(TO_DATE('20.12.2020','DD.MM.YYYY'),10), 
    (SELECT a.id_camera FROM camere a, camine b WHERE a.id_camin = b.id_camin AND a.nr_camera ='101' AND b.nume_camin='T1')  
    );
--numarul de telefon sa nu aiba prefixul 07/02/03
INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, data_decazare, id_camera) 
VALUES(
    'Marinescu Florin',
    'Facultatea de Design Industrial ?i Managementul Afacerilor',
	'Master II',
    '0588727714',
    'marinescuflor1n@gmail.com',
    'RO41RZBR0000060041414141',
    TO_DATE('20.12.2020', 'DD.MM.YYYY'),
    ADD_MONTHS(TO_DATE('20.12.2020','DD.MM.YYYY'),10), 
    (SELECT a.id_camera FROM camere a, camine b WHERE a.id_camin = b.id_camin AND a.nr_camera ='101' AND b.nume_camin='T1')  
    );
--numarul de telefon trebuie sa fie format din exact 10 cifre
INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, data_decazare, id_camera) 
VALUES(
    'Marinescu Florin',
    'Facultatea de Design Industrial ?i Managementul Afacerilor',
	'Master II',
    '02388727714', -- sau cu mai putine cifre '023827714'
    'marinescuflor1n@gmail.com',
    'RO41RZBR0000060041414141',
    TO_DATE('20.12.2020', 'DD.MM.YYYY'),
    ADD_MONTHS(TO_DATE('20.12.2020','DD.MM.YYYY'),10), 
    (SELECT a.id_camera FROM camere a, camine b WHERE a.id_camin = b.id_camin AND a.nr_camera ='101' AND b.nume_camin='T1')  
    );
    
--adresa de email nu este de forma x@y.z
INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, data_decazare, id_camera) 
VALUES(
    'Marinescu Florin',
    'Facultatea de Design Industrial ?i Managementul Afacerilor',
	'Master II',
    '0738727714', -- sau cu mai putine cifre '023827714'
    'marinescuflor1n@gmail.company', -- sau marinescuflor1n@gmail.c --sau marinescuflor1n@gmailcom
    'RO41RZBR0000060041414141',
    TO_DATE('20.12.2020', 'DD.MM.YYYY'),
    ADD_MONTHS(TO_DATE('20.12.2020','DD.MM.YYYY'),10), 
    (SELECT a.id_camera FROM camere a, camine b WHERE a.id_camin = b.id_camin AND a.nr_camera ='101' AND b.nume_camin='T1')  
    );
    
--data decazarii sa fie dupa data cazarii
INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, data_decazare, id_camera) 
VALUES(
    'Marinescu Florin Avram',
    'Facultatea de Design Industrial ?i Managementul Afacerilor',
	'Master III',
    '0775301719',
    'marinescuflor1navram@gmail.com',
    'RO41RZBR0000060041414141',
    TO_DATE('20.12.2020', 'DD.MM.YYYY'),
    ADD_MONTHS(TO_DATE('20.12.2010','DD.MM.YYYY'),10), 
    (SELECT a.id_camera FROM camere a, camine b WHERE a.id_camin = b.id_camin AND a.nr_camera ='101' AND b.nume_camin='T1')  
    );
--adresa de email sa fie unica
INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, data_decazare, id_camera) 
VALUES(
    'Marinescu Florin Avram',
    'Facultatea de Design Industrial ?i Managementul Afacerilor',
	'Master III',
    '0775301719',
    'marinescuflor1n@gmail.com',
    'RO41RZBR0000060041414141',
    TO_DATE('20.12.2020', 'DD.MM.YYYY'),
    ADD_MONTHS(TO_DATE('20.12.2020','DD.MM.YYYY'),10), 
    (SELECT a.id_camera FROM camere a, camine b WHERE a.id_camin = b.id_camin AND a.nr_camera ='101' AND b.nume_camin='T1')  
    );
--numaru de telefon sa fie unic
INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, data_decazare, id_camera) 
VALUES(
    'Marinescu Florin Avram',
    'Facultatea de Design Industrial ?i Managementul Afacerilor',
	'Master III',
    '0775301729',
    'marinescuflorinavram@gmail.com',
    'RO41RZBR0000060041414141',
    TO_DATE('20.12.2020', 'DD.MM.YYYY'),
    ADD_MONTHS(TO_DATE('20.12.2020','DD.MM.YYYY'),10), 
    (SELECT a.id_camera FROM camere a, camine b WHERE a.id_camin = b.id_camin AND a.nr_camera ='101' AND b.nume_camin='T1')  
    );
--data cazarii si data decazarii sa fie mai mare decat data curenta
INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, data_decazare, id_camera) 
VALUES(
    'Marinescu Florin Avram',
    'Facultatea de Design Industrial ?i Managementul Afacerilor',
	'Master III',
    '0775301719',
    'marinescuflor1n@gmail.com',
    'RO41RZBR0000060041414141',
    TO_DATE('10.12.2020', 'DD.MM.YYYY'),
    ADD_MONTHS(TO_DATE('20.12.2010','DD.MM.YYYY'),10), 
    (SELECT a.id_camera FROM camere a, camine b WHERE a.id_camin = b.id_camin AND a.nr_camera ='101' AND b.nume_camin='T1')  
    );
