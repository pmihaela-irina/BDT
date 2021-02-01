SELECT * FROM camere WHERE id_camin = (SELECT id_camin FROM camine WHERE nume_camin = 'T1');

SELECT s.id_student, s.nume_student, s.facultate, s.an_studiu, s.nr_telefon, s.adresa_email, s.cont_banca, s.data_cazare, s.data_decazare, s.id_camera
FROM studenti s 
JOIN camere cam ON s.id_camera = cam.id_camera
JOIN camine c ON cam.id_camin = c.id_camin
WHERE c.nume_camin = 'T1'
order by cam.id_camera;

SELECT d.CNP, d.seria_CI, d.nr_CI, d.adresa_domiciliu, d.id_student
FROM date_studenti d
JOIN studenti s ON d.id_student = s.id_student
JOIN camere cam ON s.id_camera = cam.id_camera
JOIN camine c ON cam.id_camin = c.id_camin
WHERE c.nume_camin = 'T1';

SELECT d.id_student, d.nr_avertismente, d.nr_referate, d.status, d.id_student
FROM dosare d
JOIN studenti s ON d.id_student = s.id_student
JOIN camere cam ON s.id_camera = cam.id_camera
JOIN camine c ON cam.id_camin = c.id_camin
WHERE c.nume_camin = 'T1';

SELECT r.id_student, r.octombrie, r.noiembrie, r.noiembrie, r.decembrie, r.ianuarie, r.februarie, r.martie, r.aprilie, r.mai, r.iunie, r.iulie
FROM registre r
JOIN studenti s ON r.id_student = s.id_student
JOIN camere cam ON s.id_camera = cam.id_camera
JOIN camine c ON cam.id_camin = c.id_camin
WHERE c.nume_camin = 'T1';


SELECT cam.id_camera, COUNT(d.id_student) as stud_total
FROM dosare d 
JOIN studenti s on s.id_student = d.id_student 
JOIN camere cam on s.id_camera = cam.id_camera 
JOIN camine c on cam.id_camin = c.id_camin 
WHERE d.status = 'Cazat' AND c.nume_camin = 'T1' 
group by cam.id_camera;


SELECT capacitate_camere 
FROM camine
where nume_camin = 'T1'; 


INSERT INTO conducere (nume_prodecan,nume_administrator,nume_presedinte) 
VALUES('Nastaselu Vasile', 'Florea Mihai', 'Popescu Ghiorghita');

select * from  registre where id_student = 2;
select * from conducere;

SELECT COUNT(a.id_camin)
FROM camine a
JOIN conducere b ON a.id_conducere = b.id_conducere
where b.nume_administrator = 'Isachi Daniela';

select * from conducere;
select * from login;
commit work;


select * from studenti s
join dosare d on s.id_student = d.id_student
join camere cam on s.id_camera = cam.id_camera
join camine c on cam.id_camin = c.id_camin
where d.status = 'Decazat' and c.nume_camin = 'T10';

SELECT s.id_student, s.nume_student, cam.nr_camera 
FROM studenti s 
JOIN camere cam ON s.id_camera = cam.id_camera 
JOIN camine c ON cam.id_camin = c.id_camin
WHERE c.nume_camin = 'T1' AND cam.nr_camera='101';


WITH 
nr_total AS(
    SELECT cam.id_camera, COUNT(d.id_student) as stud_total 
    FROM dosare d 
    JOIN studenti s on s.id_student = d.id_student 
    JOIN camere cam on s.id_camera = cam.id_camera 
    JOIN camine c on cam.id_camin = c.id_camin 
    WHERE d.status = 'Cazat' AND c.nume_camin = 'T1' 
    group by cam.id_camera) 
SELECT a.nr_camera, a.id_camera as CAMERA_LIBERA 
FROM camere a, nr_total b 
WHERE a.id_camera = b.id_camera AND a.nr_studenti > b.stud_total order by b.stud_total;


UPDATE Studenti 
set nume_student = 'Abcd', 
facultate = 'Facultatea de Constructii de Masini si Management Industrial', 
an_studiu = 'III', 
nr_telefon = '0757170260', 
adresa_email = 'abcd@gmail.com',
cont_banca = 'RO14RZBR0000060014141414', 
data_cazare = TO_DATE('10/20/2020', 'MM/DD/YYYY'),
id_camera = 3
WHERE id_student = 34; 

UPDATE Studenti 
set nume_student = '',
facultate = '', 
an_studiu = '', 
nr_telefon = '', 
adresa_email = '', 
cont_banca = '', 
data_cazare = TO_DATE('', 'MM/DD/YYYY'), 
id_camera = 
WHERE id_student = ;

SELECT MAX(s.data_decazare)AS MAXIM
FROM studenti s
JOIN camere cam ON s.id_camera = cam.id_camera
JOIN camine c ON cam. id_camin = c.id_camin
WHERE cam.id_camera = 3 AND c.nume_camin = 'T1';

select data_cazare from studenti
where id_student = 2;


select id_student, status from dosare;

UPDATE STUDENTI set data_decazare = sysdate
WHERE id_student = 2;