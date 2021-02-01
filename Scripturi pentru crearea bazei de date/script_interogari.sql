--afisare studentii a caror email incepe cu 'co'
SELECT nume_student FROM studenti
WHERE adresa_email like 'co%';

--afisare studentii de la Faculatea de Automatica si Calculatoare din caminul T2
SELECT s.id_student, s.nume_student, cam.nr_camera 
FROM studenti s 
JOIN camere cam ON s.id_camera = cam.id_camera
JOIN camine c ON cam.id_camin = c.id_camin
WHERE facultate = 'Facultatea de Automatic? ?i Calculatoare' and c.nume_camin = 'T2';

--afisare studenti cazati
SELECT s.id_student, s.nume_student, cam.nr_camera, c.id_camin
FROM studenti s 
JOIN camere cam ON s.id_camera = cam.id_camera 
JOIN camine c ON cam.id_camin = c.id_camin;

--afisare studentii cazati in caminul T9, ordonati dupa camere
SELECT s.id_student, s.nume_student, cam.nr_camera 
FROM studenti s 
JOIN camere cam ON s.id_camera = cam.id_camera 
JOIN camine c ON cam.id_camin = c.id_camin
WHERE c.nume_camin = 'T9' 
ORDER BY cam.nr_camera;

--afisare studenti cazati in caminul T6, camera 101
SELECT s.id_student, s.nume_student, cam.nr_camera 
FROM studenti s 
JOIN camere cam ON s.id_camera = cam.id_camera 
JOIN camine c ON cam.id_camin = c.id_camin
WHERE c.nume_camin = 'T1' AND cam.nr_camera='101';

--afisare studenti ce sunt anul I
SELECT id_student, nume_student
FROM studenti
WHERE an_studiu = 'I';

--afisare camere in care pot fi cazati doar 3 studenti
SELECT id_camera, nr_camera
FROM camere
WHERE nr_studenti = 3;

--afisare camere care sunt de tip Garsoniera si in care mai pot fi cazati studenti
SELECT id_camera, nr_camera, c.nume_camin
FROM camere cam
JOIN camine c ON cam.id_camin = c.id_camin
WHERE cam.tip_camera = 'Garsoniera' AND (status = 'Ocupata partial' OR status = 'Libera');

--afisare camere a caror baie este de tip Modul
SELECT id_camera, nr_camera, c.nume_camin
FROM camere cam
JOIN camine c ON cam.id_camin = c.id_camin
WHERE cam.tip_baie = 'Modul';

--afisare camere libere sunt in caminul T3
SELECT id_camera, nr_camera
FROM camere cam
JOIN camine c ON cam.id_camin = c.id_camin
WHERE cam.status = 'Libera' AND c.nume_camin='T3';

select * from camere;
--afisare camine care au ca administrator pe Istrate Anca
SELECT c.id_camin, c.nume_camin
FROM camine c
JOIN conducere co ON co.id_conducere = c.id_conducere
WHERE co.nume_administrator = 'Istrate Anca';

--afisare camine ce au o capacitate a camerelor de 4 persoane, ordonate dupa numarul de camere
SELECT nume_camin, nr_camere
FROM camine
WHERE capacitate_camere = 4 
ORDER BY nr_camere;

--afisare studenti ce au achitat tariful pentru luna decembrie
SELECT s.nume_student
FROM studenti s
JOIN registre r ON r.id_student = s.id_student
WHERE r.decembrie = 1;

--afisare cati studenti nu au achitat tariful pentru luna noiembrie
SELECT COUNT(id_student) FROM registre
where noiembrie = 0;

--afisare studentii cazati in caminul T10 ce nu au achitat una din lunile octombrie, noiembrie si decembrie, ordonati dupa camere
SELECT stud.nume_student, cam.nr_camera, r.octombrie, r.noiembrie, r.decembrie
FROM studenti stud
JOIN camere cam ON cam.id_camera = stud.id_camera
JOIN camine c ON c.id_camin = cam.id_camin
JOIN registre r ON r.id_student = stud.id_student
JOIN dosare d ON d.id_student = stud. id_student
WHERE d.status = 'Cazat' and c.nume_camin = 'T10' and (r.octombrie = 0 OR r.noiembrie = 0 OR r.decembrie = 0) 
ORDER BY cam.nr_camera;



--decazarea unui student daca are un numar de 3 referate
UPDATE dosare
SET status = 'Decazat'
WHERE nr_referate = 3;

UPDATE studenti
set data_decazare = SYSDATE
where id_student = (select d.id_student from dosare d where d.status = 'Decazat');


--cresterea numarului de referate daca exista un numar de 3 avertisente
UPDATE dosare
SET nr_referate =1+ nr_referate,
    nr_avertismente = 0
WHERE nr_avertismente = 3;

--afisare luni neachitate pentru fiecare student (??????)
SELECT s.nume_student, r.octombrie, r.noiembrie, r.decembrie, r.ianuarie, r.martie, r.aprilie, r.mai, r.iunie,r.iulie 
FROM studenti s
JOIN registre r ON r.id_student = s.id_student
WHERE r.octombrie = 0 OR r.noiembrie = 0 OR r.decembrie =0 OR r.ianuarie = 0 OR r.martie = 0 OR r.aprilie = 0 OR r.mai =0 OR r.iunie = 0 OR r.iulie = 0;

--suma incasata de caminul T1 pentru luna octombrie
SELECT sum(cam.tarif) as suma_incasata
FROM registre r 
JOIN studenti s ON r.id_student = s.id_student
JOIN camere cam ON s.id_camera = cam.id_camera 
JOIN camine c ON c.id_camin = cam.id_camin
WHERE c.nume_camin = 'T1' AND r.octombrie = 1;

--numarul de studenti cazati in camera dubla din caminul T1
SELECT COUNT(d.id_student)
FROM dosare d 
join studenti s on s.id_student = d.id_student
join camere cam on s.id_camera = cam.id_camera
join camine c on cam.id_camin = c.id_camin
where d.status = 'Cazat' and c.nume_camin = 'T1' and cam.tip_camera = 'Dubla';

--afisare tariful unei camere duble din caminul T1
SELECT DISTINCT cam.tarif 
FROM camere cam 
join camine c on cam.id_camin = c.id_camin
where cam.tip_camera = 'Dubla' and c.nume_camin = 'T1';

--aflu numarul de studenti din camere
select id_camera, count(id_student)
from  studenti 
group by id_camera;


select * from registre where id_student = 2;