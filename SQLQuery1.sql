create database bingo;

use bingo;


create table Cartela(
id int primary key,
nome varchar(45),
cpf varchar(14));


create table numeroBingo(
numero int primary key);


create table CartelaNumeroBingo(
cartelaId int,
numeroBingoId int,
sorteado bit default 0,
FOREIGN KEY (numeroBingoId) REFERENCES numeroBingo(numero),
FOREIGN KEY (cartelaId) REFERENCES Cartela(id),
PRIMARY KEY(numeroBingoId,cartelaId)
);

create table numeroSorteado(
numeroBingoId int primary key,
posicao int not null,
FOREIGN KEY (numeroBingoId) REFERENCES numeroBingo(numero));

select * from numeroBingo
select * from cartela

select * from CartelaNumeroBingo where cartelaId = 3

select 1 where
