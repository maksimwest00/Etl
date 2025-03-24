# ETL

Инструкция с указанием настроек для запуска.
1. Запускаем проект в IDE, например в Visual Studio 2022
2. Собираем решение
3. Открываем терминал от решения
4. Пишем docker-compose up -d
5. Должен подняться контейнер с базой данных postgres в docker, к которому можно подключиться по портам 5434:5432, (connection string лежит в пользовательских секретах в проекте Etl.API)
6. После запуска контейнера с базой данных нужно написать в терминал следующее: dotnet ef database update -p .\Etl.Infrastructure\ -s .\Etl.API\
7. Запустить сам проект Etl.API как http
8. Реализованные ендпоинты
   /University
   Имеет единственный метод HttpPut который загружает данные в базу данных

   /api/Publish
   Имеет единственный метод HttpGet с передаваемыми query параметрами:
   -название университета как name
   -страна университета как country

Скрипт создания таблицы при создании таблицы через entity framework

CREATE TABLE IF NOT EXISTS public.universities
(
    id uuid NOT NULL,
    name character varying(100) COLLATE pg_catalog."default" NOT NULL,
    country character varying(100) COLLATE pg_catalog."default" NOT NULL,
    site text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT pk_universities PRIMARY KEY (id)
)

secrets.json
{
  "ConnectionStrings": {
    "Database": "Server=localhost;Port=5434;Database=etl;User Id=postgres;Password=postgres;"
  },
  "MyVarriables": {
    "CountThreads": "5"
  }
}
