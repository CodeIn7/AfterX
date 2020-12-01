CREATE TABLE "user" (
  "id" SERIAL PRIMARY KEY,
  "email" nvarchar,
  "password" nvarchar,
  "firstname" nvarchar,
  "lastname" nvarchar,
  "gender" nvarchar,
  "yearOfBirth" date,
  "telephone" nvarchar
);

CREATE TABLE "bartender" (
  "idUser" SERIAL PRIMARY KEY
);

CREATE TABLE "club" (
  "id" SERIAL PRIMARY KEY,
  "name" nvarchar,
  "address" nvarchar
);

CREATE TABLE "city" (
  "id" SERIAL PRIMARY KEY,
  "countryId" int,
  "name" nvarchar,
  "zip" nvarchar
);

CREATE TABLE "country" (
  "id" SERIAL PRIMARY KEY,
  "name" nvarchar
);

CREATE TABLE "address" (
  "id" SERIAL PRIMARY KEY,
  "cityId" int,
  "street" nvarchar,
  "number" nvarchar
);

CREATE TABLE "role" (
  "id" SERIAL PRIMARY KEY,
  "name" varcharacter
);

CREATE TABLE "drink_club" (
  "drinkId" int,
  "clubId" int,
  "quantity" int,
  "price" numberic
);

CREATE TABLE "drink" (
  "id" SERIAL PRIMARY KEY,
  "quantity" numeric,
  "name" nvarchar,
  "drinkTypeId" int
);

CREATE TABLE "_table" (
  "id" SERIAL PRIMARY KEY,
  "number" int,
  "tableTypeId" int,
  "clubId" int,
  "capacity" int,
  "minNoBottles" int
);

CREATE TABLE "tableType" (
  "id" SERIAL PRIMARY KEY,
  "name" nvarchar
);

CREATE TABLE "drinkType" (
  "id" SERIAL PRIMARY KEY,
  "name" nvarchar
);

CREATE TABLE "reservation" (
  "id" SERIAL PRIMARY KEY,
  "tableId" int,
  "userId" int,
  "reservationDate" date,
  "numberOfPeople" int,
  "orderId" int
);

CREATE TABLE "order" (
  "id" SERIAL PRIMARY KEY,
  "tableId" int,
  "_note" nvarchar,
  "time" time
);

CREATE TABLE "order_drink" (
  "orderId" int,
  "drink_clubId" int
);

CREATE TABLE "package_drink" (
  "packageId" int,
  "drinkId" int,
  "noBottles" int
);

CREATE TABLE "package" (
  "id" SERIAL PRIMARY KEY,
  "name" nvarchar,
  "price" numberic
);

CREATE TABLE "review" (
  "id" SERIAL PRIMARY KEY,
  "clubId" int,
  "userId" int,
  "desciption" nvarchar,
  "grade" int
);

CREATE TABLE "event" (
  "id" SERIAL PRIMARY KEY,
  "clubId" int,
  "_date" date,
  "description" nvarchar,
  "price" numberic
);
