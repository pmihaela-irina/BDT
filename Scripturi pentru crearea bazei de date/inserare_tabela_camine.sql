--inserare in tabela CAMINE
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T1',197,5,2,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Popescu Ghiorghita'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T2',197,5,2,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Prodan Maria'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T3',197,5,2,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Mihai Vencu'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T4',197,5,2,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Popa Sergiu'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T5',197,5,2,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Contofan Cosmin'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T6',197,5,2,'Nu',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Mesteru Marin'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T7',148,5,2,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Babei George'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T8',143,5,2,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Sendrea Mihai'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T9',110,5,4,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Mocanu Stefan'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T10',110,5,4,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Rosu Cosmin'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T11',100,5,4,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Tanasa Andrei'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T12',97,5,3,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Cazanoschi Andrei'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T13',95,5,3,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Breaban Sergiu'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T14',96,5,3,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Lozneanu Vlad'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T15',96,5,3,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Cozma Vlad'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T16',132,5,3,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Agrigoroaie Corina'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T17',274,8,4,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Grigoruta Claudiu'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T18',113,5,4,'Nu',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Bujoreanu Cosmin'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T19',110,5,4,'Nu',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Marchidan Florin'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T20',57,5,2,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Lazar Irina'));
INSERT into camine (nume_camin, nr_camere,nr_etaje, capacitate_camere, bucatarie, id_conducere) VALUES('T21',61,5,2,'Da',(SELECT id_conducere FROM conducere WHERE nume_presedinte ='Lacatus Teodora'));

commit work;