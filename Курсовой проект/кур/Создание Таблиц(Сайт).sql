Create table Сайт (
IdСайта int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Домен varchar (60) NOT NULL,
Название varchar (60) NOT NULL,
Админнистратор varchar (60) NOT NULL,
ДатаРегистрацииСайта date NOT NULL,
ДатаОкончанияРегистрации date NOT NULL,
IdРейтин_Google int NULL,
IdРейтин_Yandex int  NULL,
FOREIGN KEY (IdРейтин_Google) REFERENCES РейтинСайтаВGogle(IdРейтин_Google),
FOREIGN KEY (IdРейтин_Yandex) REFERENCES РейтинСайтаВYandex(IdРейтин_Yandex)
); 
---------------------------------------------------
--Create table РейтинСайтаВGogle (
--IdРейтин_Google int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--Позиция_В_первыйДень int NOT NULL,
--ДатаВ_первыйДень datetime NOT NULL,
--Позиция_В_nДень int NOT NULL,
--ДатаВ_nДень datetime NOT NULL,
--);
---------------------------------------------------
--Create table РейтинСайтаВYandex (
--IdРейтин_Yandex int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--Позиция_В_первыйДень int NOT NULL,
--ДатаВ_первыйДень datetime NOT NULL,
--Позиция_В_nДень int NOT NULL,
--ДатаВ_nДень datetime NOT NULL,
--);