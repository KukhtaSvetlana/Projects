Create table ���� (
Id����� int IDENTITY(1,1) NOT NULL PRIMARY KEY,
����� varchar (60) NOT NULL,
�������� varchar (60) NOT NULL,
�������������� varchar (60) NOT NULL,
�������������������� date NOT NULL,
������������������������ date NOT NULL,
Id������_Google int NULL,
Id������_Yandex int  NULL,
FOREIGN KEY (Id������_Google) REFERENCES ������������Gogle(Id������_Google),
FOREIGN KEY (Id������_Yandex) REFERENCES ������������Yandex(Id������_Yandex)
); 
---------------------------------------------------
--Create table ������������Gogle (
--Id������_Google int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--�������_�_���������� int NOT NULL,
--�����_���������� datetime NOT NULL,
--�������_�_n���� int NOT NULL,
--�����_n���� datetime NOT NULL,
--);
---------------------------------------------------
--Create table ������������Yandex (
--Id������_Yandex int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--�������_�_���������� int NOT NULL,
--�����_���������� datetime NOT NULL,
--�������_�_n���� int NOT NULL,
--�����_n���� datetime NOT NULL,
--);